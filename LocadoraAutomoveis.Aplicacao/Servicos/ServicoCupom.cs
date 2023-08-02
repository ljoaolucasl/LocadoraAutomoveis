using FluentResults;
using FluentValidation.Results;
using LocadoraAutomoveis.Aplicacao.Compartilhado;
using LocadoraAutomoveis.Aplicacao.Extensions;
using LocadoraAutomoveis.Dominio.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloCupom;
using Microsoft.Data.SqlClient;
using Serilog;

namespace LocadoraAutomoveis.Aplicacao.Servicos
{
    public class ServicoCupom : IServicoBase<Cupom>
    {
        private readonly IRepositorioCupom _repositorioCupom;
        private readonly IValidadorCupom _validadorCupom;

        public ServicoCupom(IRepositorioCupom repositorioCupom, IValidadorCupom validadorCupom)
        {
            _repositorioCupom = repositorioCupom;
            _validadorCupom = validadorCupom;
        }
        #region CRUD
        public Result Inserir(Cupom cupomParaAdicionar)
        {
            Log.Debug("Tentando adicionar o Cupom '{NOME}'", cupomParaAdicionar.Nome);

            Result resultado = ValidarRegistro(cupomParaAdicionar);

            if (resultado.IsFailed)
            {
                Log.Warning("Falha ao tentar adicionar o Cupom '{NOME}'", cupomParaAdicionar.Nome);
                return resultado;
            }

            try
            {
                _repositorioCupom.Inserir(cupomParaAdicionar);

                Log.Debug("Adicionado o Cupom '{NOME} #{ID}' com sucesso!", cupomParaAdicionar.Nome, cupomParaAdicionar.ID);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                CustomError erro = new("Falha ao tentar inserir cupom", "Cupom", ex.Message);

                Log.Error(ex, erro.ErrorMessage + "{C}", cupomParaAdicionar);

                return Result.Fail(erro);
            }
        }

        public Result Editar(Cupom cupomParaEditar)
        {
            Log.Debug("Tentando editar o Cupom '{NOME} #{ID}'", cupomParaEditar.Nome, cupomParaEditar.ID);

            Result resultado = ValidarRegistro(cupomParaEditar);

            if (resultado.IsFailed)
            {
                Log.Warning("Falha ao tentar editar o Cupom '{NOME} #{ID}'", cupomParaEditar.Nome, cupomParaEditar.ID);
                return resultado;
            }
            try
            {
                _repositorioCupom.Editar(cupomParaEditar);

                Log.Debug("Editado o Cupom '{NOME} #{ID}' com sucesso!", cupomParaEditar.Nome, cupomParaEditar.ID);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                CustomError erro = new("Falha ao tentar editar cupom", "Cupom", ex.Message);

                Log.Error(ex, erro.ErrorMessage + "{C}", cupomParaEditar);

                return Result.Fail(erro);
            }
        }

        public Result Excluir(Cupom cupomParaExcluir)
        {
            Log.Debug("Tentando excluir o Cupom '{NOME} #{ID}'", cupomParaExcluir.Nome, cupomParaExcluir.ID);

            if (!_repositorioCupom.Existe(cupomParaExcluir, true))
            {
                Log.Warning("Cupom {ID} não encontrado para excluir", cupomParaExcluir.ID);

                return Result.Fail("Cupom não encontrado");
            }

            try
            {
                _repositorioCupom.Excluir(cupomParaExcluir);

                Log.Debug("Excluído o Cupom '{NOME} #{ID}' com sucesso!", cupomParaExcluir.Nome, cupomParaExcluir.ID);

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                Log.Warning("Falha ao tentar excluir o Cupom '{NOME} #{ID}'", cupomParaExcluir.Nome, cupomParaExcluir.ID, ex);

                List<IError> erros = new();

                if (ex.Message.Contains("FK_TBCupom_TBOBJETORELACAO"))
                    erros.Add(new CustomError("Esse Cupom está relacionado a um ObjetoRelacao." +
                        " Primeiro exclua o ObjetoRelacao relacionado", "Cupom"));
                else
                    erros.Add(new CustomError("Falha ao tentar excluir cupom", "Cupom"));

                return Result.Fail(erros);
            }
        }
        #endregion

        public Cupom SelecionarRegistroPorID(Guid cupomID)
        {
            return _repositorioCupom.SelecionarPorID(cupomID);
        }

        public IEnumerable<Cupom> SelecionarTodosOsRegistros()
        {
            return _repositorioCupom.SelecionarTodos();
        }

        public Result ValidarRegistro(Cupom cupomParaValidar)
        {
            List<IError> erros = new();

            ValidationResult validacao = _validadorCupom.Validate(cupomParaValidar);

            if (validacao != null)
                erros = validacao.ConverterParaListaDeErros();

            if (_repositorioCupom.Existe(cupomParaValidar))
                erros.Add(new CustomError("Esse cupom já existe", "Nome"));

            return Result.Fail(erros);
        }
    }
}
