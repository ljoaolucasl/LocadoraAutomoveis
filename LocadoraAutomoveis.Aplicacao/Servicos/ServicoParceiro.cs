using FluentResults;
using FluentValidation.Results;
using LocadoraAutomoveis.Aplicacao.Compartilhado;
using LocadoraAutomoveis.Aplicacao.Extensions;
using LocadoraAutomoveis.Dominio.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloParceiro;
using LocadoraAutomoveis.Infraestrutura.Repositorios;
using Microsoft.Data.SqlClient;
using Serilog;

namespace LocadoraAutomoveis.Aplicacao.Servicos
{
    public class ServicoParceiro : IServicoBase<Parceiro>
    {
        private readonly IRepositorioParceiro _repositorioParceiro;
        private readonly IValidadorParceiro _validadorParceiro;

        public ServicoParceiro(IRepositorioParceiro repositorioParceiro, IValidadorParceiro validadorParceiro)
        {
            _repositorioParceiro = repositorioParceiro;
            _validadorParceiro = validadorParceiro;
        }

        #region CRUD
        public Result Inserir(Parceiro parceiroParaAdicionar)
        {
            Log.Debug("Tentando adicionar o Parceiro '{NOME}'", parceiroParaAdicionar.Nome);

            Result resultado = ValidarRegistro(parceiroParaAdicionar);

            if (resultado.IsFailed)
            {
                Log.Warning("Falha ao tentar adicionar o Parceiro '{NOME}'", parceiroParaAdicionar.Nome);
                return resultado;
            }

            try
            {
                _repositorioParceiro.Inserir(parceiroParaAdicionar);

                Log.Debug("Adicionado o Parceiro '{NOME} #{ID}' com sucesso!", parceiroParaAdicionar.Nome, parceiroParaAdicionar.ID);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                CustomError erro = new("Falha ao tentar inserir parceiro", "Parceiro", ex.Message);

                Log.Error(ex, erro.ErrorMessage + "{P}", parceiroParaAdicionar);

                return Result.Fail(erro);
            }
        }

        public Result Editar(Parceiro parceiroParaEditar)
        {
            Log.Debug("Tentando editar o Parceiro '{NOME} #{ID}'", parceiroParaEditar.Nome, parceiroParaEditar.ID);

            Result resultado = ValidarRegistro(parceiroParaEditar);

            if (resultado.IsFailed)
            {
                Log.Warning("Falha ao tentar editar o Parceiro '{NOME} #{ID}'", parceiroParaEditar.Nome, parceiroParaEditar.ID);
                return resultado;
            }
            try
            {
                _repositorioParceiro.Editar(parceiroParaEditar);

                Log.Debug("Editado o Parceiro '{NOME} #{ID}' com sucesso!", parceiroParaEditar.Nome, parceiroParaEditar.ID);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                CustomError erro = new("Falha ao tentar editar parceiro ", "Parceiro", ex.Message);

                Log.Error(ex, erro.ErrorMessage + "{P}", parceiroParaEditar);

                return Result.Fail(erro);
            }
        }

        public Result Excluir(Parceiro parceiroParaExcluir)
        {
            Log.Debug("Tentando excluir o Parceiro '{NOME} #{ID}'", parceiroParaExcluir.Nome, parceiroParaExcluir.ID);

            if (!_repositorioParceiro.Existe(parceiroParaExcluir, true))
            {
                Log.Warning("Parceiro {ID} não encontrado para excluir", parceiroParaExcluir.ID);

                return Result.Fail("Parceiro não encontrado");
            }

            try
            {
                _repositorioParceiro.Excluir(parceiroParaExcluir);

                Log.Debug("Excluído o Parceiro '{NOME} #{ID}' com sucesso!", parceiroParaExcluir.Nome, parceiroParaExcluir.ID);

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                Log.Warning("Falha ao tentar excluir o Parceiro '{NOME} #{ID}'", parceiroParaExcluir.Nome, parceiroParaExcluir.ID, ex);

                List<IError> erros = new();

                if (ex.Message.Contains("FK_TBParceiro_TBOBJETORELACAO"))
                    erros.Add(new CustomError("Esse Parceiro está relacionado a um ObjetoRelacao." +
                        " Primeiro exclua o ObjetoRelacao relacionado", "Categoria"));
                else
                    erros.Add(new CustomError("Falha ao tentar excluir parceiro", "Parceiro"));

                return Result.Fail(erros);
            }
        }
        #endregion

        public Parceiro SelecionarRegistroPorID(Guid parceiroID)
        {
            return _repositorioParceiro.SelecionarPorID(parceiroID);
        }

        public IEnumerable<Parceiro> SelecionarTodosOsRegistros()
        {
            return _repositorioParceiro.SelecionarTodos();
        }

        public Result ValidarRegistro(Parceiro parceiroParaValidar)
        {
            List<IError> erros = new();

            ValidationResult validacao = _validadorParceiro.Validate(parceiroParaValidar);

            if (validacao != null)
                erros = validacao.ConverterParaListaDeErros();

            if (_repositorioParceiro.Existe(parceiroParaValidar))
                erros.Add(new CustomError("Esse parceiro já existe", "Nome"));

            return Result.Fail(erros);
        }
    }
}
