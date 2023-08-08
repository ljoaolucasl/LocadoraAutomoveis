using FizzWare.NBuilder;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;
using LocadoraAutomoveis.Infraestrutura.Repositorios;

namespace LocadoraAutomoveis.Testes.Infra.ModuloCategoriaAutomoveis
{
    [TestClass]
    public class RepositorioCategoriaAutomoveisTeste
    {
        private RepositorioCategoriaAutomoveis _repositorioCategoriaAutomoveis;

        private ContextoDados _contexto;

        [TestInitialize]
        public void Setup()
        {
            _contexto = new LocadoraAutomoveisDesignFactory().CreateDbContext(null);

            _repositorioCategoriaAutomoveis = new RepositorioCategoriaAutomoveis(_contexto);

            _contexto.RemoveRange(new RepositorioAluguel(_contexto).SelecionarTodos());
            _contexto.RemoveRange(new RepositorioPlanosCobrancas(_contexto).SelecionarTodos());
            _contexto.RemoveRange(new RepositorioAutomovel(_contexto).SelecionarTodos());
            _contexto.RemoveRange(_repositorioCategoriaAutomoveis.SelecionarTodos());

            BuilderSetup.SetCreatePersistenceMethod<CategoriaAutomoveis>(_repositorioCategoriaAutomoveis.Inserir);
        }

        [TestMethod]
        public void Deve_adicionar_uma_categoria()
        {
            //arrange/action
            var categoria = Builder<CategoriaAutomoveis>.CreateNew().Persist();
            _contexto.SaveChanges();

            //assert
            _repositorioCategoriaAutomoveis.SelecionarPorID(categoria.ID).Should().Be(categoria);
        }

        [TestMethod]
        public void Deve_editar_uma_categoria()
        {
            //arrange
            var categoria1 = Builder<CategoriaAutomoveis>.CreateNew().Persist();
            var categoria2 = _repositorioCategoriaAutomoveis.SelecionarPorID(categoria1.ID);
            categoria2.Nome = "Esportivo";

            //action
            _repositorioCategoriaAutomoveis.Editar(categoria2);

            //assert
            var categoriaSelecionada = _repositorioCategoriaAutomoveis.SelecionarPorID(categoria1.ID);
            _repositorioCategoriaAutomoveis.SelecionarTodos().Count.Should().Be(1);
            categoriaSelecionada.Should().Be(categoria2);
        }

        [TestMethod]
        public void Deve_excluir_uma_categoria()
        {
            //arrange
            var categoria1 = Builder<CategoriaAutomoveis>.CreateNew().Persist();
            var categoriaSelecionada = _repositorioCategoriaAutomoveis.SelecionarPorID(categoria1.ID);

            //action
            _repositorioCategoriaAutomoveis.Excluir(categoriaSelecionada);

            //assert
            _repositorioCategoriaAutomoveis.SelecionarTodos().Count.Should().Be(0);
        }

        [TestMethod]
        public void Deve_selecionar_por_ID_uma_categoria()
        {
            //arrange
            var categoria1 = Builder<CategoriaAutomoveis>.CreateNew().Persist();

            //action
            var categoriaSelecionada = _repositorioCategoriaAutomoveis.SelecionarPorID(categoria1.ID);

            //assert
            categoriaSelecionada.Should().Be(categoria1);
        }

        [TestMethod]
        public void Deve_selecionar_todas_as_categorias()
        {
            //arrange
            var categoria1 = Builder<CategoriaAutomoveis>.CreateNew().Persist();
            var categoria2 = Builder<CategoriaAutomoveis>.CreateNew().Persist();
            var categoria3 = Builder<CategoriaAutomoveis>.CreateNew().Persist();
            var categoria4 = Builder<CategoriaAutomoveis>.CreateNew().Persist();

            //action
            var listaCategorias = _repositorioCategoriaAutomoveis.SelecionarTodos();

            //assert
            listaCategorias[0].Should().Be(categoria1);
            listaCategorias[3].Should().Be(categoria4);
            listaCategorias.Count.Should().Be(4);
        }

        [TestMethod]
        public void Deve_verificar_se_categoria_existe_validacao()
        {
            //arrange
            var categoria1 = Builder<CategoriaAutomoveis>.CreateNew().Persist();
            var categoria2 = new CategoriaAutomoveis(categoria1.Nome);

            //action
            bool resultado = _repositorioCategoriaAutomoveis.Existe(categoria2);

            //assert
            resultado.Should().BeTrue();
        }

        [TestMethod]
        public void Deve_permitir_se_categoria_com_nome_e_ID_iguais_validacao()
        {
            //arrange
            var categoria1 = Builder<CategoriaAutomoveis>.CreateNew().Persist();
            var categoria2 = new CategoriaAutomoveis(categoria1.Nome) { ID = categoria1.ID };

            //action
            bool resultado = _repositorioCategoriaAutomoveis.Existe(categoria2);

            //assert
            resultado.Should().BeFalse();
        }

        [TestMethod]
        public void Deve_verificar_se_categoria_existe_exclusao()
        {
            //arrange
            var categoria1 = Builder<CategoriaAutomoveis>.CreateNew().Persist();
            var categoria2 = _repositorioCategoriaAutomoveis.SelecionarPorID(categoria1.ID);

            //action
            bool resultado = _repositorioCategoriaAutomoveis.Existe(categoria2, true);

            //assert
            resultado.Should().BeTrue();
        }
    }
}
