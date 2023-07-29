using FluentResults;
using FluentValidation.Results;
using LocadoraAutomoveis.Aplicacao.Extensions;
using LocadoraAutomoveis.Dominio.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.Infraestrutura.Repositorios;
using Microsoft.Data.SqlClient;
using Serilog;

namespace LocadoraAutomoveis.Aplicacao.Servicos
{
    public class ServicoCategoriaAutomoveis : IServicoBase<CategoriaAutomoveis>
    {
        private readonly RepositorioCategoriaAutomoveis _repositorioCategoriaAutomoveis;

        public ServicoCategoriaAutomoveis(RepositorioCategoriaAutomoveis repositorioCategoriaAutomoveis)
        {
            _repositorioCategoriaAutomoveis = repositorioCategoriaAutomoveis;
        }

        #region CRUD
        public Result Adicionar(CategoriaAutomoveis categoriaParaAdicionar)
        {
            Log.Debug("Tentando adicionar a Categoria '{NOME}'", categoriaParaAdicionar.Nome);

            Result resultado = ValidarRegistro(categoriaParaAdicionar);

            if (resultado.IsFailed)
            {
                Log.Warning("Falha ao tentar adicionar a Categoria '{NOME}'", categoriaParaAdicionar.Nome);
                return resultado;
            }

            _repositorioCategoriaAutomoveis.Adicionar(categoriaParaAdicionar);

            Log.Debug("Adicionado a Categoria '{NOME} #{ID}' com sucesso!", categoriaParaAdicionar.Nome, categoriaParaAdicionar.ID);

            return Result.Ok();
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

            _repositorioCategoriaAutomoveis.Adicionar(categoriaParaEditar);

            Log.Debug("Editado a Categoria '{NOME} #{ID}' com sucesso!", categoriaParaEditar.Nome, categoriaParaEditar.ID);

            return Result.Ok();
        }

        public Result Excluir(CategoriaAutomoveis categoriaParaExcluir)
        {
            Log.Debug("Tentando excluir a Categoria '{NOME} #{ID}'", categoriaParaExcluir.Nome, categoriaParaExcluir.ID);

            try
            {
                _repositorioCategoriaAutomoveis.Excluir(categoriaParaExcluir);
            }
            catch (SqlException ex)
            {
                Log.Warning("Falha ao tentar excluir a Categoria '{NOME} #{ID}'", categoriaParaExcluir.Nome, categoriaParaExcluir.ID, ex);

                //if (ex.Message.Contains("FK_TBPADRAO_TBOBJETORELACAO"))
                //    return Result.Fail(new Error("Esse Padrão está relacionado à um ObjetoRelacao." +
                //        " Primeiro exclua o ObjetoRelacao relacionado"));
            }

            Log.Debug("Excluído a Categoria '{NOME} #{ID}' com sucesso!", categoriaParaExcluir.Nome, categoriaParaExcluir.ID);

            return Result.Ok();
        }
        #endregion

        public CategoriaAutomoveis SelecionarRegistroPorID(int categoriaID)
        {
            return _repositorioCategoriaAutomoveis.SelecionarPorID(categoriaID);
        }

        public IEnumerable<CategoriaAutomoveis> SelecionarTodosOsRegistros()
        {
            return _repositorioCategoriaAutomoveis.SelecionarTodos();
        }

        public Result ValidarRegistro(CategoriaAutomoveis categoriaParaValidar)
        {
            ValidationResult validacao = new ValidadorCategoriaAutomoveis().Validate(categoriaParaValidar);

            List<IError> erros = validacao.ConverterParaListaDeErros();

            return Result.Fail(erros);
        }
    }
}
