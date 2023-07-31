using FluentResults;
using FluentValidation.Results;
using Microsoft.Data.SqlClient;
using Serilog;
using LocadoraAutomoveis.Aplicacao.Extensions;
using LocadoraAutomoveis.Dominio.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloPadrao;
using LocadoraAutomoveis.Infraestrutura.Repositorios;

namespace LocadoraAutomoveis.Aplicacao.Servicos
{
    public class ServicoPadrao : IServicoBase<Padrao>
    {
        private readonly RepositorioPadrao _repositorioPadrao;

        public ServicoPadrao(RepositorioPadrao repositorioPadrao)
        {
            _repositorioPadrao = repositorioPadrao;
        }

        #region CRUD
        public Result Inserir(Padrao padraoParaAdicionar)
        {
            Log.Debug("Tentando adicionar o Padrão '{NOME}'", padraoParaAdicionar.Nome);

            Result resultado = ValidarRegistro(padraoParaAdicionar);

            if (resultado.IsFailed)
            {
                Log.Warning("Falha ao tentar adicionar o Padrão '{NOME}'", padraoParaAdicionar.Nome);
                return resultado;
            }

            _repositorioPadrao.Inserir(padraoParaAdicionar);

            Log.Debug("Adicionado o Padrão '{NOME} #{ID}' com sucesso!", padraoParaAdicionar.Nome, padraoParaAdicionar.ID);

            return Result.Ok();
        }

        public Result Editar(Padrao padraoParaEditar)
        {
            Log.Debug("Tentando editar o Padrão '{NOME} #{ID}'", padraoParaEditar.Nome, padraoParaEditar.ID);

            Result resultado = ValidarRegistro(padraoParaEditar);

            if (resultado.IsFailed)
            {
                Log.Warning("Falha ao tentar editar o Padrão '{NOME} #{ID}'", padraoParaEditar.Nome, padraoParaEditar.ID);
                return resultado;
            }

            _repositorioPadrao.Inserir(padraoParaEditar);

            Log.Debug("Editado o Padrão '{NOME} #{ID}' com sucesso!", padraoParaEditar.Nome, padraoParaEditar.ID);

            return Result.Ok();
        }

        public Result Excluir(Padrao padraoParaExcluir)
        {
            Log.Debug("Tentando excluir o Padrão '{NOME} #{ID}'", padraoParaExcluir.Nome, padraoParaExcluir.ID);

            try
            {
                _repositorioPadrao.Excluir(padraoParaExcluir);
            }
            catch (SqlException ex)
            {
                Log.Warning("Falha ao tentar excluir o Padrão '{NOME} #{ID}'", padraoParaExcluir.Nome, padraoParaExcluir.ID, ex);

                if (ex.Message.Contains("FK_TBPADRAO_TBOBJETORELACAO"))
                    return Result.Fail(new Error("Esse Padrão está relacionado à um ObjetoRelacao." +
                        " Primeiro exclua o ObjetoRelacao relacionado"));
            }

            Log.Debug("Excluído o Padrão '{NOME} #{ID}' com sucesso!", padraoParaExcluir.Nome, padraoParaExcluir.ID);

            return Result.Ok();
        }
        #endregion

        public Padrao SelecionarRegistroPorID(int padraoID)
        {
            return _repositorioPadrao.SelecionarPorID(padraoID);
        }

        public IEnumerable<Padrao> SelecionarTodosOsRegistros()
        {
            return _repositorioPadrao.SelecionarTodos();
        }

        public Result ValidarRegistro(Padrao padraoParaValidar)
        {
            ValidationResult validacao = new ValidadorPadrao().Validate(padraoParaValidar);

            List<IError> erros = validacao.ConverterParaListaDeErros();

            return Result.Fail(erros);
        }
    }
}