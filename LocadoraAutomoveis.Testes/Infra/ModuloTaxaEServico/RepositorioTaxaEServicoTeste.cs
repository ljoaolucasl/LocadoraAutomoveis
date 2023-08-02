using FizzWare.NBuilder;
using LocadoraAutomoveis.Dominio.ModuloTaxaEServico;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;
using LocadoraAutomoveis.Infraestrutura.Repositorios;

namespace LocadoraAutomoveis.Testes.Infra.ModuloTaxaEServico
{
    [TestClass]
    public class RepositorioTaxaEServicoTeste
    {
        private RepositorioTaxaEServico _repositorioTaxaEServico;

        private ContextoDados _contexto;

        [TestInitialize]
        public void Setup()
        {
            _contexto = new LocadoraAutomoveisDesignFactory().CreateDbContext(null);

            _repositorioTaxaEServico = new RepositorioTaxaEServico(_contexto);

            _contexto.RemoveRange(_repositorioTaxaEServico.Registros);

            BuilderSetup.SetCreatePersistenceMethod<TaxaEServico>(_repositorioTaxaEServico.Inserir);

            BuilderSetup.DisablePropertyNamingFor<TaxaEServico, Guid>(x => x.ID);
        }

        [TestMethod]
        public void Deve_adicionar_uma_taxa_e_servico()
        {
            //arrange/action
            var taxa = Builder<TaxaEServico>.CreateNew().Persist();

            //assert
            _repositorioTaxaEServico.SelecionarPorID(taxa.ID).Should().Be(taxa);
        }

        [TestMethod]
        public void Deve_editar_uma_taxa_e_servico()
        {
            //arrange
            var taxa1 = Builder<TaxaEServico>.CreateNew().Persist();
            var taxa2 = _repositorioTaxaEServico.SelecionarPorID(taxa1.ID);
            taxa2.Nome = "Esportivo";

            //action
            _repositorioTaxaEServico.Editar(taxa2);

            //assert
            var taxaSelecionada = _repositorioTaxaEServico.SelecionarPorID(taxa1.ID);
            _repositorioTaxaEServico.SelecionarTodos().Count.Should().Be(1);
            taxaSelecionada.Should().Be(taxa2);
        }

        [TestMethod]
        public void Deve_excluir_uma_taxa_e_servico()
        {
            //arrange
            var taxa1 = Builder<TaxaEServico>.CreateNew().Persist();
            var taxaSelecionada = _repositorioTaxaEServico.SelecionarPorID(taxa1.ID);

            //action
            _repositorioTaxaEServico.Excluir(taxaSelecionada);

            //assert
            _repositorioTaxaEServico.SelecionarTodos().Count.Should().Be(0);
        }

        [TestMethod]
        public void Deve_selecionar_por_ID_uma_taxa_e_servico()
        {
            //arrange
            var taxa1 = Builder<TaxaEServico>.CreateNew().Persist();

            //action
            var taxaSelecionada = _repositorioTaxaEServico.SelecionarPorID(taxa1.ID);

            //assert
            taxaSelecionada.Should().Be(taxa1);
        }

        [TestMethod]
        public void Deve_selecionar_todas_as_taxa_e_servicos()
        {
            //arrange
            var taxa1 = Builder<TaxaEServico>.CreateNew().Persist();
            var taxa2 = Builder<TaxaEServico>.CreateNew().Persist();
            var taxa3 = Builder<TaxaEServico>.CreateNew().Persist();
            var taxa4 = Builder<TaxaEServico>.CreateNew().Persist();

            //action
            var listaTaxas = _repositorioTaxaEServico.SelecionarTodos();

            //assert
            listaTaxas[0].Should().Be(taxa1);
            listaTaxas[3].Should().Be(taxa4);
            listaTaxas.Count.Should().Be(4);
        }

        [TestMethod]
        public void Deve_verificar_se_taxa_e_servico_existe_validacao()
        {
            //arrange
            var taxa1 = Builder<TaxaEServico>.CreateNew().Persist();
            var taxa2 = new TaxaEServico(taxa1.Nome, 10, Tipo.Diario);

            //action
            bool resultado = _repositorioTaxaEServico.Existe(taxa2);

            //assert
            resultado.Should().BeTrue();
        }

        [TestMethod]
        public void Deve_permitir_se_taxa_e_servico_com_nome_e_ID_iguais_validacao()
        {
            //arrange
            var taxa1 = Builder<TaxaEServico>.CreateNew().Persist();
            var taxa2 = new TaxaEServico(taxa1.Nome, 10, Tipo.Diario) { ID = taxa1.ID };

            //action
            bool resultado = _repositorioTaxaEServico.Existe(taxa2);

            //assert
            resultado.Should().BeFalse();
        }

        [TestMethod]
        public void Deve_verificar_se_taxa_e_servico_existe_exclusao()
        {
            //arrange
            var taxa1 = Builder<TaxaEServico>.CreateNew().Persist();
            var taxa2 = _repositorioTaxaEServico.SelecionarPorID(taxa1.ID);

            //action
            bool resultado = _repositorioTaxaEServico.Existe(taxa2, true);

            //assert
            resultado.Should().BeTrue();
        }
    }
}
