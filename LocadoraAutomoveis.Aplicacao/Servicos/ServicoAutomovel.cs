using LocadoraAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using Microsoft.EntityFrameworkCore;

namespace LocadoraAutomoveis.Aplicacao.Servicos
{
    public class ServicoAutomovel : IServicoBase<Automovel>
    {
        private readonly IRepositorioAutomovel _repositorioAutomovel;
        private readonly IValidadorAutomovel _validadorAutomovel;

        public ServicoAutomovel(IRepositorioAutomovel repositorioAutomovel, IValidadorAutomovel validadorAutomovel)
        {
            _repositorioAutomovel = repositorioAutomovel;
            _validadorAutomovel = validadorAutomovel;
        }

        #region CRUD
        public Result Inserir(Automovel automovelParaAdicionar)
        {
            Log.Debug("Tentando inserir o Automóvel '{PLACA}'", automovelParaAdicionar.Placa);

            Result resultado = ValidarRegistro(automovelParaAdicionar);

            if (resultado.IsFailed)
            {
                Log.Warning("Falha ao tentar inserir o Automóvel '{PLACA}'", automovelParaAdicionar.Placa);
                return resultado;
            }

            try
            {
                _repositorioAutomovel.Inserir(automovelParaAdicionar);

                Log.Debug("Inserido o Automóvel '{PLACA} #{ID}' com sucesso!", automovelParaAdicionar.Placa, automovelParaAdicionar.ID);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                CustomError erro = new("Falha ao tentar inserir o Automóvel ", "Automovel", ex.Message);

                Log.Error(ex, erro.ErrorMessage + "{A}", automovelParaAdicionar);

                return Result.Fail(erro);
            }
        }

        public Result Editar(Automovel automovelParaEditar)
        {
            Log.Debug("Tentando editar o Automóvel '{PLACA} #{ID}'", automovelParaEditar.Placa, automovelParaEditar.ID);

            Result resultado = ValidarRegistro(automovelParaEditar);

            if (resultado.IsFailed)
            {
                Log.Warning("Falha ao tentar editar o Automóvel '{PLACA} #{ID}'", automovelParaEditar.Placa, automovelParaEditar.ID);
                return resultado;
            }
            try
            {
                _repositorioAutomovel.Editar(automovelParaEditar);

                Log.Debug("Editado o Automóvel '{PLACA} #{ID}' com sucesso!", automovelParaEditar.Placa, automovelParaEditar.ID);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                CustomError erro = new("Falha ao tentar editar o Automóvel ", "Automovel", ex.Message);

                Log.Error(ex, erro.ErrorMessage + "{A}", automovelParaEditar);

                return Result.Fail(erro);
            }
        }

        public Result Excluir(Automovel automovelParaExcluir)
        {
            Log.Debug("Tentando excluir o Automóvel '{PLACA} #{ID}'", automovelParaExcluir.Placa, automovelParaExcluir.ID);

            if (_repositorioAutomovel.Existe(automovelParaExcluir, true) == false)
            {
                Log.Warning("Automóvel {ID} não encontrado para excluir", automovelParaExcluir.ID);

                return Result.Fail("Automóvel não encontrado");
            }

            try
            {
                _repositorioAutomovel.Excluir(automovelParaExcluir);

                Log.Debug("Excluído o Automóvel '{PLACA} #{ID}' com sucesso!", automovelParaExcluir.Placa, automovelParaExcluir.ID);

                return Result.Ok();
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlException)
            {
                Log.Warning("Falha ao tentar excluir o Automóvel '{PLACA} #{ID}'", automovelParaExcluir.Placa, automovelParaExcluir.ID, ex);

                List<IError> erros = new();

                if (sqlException.Message.Contains("FK_TBCategoriaAutomoveis_TBOBJETORELACAO"))
                    erros.Add(new CustomError("Essa Categoria está relacionada à um ObjetoRelacao." +
                        " Primeiro exclua o ObjetoRelacao relacionado", "Categoria"));
                else
                    erros.Add(new CustomError("Falha ao tentar excluir o Automóvel", "Automóvel"));

                return Result.Fail(erros);
            }
        }
        #endregion

        public Automovel SelecionarRegistroPorID(Guid categoriaID)
        {
            return _repositorioAutomovel.SelecionarPorID(categoriaID);
        }

        public List<Automovel> SelecionarTodosOsRegistros()
        {
            return _repositorioAutomovel.SelecionarTodos();
        }

        public List<Automovel> FiltrarAutomoveisPorCategoria(CategoriaAutomoveis categoria)
        {
            return _repositorioAutomovel.SelecionarPorCategoria(categoria);
        }

        public Result ValidarRegistro(Automovel categoriaParaValidar)
        {
            List<IError> erros = new();

            ValidationResult validacao = _validadorAutomovel.Validate(categoriaParaValidar);

            if (validacao != null)
                erros = validacao.ConverterParaListaDeErros();

            if (_repositorioAutomovel.Existe(categoriaParaValidar))
                erros.Add(new CustomError("Esse Automóvel já existe", "Placa"));

            return Result.Fail(erros);
        }
    }
}
