using FizzWare.NBuilder;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloParceiro;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;
using LocadoraAutomoveis.Infraestrutura.Repositorios;

namespace LocadoraAutomoveis.Testes.Infra.ModuloParceiro
{
    [TestClass]
    public class RepositorioParceiroTeste
    {
        private RepositorioParceiro _repositorioParceiro;
        private RepositorioCupom _repositorioCupom;

        private ContextoDados _contexto;

        [TestInitialize]
        public void Setup()
        {
            _contexto = new LocadoraAutomoveisDesignFactory().CreateDbContext(null);

            _repositorioParceiro = new RepositorioParceiro(_contexto);
            _repositorioCupom = new RepositorioCupom(_contexto);

            _contexto.RemoveRange(_repositorioCupom.Registros);
            _contexto.RemoveRange(_repositorioParceiro.Registros);

            BuilderSetup.SetCreatePersistenceMethod<Parceiro>(_repositorioParceiro.Inserir);
        }

        [TestMethod]
        public void Deve_adicionar_um_parceiro()
        {
            var parceiro = Builder<Parceiro>.CreateNew().Persist();

            _repositorioParceiro.SelecionarPorID(parceiro.ID).Should().Be(parceiro);
        }

        [TestMethod]
        public void Deve_editar_um_parceiro()
        {
            var parceiro1 = Builder<Parceiro>.CreateNew().Persist();
            var parceiro2 = _repositorioParceiro.SelecionarPorID(parceiro1.ID);
            parceiro2.Nome = "Academia do Programador";

            _repositorioParceiro.Editar(parceiro2);

            var parceiroSelecionado = _repositorioParceiro.SelecionarPorID(parceiro1.ID);
            _repositorioParceiro.SelecionarTodos().Count.Should().Be(1);
            parceiroSelecionado.Should().Be(parceiro2);
        }

        [TestMethod]
        public void Deve_excluir_um_parceiro()
        {
            var parceiro1 = Builder<Parceiro>.CreateNew().Persist();
            var parceiroSelecionado = _repositorioParceiro.SelecionarPorID(parceiro1.ID);

            _repositorioParceiro.Excluir(parceiroSelecionado);

            _repositorioParceiro.SelecionarTodos().Count.Should().Be(0);
        }

        [TestMethod]
        public void Deve_selecionar_por_ID_um_parceiro()
        {
            var parceiro1 = Builder<Parceiro>.CreateNew().Persist();

            var parceiroSelecionado = _repositorioParceiro.SelecionarPorID(parceiro1.ID);

            parceiroSelecionado.Should().Be(parceiro1);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_parceiros()
        {
            var parceiro1 = Builder<Parceiro>.CreateNew().Persist();
            var parceiro2 = Builder<Parceiro>.CreateNew().Persist();
            var parceiro3 = Builder<Parceiro>.CreateNew().Persist();
            var parceiro4 = Builder<Parceiro>.CreateNew().Persist();

            var listaParceiros = _repositorioParceiro.SelecionarTodos();

            listaParceiros[0].Should().Be(parceiro1);
            listaParceiros[3].Should().Be(parceiro4);
            listaParceiros.Count.Should().Be(4);
        }

        [TestMethod]
        public void Deve_verificar_se_parceiro_existe_validacao()
        {
            var parceiro1 = Builder<Parceiro>.CreateNew().Persist();
            var parceiro2 = new Parceiro(parceiro1.Nome);

            bool resultado = _repositorioParceiro.Existe(parceiro2);

            resultado.Should().BeTrue();
        }

        [TestMethod]
        public void Deve_permitir_se_parceiro_com_nome_e_ID_iguais_validacao()
        {
            var parceiro1 = Builder<Parceiro>.CreateNew().Persist();
            var parceiro2 = new Parceiro(parceiro1.Nome) { ID = parceiro1.ID };

            bool resultado = _repositorioParceiro.Existe(parceiro2);

            resultado.Should().BeFalse();
        }

        [TestMethod]
        public void Deve_verificar_se_parceiro_existe_exclusao()
        {
            var parceiro1 = Builder<Parceiro>.CreateNew().Persist();
            var parceiro2 = _repositorioParceiro.SelecionarPorID(parceiro1.ID);

            bool resultado = _repositorioParceiro.Existe(parceiro2, true);

            resultado.Should().BeTrue();
        }
    }
}
