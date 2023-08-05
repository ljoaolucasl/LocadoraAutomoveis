using LocadoraAutomoveis.Dominio.ModuloAluguel;
using Microsoft.EntityFrameworkCore;

namespace LocadoraAutomoveis.Aplicacao.Servicos
{
    public class ServicoAluguel : IServicoBase<Aluguel>
    {
        private readonly IRepositorioAluguel _repositorioAluguel;
        private readonly IValidadorAluguel _validadorAluguel;

        public ServicoAluguel(IRepositorioAluguel repositorioAluguel, IValidadorAluguel validadorAluguel)
        {
            _repositorioAluguel = repositorioAluguel;
            _validadorAluguel = validadorAluguel;
        }

        #region CRUD
        public Result Inserir(Aluguel aluguelParaAdicionar)
        {
            Log.Debug("Tentando inserir o Aluguel '{CLIENTE}'", aluguelParaAdicionar.Cliente.Nome);

            Result resultado = ValidarRegistro(aluguelParaAdicionar);

            if (resultado.IsFailed)
            {
                Log.Warning("Falha ao tentar inserir o Aluguel '{CLIENTE}'", aluguelParaAdicionar.Cliente.Nome);
                return resultado;
            }

            try
            {
                _repositorioAluguel.Inserir(aluguelParaAdicionar);

                Log.Debug("Inserido o Aluguel '{CLIENTE} #{ID}' com sucesso!", aluguelParaAdicionar.Cliente.Nome, aluguelParaAdicionar.ID);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                CustomError erro = new("Falha ao tentar inserir o Aluguel ", "Automovel", ex.Message);

                Log.Error(ex, erro.ErrorMessage + "{A}", aluguelParaAdicionar);

                return Result.Fail(erro);
            }
        }

        public Result Editar(Aluguel aluguelParaEditar)
        {
            Log.Debug("Tentando editar o Aluguel '{CLIENTE} #{ID}'", aluguelParaEditar.Cliente.Nome, aluguelParaEditar.ID);

            Result resultado = ValidarRegistro(aluguelParaEditar);

            if (resultado.IsFailed)
            {
                Log.Warning("Falha ao tentar editar o Aluguel '{CLIENTE} #{ID}'", aluguelParaEditar.Cliente.Nome, aluguelParaEditar.ID);
                return resultado;
            }
            try
            {
                _repositorioAluguel.Editar(aluguelParaEditar);

                Log.Debug("Editado o Aluguel '{CLIENTE} #{ID}' com sucesso!", aluguelParaEditar.Cliente.Nome, aluguelParaEditar.ID);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                CustomError erro = new("Falha ao tentar editar o Aluguel ", "Automovel", ex.Message);

                Log.Error(ex, erro.ErrorMessage + "{A}", aluguelParaEditar);

                return Result.Fail(erro);
            }
        }

        public Result Excluir(Aluguel aluguelParaExcluir)
        {
            Log.Debug("Tentando excluir o Aluguel '{CLIENTE} #{ID}'", aluguelParaExcluir.Cliente.Nome, aluguelParaExcluir.ID);

            if (_repositorioAluguel.Existe(aluguelParaExcluir, true) == false)
            {
                Log.Warning("Aluguel {ID} não encontrado para excluir", aluguelParaExcluir.ID);

                return Result.Fail("Aluguel não encontrado");
            }

            try
            {
                if (_validadorAluguel.ValidarSeAluguelConcluido(aluguelParaExcluir))
                {
                    _repositorioAluguel.Excluir(aluguelParaExcluir);

                    Log.Debug("Excluído o Aluguel '{CLIENTE} #{ID}' com sucesso!", aluguelParaExcluir.Cliente.Nome, aluguelParaExcluir.ID);

                    return Result.Ok();
                }
                else
                {
                    Log.Warning("Falha ao tentar excluir o Aluguel '{CLIENTE} #{ID}'. Aluguel está em aberto", aluguelParaExcluir.Cliente.Nome, aluguelParaExcluir.ID);

                    List<IError> erros = new();

                    erros.Add(new CustomError("Esse Aluguel está em aberto. Finalize o Aluguel antes de excluí-lo", "Aluguel"));

                    return Result.Fail(erros);
                }
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlException)
            {
                Log.Warning("Falha ao tentar excluir o Aluguel '{CLIENTE} #{ID}'", aluguelParaExcluir.Cliente.Nome, aluguelParaExcluir.ID, ex);

                List<IError> erros = new();

                erros.Add(new CustomError("Falha ao tentar excluir o Aluguel", "Aluguel"));

                return Result.Fail(erros);
            }
        }
        #endregion

        public Aluguel SelecionarRegistroPorID(Guid aluguelID)
        {
            return _repositorioAluguel.SelecionarPorID(aluguelID);
        }

        public List<Aluguel> SelecionarTodosOsRegistros()
        {
            return _repositorioAluguel.SelecionarTodos();
        }

        public Result ValidarRegistro(Aluguel aluguelParaValidar)
        {
            List<IError> erros = new();

            ValidationResult validacao = _validadorAluguel.Validate(aluguelParaValidar);

            if (validacao != null)
                erros = validacao.ConverterParaListaDeErros();

            if (_repositorioAluguel.Existe(aluguelParaValidar))
                erros.Add(new CustomError("Esse Aluguel já existe", "Aluguel"));

            return Result.Fail(erros);
        }
    }
}
