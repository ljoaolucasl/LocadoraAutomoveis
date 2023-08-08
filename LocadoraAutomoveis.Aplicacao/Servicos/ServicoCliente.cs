using LocadoraAutomoveis.Dominio.ModuloAutomovel;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace LocadoraAutomoveis.Aplicacao.Servicos
{
    public class ServicoCliente : IServicoCliente
    {
        private readonly IRepositorioCliente _repositorioCliente;
        private readonly IValidadorCliente _validadorCliente;
        private readonly IContextoPersistencia _contextoPersistencia;

        public ServicoCliente(IRepositorioCliente repositorioCliente, IValidadorCliente validadorCliente,
            IContextoPersistencia contextoPersistencia)
        {
            _repositorioCliente = repositorioCliente;
            _validadorCliente = validadorCliente;
            _contextoPersistencia = contextoPersistencia;
        }

        #region CRUD
        public Result Inserir(Cliente clienteParaAdicionar)
        {
            Log.Debug("Tentando adicionar o Cliente '{NOME}'", clienteParaAdicionar.Nome);

            Result resultado = ValidarRegistro(clienteParaAdicionar);

            if (resultado.IsFailed)
            {
                Log.Warning("Falha ao tentar adicionar o Cliente '{NOME}'", clienteParaAdicionar.Nome);

                _contextoPersistencia.DesfazerAlteracoes();

                return resultado;
            }

            try
            {
                _repositorioCliente.Inserir(clienteParaAdicionar);

                _contextoPersistencia.GravarDados();

                Log.Debug("Adicionado o Cliente '{NOME} #{ID}' com sucesso!", clienteParaAdicionar.Nome, clienteParaAdicionar.ID);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                _contextoPersistencia.DesfazerAlteracoes();

                CustomError erro = new("Falha ao tentar inserir Cliente ", "Cliente", ex.Message);

                Log.Error(ex, erro.ErrorMessage + "{C}", clienteParaAdicionar);

                return Result.Fail(erro);
            }
        }

        public Result Editar(Cliente clienteParaEditar)
        {
            Log.Debug("Tentando editar o Cliente '{NOME} #{ID}'", clienteParaEditar.Nome, clienteParaEditar.ID);

            Result resultado = ValidarRegistro(clienteParaEditar);

            if (resultado.IsFailed)
            {
                Log.Warning("Falha ao tentar editar o Cliente '{NOME} #{ID}'", clienteParaEditar.Nome, clienteParaEditar.ID);

                _contextoPersistencia.DesfazerAlteracoes();

                return resultado;
            }
            try
            {
                _repositorioCliente.Editar(clienteParaEditar);

                _contextoPersistencia.GravarDados();

                Log.Debug("Editado o Cliente '{NOME} #{ID}' com sucesso!", clienteParaEditar.Nome, clienteParaEditar.ID);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                _contextoPersistencia.DesfazerAlteracoes();

                CustomError erro = new("Falha ao tentar editar Cliente ", "Cliente", ex.Message);

                Log.Error(ex, erro.ErrorMessage + "{C}", clienteParaEditar);

                return Result.Fail(erro);
            }
        }

        public Result Excluir(Cliente clienteParaExcluir)
        {
            Log.Debug("Tentando excluir o Cliente '{NOME} #{ID}'", clienteParaExcluir.Nome, clienteParaExcluir.ID);

            if (_repositorioCliente.Existe(clienteParaExcluir, true) == false)
            {
                Log.Warning("Cliente {ID} não encontrado para excluir", clienteParaExcluir.ID);

                _contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail("Cliente não encontrado");
            }
            try
            {
                _repositorioCliente.Excluir(clienteParaExcluir);

                _contextoPersistencia.GravarDados();

                Log.Debug("Excluído o Cliente '{NOME} #{ID}' com sucesso!", clienteParaExcluir.Nome, clienteParaExcluir.ID);

                return Result.Ok();
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlException)
            {
                List<IError> erros = AnalisarErros(clienteParaExcluir, sqlException);

                return Result.Fail(erros);
            }
            catch (InvalidOperationException ex)
            {
                List<IError> erros = AnalisarErros(clienteParaExcluir, ex);

                return Result.Fail(erros);
            }
        }

        private List<IError> AnalisarErros(Cliente clienteParaExcluir, Exception exception)
        {
            List<IError> erros = new();

            _contextoPersistencia.DesfazerAlteracoes();

            Log.Warning("Falha ao tentar excluir o Cliente '{NOME} #{ID}'", clienteParaExcluir.Nome, clienteParaExcluir.ID, exception);

            if (exception.Message.Contains("FK_TBAluguel_TBCliente"))
                erros.Add(new CustomError("Esse Cliente está relacionado a um Aluguel." +
            " Primeiro exclua o Aluguel relacionado", "Cliente"));
            else
                erros.Add(new CustomError("Falha ao tentar excluir Cliente", "Cliente"));

            return erros;
        }
        #endregion

        public Cliente SelecionarRegistroPorID(Guid taxaID)
        {
            return _repositorioCliente.SelecionarPorID(taxaID);
        }

        public List<Cliente> SelecionarTodosOsRegistros()
        {
            return _repositorioCliente.SelecionarTodos();
        }

        public Result ValidarRegistro(Cliente clienteParaValidar)
        {
            List<IError> erros = new();

            ValidationResult validacao = _validadorCliente.Validate(clienteParaValidar);

            if (validacao != null)
                erros = validacao.ConverterParaListaDeErros();

            if (_repositorioCliente.Existe(clienteParaValidar))
                erros.Add(new CustomError("Esse Cliente já existe", "Nome"));

            return Result.Fail(erros);
        }
    }
}
