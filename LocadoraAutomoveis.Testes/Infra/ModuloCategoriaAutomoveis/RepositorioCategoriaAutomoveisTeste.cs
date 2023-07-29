using FizzWare.NBuilder;
using FluentAssertions;
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

            _contexto.RemoveRange(_repositorioCategoriaAutomoveis.Registros);

            BuilderSetup.SetCreatePersistenceMethod<CategoriaAutomoveis>(_repositorioCategoriaAutomoveis.Adicionar);

            BuilderSetup.DisablePropertyNamingFor<CategoriaAutomoveis, int>(x => x.ID);
        }

        [TestMethod]
        public void Deve_adicionar_uma_disciplina()
        {
            //arrange/action
            var categoria = Builder<CategoriaAutomoveis>.CreateNew().Persist();

            //assert
            _repositorioCategoriaAutomoveis.SelecionarPorID(categoria.ID).Should().Be(categoria);
        }

        [TestMethod]
        public void Deve_editar_uma_disciplina()
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

        //[TestMethod]
        //public void Deve_excluir_uma_disciplina()
        //{
        //    var categoria1 = new Disciplina("Matemática") { Id = 1 };

        //    _repositorioDisciplina.Adicionar(disciplina1);

        //    var disciplinaSelecionada = _repositorioDisciplina.SelecionarPorId(1);

        //    _repositorioDisciplina.Excluir(disciplinaSelecionada);

        //    Assert.IsTrue(_repositorioDisciplina.ObterListaRegistros().Count == 0);
        //}

        //[TestMethod]
        //public void Deve_selecionar_por_ID_uma_disciplina()
        //{
        //    var disciplina = new Disciplina("Matemática") { Id = 1 };

        //    _repositorioDisciplina.Adicionar(disciplina);

        //    var disciplinaSelecionada = _repositorioDisciplina.SelecionarPorId(1);

        //    Assert.AreEqual(disciplinaSelecionada, disciplina);
        //}

        //[TestMethod]
        //public void Deve_selecionar_todas_as_disciplina()
        //{
        //    //arrange
        //    var disciplina1 = new Disciplina("Matemática") { Id = 1 };
        //    var disciplina2 = new Disciplina("Português") { Id = 2 };
        //    var disciplina3 = new Disciplina("Artes") { Id = 3 };
        //    var disciplina4 = new Disciplina("História") { Id = 4 };

        //    //action
        //    _repositorioDisciplina.Adicionar(disciplina1);
        //    _repositorioDisciplina.Adicionar(disciplina2);
        //    _repositorioDisciplina.Adicionar(disciplina3);
        //    _repositorioDisciplina.Adicionar(disciplina4);

        //    var listaDisciplinas = _repositorioDisciplina.ObterListaRegistros();

        //    //assert
        //    Assert.IsTrue(listaDisciplinas.Count == 4);
        //}
    }
}
