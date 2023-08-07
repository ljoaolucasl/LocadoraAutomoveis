using LocadoraAutomoveis.Dominio.ModuloTaxaEServico;

namespace LocadoraAutomoveis.Aplicacao.Servicos
{
    public class ServicoTaxaEServico : IServicoTaxaEServico
    {
        private readonly IRepositorioTaxaEServico _repositorioTaxaEServico;
        private readonly IValidadorTaxaEServico _validadorTaxaEServico;

        public ServicoTaxaEServico(IRepositorioTaxaEServico repositorioTaxaEServico, IValidadorTaxaEServico validadorTaxaEServico)
        {
            _repositorioTaxaEServico = repositorioTaxaEServico;
            _validadorTaxaEServico = validadorTaxaEServico;
        }

        #region CRUD
        public Result Inserir(TaxaEServico taxaParaAdicionar)
        {
            Log.Debug("Tentando inserir a Taxa e Serviço '{NOME}'", taxaParaAdicionar.Nome);

            Result resultado = ValidarRegistro(taxaParaAdicionar);

            if (resultado.IsFailed)
            {
                Log.Warning("Falha ao tentar inserir a Taxa e Serviço '{NOME}'", taxaParaAdicionar.Nome);
                return resultado;
            }

            try
            {
                _repositorioTaxaEServico.Inserir(taxaParaAdicionar);

                Log.Debug("Inserido a Taxa e Serviço '{NOME} #{ID}' com sucesso!", taxaParaAdicionar.Nome, taxaParaAdicionar.ID);

                return Result.Ok();
            }
            catch (Exception ex)
            {
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
                return resultado;
            }
            try
            {
                _repositorioTaxaEServico.Editar(taxaParaEditar);

                Log.Debug("Editado a Taxa e Serviço '{NOME} #{ID}' com sucesso!", taxaParaEditar.Nome, taxaParaEditar.ID);

                return Result.Ok();
            }
            catch (Exception ex)
            {
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

                return Result.Fail("Taxa e Serviço não encontrado");
            }

            try
            {
                _repositorioTaxaEServico.Excluir(taxaParaExcluir);

                Log.Debug("Excluído a Taxa e Serviço '{NOME} #{ID}' com sucesso!", taxaParaExcluir.Nome, taxaParaExcluir.ID);

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                Log.Warning("Falha ao tentar excluir a Taxa e Serviço '{NOME} #{ID}'", taxaParaExcluir.Nome, taxaParaExcluir.ID, ex);

                List<IError> erros = new();

                if (ex.Message.Contains("FK_TBTaxaEServicos_TBOBJETORELACAO"))
                    erros.Add(new CustomError("Essa Taxa e Serviço está relacionada à um ObjetoRelacao." +
                        " Primeiro exclua o ObjetoRelacao relacionado", "Taxa"));
                else
                    erros.Add(new CustomError("Falha ao tentar excluir a Taxa e Serviço", "Taxa"));

                return Result.Fail(erros);
            }
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
