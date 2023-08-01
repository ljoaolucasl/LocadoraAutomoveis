using FluentResults;
using FluentValidation.Results;
using LocadoraAutomoveis.Aplicacao.Extensions;
using LocadoraAutomoveis.Dominio.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloParceiro;
using LocadoraAutomoveis.Infraestrutura.Repositorios;
using Microsoft.Data.SqlClient;
using Serilog;

namespace LocadoraAutomoveis.Aplicacao.Servicos
{
    public class ServicoParceiro : IServicoBase<Parceiro>
    {
        private readonly RepositorioParceiro _repositorioParceiro;

        public ServicoParceiro(RepositorioParceiro repositorioParceiro)
        {
            _repositorioParceiro = repositorioParceiro;
        }

        public Result Inserir(Parceiro parceiroParaAdicionar)
        {
            Log.Debug("Tentando adicionar a Parceiro '{NOME}'", parceiroParaAdicionar.Nome);

            Result resultado = ValidarRegistro(parceiroParaAdicionar);

            if (resultado.IsFailed)
            {
                Log.Warning("Tentando adicionar a Parceiro '{NOME}'", parceiroParaAdicionar.Nome);
                return resultado;
            }

            _repositorioParceiro.Inserir(parceiroParaAdicionar);

            Log.Debug("Adicionado a Parceiro '{NOME} #{ID}' com sucesso!", parceiroParaAdicionar.Nome, parceiroParaAdicionar.ID);

            return Result.Ok();
        }

        public Result Editar(Parceiro parceiroParaEditar)
        {
            Log.Debug("Tentando editar a Parceiro '{NOME} #{ID}'", parceiroParaEditar.Nome, parceiroParaEditar.ID);

            Result resultado = ValidarRegistro(parceiroParaEditar);

            if (resultado.IsFailed)
            {
                Log.Warning("Falha ao tentar editar a Parceiro '{NOME} #{ID}'", parceiroParaEditar.Nome, parceiroParaEditar.ID);
                return resultado;
            }

            _repositorioParceiro.Inserir(parceiroParaEditar);

            Log.Debug("Editado a Parceiro '{NOME} #{ID}' com sucesso!", parceiroParaEditar.Nome, parceiroParaEditar.ID);

            return Result.Ok();
        }

        public Result Excluir(Parceiro parceiroParaExcluir)
        {
            Log.Debug("Tentando excluir a Parceiro '{NOME} #{ID}'", parceiroParaExcluir.Nome, parceiroParaExcluir.ID);

            try
            {
                _repositorioParceiro.Excluir(parceiroParaExcluir);
            }
            catch (SqlException ex)
            {
                Log.Warning("Falha ao tentar excluir a Parceiro '{NOME} #{ID}'", parceiroParaExcluir.Nome, parceiroParaExcluir.ID, ex);

                //if (ex.Message.Contains("FK_TBPADRAO_TBOBJETORELACAO"))
                //    return Result.Fail(new Error("Esse Padrão está relacionado à um ObjetoRelacao." +
                //        " Primeiro exclua o ObjetoRelacao relacionado"));
            }

            Log.Debug("Excluído a Parceiro '{NOME} #{ID}' com sucesso!", parceiroParaExcluir.Nome, parceiroParaExcluir.ID);

            return Result.Ok();
        }

        public Parceiro SelecionarRegistroPorID(int parceiroID)
        {
            return _repositorioParceiro.SelecionarPorID(parceiroID);
        }

        public IEnumerable<Parceiro> SelecionarTodosOsRegistros()
        {
            return _repositorioParceiro.SelecionarTodos();
        }

        public Result ValidarRegistro(Parceiro parceiroParaValidar)
        {
            ValidationResult validacao = new ValidadorParceiro().Validate(parceiroParaValidar);

            List<IError> erros = validacao.ConverterParaListaDeErros();

            return Result.Fail(erros);
        }
    }
}
