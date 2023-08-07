using FluentResults;
using FluentValidation.Results;
using LocadoraAutomoveis.Aplicacao.Compartilhado;
using LocadoraAutomoveis.Aplicacao.Extensions;
using LocadoraAutomoveis.Dominio.Compartilhado;
using LocadoraAutomoveis.Dominio.Extensions;
using LocadoraAutomoveis.Dominio.ModuloPlanosCobrancas;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace LocadoraAutomoveis.Aplicacao.Servicos
{
    public class ServicoPlanosCobrancas : IServicoPlanoCobranca
    {
        private readonly IRepositorioPlanoCobranca _repositorioPlanoCobranca;
        private readonly IValidadorPlanoCobranca _validadorPlanoCobranca;

        public ServicoPlanosCobrancas(IRepositorioPlanoCobranca repositorioPlanoCobranca, IValidadorPlanoCobranca validadorPlanoCobranca)
        {
            _repositorioPlanoCobranca = repositorioPlanoCobranca;
            _validadorPlanoCobranca = validadorPlanoCobranca;
        }

        #region CRUD
        public Result Inserir(PlanoCobranca planoCobrancaParaAdicionar)
        {
            Log.Debug("Tentando adicionar o Plano de Cobrança'{ID}'", planoCobrancaParaAdicionar.ID);

            Result resultado = ValidarRegistro(planoCobrancaParaAdicionar);

            if (resultado.IsFailed)
            {
                Log.Warning("Falha ao tentar adicionar o Plano de Cobrança'{ID}'", planoCobrancaParaAdicionar.ID);
                return resultado;
            }

            try
            {
                _repositorioPlanoCobranca.Inserir(planoCobrancaParaAdicionar);

                Log.Debug("Adicionado o Plano de Cobrança'{NOME} #{ID}' com sucesso!", planoCobrancaParaAdicionar, planoCobrancaParaAdicionar.ID);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                CustomError erro = new("Falha ao tentar inserir Plano de Cobrança", "Plano de Cobrança", ex.Message);

                Log.Error(ex, erro.ErrorMessage + "{P}", planoCobrancaParaAdicionar);

                return Result.Fail(erro);
            }
        }

        public Result Editar(PlanoCobranca planoCobrancaParaEditar)
        {
            Log.Debug("Tentando editar o Plano de Cobrança'{NOME} #{ID}'", planoCobrancaParaEditar, planoCobrancaParaEditar.ID);

            Result resultado = ValidarRegistro(planoCobrancaParaEditar);

            if (resultado.IsFailed)
            {
                Log.Warning("Falha ao tentar editar o Plano de Cobrança'{NOME} #{ID}'", planoCobrancaParaEditar, planoCobrancaParaEditar.ID);
                return resultado;
            }
            try
            {
                _repositorioPlanoCobranca.Editar(planoCobrancaParaEditar);

                Log.Debug("Editado o Plano de Cobrança'{NOME} #{ID}' com sucesso!", planoCobrancaParaEditar, planoCobrancaParaEditar.ID);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                CustomError erro = new("Falha ao tentar editar plano de cobrança", "Plano de Cobrança", ex.Message);

                Log.Error(ex, erro.ErrorMessage + "{P}", planoCobrancaParaEditar);

                return Result.Fail(erro);
            }
        }

        public Result Excluir(PlanoCobranca planoCobrancaParaExcluir)
        {
            Log.Debug("Tentando excluir o Plano de Cobrança'{NOME} #{ID}'", planoCobrancaParaExcluir, planoCobrancaParaExcluir.ID);

            if (!_repositorioPlanoCobranca.Existe(planoCobrancaParaExcluir, true))
            {
                Log.Warning("Plano de Cobrança {ID} não encontrado para excluir", planoCobrancaParaExcluir.ID);

                return Result.Fail("Plano de Cobrança não encontrado");
            }

            try
            {
                _repositorioPlanoCobranca.Excluir(planoCobrancaParaExcluir);

                Log.Debug("Excluído o Plano de Cobrança'{NOME} #{ID}' com sucesso!", planoCobrancaParaExcluir, planoCobrancaParaExcluir.ID);

                return Result.Ok();
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqlException)
            {
                Log.Warning("Falha ao tentar excluir o Plano de Cobrança'{NOME} #{ID}'", planoCobrancaParaExcluir, planoCobrancaParaExcluir.ID, ex);

                List<IError> erros = new();

                if (ex.Message.Contains("FK_TBPlanosCobrancas_TBAluguel"))
                    erros.Add(new CustomError("Esse plano de cobrança está relacionado a um aluguel." +
                        " Primeiro exclua o aluguel relacionado", "Plano de Cobrança"));
                else
                    erros.Add(new CustomError("Falha ao tentar excluir o plano de cobrança", "Plano de Cobrança"));

                return Result.Fail(erros);
            }
        }
        #endregion

        public PlanoCobranca SelecionarRegistroPorID(Guid planoCobrancaID)
        {
            return _repositorioPlanoCobranca.SelecionarPorID(planoCobrancaID);
        }

        public List<PlanoCobranca> SelecionarTodosOsRegistros()
        {
            return _repositorioPlanoCobranca.SelecionarTodos();
        }

        public Result ValidarRegistro(PlanoCobranca planoCobrancaParaValidar)
        {
            List<IError> erros = new();

            ValidationResult validacao = _validadorPlanoCobranca.Validate(planoCobrancaParaValidar);

            if (validacao != null)
                erros = validacao.ConverterParaListaDeErros();

            if (_repositorioPlanoCobranca.Existe(planoCobrancaParaValidar))
                erros.Add(new CustomError("Esse plano de cobrança já existe", "Plano"));

            return Result.Fail(erros);
        }
    }
}
