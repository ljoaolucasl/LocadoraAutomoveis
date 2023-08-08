using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraAutomoveis.Aplicacao.Servicos
{
    public class ServicoCategoriaAutomoveis : IServicoCategoriaAutomoveis
    {
        private readonly IRepositorioCategoria _repositorioCategoriaAutomoveis;
        private readonly IValidadorCategoria _validadorCategoria;
        private readonly IContextoPersistencia _contextoPersistencia;

        public ServicoCategoriaAutomoveis(IRepositorioCategoria repositorioCategoriaAutomoveis, IValidadorCategoria validadorCategoria,
            IContextoPersistencia contextoPersistencia)
        {
            _repositorioCategoriaAutomoveis = repositorioCategoriaAutomoveis;
            _validadorCategoria = validadorCategoria;
            _contextoPersistencia = contextoPersistencia;
        }

        #region CRUD
        public Result Inserir(CategoriaAutomoveis categoriaParaAdicionar)
        {
            Log.Debug("Tentando inserir a Categoria '{NOME}'", categoriaParaAdicionar.Nome);

            Result resultado = ValidarRegistro(categoriaParaAdicionar);

            if (resultado.IsFailed)
            {
                Log.Warning("Falha ao tentar inserir a Categoria '{NOME}'", categoriaParaAdicionar.Nome);

                _contextoPersistencia.DesfazerAlteracoes();

                return resultado;
            }
            try
            {
                _repositorioCategoriaAutomoveis.Inserir(categoriaParaAdicionar);

                _contextoPersistencia.GravarDados();

                Log.Debug("Inserido a Categoria '{NOME} #{ID}' com sucesso!", categoriaParaAdicionar.Nome, categoriaParaAdicionar.ID);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                _contextoPersistencia.DesfazerAlteracoes();

                CustomError erro = new("Falha ao tentar inserir a Categoria ", "Categoria", ex.Message);

                Log.Error(ex, erro.ErrorMessage + "{C}", categoriaParaAdicionar);

                return Result.Fail(erro);
            }
        }

        public Result Editar(CategoriaAutomoveis categoriaParaEditar)
        {
            Log.Debug("Tentando editar a Categoria '{NOME} #{ID}'", categoriaParaEditar.Nome, categoriaParaEditar.ID);

            Result resultado = ValidarRegistro(categoriaParaEditar);

            if (resultado.IsFailed)
            {
                Log.Warning("Falha ao tentar editar a Categoria '{NOME} #{ID}'", categoriaParaEditar.Nome, categoriaParaEditar.ID);

                _contextoPersistencia.DesfazerAlteracoes();

                return resultado;
            }
            try
            {
                _repositorioCategoriaAutomoveis.Editar(categoriaParaEditar);

                _contextoPersistencia.GravarDados();

                Log.Debug("Editado a Categoria '{NOME} #{ID}' com sucesso!", categoriaParaEditar.Nome, categoriaParaEditar.ID);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                _contextoPersistencia.DesfazerAlteracoes();

                CustomError erro = new("Falha ao tentar editar a Categoria ", "Categoria", ex.Message);

                Log.Error(ex, erro.ErrorMessage + "{C}", categoriaParaEditar);

                return Result.Fail(erro);
            }
        }

        public Result Excluir(CategoriaAutomoveis categoriaParaExcluir)
        {
            Log.Debug("Tentando excluir a Categoria '{NOME} #{ID}'", categoriaParaExcluir.Nome, categoriaParaExcluir.ID);

            if (_repositorioCategoriaAutomoveis.Existe(categoriaParaExcluir, true) == false)
            {
                Log.Warning("Categoria {ID} não encontrada para excluir", categoriaParaExcluir.ID);

                _contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail("Categoria não encontrada");
            }

            try
            {
                _repositorioCategoriaAutomoveis.Excluir(categoriaParaExcluir);

                _contextoPersistencia.GravarDados();

                Log.Debug("Excluído a Categoria '{NOME} #{ID}' com sucesso!", categoriaParaExcluir.Nome, categoriaParaExcluir.ID);

                return Result.Ok();
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlException)
            {
                _contextoPersistencia.DesfazerAlteracoes();

                Log.Warning("Falha ao tentar excluir a Categoria '{NOME} #{ID}'", categoriaParaExcluir.Nome, categoriaParaExcluir.ID, ex);

                List<IError> erros = new();

                if (sqlException.Message.Contains("FK_TBAluguel_TBCategoriaAutomoveis"))
                    erros.Add(new CustomError("Essa Categoria de Automóveis está relacionada a um Aluguel." +
                        " Primeiro exclua o Aluguel relacionado", "CategoriaAutomoveis"));

                else if (sqlException.Message.Contains("FK_TBAutomovel_TBCategoriaAutomoveis"))
                    erros.Add(new CustomError("Essa Categoria de Automóveis está relacionada a um Automóvel." +
                        " Primeiro exclua o Automóvel relacionado", "CategoriaAutomoveis"));

                else if (sqlException.Message.Contains("FK_TBPlanoCobranca_TBCategoriaAutomoveis"))
                    erros.Add(new CustomError("Essa Categoria de Automóveis está relacionada a um Plano de Cobrança." +
                        " Primeiro exclua o Plano de Cobrança relacionado", "CategoriaAutomoveis"));
                else
                    erros.Add(new CustomError("Falha ao tentar excluir a Categoria de Automóveis", "CategoriaAutomoveis"));

                return Result.Fail(erros);
            }
            catch (InvalidOperationException ex)
            {
                _contextoPersistencia.DesfazerAlteracoes();

                Log.Warning("Falha ao tentar excluir a Categoria '{NOME} #{ID}'", categoriaParaExcluir.Nome, categoriaParaExcluir.ID, ex);

                List<IError> erros = new();

                if (ex.Message.Contains("'CategoriaAutomoveis' and 'Automovel' "))
                    erros.Add(new CustomError("Essa Categoria de Automóveis está relacionada a um Automóvel." +
                        " Primeiro exclua o Automóvel relacionado", "CategoriaAutomoveis"));
                else
                    erros.Add(new CustomError("Falha ao tentar excluir a Categoria de Automóveis", "CategoriaAutomoveis"));

                return Result.Fail(erros);
            }
        }
        #endregion

        public CategoriaAutomoveis? SelecionarRegistroPorID(Guid categoriaID)
        {
            return _repositorioCategoriaAutomoveis.SelecionarPorID(categoriaID);
        }

        public List<CategoriaAutomoveis> SelecionarTodosOsRegistros()
        {
            return _repositorioCategoriaAutomoveis.SelecionarTodos();
        }

        public Result ValidarRegistro(CategoriaAutomoveis categoriaParaValidar)
        {
            List<IError> erros = new();

            ValidationResult validacao = _validadorCategoria.Validate(categoriaParaValidar);

            if (validacao != null)
                erros = validacao.ConverterParaListaDeErros();

            if (_repositorioCategoriaAutomoveis.Existe(categoriaParaValidar))
                erros.Add(new CustomError("Essa Categoria já existe", "Nome"));

            return Result.Fail(erros);
        }
    }
}
