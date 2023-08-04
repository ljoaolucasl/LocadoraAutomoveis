using LocadoraAutomoveis.Dominio.ModuloAluguel;
using LocadoraAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Dominio.ModuloCupom;
using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using LocadoraAutomoveis.Dominio.ModuloTaxaEServico;

namespace LocadoraAutomoveis.Testes.Dominio.ModuloAluguel
{
    [TestClass]
    public class AluguelTeste
    {
        private ValidadorAluguel _validador;
        private Aluguel _aluguel;

        [TestInitialize]
        public void Setup()
        {
            _validador = new ValidadorAluguel();

            Funcionario funcionario = new();
            Cliente cliente = new();
            CategoriaAutomoveis categoria = new();
            PlanoCobranca plano = new();
            Condutores condutor = new();
            Automovel automovel = new();
            Cupom cupom = new();
            List<TaxaEServico> listTaxa = new();
            DateTime dataLocacao = DateTime.Now;
            DateTime dataPrevista = dataLocacao.AddDays(1);
            decimal valorTotal = 1000;

            _aluguel = new Aluguel(funcionario, cliente, categoria, plano, condutor, automovel, cupom, listTaxa, dataLocacao, dataPrevista, valorTotal);
        }

        [TestMethod]
        public void Deve_aceitar_Aluguel_valida()
        {
            //action
            ValidationResult resultado = _validador.Validate(_aluguel);

            //assert
            resultado.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void Nao_deve_aceitar_Funcionario_nulo()
        {
            //arrange
            _aluguel.Funcionario = null;

            //action
            ValidationResult resultado = _validador.Validate(_aluguel);

            //assert
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_Cliente_nulo()
        {
            //arrange
            _aluguel.Cliente = null;

            //action
            ValidationResult resultado = _validador.Validate(_aluguel);

            //assert
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_Categoria_nulo()
        {
            //arrange
            _aluguel.CategoriaAutomoveis = null;

            //action
            ValidationResult resultado = _validador.Validate(_aluguel);

            //assert
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_Plano_nulo()
        {
            //arrange
            _aluguel.PlanoCobranca = null;

            //action
            ValidationResult resultado = _validador.Validate(_aluguel);

            //assert
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_Condutor_nulo()
        {
            //arrange
            _aluguel.Condutor = null;

            //action
            ValidationResult resultado = _validador.Validate(_aluguel);

            //assert
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_Automovel_nulo()
        {
            //arrange
            _aluguel.Automovel = null;

            //action
            ValidationResult resultado = _validador.Validate(_aluguel);

            //assert
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_Cupom_nulo()
        {
            //arrange
            _aluguel.Cupom = null;

            //action
            ValidationResult resultado = _validador.Validate(_aluguel);

            //assert
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_lista_Taxas_nula()
        {
            //arrange
            _aluguel.ListaTaxasEServicos = null;

            //action
            ValidationResult resultado = _validador.Validate(_aluguel);

            //assert
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_lista_Taxas_vazia()
        {
            //arrange
            _aluguel.ListaTaxasEServicos = new();

            //action
            ValidationResult resultado = _validador.Validate(_aluguel);

            //assert
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_dataLocacao_maior_que_dataPrevista()
        {
            //arrange
            _aluguel.DataLocacao = _aluguel.DataPrevistaRetorno.AddDays(1);

            //action
            ValidationResult resultado = _validador.Validate(_aluguel);

            //assert
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_dataPrevista_menor_que_dataLocacao()
        {
            //arrange
            _aluguel.DataPrevistaRetorno = _aluguel.DataLocacao.AddDays(-1);

            //action
            ValidationResult resultado = _validador.Validate(_aluguel);

            //assert
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_ValorTotal_menor_que_zero()
        {
            //arrange
            _aluguel.ValorTotal = -1;

            //action
            ValidationResult resultado = _validador.Validate(_aluguel);

            //assert
            resultado.IsValid.Should().BeFalse();
        }
    }
}
