using FizzWare.NBuilder;
using LocadoraAutomoveis.Dominio.ModuloAutomovel;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Dominio.ModuloCondutores;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;
using LocadoraAutomoveis.Infraestrutura.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Testes.Infra.ModuloCondutores
{
    [TestClass]
    public class RepositorioCondutoresTeste
    {
        private RepositorioCondutores _repositorioCondutores;
        private RepositorioCliente _repositorioClientes;

        private ContextoDados _contexto;

        [TestInitialize]
        public void Setup()
        {
            _contexto = new LocadoraAutomoveisDesignFactory().CreateDbContext(null);

            _repositorioCondutores = new RepositorioCondutores(_contexto);
            _repositorioClientes = new RepositorioCliente(_contexto);

            _contexto.RemoveRange(new RepositorioAluguel(_contexto).SelecionarTodos());
            _contexto.RemoveRange(_repositorioCondutores.Registros);
            _contexto.RemoveRange(_repositorioClientes.Registros);

            BuilderSetup.SetCreatePersistenceMethod<Condutor>(_repositorioCondutores.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<Cliente>(_repositorioClientes.Inserir);
        }

        [TestMethod]
        public void Deve_adicionar_um_condutor()
        {
            var cliente = Builder<Cliente>.CreateNew().Build();
            var condutor = Builder<Condutor>.CreateNew().With(c => c.Cliente = cliente).Persist();
            _contexto.SaveChanges();

            _repositorioCondutores.SelecionarPorID(condutor.ID).Should().Be(condutor);
        }

        [TestMethod]
        public void Deve_editar_um_condutor()
        {
            var cliente1 = Builder<Cliente>.CreateNew().Build();
            var condutor1 = Builder<Condutor>.CreateNew().With(c => c.Cliente = cliente1).Persist();
            _contexto.SaveChanges();
            var condutor2 = _repositorioCondutores.SelecionarPorID(condutor1.ID);
            condutor2.Nome = "Felipe";

            _repositorioCondutores.Editar(condutor2);
            _contexto.SaveChanges();

            var condutorSelecionado = _repositorioCondutores.SelecionarPorID(condutor1.ID);
            _repositorioCondutores.SelecionarTodos().Should().HaveCount(1);
            condutorSelecionado.Should().Be(condutor2);
        }

        [TestMethod]
        public void Deve_excluir_um_condutor()
        {
            var cliente1 = Builder<Cliente>.CreateNew().Build();
            var condutor1 = Builder<Condutor>.CreateNew().With(c => c.Cliente = cliente1).Persist();
            _contexto.SaveChanges();
            var disciplinaSelecionada = _repositorioCondutores.SelecionarPorID(condutor1.ID);

            _repositorioCondutores.Excluir(disciplinaSelecionada);
            _contexto.SaveChanges();

            _repositorioCondutores.SelecionarTodos().Should().HaveCount(0);
        }

        [TestMethod]
        public void Deve_selecionar_por_ID_um_condutor()
        {
            var cliente1 = Builder<Cliente>.CreateNew().Build();
            var condutor1 = Builder<Condutor>.CreateNew().With(c => c.Cliente = cliente1).Persist();
            _contexto.SaveChanges();

            var condutorSelecionado = _repositorioCondutores.SelecionarPorID(condutor1.ID);

            condutorSelecionado.Should().Be(condutor1);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_condutores()
        {
            var cliente1 = Builder<Cliente>.CreateNew().Build();
            var condutor1 = Builder<Condutor>.CreateNew().With(c => c.Cliente = cliente1).Persist();
            _contexto.SaveChanges();
            var condutor2 = Builder<Condutor>.CreateNew().With(c => c.Cliente = cliente1).Persist();
            _contexto.SaveChanges();
            var condutor3 = Builder<Condutor>.CreateNew().With(c => c.Cliente = cliente1).Persist();
            _contexto.SaveChanges();
            var condutor4 = Builder<Condutor>.CreateNew().With(c => c.Cliente = cliente1).Persist();
            _contexto.SaveChanges();

            var listaCondutores = _repositorioCondutores.SelecionarTodos();

            listaCondutores[0].Should().Be(condutor1);
            listaCondutores[3].Should().Be(condutor4);
            listaCondutores.Should().HaveCount(4);
        }

        [TestMethod]
        public void Deve_retornar_true_se_condutor_existe_validacao()
        {
            var cliente1 = Builder<Cliente>.CreateNew().Build();
            var condutor1 = Builder<Condutor>.CreateNew().With(c => c.Cliente = cliente1).Persist();
            _contexto.SaveChanges();
            var condutor2 = new Condutor(condutor1.Cliente, condutor1.TipoCondutor, condutor1.Nome, condutor1.Email, condutor1.Telefone, condutor1.CPF, condutor1.CNH,
                condutor1.Validade);

            bool resultado = _repositorioCondutores.Existe(condutor2);

            resultado.Should().BeTrue();
        }

        [TestMethod]
        public void Deve_retornar_false_se_condutor_equals_e_ID_igual_validacao()
        {
            var cliente1 = Builder<Cliente>.CreateNew().Build();
            var condutor1 = Builder<Condutor>.CreateNew().With(c => c.Cliente = cliente1).Persist();
            _contexto.SaveChanges();
            var condutor2 = _repositorioCondutores.SelecionarPorID(condutor1.ID);

            bool resultado = _repositorioCondutores.Existe(condutor2);

            resultado.Should().BeFalse();
        }

        [TestMethod]
        public void Deve_verificar_se_condutor_existe_exclusao()
        {
            var cliente1 = Builder<Cliente>.CreateNew().Build();
            var condutor1 = Builder<Condutor>.CreateNew().With(c => c.Cliente = cliente1).Persist();
            _contexto.SaveChanges();
            var condutor2 = _repositorioCondutores.SelecionarPorID(condutor1.ID);

            bool resultado = _repositorioCondutores.Existe(condutor2, true);

            resultado.Should().BeTrue();
        }


        [TestMethod]
        public void Nao_deve_aceitar_condutor_com_o_mesmo_cliente()
        {
            var cliente1 = Builder<Cliente>.CreateNew().Build();
            var condutor1 = Builder<Condutor>.CreateNew().With(c => c.Cliente = cliente1).Persist();
            _contexto.SaveChanges();
            var condutor2 = _repositorioCondutores.SelecionarPorID(condutor1.ID);

            bool resultado = _repositorioCondutores.Existe(condutor2);

            resultado.Should().BeFalse();
        }
    }
}
