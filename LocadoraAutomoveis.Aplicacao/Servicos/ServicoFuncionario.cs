using FluentResults;
using FluentValidation.Results;
using LocadoraAutomoveis.Aplicacao.Extensions;
using LocadoraAutomoveis.Dominio.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using LocadoraAutomoveis.Infraestrutura.Repositorios;
using Microsoft.Data.SqlClient;
using Serilog;

namespace LocadoraAutomoveis.Aplicacao.Servicos
{
    public class ServicoFuncionario : IServicoBase<Funcionario>
    {
        private readonly RepositorioFuncionario _repositorioFuncionarios;

        public ServicoFuncionario(RepositorioFuncionario repositorioFuncionarios)
        {
            _repositorioFuncionarios = repositorioFuncionarios;
        }

        #region CRUD
        public Result Adicionar(Funcionario funcionarioParaAdicionar)
        {
            Log.Debug("Tentando adicionar o Funcionário '{NOME}'", funcionarioParaAdicionar.Nome);
            Log.Debug("Tentando adicionar o Funcionário '{ADMISSAO}'", funcionarioParaAdicionar.Admissao);
            Log.Debug("Tentando adicionar o Funcionário '{SALARIO}'", funcionarioParaAdicionar.Salario);

            Result resultado = ValidarRegistro(funcionarioParaAdicionar);

            if (resultado.IsFailed)
            {
                Log.Warning("Falha ao tentar adicionar o Funcionário '{NOME}'", funcionarioParaAdicionar.Nome);
                Log.Warning("Falha ao tentar adicionar o Funcionário '{ADMISSAO}'", funcionarioParaAdicionar.Admissao);
                Log.Warning("Falha ao tentar adicionar o Funcionário '{SALARIO}'", funcionarioParaAdicionar.Salario);

                return resultado;
            }

            _repositorioFuncionarios.Adicionar(funcionarioParaAdicionar);

            Log.Debug("Adicionado o Funcionário '{NOME} {ADMISSAO} {SALARIO} #{ID}' com sucesso!", funcionarioParaAdicionar.Nome, funcionarioParaAdicionar.Admissao, funcionarioParaAdicionar.Salario, funcionarioParaAdicionar.ID);

            return Result.Ok();
        }

        public Result Editar(Funcionario funcionarioParaEditar)
        {
            Log.Debug("Tentando editar o Funcionário '{NOME} {ADMISSAO} {SALARIO} #{ID}'", funcionarioParaEditar.Nome, funcionarioParaEditar.Admissao, funcionarioParaEditar.Salario, funcionarioParaEditar.ID);

            Result resultado = ValidarRegistro(funcionarioParaEditar);

            if (resultado.IsFailed)
            {
                Log.Warning("Falha ao tentar editar o Funcionário '{NOME} {ADMISSAO} {SALARIO} #{ID}'", funcionarioParaEditar.Nome, funcionarioParaEditar.Admissao, funcionarioParaEditar.Salario, funcionarioParaEditar.ID);
                return resultado;
            }

            _repositorioFuncionarios.Adicionar(funcionarioParaEditar);

            Log.Debug("Editado o Funcionário '{NOME} {ADMISSAO} {SALARIO} #{ID}' com sucesso!", funcionarioParaEditar.Nome, funcionarioParaEditar.Admissao, funcionarioParaEditar.Salario, funcionarioParaEditar.ID);

            return Result.Ok();
        }

        public Result Excluir(Funcionario funcionarioParaExcluir)
        {
            Log.Debug("Tentando excluir o Funcionário '{NOME} {ADMISSAO} {SALARIO} #{ID}'", funcionarioParaExcluir.Nome, funcionarioParaExcluir.Admissao, funcionarioParaExcluir.Salario, funcionarioParaExcluir.ID);

            try
            {
                _repositorioFuncionarios.Excluir(funcionarioParaExcluir);
            }
            catch (SqlException ex)
            {
                Log.Warning("Falha ao tentar excluir o Funcionário '{NOME} {ADMISSAO} {SALARIO} #{ID}'", funcionarioParaExcluir.Nome, funcionarioParaExcluir.Admissao, funcionarioParaExcluir.Salario, funcionarioParaExcluir.ID, ex);

                //if (ex.Message.Contains("FK_TBPADRAO_TBOBJETORELACAO"))
                //    return Result.Fail(new Error("Esse Padrão está relacionado à um ObjetoRelacao." +
                //        " Primeiro exclua o ObjetoRelacao relacionado"));
            }

            Log.Debug("Excluído o Funcionário '{NOME} {ADMISSAO} {SALARIO} #{ID}' com sucesso!", funcionarioParaExcluir.Nome, funcionarioParaExcluir.Admissao, funcionarioParaExcluir.Salario, funcionarioParaExcluir.ID);

            return Result.Ok();
        }
        #endregion

        public Funcionario SelecionarRegistroPorID(int categoriaID)
        {
            return _repositorioFuncionarios.SelecionarPorID(categoriaID);
        }

        public IEnumerable<Funcionario> SelecionarTodosOsRegistros()
        {
            return _repositorioFuncionarios.SelecionarTodos();
        }

        public Result ValidarRegistro(Funcionario funcionarioParaValidar)
        {
            ValidationResult validacao = new ValidadorFuncionario().Validate(funcionarioParaValidar);

            List<IError> erros = validacao.ConverterParaListaDeErros();

            return Result.Fail(erros);
        }
    }
}
