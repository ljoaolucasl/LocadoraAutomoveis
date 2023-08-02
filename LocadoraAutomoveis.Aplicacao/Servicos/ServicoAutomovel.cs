using FluentResults;
using LocadoraAutomoveis.Aplicacao.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloAutomoveis;
using Microsoft.Data.SqlClient;
using Serilog;

namespace LocadoraAutomoveis.Aplicacao.Servicos
{
    public class ServicoAutomovel
    {
        private readonly IRepositorioAutomovel _repositorioAutomovel;
        private readonly IValidadorAutomovel _validadorAutomovel;

        public ServicoCategoriaAutomoveis(IRepositorioAutomovel repositorioAutomovel, IValidadorAutomovel validadorAutomovel)
        {
            _repositorioAutomovel = repositorioAutomovel;
            _validadorAutomovel = validadorAutomovel;
        }

        #region CRUD
        public Result Inserir(CategoriaAutomoveis categoriaParaAdicionar)
        {
            Log.Debug("Tentando adicionar a Categoria '{NOME}'", categoriaParaAdicionar.Nome);

            Result resultado = ValidarRegistro(categoriaParaAdicionar);

            if (resultado.IsFailed)
            {
                Log.Warning("Falha ao tentar adicionar a Categoria '{NOME}'", categoriaParaAdicionar.Nome);
                return resultado;
            }

            try
            {
                _repositorioAutomovel.Inserir(categoriaParaAdicionar);

                Log.Debug("Adicionado a Categoria '{NOME} #{ID}' com sucesso!", categoriaParaAdicionar.Nome, categoriaParaAdicionar.ID);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                CustomError erro = new CustomError("Falha ao tentar inserir categoria ", "Categoria", ex.Message);

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
                return resultado;
            }
            try
            {
                _repositorioAutomovel.Editar(categoriaParaEditar);

                Log.Debug("Editado a Categoria '{NOME} #{ID}' com sucesso!", categoriaParaEditar.Nome, categoriaParaEditar.ID);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                CustomError erro = new CustomError("Falha ao tentar editar categoria ", "Categoria", ex.Message);

                Log.Error(ex, erro.ErrorMessage + "{C}", categoriaParaEditar);

                return Result.Fail(erro);
            }
        }

        public Result Excluir(CategoriaAutomoveis categoriaParaExcluir)
        {
            Log.Debug("Tentando excluir a Categoria '{NOME} #{ID}'", categoriaParaExcluir.Nome, categoriaParaExcluir.ID);

            if (_repositorioAutomovel.Existe(categoriaParaExcluir, true) == false)
            {
                Log.Warning("Categoria {ID} não encontrada para excluir", categoriaParaExcluir.ID);

                return Result.Fail("Categoria não encontrada");
            }

            try
            {
                _repositorioAutomovel.Excluir(categoriaParaExcluir);

                Log.Debug("Excluído a Categoria '{NOME} #{ID}' com sucesso!", categoriaParaExcluir.Nome, categoriaParaExcluir.ID);

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                Log.Warning("Falha ao tentar excluir a Categoria '{NOME} #{ID}'", categoriaParaExcluir.Nome, categoriaParaExcluir.ID, ex);

                List<IError> erros = new();

                if (ex.Message.Contains("FK_TBCategoriaAutomoveis_TBOBJETORELACAO"))
                    erros.Add(new CustomError("Essa Categoria está relacionada à um ObjetoRelacao." +
                        " Primeiro exclua o ObjetoRelacao relacionado", "Categoria"));
                else
                    erros.Add(new CustomError("Falha ao tentar excluir categoria", "Categoria"));

                return Result.Fail(erros);
            }
        }
        #endregion

        public CategoriaAutomoveis SelecionarRegistroPorID(Guid categoriaID)
        {
            return _repositorioAutomovel.SelecionarPorID(categoriaID);
        }

        public IEnumerable<CategoriaAutomoveis> SelecionarTodosOsRegistros()
        {
            return _repositorioAutomovel.SelecionarTodos();
        }

        public Result ValidarRegistro(CategoriaAutomoveis categoriaParaValidar)
        {
            List<IError> erros = new();

            ValidationResult validacao = _validadorAutomovel.Validate(categoriaParaValidar);

            if (validacao != null)
                erros = validacao.ConverterParaListaDeErros();

            if (_repositorioAutomovel.Existe(categoriaParaValidar))
                erros.Add(new CustomError("Essa Categoria já existe", "Nome"));

            return Result.Fail(erros);
        }
    }
}
