using FluentResults;
using FluentValidation.Results;
using LocadoraAutomoveis.Aplicacao.Compartilhado;
using LocadoraAutomoveis.Aplicacao.Extensions;
using LocadoraAutomoveis.Dominio.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace LocadoraAutomoveis.Aplicacao.Servicos
{
    public class ServicoCliente : IServicoCliente
    {
        private readonly IRepositorioCliente _repositorioCliente;
        private readonly IValidadorCliente _validadorCliente;

        public ServicoCliente(IRepositorioCliente repositorioCliente, IValidadorCliente validadorCliente)
        {
            _repositorioCliente = repositorioCliente;
            _validadorCliente = validadorCliente;
        }

        #region CRUD
        public Result Inserir(Cliente clienteParaAdicionar)
        {
            Log.Debug("Tentando adicionar o Cliente '{NOME}'", clienteParaAdicionar.Nome);

            Result resultado = ValidarRegistro(clienteParaAdicionar);

            if (resultado.IsFailed)
            {
                Log.Warning("Falha ao tentar adicionar o Cliente '{NOME}'", clienteParaAdicionar.Nome);
                return resultado;
            }

            try
            {
                _repositorioCliente.Inserir(clienteParaAdicionar);

                Log.Debug("Adicionado o Cliente '{NOME} #{ID}' com sucesso!", clienteParaAdicionar.Nome, clienteParaAdicionar.ID);

                return Result.Ok();
            }
            catch (Exception ex)
            {
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
                return resultado;
            }
            try
            {
                _repositorioCliente.Editar(clienteParaEditar);

                Log.Debug("Editado o Cliente '{NOME} #{ID}' com sucesso!", clienteParaEditar.Nome, clienteParaEditar.ID);

                return Result.Ok();
            }
            catch (Exception ex)
            {
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

                return Result.Fail("Cliente não encontrado");
            }

            try
            {
                _repositorioCliente.Excluir(clienteParaExcluir);

                Log.Debug("Excluído o Cliente '{NOME} #{ID}' com sucesso!", clienteParaExcluir.Nome, clienteParaExcluir.ID);

                return Result.Ok();
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlException)
            {
                Log.Warning("Falha ao tentar excluir o Cliente '{NOME} #{ID}'", clienteParaExcluir.Nome, clienteParaExcluir.ID, ex);

                List<IError> erros = new();

                if (sqlException.Message.Contains("FK_TBAluguel_TBCliente"))
                    erros.Add(new CustomError("Esse Cliente está relacionado a um Aluguel." +
                " Primeiro exclua o Aluguel relacionado", "Cliente"));
                else
                    erros.Add(new CustomError("Falha ao tentar excluir Cliente", "Cliente"));

                return Result.Fail(erros);
            }
            catch (InvalidOperationException ex)
            {
                Log.Warning("Falha ao tentar excluir o Cliente '{NOME} #{ID}'", clienteParaExcluir.Nome, clienteParaExcluir.ID, ex);

                List<IError> erros = new();

                if (ex.Message.Contains("'Cliente' and 'Condutor' "))
                    erros.Add(new CustomError("Esse Cliente de Condutor está relacionado a um Condutor." +
                        " Primeiro exclua o Condutor relacionado", "Cliente"));
                else
                    erros.Add(new CustomError("Falha ao tentar excluir a Cliente de Condutor", "Cliente"));

                return Result.Fail(erros);
            }
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
