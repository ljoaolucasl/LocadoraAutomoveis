using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;
using LocadoraAutomoveis.Infraestrutura.Repositorios;

namespace LocadoraAutomoveis.Testes.Infra.ModuloFuncionario
{
    [TestClass]
    public class RepositorioFuncionarioTeste
    {
        private RepositorioFuncionario _repositorioFuncionarios;

        private ContextoDados _contexto;

        [TestInitialize]
        public void Setup()
        {
            _contexto = new LocadoraAutomoveisDesignFactory().CreateDbContext(null);

            _repositorioFuncionarios = new RepositorioFuncionario(_contexto);

            _contexto.RemoveRange(_repositorioFuncionarios.Registros);

            BuilderSetup.SetCreatePersistenceMethod<Funcionario>(_repositorioFuncionarios.Inserir);

            BuilderSetup.DisablePropertyNamingFor<Funcionario, Guid>(x => x.ID);
        }

        [TestMethod]
        public void Deve_adicionar_um_funcionario()
        {
            //arrange/action
            var funcionario = Builder<Funcionario>.CreateNew().Persist();

            //assert
            _repositorioFuncionarios.SelecionarPorID(funcionario.ID).Should().Be(funcionario);
        }

        [TestMethod]
        public void Deve_editar_um_funcionario()
        {
            //arrange
            var funcionario1 = Builder<Funcionario>.CreateNew().Persist();
            var funcionario2 = _repositorioFuncionarios.SelecionarPorID(funcionario1.ID);
            funcionario2.Nome = "Felipe";
            funcionario2.Admissao = DateTime.Parse("12/08/2023");
            funcionario2.Salario = 1300;

            //action
            _repositorioFuncionarios.Editar(funcionario2);

            //assert
            var categoriaSelecionada = _repositorioFuncionarios.SelecionarPorID(funcionario1.ID);
            _repositorioFuncionarios.SelecionarTodos().Count.Should().Be(1);
            categoriaSelecionada.Should().Be(funcionario2);
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
