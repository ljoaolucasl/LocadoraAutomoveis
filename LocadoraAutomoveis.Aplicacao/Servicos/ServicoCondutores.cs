using FluentResults;
using FluentValidation.Results;
using LocadoraAutomoveis.Aplicacao.Compartilhado;
using LocadoraAutomoveis.Aplicacao.Extensions;
using LocadoraAutomoveis.Dominio.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloCondutores;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace LocadoraAutomoveis.Aplicacao.Servicos
{
    public class ServicoCondutores : IServicoBase<Condutores>
    {
        private readonly IRepositorioCondutores _repositorioCondutor;
        private readonly IValidadorCondutores _validadorCondutor;

        public ServicoCondutores(IRepositorioCondutores repositorioCondutor, IValidadorCondutores validadorCondutor)
        {
            _repositorioCondutor = repositorioCondutor;
            _validadorCondutor = validadorCondutor;
        }

        #region CRUD
        public Result Inserir(Condutores condutorParaAdicionar)
        {
            Log.Debug("Tentando adicionar o Condutor '{NOME}'", condutorParaAdicionar.Nome);

            Result resultado = ValidarRegistro(condutorParaAdicionar);

            if (resultado.IsFailed)
            {
                Log.Warning("Falha ao tentar adicionar o Condutor '{NOME}'", condutorParaAdicionar.Nome);
                return resultado;
            }

            try
            {
                _repositorioCondutor.Inserir(condutorParaAdicionar);

                Log.Debug("Adicionado o Condutor '{NOME} #{ID}' com sucesso!", condutorParaAdicionar.Nome, condutorParaAdicionar.ID);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                CustomError erro = new("Falha ao tentar inserir o Condutor ", "Condutor", ex.Message);

                Log.Error(ex, erro.ErrorMessage + "{C}", condutorParaAdicionar);

                return Result.Fail(erro);
            }
        }

        public Result Editar(Condutores condutorParaEditar)
        {
            Log.Debug("Tentando editar o Condutor '{NOME} #{ID}'", condutorParaEditar.Nome, condutorParaEditar.ID);

            Result resultado = ValidarRegistro(condutorParaEditar);

            if (resultado.IsFailed)
            {
                Log.Warning("Falha ao tentar editar o Condutor '{NOME} #{ID}'", condutorParaEditar.Nome, condutorParaEditar.ID);
                return resultado;
            }
            try
            {
                _repositorioCondutor.Editar(condutorParaEditar);

                Log.Debug("Editado o Condutor '{NOME} #{ID}' com sucesso!", condutorParaEditar.Nome, condutorParaEditar.ID);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                CustomError erro = new("Falha ao tentar editar o Condutor ", "Condutor", ex.Message);

                Log.Error(ex, erro.ErrorMessage + "{C}", condutorParaEditar);

                return Result.Fail(erro);
            }
        }

        public Result Excluir(Condutores condutorParaExcluir)
        {
            Log.Debug("Tentando excluir o Condutor '{NOME} #{ID}'", condutorParaExcluir.Nome, condutorParaExcluir.ID);

            if (_repositorioCondutor.Existe(condutorParaExcluir, true) == false)
            {
                Log.Warning("Condutor {ID} não encontrado para excluir", condutorParaExcluir.ID);

                return Result.Fail("Condutor não encontrado");
            }

            try
            {
                _repositorioCondutor.Excluir(condutorParaExcluir);

                Log.Debug("Excluído o Condutor '{NOME} #{ID}' com sucesso!", condutorParaExcluir.Nome, condutorParaExcluir.ID);

                return Result.Ok();
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlException)
            {
                Log.Warning("Falha ao tentar excluir o Condutor '{NOME} #{ID}'", condutorParaExcluir.Nome, condutorParaExcluir.ID, ex);

                List<IError> erros = new();

                if (sqlException.Message.Contains("FK_TBCondutores_TBOBJETORELACAO"))
                    erros.Add(new CustomError("Esse Condutor está relacionado à um ObjetoRelacao." +
                        " Primeiro exclua o ObjetoRelacao relacionado", "Condutor"));
                else
                    erros.Add(new CustomError("Falha ao tentar excluir o Condutor", "Condutor"));

                return Result.Fail(erros);
            }
        }
        #endregion

        public Condutores SelecionarRegistroPorID(Guid taxaID)
        {
            return _repositorioCondutor.SelecionarPorID(taxaID);
        }

        public List<Condutores> SelecionarTodosOsRegistros()
        {
            return _repositorioCondutor.SelecionarTodos();
        }

        public Result ValidarRegistro(Condutores condutorParaValidar)
        {
            List<IError> erros = new();

            ValidationResult validacao = _validadorCondutor.Validate(condutorParaValidar);

            if (validacao != null)
                erros = validacao.ConverterParaListaDeErros();

            if (_repositorioCondutor.Existe(condutorParaValidar))
                erros.Add(new CustomError("Esse Condutor já existe", "Nome"));

            return Result.Fail(erros);
        }
    }
}
