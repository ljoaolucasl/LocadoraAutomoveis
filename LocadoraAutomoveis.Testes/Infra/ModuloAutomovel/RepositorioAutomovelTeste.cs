using FizzWare.NBuilder;
using LocadoraAutomoveis.Dominio.ModuloAutomovel;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;
using LocadoraAutomoveis.Infraestrutura.Repositorios;

namespace LocadoraAutomoveis.Testes.Infra.ModuloAutomovel
{
    [TestClass]
    public class RepositorioAutomovelTeste
    {
        private RepositorioAutomovel _repositorioAutomovel;

        private ContextoDados _contexto;

        [TestInitialize]
        public void Setup()
        {
            _contexto = new LocadoraAutomoveisDesignFactory().CreateDbContext(null);

            _repositorioAutomovel = new RepositorioAutomovel(_contexto);

            _contexto.RemoveRange(new RepositorioAluguel(_contexto).SelecionarTodos());
            _contexto.RemoveRange(_repositorioAutomovel.SelecionarTodos());

            BuilderSetup.SetCreatePersistenceMethod<Automovel>(_repositorioAutomovel.Inserir);
        }

        [TestMethod]
        public void Deve_adicionar_um_automovel()
        {
            //arrange/action
            var categoria1 = Builder<CategoriaAutomoveis>.CreateNew().Build();
            var automovel = Builder<Automovel>.CreateNew().With(c => c.Categoria = categoria1).With(c => c.Imagem = new byte[12]).Persist();
            _contexto.SaveChanges();

            //assert
            _repositorioAutomovel.SelecionarPorID(automovel.ID).Should().Be(automovel);
        }

        [TestMethod]
        public void Deve_editar_um_automovel()
        {
            //arrange
            var categoria1 = Builder<CategoriaAutomoveis>.CreateNew().Build();
            var automovel1 = Builder<Automovel>.CreateNew().With(c => c.Categoria = categoria1).With(c => c.Imagem = new byte[12]).Persist();
            _contexto.SaveChanges();
            var automovel2 = _repositorioAutomovel.SelecionarPorID(automovel1.ID);
            automovel2.Modelo = "Esportivo";

            //action
            _repositorioAutomovel.Editar(automovel2);
            _contexto.SaveChanges();

            //assert
            var automovelSelecionado = _repositorioAutomovel.SelecionarPorID(automovel1.ID);
            _repositorioAutomovel.SelecionarTodos().Should().HaveCount(1);
            automovelSelecionado.Should().Be(automovel2);
        }

        [TestMethod]
        public void Deve_excluir_um_automovel()
        {
            //arrange
            var categoria1 = Builder<CategoriaAutomoveis>.CreateNew().Build();
            var automovel1 = Builder<Automovel>.CreateNew().With(c => c.Categoria = categoria1).With(c => c.Imagem = new byte[12]).Persist();
            _contexto.SaveChanges();
            var automovelSelecionada = _repositorioAutomovel.SelecionarPorID(automovel1.ID);

            //action
            _repositorioAutomovel.Excluir(automovelSelecionada);
            _contexto.SaveChanges();

            //assert
            _repositorioAutomovel.SelecionarTodos().Should().HaveCount(0);
        }

