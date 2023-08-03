using FizzWare.NBuilder;
using LocadoraAutomoveis.Dominio.ModuloCupom;
using LocadoraAutomoveis.Dominio.ModuloParceiro;
using LocadoraAutomoveis.Dominio.ModuloTaxaEServico;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;
using LocadoraAutomoveis.Infraestrutura.Repositorios;

namespace LocadoraAutomoveis.Testes.Infra.ModuloCupom
{
    [TestClass]
    public class RepositorioCupomTeste
    {
        private RepositorioCupom _repositorioCupom;

        private ContextoDados _contexto;

        [TestInitialize]
        public void Setup()
        {
            _contexto = new LocadoraAutomoveisDesignFactory().CreateDbContext(null);

            _repositorioCupom = new RepositorioCupom(_contexto);

            _contexto.RemoveRange(_repositorioCupom.Registros);

            BuilderSetup.SetCreatePersistenceMethod<Cupom>(_repositorioCupom.Inserir);

            BuilderSetup.DisablePropertyNamingFor<Cupom, Guid>(x => x.ID);
        }

        [TestMethod]
        public void Deve_adicionar_um_cupom()
        {
            var cupom = Builder<Cupom>.CreateNew().Persist();

            _repositorioCupom.SelecionarPorID(cupom.ID).Should().Be(cupom);
        }

        [TestMethod]
        public void Deve_editar_um_cupom()
        {
            var cupom1 = Builder<Cupom>.CreateNew().Persist();
            var cupom2 = _repositorioCupom.SelecionarPorID(cupom1.ID);
            cupom2.Nome = "Cupom";

            _repositorioCupom.Editar(cupom2);

            var cupomSelecionado = _repositorioCupom.SelecionarPorID(cupom1.ID);
            _repositorioCupom.SelecionarTodos().Count.Should().Be(1);
            cupomSelecionado.Should().Be(cupom2);
        }

        [TestMethod]
        public void Deve_excluir_um_cupom()
        {
            var cupom = Builder<Cupom>.CreateNew().Persist();
            var cupomSelecionado = _repositorioCupom.SelecionarPorID(cupom.ID);

            _repositorioCupom.Excluir(cupomSelecionado);

            _repositorioCupom.SelecionarTodos().Count.Should().Be(0);
        }

        [TestMethod]
        public void Deve_selecionar_por_ID_um_cupom()
        {
            var cupom = Builder<Cupom>.CreateNew().Persist();

            var cupomSelecionado = _repositorioCupom.SelecionarPorID(cupom.ID);

            cupomSelecionado.Should().Be(cupom);
        }

        [TestMethod]
        public void Deve_selecionar_todos_cupons()
        {
            var cupom1 = Builder<Cupom>.CreateNew().Persist();
            var cupom2 = Builder<Cupom>.CreateNew().Persist();
            var cupom3 = Builder<Cupom>.CreateNew().Persist();
            var cupom4 = Builder<Cupom>.CreateNew().Persist();

            var listaCupons = _repositorioCupom.SelecionarTodos();

            listaCupons[0].Should().Be(cupom1);
            listaCupons[3].Should().Be(cupom4);
            listaCupons.Count.Should().Be(4);
        }

        [TestMethod]
        public void Deve_verificar_se_cupom_existe_validacao()
        {
            var cupom1 = Builder<Cupom>.CreateNew().Persist();
            var cupom2 = new Cupom(cupom1.Nome, 12, DateTime.Now, new Parceiro("Teste"));

            bool resultado = _repositorioCupom.Existe(cupom2);

            resultado.Should().BeTrue();
        }

        [TestMethod]
        public void Deve_permitir_se_cupom_com_nome_e_ID_iguais_validacao()
        {
            var cupom1 = Builder<TaxaEServico>.CreateNew().Persist();
            var cupom2 = new Cupom(cupom1.Nome, 12, DateTime.Now, new Parceiro("Teste")) { ID = cupom1.ID };

            bool resultado = _repositorioCupom.Existe(cupom2);

            resultado.Should().BeFalse();
        }

        [TestMethod]
        public void Deve_verificar_se_cupom_existe_exclusao()
        {
            var cupom1 = Builder<Cupom>.CreateNew().Persist();
            var cupom2 = _repositorioCupom.SelecionarPorID(cupom1.ID);

            bool resultado = _repositorioCupom.Existe(cupom2, true);

            resultado.Should().BeTrue();
        }
    }
}
