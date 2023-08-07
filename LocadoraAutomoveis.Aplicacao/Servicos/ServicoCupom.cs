using LocadoraAutomoveis.Dominio.ModuloCupom;
using Microsoft.EntityFrameworkCore;

namespace LocadoraAutomoveis.Aplicacao.Servicos
{
    public class ServicoCupom : IServicoCupom
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
            catch (DbUpdateException ex) when (ex.InnerException is SqlException)
            {
                Log.Warning("Falha ao tentar excluir o Cupom '{NOME} #{ID}'", cupomParaExcluir.Nome, cupomParaExcluir.ID, ex);

                List<IError> erros = new();

                if (ex.Message.Contains("FK_TBCupom_TBAluguel"))
                    erros.Add(new CustomError("Esse Cupom está relacionado a um aluguel." +
                        " Primeiro exclua o aluguel relacionado", "Cupom"));
                else
                    erros.Add(new CustomError("Falha ao tentar excluir o cupom", "Cupom"));

                return Result.Fail(erros);
            }
        }
        #endregion

        public Cupom SelecionarRegistroPorID(Guid cupomID)
        {
            return _repositorioCupom.SelecionarPorID(cupomID);
        }

        public List<Cupom> SelecionarTodosOsRegistros()
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
