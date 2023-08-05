using FizzWare.NBuilder;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloPlanosCobrancas;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;
using LocadoraAutomoveis.Infraestrutura.Repositorios;

namespace LocadoraAutomoveis.Testes.Infra.ModuloPlanosCobrancas
{
    [TestClass]
    public class RepositorioPlanosCobrancasTeste
    {
        private RepositorioPlanosCobrancas _repositorioPlanosCobrancas;

        private ContextoDados _contexto;

        [TestInitialize]
        public void Setup()
        {
            _contexto = new LocadoraAutomoveisDesignFactory().CreateDbContext(null);

            _repositorioPlanosCobrancas = new RepositorioPlanosCobrancas(_contexto);

            _contexto.RemoveRange(_repositorioPlanosCobrancas.SelecionarTodos());

            BuilderSetup.SetCreatePersistenceMethod<PlanoCobranca>(_repositorioPlanosCobrancas.Inserir);
        }

        [TestMethod]
        public void Deve_adicionar_um_planoCobranca()
        {
            var categoria = Builder<CategoriaAutomoveis>.CreateNew().Build();
            var planoCobranca = Builder<PlanoCobranca>.CreateNew().With(c => c.CategoriaAutomoveis = categoria).Persist();

            _repositorioPlanosCobrancas.SelecionarPorID(planoCobranca.ID).Should().Be(planoCobranca);
        }

        [TestMethod]
        public void Deve_editar_um_planoCobranca()
        {
            var categoria = Builder<CategoriaAutomoveis>.CreateNew().Build();
            var planoCobranca1 = Builder<PlanoCobranca>.CreateNew().With(c => c.CategoriaAutomoveis = categoria).Persist();
            var planoCobranca2 = _repositorioPlanosCobrancas.SelecionarPorID(planoCobranca1.ID);
            planoCobranca2.ValorDia = 1;

            _repositorioPlanosCobrancas.Editar(planoCobranca2);

            var planoCobrancaSelecionado = _repositorioPlanosCobrancas.SelecionarPorID(planoCobranca1.ID);
            _repositorioPlanosCobrancas.SelecionarTodos().Should().HaveCount(1);
            planoCobrancaSelecionado.Should().Be(planoCobranca2);
        }

        [TestMethod]
        public void Deve_excluir_um_planoCobranca()
        {
            var categoria = Builder<CategoriaAutomoveis>.CreateNew().Build();
            var planoCobranca = Builder<PlanoCobranca>.CreateNew().With(c => c.CategoriaAutomoveis = categoria).Persist();
            var planoCobrancaSelecionado = _repositorioPlanosCobrancas.SelecionarPorID(planoCobranca.ID);

            _repositorioPlanosCobrancas.Excluir(planoCobrancaSelecionado);

            _repositorioPlanosCobrancas.SelecionarTodos().Should().HaveCount(0);
        }

        [TestMethod]
        public void Deve_selecionar_por_ID_um_planoCobranca()
        {
            var categoria = Builder<CategoriaAutomoveis>.CreateNew().Build();
            var planoCobranca = Builder<PlanoCobranca>.CreateNew().With(c => c.CategoriaAutomoveis = categoria).Persist();

            var planoCobrancaSelecionado = _repositorioPlanosCobrancas.SelecionarPorID(planoCobranca.ID);

            planoCobrancaSelecionado.Should().Be(planoCobranca);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_planosCobrancas()
        {
            var categoria = Builder<CategoriaAutomoveis>.CreateNew().Build();
            var planoCobranca1 = Builder<PlanoCobranca>.CreateNew().With(c => c.CategoriaAutomoveis = categoria).Persist();
            var planoCobranca2 = Builder<PlanoCobranca>.CreateNew().With(c => c.CategoriaAutomoveis = categoria).Persist();
            var planoCobranca3 = Builder<PlanoCobranca>.CreateNew().With(c => c.CategoriaAutomoveis = categoria).Persist();
            var planoCobranca4 = Builder<PlanoCobranca>.CreateNew().With(c => c.CategoriaAutomoveis = categoria).Persist();

            var listaPlanosCobrancas = _repositorioPlanosCobrancas.SelecionarTodos();

            listaPlanosCobrancas[0].Should().Be(planoCobranca1);
            listaPlanosCobrancas[3].Should().Be(planoCobranca4);
            listaPlanosCobrancas.Should().HaveCount(4);
        }
    }
}
