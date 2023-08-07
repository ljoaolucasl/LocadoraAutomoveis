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

            _contexto.RemoveRange(new RepositorioAluguel(_contexto).SelecionarTodos());
            _contexto.RemoveRange(_repositorioFuncionarios.Registros);

            BuilderSetup.SetCreatePersistenceMethod<Funcionario>(_repositorioFuncionarios.Inserir);

            BuilderSetup.DisablePropertyNamingFor<Funcionario, Guid>(x => x.ID);
        }

        [TestMethod]
        public void Deve_adicionar_um_funcionario()
        {
            var funcionario = Builder<Funcionario>.CreateNew().Persist();

            _repositorioFuncionarios.SelecionarPorID(funcionario.ID).Should().Be(funcionario);
        }

        [TestMethod]
        public void Deve_editar_um_funcionario()
        {
            var funcionario1 = Builder<Funcionario>.CreateNew().Persist();
            var funcionario2 = _repositorioFuncionarios.SelecionarPorID(funcionario1.ID);
            funcionario2.Nome = "Felipe";
            funcionario2.Admissao = DateTime.Parse("12/08/2023");
            funcionario2.Salario = 1300;

            _repositorioFuncionarios.Editar(funcionario2);

            var funcionarioSelecionado = _repositorioFuncionarios.SelecionarPorID(funcionario1.ID);
            _repositorioFuncionarios.SelecionarTodos().Count.Should().Be(1);
            funcionarioSelecionado.Should().Be(funcionario2);
        }

        [TestMethod]
        public void Deve_excluir_um_funcionario()
        {
            var funcionario1 = Builder<Funcionario>.CreateNew().Persist();
            var funcionarioSelecionado = _repositorioFuncionarios.SelecionarPorID(funcionario1.ID);

            _repositorioFuncionarios.Excluir(funcionarioSelecionado);

            _repositorioFuncionarios.SelecionarTodos().Count.Should().Be(0);
        }

        [TestMethod]
        public void Deve_selecionar_por_ID_um_funcionario()
        {
            var funcionario1 = Builder<Funcionario>.CreateNew().Persist();

            var funcionarioSelecionado = _repositorioFuncionarios.SelecionarPorID(funcionario1.ID);

            funcionarioSelecionado.Should().Be(funcionario1);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_funcionarios()
        {
            var funcionario1 = Builder<Funcionario>.CreateNew().Persist();
            var funcionario2 = Builder<Funcionario>.CreateNew().Persist();
            var funcionario3 = Builder<Funcionario>.CreateNew().Persist();
            var funcionario4 = Builder<Funcionario>.CreateNew().Persist();

            var listaFuncionarios = _repositorioFuncionarios.SelecionarTodos();

            listaFuncionarios[0].Should().Be(funcionario1);
            listaFuncionarios[3].Should().Be(funcionario4);
            listaFuncionarios.Count.Should().Be(4);
        }

        [TestMethod]
        public void Deve_verificar_se_funcionario_existe_validacao()
        {
            var funcionario1 = Builder<Funcionario>.CreateNew().Persist();
            var funcionario2 = new Funcionario(funcionario1.Nome, Convert.ToDateTime("05/08/2023"), 500);

            bool resultado = _repositorioFuncionarios.Existe(funcionario2);

            resultado.Should().BeTrue();
        }

        [TestMethod]
        public void Deve_permitir_se_funcionario_com_nome_e_ID_iguais_validacao()
        {
            var funcionario1 = Builder<Funcionario>.CreateNew().Persist();
            var funcionario2 = new Funcionario(funcionario1.Nome, Convert.ToDateTime("05/08/2023"), 500) { ID = funcionario1.ID };

            bool resultado = _repositorioFuncionarios.Existe(funcionario2);

            resultado.Should().BeFalse();
        }

        [TestMethod]
        public void Deve_verificar_se_funcionario_existe_exclusao()
        {
            var funcionario1 = Builder<Funcionario>.CreateNew().Persist();
            var funcionario2 = _repositorioFuncionarios.SelecionarPorID(funcionario1.ID);

            bool resultado = _repositorioFuncionarios.Existe(funcionario2, true);

            resultado.Should().BeTrue();
        }
    }
}
