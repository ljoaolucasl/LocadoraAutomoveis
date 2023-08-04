using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;
using LocadoraAutomoveis.Infraestrutura.Repositorios;

namespace LocadoraAutomoveis.Testes.Infra.ModuloCliente
{
    [TestClass]
    public class RepositorioClienteTeste
    {
        private RepositorioCliente _repositorioCliente;

        private ContextoDados _contexto;

        [TestInitialize]
        public void Setup()
        {
            _contexto = new LocadoraAutomoveisDesignFactory().CreateDbContext(null);

            _repositorioCliente = new RepositorioCliente(_contexto);

            _contexto.RemoveRange(_repositorioCliente.Registros);

            BuilderSetup.SetCreatePersistenceMethod<Cliente>(_repositorioCliente.Inserir);

            BuilderSetup.DisablePropertyNamingFor<Cliente, Guid>(x => x.ID);
        }

        [TestMethod]
        public void Deve_adicionar_um_cliente()
        {
            var cliente = Builder<Cliente>.CreateNew().Persist();

            _repositorioCliente.SelecionarPorID(cliente.ID).Should().Be(cliente);
        }

        [TestMethod]
        public void Deve_editar_um_cliente()
        {
            var cliente1 = Builder<Cliente>.CreateNew().Persist();
            var cliente2 = _repositorioCliente.SelecionarPorID(cliente1.ID);
            cliente2.Nome = "Marcos";
            cliente2.Email = "mateuszancheta@gmail.com";
            cliente2.Telefone = "(49) 92323-4423";
            cliente2.TipoCliente = TipoDocumento.CPF;
            cliente2.Documento = "234.423.563-45";
            cliente2.Estado = "Santa Catarina";
            cliente2.Cidade = "Lages";
            cliente2.Bairro = "São Cristovão";
            cliente2.Rua = "Rio de Janeiro";
            cliente2.Numero = 12;

            _repositorioCliente.Editar(cliente2);

            var funcionarioSelecionado = _repositorioCliente.SelecionarPorID(cliente1.ID);
            _repositorioCliente.SelecionarTodos().Count.Should().Be(1);
            funcionarioSelecionado.Should().Be(cliente2);
        }

        [TestMethod]
        public void Deve_excluir_um_cliente()
        {
            var cliente1 = Builder<Cliente>.CreateNew().Persist();
            var clienteSelecionado = _repositorioCliente.SelecionarPorID(cliente1.ID);

            _repositorioCliente.Excluir(clienteSelecionado);

            _repositorioCliente.SelecionarTodos().Count.Should().Be(0);
        }

        [TestMethod]
        public void Deve_selecionar_por_ID_um_cliente()
        {
            var cliente1 = Builder<Cliente>.CreateNew().Persist();

            var clienteSelecionado = _repositorioCliente.SelecionarPorID(cliente1.ID);

            clienteSelecionado.Should().Be(cliente1);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_clientes()
        {
            //arrange
            var cliente1 = Builder<Cliente>.CreateNew().Persist();
            var cliente2 = Builder<Cliente>.CreateNew().Persist();
            var cliente3 = Builder<Cliente>.CreateNew().Persist();
            var cliente4 = Builder<Cliente>.CreateNew().Persist();

            //action
            var listaClientes = _repositorioCliente.SelecionarTodos();

            //assert
            listaClientes[0].Should().Be(cliente1);
            listaClientes[3].Should().Be(cliente4);
            listaClientes.Count.Should().Be(4);
        }

        [TestMethod]
        public void Deve_verificar_se_cliente_existe_validacao()
        {
            var cliente1 = Builder<Cliente>.CreateNew().Persist();
            var cliente2 = new Cliente(cliente1.Nome, cliente1.Email, cliente1.Telefone, 
                cliente1.TipoCliente, cliente1.Documento, cliente1.Estado, cliente1.Cidade,
                cliente1.Bairro, cliente1.Rua, cliente1.Numero);

            bool resultado = _repositorioCliente.Existe(cliente2);

            resultado.Should().BeTrue();
        }

        [TestMethod]
        public void Deve_permitir_se_cliente_com_nome_e_ID_iguais_validacao()
        {
            var cliente1 = Builder<Cliente>.CreateNew().Persist();
            var cliente2 = new Cliente(cliente1.Nome, cliente1.Email, cliente1.Telefone,
                cliente1.TipoCliente, cliente1.Documento, cliente1.Estado, cliente1.Cidade,
                cliente1.Bairro, cliente1.Rua, cliente1.Numero) { ID = cliente1.ID };

            bool resultado = _repositorioCliente.Existe(cliente2);

            resultado.Should().BeFalse();
        }

        [TestMethod]
        public void Deve_verificar_se_cliente_existe_exclusao()
        {
            var cliente1 = Builder<Cliente>.CreateNew().Persist();
            var cliente2 = _repositorioCliente.SelecionarPorID(cliente1.ID);

            bool resultado = _repositorioCliente.Existe(cliente2, true);

            resultado.Should().BeTrue();
        }
    }
}
