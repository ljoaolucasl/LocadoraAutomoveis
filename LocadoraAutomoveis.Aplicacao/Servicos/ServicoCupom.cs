using LocadoraAutomoveis.Dominio.ModuloCupom;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraAutomoveis.Aplicacao.Servicos
{
    public class ServicoCupom : IServicoCupom
    {
        private readonly IRepositorioCupom _repositorioCupom;
        private readonly IValidadorCupom _validadorCupom;
        private readonly IContextoPersistencia _contextoPersistencia;

        public ServicoCupom(IRepositorioCupom repositorioCupom, IValidadorCupom validadorCupom, IContextoPersistencia contextoPersistencia)
        {
            _repositorioCupom = repositorioCupom;
            _validadorCupom = validadorCupom;
            _contextoPersistencia = contextoPersistencia;
        }

        #region CRUD
        public Result Inserir(Cupom cupomParaAdicionar)
        {
            Log.Debug("Tentando adicionar o Cupom '{NOME}'", cupomParaAdicionar.Nome);

            Result resultado = ValidarRegistro(cupomParaAdicionar);

            if (resultado.IsFailed)
            {
                Log.Warning("Falha ao tentar adicionar o Cupom '{NOME}'", cupomParaAdicionar.Nome);

                _contextoPersistencia.DesfazerAlteracoes();

                return resultado;
            }

            try
            {
                _repositorioCupom.Inserir(cupomParaAdicionar);

                _contextoPersistencia.GravarDados();

                Log.Debug("Adicionado o Cupom '{NOME} #{ID}' com sucesso!", cupomParaAdicionar.Nome, cupomParaAdicionar.ID);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                _contextoPersistencia.DesfazerAlteracoes();

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

                _contextoPersistencia.DesfazerAlteracoes();

                return resultado;
            }
            try
            {
                _repositorioCupom.Editar(cupomParaEditar);

                _contextoPersistencia.GravarDados();

                Log.Debug("Editado o Cupom '{NOME} #{ID}' com sucesso!", cupomParaEditar.Nome, cupomParaEditar.ID);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                _contextoPersistencia.DesfazerAlteracoes();

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

                _contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail("Cupom não encontrado");
            }

            try
            {
                _repositorioCupom.Excluir(cupomParaExcluir);

                _contextoPersistencia.GravarDados();

                Log.Debug("Excluído o Cupom '{NOME} #{ID}' com sucesso!", cupomParaExcluir.Nome, cupomParaExcluir.ID);

                return Result.Ok();
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlException)
            {
                _contextoPersistencia.DesfazerAlteracoes();

                Log.Warning("Falha ao tentar excluir o Cupom '{NOME} #{ID}'", cupomParaExcluir.Nome, cupomParaExcluir.ID, ex);

                List<IError> erros = new();

                if (sqlException.Message.Contains("FK_TBAluguel_TBCupom"))
                    erros.Add(new CustomError("Esse Cupom está relacionado a um Aluguel." +
                " Primeiro exclua o Aluguel relacionado", "Cupom"));
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
