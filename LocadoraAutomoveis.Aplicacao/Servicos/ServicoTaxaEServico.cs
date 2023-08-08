using LocadoraAutomoveis.Dominio.ModuloTaxaEServico;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraAutomoveis.Aplicacao.Servicos
{
    public class ServicoTaxaEServico : IServicoTaxaEServico
    {
        private readonly IRepositorioTaxaEServico _repositorioTaxaEServico;
        private readonly IValidadorTaxaEServico _validadorTaxaEServico;
        private readonly IContextoPersistencia _contextoPersistencia;

        public ServicoTaxaEServico(IRepositorioTaxaEServico repositorioTaxaEServico, IValidadorTaxaEServico validadorTaxaEServico,
            IContextoPersistencia contextoPersistencia)
        {
            _repositorioTaxaEServico = repositorioTaxaEServico;
            _validadorTaxaEServico = validadorTaxaEServico;
            _contextoPersistencia = contextoPersistencia;
        }

        #region CRUD
        public Result Inserir(TaxaEServico taxaParaAdicionar)
        {
            Log.Debug("Tentando inserir a Taxa e Serviço '{NOME}'", taxaParaAdicionar.Nome);

            Result resultado = ValidarRegistro(taxaParaAdicionar);

            if (resultado.IsFailed)
            {
                Log.Warning("Falha ao tentar inserir a Taxa e Serviço '{NOME}'", taxaParaAdicionar.Nome);

                _contextoPersistencia.DesfazerAlteracoes();

                return resultado;
            }

            try
            {
                _repositorioTaxaEServico.Inserir(taxaParaAdicionar);

                _contextoPersistencia.GravarDados();

                Log.Debug("Inserido a Taxa e Serviço '{NOME} #{ID}' com sucesso!", taxaParaAdicionar.Nome, taxaParaAdicionar.ID);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                _contextoPersistencia.DesfazerAlteracoes();

                CustomError erro = new("Falha ao tentar inserir Taxa e Serviço ", "Taxa", ex.Message);

                Log.Error(ex, erro.ErrorMessage + "{T}", taxaParaAdicionar);

                return Result.Fail(erro);
            }
        }

        public Result Editar(TaxaEServico taxaParaEditar)
        {
            Log.Debug("Tentando editar a Taxa e Serviço '{NOME} #{ID}'", taxaParaEditar.Nome, taxaParaEditar.ID);

            Result resultado = ValidarRegistro(taxaParaEditar);

            if (resultado.IsFailed)
            {
                Log.Warning("Falha ao tentar editar a Taxa e Serviço '{NOME} #{ID}'", taxaParaEditar.Nome, taxaParaEditar.ID);

                _contextoPersistencia.DesfazerAlteracoes();

                return resultado;
            }
            try
            {
                _repositorioTaxaEServico.Editar(taxaParaEditar);

                _contextoPersistencia.GravarDados();

                Log.Debug("Editado a Taxa e Serviço '{NOME} #{ID}' com sucesso!", taxaParaEditar.Nome, taxaParaEditar.ID);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                _contextoPersistencia.DesfazerAlteracoes();

                CustomError erro = new("Falha ao tentar editar Taxa e Serviço ", "Taxa", ex.Message);

                Log.Error(ex, erro.ErrorMessage + "{T}", taxaParaEditar);

                return Result.Fail(erro);
            }
        }

        public Result Excluir(TaxaEServico taxaParaExcluir)
        {
            Log.Debug("Tentando excluir a Taxa e Serviço '{NOME} #{ID}'", taxaParaExcluir.Nome, taxaParaExcluir.ID);

            if (_repositorioTaxaEServico.Existe(taxaParaExcluir, true) == false)
            {
                Log.Warning("Taxa e Serviço {ID} não encontrado para excluir", taxaParaExcluir.ID);

                _contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail("Taxa e Serviço não encontrado");
            }

            try
            {
                _repositorioTaxaEServico.Excluir(taxaParaExcluir);

                _contextoPersistencia.GravarDados();

                Log.Debug("Excluído a Taxa e Serviço '{NOME} #{ID}' com sucesso!", taxaParaExcluir.Nome, taxaParaExcluir.ID);

                return Result.Ok();
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlException)
            {
                List<IError> erros = AnalisarErros(taxaParaExcluir, sqlException);

                return Result.Fail(erros);
            }
            catch (InvalidOperationException ex)
            {
                List<IError> erros = AnalisarErros(taxaParaExcluir, ex);

                return Result.Fail(erros);
            }
        }

        private List<IError> AnalisarErros(TaxaEServico taxaParaExcluir, Exception exception)
        {
            List<IError> erros = new();

            _contextoPersistencia.DesfazerAlteracoes();

            Log.Warning("Falha ao tentar excluir a Taxa e Serviço '{NOME} #{ID}'", taxaParaExcluir.Nome, taxaParaExcluir.ID, exception);

            if (exception.Message.Contains("FK_TBAluguel_TBTaxaEServicos"))
                erros.Add(new CustomError("Essa Taxa e Serviço está relacionada a um Aluguel." +
            " Primeiro exclua o Aluguel relacionado", "Taxa"));
            else
                erros.Add(new CustomError("Falha ao tentar excluir a Taxa e Serviço", "Taxa"));

            return erros;
        }
        #endregion

        public TaxaEServico SelecionarRegistroPorID(Guid taxaID)
        {
            return _repositorioTaxaEServico.SelecionarPorID(taxaID);
        }

        public List<TaxaEServico> SelecionarTodosOsRegistros()
        {
            return _repositorioTaxaEServico.SelecionarTodos();
        }

        public Result ValidarRegistro(TaxaEServico taxaParaValidar)
        {
            List<IError> erros = new();

            ValidationResult validacao = _validadorTaxaEServico.Validate(taxaParaValidar);

            if (validacao != null)
                erros = validacao.ConverterParaListaDeErros();

            if (_repositorioTaxaEServico.Existe(taxaParaValidar))
                erros.Add(new CustomError("Essa Taxa e Serviço já existe", "Nome"));

            return Result.Fail(erros);
        }
    }
}
