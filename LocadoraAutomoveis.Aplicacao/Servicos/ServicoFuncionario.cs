using LocadoraAutomoveis.Dominio.ModuloCupom;
using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace LocadoraAutomoveis.Aplicacao.Servicos
{
    public class ServicoFuncionario : IServicoFuncionario
    {
        private readonly IRepositorioFuncionario _repositorioFuncionarios;
        private readonly IValidadorFuncionario _validadorFuncionario;
        private readonly IContextoPersistencia _contextoPersistencia;

        public ServicoFuncionario(IRepositorioFuncionario repositorioFuncionarios, IValidadorFuncionario validadorFuncionario,
            IContextoPersistencia contextoPersistencia)
        {
            _repositorioFuncionarios = repositorioFuncionarios;
            _validadorFuncionario = validadorFuncionario;
            _contextoPersistencia = contextoPersistencia;
        }

        #region CRUD
        public Result Inserir(Funcionario funcionarioParaAdicionar)
        {
            Log.Debug("Tentando adicionar o Funcionário '{NOME}' ", funcionarioParaAdicionar.Nome);

            Result resultado = ValidarRegistro(funcionarioParaAdicionar);

            if (resultado.IsFailed)
            {
                Log.Warning("Falha ao tentar adicionar o Funcionário '{NOME}'", funcionarioParaAdicionar.Nome);

                _contextoPersistencia.DesfazerAlteracoes();

                return resultado;
            }
            try
            {
                _repositorioFuncionarios.Inserir(funcionarioParaAdicionar);

                _contextoPersistencia.GravarDados();

                Log.Debug("Adicionado o Funcionário '{NOME} #{ID}' com sucesso!", funcionarioParaAdicionar.Nome, funcionarioParaAdicionar.ID);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                _contextoPersistencia.DesfazerAlteracoes();

                CustomError erro = new CustomError("Falha ao tentar inserir Funcionário ", "Funcionario", ex.Message);

                Log.Error(ex, erro.ErrorMessage + "{F}", funcionarioParaAdicionar);

                return Result.Fail(erro);
            }
        }

        public Result Editar(Funcionario funcionarioParaEditar)
        {
            Log.Debug("Tentando editar o Funcionário '{NOME} #{ID}'", funcionarioParaEditar.Nome, funcionarioParaEditar.ID);

            Result resultado = ValidarRegistro(funcionarioParaEditar);

            if (resultado.IsFailed)
            {
                Log.Warning("Falha ao tentar editar o Funcionário '{NOME} #{ID}'", funcionarioParaEditar.Nome, funcionarioParaEditar.ID);

                _contextoPersistencia.DesfazerAlteracoes();

                return resultado;
            }
            try
            {
                _repositorioFuncionarios.Editar(funcionarioParaEditar);

                _contextoPersistencia.GravarDados();

                Log.Debug("Editado o Funcionário '{NOME} #{ID}' com sucesso!", funcionarioParaEditar.Nome, funcionarioParaEditar.ID);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                _contextoPersistencia.DesfazerAlteracoes();

                CustomError erro = new CustomError("Falha ao tentar editar Funcionário ", "Funcionario", ex.Message);

                Log.Error(ex, erro.ErrorMessage + "{F}", funcionarioParaEditar);

                return Result.Fail(erro);
            }
        }

        public Result Excluir(Funcionario funcionarioParaExcluir)
        {
            Log.Debug("Tentando excluir o Funcionário '{NOME} #{ID}'", funcionarioParaExcluir.Nome, funcionarioParaExcluir.ID);

            if (_repositorioFuncionarios.Existe(funcionarioParaExcluir, true) == false)
            {
                Log.Warning("Funcionário {ID} não encontrado para excluir", funcionarioParaExcluir.ID);

                _contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail("Funcionário não encontrado");
            }

            try
            {
                _repositorioFuncionarios.Excluir(funcionarioParaExcluir);

                _contextoPersistencia.GravarDados();

                Log.Debug("Excluído o Funcionário '{NOME} #{ID}' com sucesso!", funcionarioParaExcluir.Nome, funcionarioParaExcluir.ID);

                return Result.Ok();
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlException)
            {
                List<IError> erros = AnalisarErros(funcionarioParaExcluir, sqlException);

                return Result.Fail(erros);
            }
            catch (InvalidOperationException ex)
            {
                List<IError> erros = AnalisarErros(funcionarioParaExcluir, ex);

                return Result.Fail(erros);
            }
        }

        private List<IError> AnalisarErros(Funcionario funcionarioParaExcluir, Exception exception)
        {
            List<IError> erros = new();

            _contextoPersistencia.DesfazerAlteracoes();

            Log.Warning("Falha ao tentar excluir Funcionário '{NOME} #{ID}'", funcionarioParaExcluir.Nome, funcionarioParaExcluir.ID, exception);

            if (exception.Message.Contains("FK_TBAluguel_TBFuncionario"))
                erros.Add(new CustomError("Esse Funcionário está relacionado a um Aluguel." +
                    " Primeiro exclua o Aluguel relacionado", "Funcionario"));
            else
                erros.Add(new CustomError("Falha ao tentar excluir Funcionário", "Funcionario"));

            return erros;
        }
        #endregion

        public Funcionario? SelecionarRegistroPorID(Guid categoriaID)
        {
            return _repositorioFuncionarios.SelecionarPorID(categoriaID);
        }

        public List<Funcionario> SelecionarTodosOsRegistros()
        {
            return _repositorioFuncionarios.SelecionarTodos();
        }

        public Result ValidarRegistro(Funcionario funcionarioParaValidar)
        {
            List<IError> erros = new();

            ValidationResult validacao = _validadorFuncionario.Validate(funcionarioParaValidar);

            if (validacao != null)
                erros = validacao.ConverterParaListaDeErros();

            if (_repositorioFuncionarios.Existe(funcionarioParaValidar))
                erros.Add(new CustomError("Esse Funcionário já existe", "Nome"));

            return Result.Fail(erros);
        }
    }
}
