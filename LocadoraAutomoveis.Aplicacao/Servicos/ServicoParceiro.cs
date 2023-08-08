using LocadoraAutomoveis.Dominio.ModuloParceiro;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraAutomoveis.Aplicacao.Servicos
{
    public class ServicoParceiro : IServicoParceiro
    {
        private readonly IRepositorioParceiro _repositorioParceiro;
        private readonly IValidadorParceiro _validadorParceiro;
        private readonly IContextoPersistencia _contextoPersistencia;

        public ServicoParceiro(IRepositorioParceiro repositorioParceiro, IValidadorParceiro validadorParceiro,
            IContextoPersistencia contextoPersistencia)
        {
            _repositorioParceiro = repositorioParceiro;
            _validadorParceiro = validadorParceiro;
            _contextoPersistencia = contextoPersistencia;
        }

        #region CRUD
        public Result Inserir(Parceiro parceiroParaAdicionar)
        {
            Log.Debug("Tentando adicionar o Parceiro '{NOME}'", parceiroParaAdicionar.Nome);

            Result resultado = ValidarRegistro(parceiroParaAdicionar);

            if (resultado.IsFailed)
            {
                Log.Warning("Falha ao tentar adicionar o Parceiro '{NOME}'", parceiroParaAdicionar.Nome);

                _contextoPersistencia.DesfazerAlteracoes();

                return resultado;
            }

            try
            {
                _repositorioParceiro.Inserir(parceiroParaAdicionar);

                _contextoPersistencia.GravarDados();

                Log.Debug("Adicionado o Parceiro '{NOME} #{ID}' com sucesso!", parceiroParaAdicionar.Nome, parceiroParaAdicionar.ID);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                _contextoPersistencia.DesfazerAlteracoes();

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

                _contextoPersistencia.DesfazerAlteracoes();

                return resultado;
            }
            try
            {
                _repositorioParceiro.Editar(parceiroParaEditar);

                _contextoPersistencia.GravarDados();

                Log.Debug("Editado o Parceiro '{NOME} #{ID}' com sucesso!", parceiroParaEditar.Nome, parceiroParaEditar.ID);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                _contextoPersistencia.DesfazerAlteracoes();

                CustomError erro = new("Falha ao tentar editar parceiro", "Parceiro", ex.Message);

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

                _contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail("Parceiro não encontrado");
            }

            try
            {
                _repositorioParceiro.Excluir(parceiroParaExcluir);

                _contextoPersistencia.GravarDados();

                Log.Debug("Excluído o Parceiro '{NOME} #{ID}' com sucesso!", parceiroParaExcluir.Nome, parceiroParaExcluir.ID);

                return Result.Ok();
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlException)
            {
                _contextoPersistencia.DesfazerAlteracoes();

                Log.Warning("Falha ao tentar excluir o Parceiro '{NOME} #{ID}'", parceiroParaExcluir.Nome, parceiroParaExcluir.ID, ex);

                List<IError> erros = new();

                if (sqlException.Message.Contains("FK_TBCupom_TBParceiro"))
                    erros.Add(new CustomError("Esse Parceiro está relacionado a um Cupom." +
                        " Primeiro exclua o Cupom relacionado", "Parceiro"));
                else
                    erros.Add(new CustomError("Falha ao tentar excluir o Parceiro", "Parceiro"));

                return Result.Fail(erros);
            }
        }
        #endregion

        public Parceiro SelecionarRegistroPorID(Guid parceiroID)
        {
            return _repositorioParceiro.SelecionarPorID(parceiroID);
        }

        public List<Parceiro> SelecionarTodosOsRegistros()
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