        [TestMethod]
        public void Deve_selecionar_por_ID_um_automovel()
        {
            //arrange
            var categoria1 = Builder<CategoriaAutomoveis>.CreateNew().Build();
            var automovel1 = Builder<Automovel>.CreateNew().With(c => c.Categoria = categoria1).With(c => c.Imagem = new byte[12]).Persist();
            _contexto.SaveChanges();

            //action
            var automovelSelecionada = _repositorioAutomovel.SelecionarPorID(automovel1.ID);

            //assert
            automovelSelecionada.Should().Be(automovel1);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_automoveis()
        {
            //arrange
            var categoria1 = Builder<CategoriaAutomoveis>.CreateNew().Build();
            var automovel1 = Builder<Automovel>.CreateNew().With(c => c.Categoria = categoria1).With(c => c.Imagem = new byte[12]).Persist();
            var automovel2 = Builder<Automovel>.CreateNew().With(c => c.Categoria = categoria1).With(c => c.Imagem = new byte[12]).Persist();
            var automovel3 = Builder<Automovel>.CreateNew().With(c => c.Categoria = categoria1).With(c => c.Imagem = new byte[12]).Persist();
            var automovel4 = Builder<Automovel>.CreateNew().With(c => c.Categoria = categoria1).With(c => c.Imagem = new byte[12]).Persist();
            _contexto.SaveChanges();

            //action
            var listaautomovels = _repositorioAutomovel.SelecionarTodos();

            //assert
            listaautomovels[0].Should().Be(automovel1);
            listaautomovels[3].Should().Be(automovel4);
            listaautomovels.Should().HaveCount(4);
        }

        [TestMethod]
        public void Deve_selecionar_os_automoveis_por_categoria()
        {
            //arrange
            var categoria1 = Builder<CategoriaAutomoveis>.CreateNew().Build();
            var categoria2 = Builder<CategoriaAutomoveis>.CreateNew().Build();
            var automovel1 = Builder<Automovel>.CreateNew().With(c => c.Categoria = categoria1).With(c => c.Imagem = new byte[12]).Persist();
            var automovel2 = Builder<Automovel>.CreateNew().With(c => c.Categoria = categoria2).With(c => c.Imagem = new byte[12]).Persist();
            var automovel3 = Builder<Automovel>.CreateNew().With(c => c.Categoria = categoria1).With(c => c.Imagem = new byte[12]).Persist();
            var automovel4 = Builder<Automovel>.CreateNew().With(c => c.Categoria = categoria2).With(c => c.Imagem = new byte[12]).Persist();
            _contexto.SaveChanges();

            //action
            var listaAutomoveis = _repositorioAutomovel.SelecionarPorCategoria(categoria2);

            //assert
            listaAutomoveis[0].Should().Be(automovel2);
            listaAutomoveis[1].Should().Be(automovel4);
            listaAutomoveis.Should().HaveCount(2);
        }

        [TestMethod]
        public void Deve_retornar_true_se_automovel_existe_validacao()
        {
            //arrange
            var categoria1 = Builder<CategoriaAutomoveis>.CreateNew().Build();
            var automovel1 = Builder<Automovel>.CreateNew().With(c => c.Categoria = categoria1).With(c => c.Imagem = new byte[12]).Persist();
            var automovel2 = new Automovel(automovel1.Categoria, automovel1.Placa, automovel1.Marca, automovel1.Cor, automovel1.Modelo, automovel1.Imagem,
                automovel1.TipoCombustivel, automovel1.CapacidadeCombustivel, automovel1.Ano, automovel1.Quilometragem, false);
            _contexto.SaveChanges();

            //action
            bool resultado = _repositorioAutomovel.Existe(automovel2);

            //assert
            resultado.Should().BeTrue();
        }

        [TestMethod]
        public void Deve_retornar_false_se_automovel_equals_e_ID_igual_validacao()
        {
            //arrange
            var categoria1 = Builder<CategoriaAutomoveis>.CreateNew().Build();
            var automovel1 = Builder<Automovel>.CreateNew().With(c => c.Categoria = categoria1).With(c => c.Imagem = new byte[12]).Persist();
            var automovel2 = _repositorioAutomovel.SelecionarPorID(automovel1.ID);
            _contexto.SaveChanges();

            //action
            bool resultado = _repositorioAutomovel.Existe(automovel2);

            //assert
            resultado.Should().BeFalse();
        }

        [TestMethod]
        public void Deve_verificar_se_automovel_existe_exclusao()
        {
            //arrange
            var categoria1 = Builder<CategoriaAutomoveis>.CreateNew().Build();
            var automovel1 = Builder<Automovel>.CreateNew().With(c => c.Categoria = categoria1).With(c => c.Imagem = new byte[12]).Persist();
            _contexto.SaveChanges();
            var automovel2 = _repositorioAutomovel.SelecionarPorID(automovel1.ID);

            //action
            bool resultado = _repositorioAutomovel.Existe(automovel2, true);

            //assert
            resultado.Should().BeTrue();
        }
    }
}
