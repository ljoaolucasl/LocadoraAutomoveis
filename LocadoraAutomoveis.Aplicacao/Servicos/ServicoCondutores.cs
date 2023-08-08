﻿using LocadoraAutomoveis.Dominio.ModuloCondutores;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraAutomoveis.Aplicacao.Servicos
{
    public class ServicoCondutores : IServicoCondutor
    {
        private readonly IRepositorioCondutores _repositorioCondutor;
        private readonly IValidadorCondutores _validadorCondutor;
        private readonly IContextoPersistencia _contextoPersistencia;

        public ServicoCondutores(IRepositorioCondutores repositorioCondutor, IValidadorCondutores validadorCondutor,
            IContextoPersistencia contextoPersistencia)
        {
            _repositorioCondutor = repositorioCondutor;
            _validadorCondutor = validadorCondutor;
            _contextoPersistencia = contextoPersistencia;
        }

        #region CRUD
        public Result Inserir(Condutor condutorParaAdicionar)
        {
            Log.Debug("Tentando adicionar o Condutor '{NOME}'", condutorParaAdicionar.Nome);

            Result resultado = ValidarRegistro(condutorParaAdicionar);

            if (resultado.IsFailed)
            {
                Log.Warning("Falha ao tentar adicionar o Condutor '{NOME}'", condutorParaAdicionar.Nome);

                _contextoPersistencia.DesfazerAlteracoes();

                return resultado;
            }

            try
            {
                _repositorioCondutor.Inserir(condutorParaAdicionar);

                _contextoPersistencia.GravarDados();

                Log.Debug("Adicionado o Condutor '{NOME} #{ID}' com sucesso!", condutorParaAdicionar.Nome, condutorParaAdicionar.ID);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                _contextoPersistencia.DesfazerAlteracoes();

                CustomError erro = new("Falha ao tentar inserir o Condutor ", "Condutor", ex.Message);

                Log.Error(ex, erro.ErrorMessage + "{C}", condutorParaAdicionar);

                return Result.Fail(erro);
            }
        }

        public Result Editar(Condutor condutorParaEditar)
        {
            Log.Debug("Tentando editar o Condutor '{NOME} #{ID}'", condutorParaEditar.Nome, condutorParaEditar.ID);

            Result resultado = ValidarRegistro(condutorParaEditar);

            if (resultado.IsFailed)
            {
                Log.Warning("Falha ao tentar editar o Condutor '{NOME} #{ID}'", condutorParaEditar.Nome, condutorParaEditar.ID);

                _contextoPersistencia.DesfazerAlteracoes();

                return resultado;
            }
            try
            {
                _repositorioCondutor.Editar(condutorParaEditar);

                _contextoPersistencia.GravarDados();

                Log.Debug("Editado o Condutor '{NOME} #{ID}' com sucesso!", condutorParaEditar.Nome, condutorParaEditar.ID);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                _contextoPersistencia.DesfazerAlteracoes();

                CustomError erro = new("Falha ao tentar editar o Condutor ", "Condutor", ex.Message);

                Log.Error(ex, erro.ErrorMessage + "{C}", condutorParaEditar);

                return Result.Fail(erro);
            }
        }

        public Result Excluir(Condutor condutorParaExcluir)
        {
            Log.Debug("Tentando excluir o Condutor '{NOME} #{ID}'", condutorParaExcluir.Nome, condutorParaExcluir.ID);

            if (_repositorioCondutor.Existe(condutorParaExcluir, true) == false)
            {
                Log.Warning("Condutor {ID} não encontrado para excluir", condutorParaExcluir.ID);

                _contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail("Condutor não encontrado");
            }

            try
            {
                _repositorioCondutor.Excluir(condutorParaExcluir);

                _contextoPersistencia.GravarDados();

                Log.Debug("Excluído o Condutor '{NOME} #{ID}' com sucesso!", condutorParaExcluir.Nome, condutorParaExcluir.ID);

                return Result.Ok();
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlException)
            {
                _contextoPersistencia.DesfazerAlteracoes();

                Log.Warning("Falha ao tentar excluir o Condutor '{NOME} #{ID}'", condutorParaExcluir.Nome, condutorParaExcluir.ID, ex);

                List<IError> erros = new();

                if (sqlException.Message.Contains("FK_TBAluguel_TBCondutor"))
                    erros.Add(new CustomError("Esse Condutor está relacionado a um Aluguel." +
                " Primeiro exclua o Aluguel relacionado", "Condutor"));
                else
                    erros.Add(new CustomError("Falha ao tentar excluir o Condutor", "Condutor"));

                return Result.Fail(erros);
            }
        }
        #endregion

        public Condutor SelecionarRegistroPorID(Guid taxaID)
        {
            return _repositorioCondutor.SelecionarPorID(taxaID);
        }

        public List<Condutor> SelecionarTodosOsRegistros()
        {
            return _repositorioCondutor.SelecionarTodos();
        }

        public Result ValidarRegistro(Condutor condutorParaValidar)
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
