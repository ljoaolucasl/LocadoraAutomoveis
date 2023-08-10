using LocadoraAutomoveis.Dominio.ModuloPlanosCobrancas;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraAutomoveis.Aplicacao.Servicos
{
    public class ServicoPlanosCobrancas : IServicoPlanoCobranca
    {
        private readonly IRepositorioPlanoCobranca _repositorioPlanoCobranca;
        private readonly IValidadorPlanoCobranca _validadorPlanoCobranca;
        private readonly IContextoPersistencia _contextoPersistencia;

        public ServicoPlanosCobrancas(IRepositorioPlanoCobranca repositorioPlanoCobranca, IValidadorPlanoCobranca validadorPlanoCobranca,
            IContextoPersistencia contextoPersistencia)
        {
            _repositorioPlanoCobranca = repositorioPlanoCobranca;
            _validadorPlanoCobranca = validadorPlanoCobranca;
            _contextoPersistencia = contextoPersistencia;
        }

        #region CRUD
        public Result Inserir(PlanoCobranca planoCobrancaParaAdicionar)
        {
            Log.Debug("Tentando adicionar o Plano de Cobrança'{ID}'", planoCobrancaParaAdicionar.ID);

            Result resultado = ValidarRegistro(planoCobrancaParaAdicionar);

            if (resultado.IsFailed)
            {
                Log.Warning("Falha ao tentar adicionar o Plano de Cobrança'{ID}'", planoCobrancaParaAdicionar.ID);

                _contextoPersistencia.DesfazerAlteracoes();

                return resultado;
            }

            try
            {
                _repositorioPlanoCobranca.Inserir(planoCobrancaParaAdicionar);

                _contextoPersistencia.GravarDados();

                Log.Debug("Adicionado o Plano de Cobrança'{NOME} #{ID}' com sucesso!", planoCobrancaParaAdicionar, planoCobrancaParaAdicionar.ID);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                _contextoPersistencia.DesfazerAlteracoes();

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

                _contextoPersistencia.DesfazerAlteracoes();

                return resultado;
            }
            try
            {
                _repositorioPlanoCobranca.Editar(planoCobrancaParaEditar);

                _contextoPersistencia.GravarDados();

                Log.Debug("Editado o Plano de Cobrança'{NOME} #{ID}' com sucesso!", planoCobrancaParaEditar, planoCobrancaParaEditar.ID);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                _contextoPersistencia.DesfazerAlteracoes();

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

                _contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail("Plano de Cobrança não encontrado");
            }
            try
            {
                _repositorioPlanoCobranca.Excluir(planoCobrancaParaExcluir);

                _contextoPersistencia.GravarDados();

                Log.Debug("Excluído o Plano de Cobrança'{NOME} #{ID}' com sucesso!", planoCobrancaParaExcluir, planoCobrancaParaExcluir.ID);

                return Result.Ok();
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlException)
            {
                List<IError> erros = AnalisarErros(planoCobrancaParaExcluir, sqlException);

                return Result.Fail(erros);
            }
            catch (InvalidOperationException ex)
            {
                List<IError> erros = AnalisarErros(planoCobrancaParaExcluir, ex);

                return Result.Fail(erros);
            }
        }

        private List<IError> AnalisarErros(PlanoCobranca planoCobrancaParaExcluir, Exception exception)
        {
            List<IError> erros = new();

            _contextoPersistencia.DesfazerAlteracoes();

            Log.Warning("Falha ao tentar excluir o Plano de Cobrança'{NOME} #{ID}'", planoCobrancaParaExcluir, planoCobrancaParaExcluir.ID, exception);

            if (exception.Message.Contains("FK_TBAluguel_TBPlanoCobranca") || exception.Message.Contains("'PlanoCobranca' and 'Aluguel'"))
                erros.Add(new CustomError("Esse Plano de Cobrança está relacionado a um Aluguel." +
            " Primeiro exclua o Aluguel relacionado", "Plano de Cobrança"));
            else
                erros.Add(new CustomError("Falha ao tentar excluir o plano de cobrança", "Plano de Cobrança"));

            return erros;
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
