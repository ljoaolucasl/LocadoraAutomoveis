using LocadoraAutomoveis.Dominio.ModuloAluguel;
using LocadoraAutomoveis.Dominio.ModuloAutomovel;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Dominio.ModuloCondutores;
using LocadoraAutomoveis.Dominio.ModuloCupom;
using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using LocadoraAutomoveis.Dominio.ModuloPlanosCobrancas;
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
            Condutor condutor = new() { Validade = DateTime.Now.AddDays(1) };
            Automovel automovel = new() { Alugado = false };
            Cupom cupom = new();
            List<TaxaEServico> listTaxa = new() { new TaxaEServico() };
            DateTime dataLocacao = DateTime.Now;
            DateTime dataPrevista = dataLocacao.AddDays(1);
            DateTime dataDevolucao = dataLocacao.AddDays(2);
            decimal quilometrosRodados = 100;
            NivelTanque nivelTanque = NivelTanque.MeioTanque;
            decimal valorTotal = 1000;

            _aluguel = new Aluguel(funcionario, cliente, categoria, plano, condutor,
                automovel, cupom, listTaxa, dataLocacao, dataPrevista,
                dataDevolucao, quilometrosRodados, nivelTanque, valorTotal, true, TipoPlano.Diario);
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
        public void Nao_deve_aceitar_Condutor_validade_vencida()
        {
            //arrange
            _aluguel.Condutor.Validade = DateTime.Now.AddDays(-1);

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
        public void Nao_deve_aceitar_Automovel_ja_alugado()
        {
            //arrange
            _aluguel.Automovel.Alugado = true;

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
        public void Nao_deve_aceitar_dataDevolucao_maior_que_dataLocacao()
        {
            //arrange
            _aluguel.DataDevolucao = _aluguel.DataLocacao.AddDays(-1);

            //action
            ValidationResult resultado = _validador.Validate(_aluguel);

            //assert
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_quilometragem_menor_que_zero()
        {
            //arrange
            _aluguel.QuilometrosRodados = -1;

            //action
            ValidationResult resultado = _validador.Validate(_aluguel);

            //assert
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_CombustivelRestante_invalido()
        {
            //arrange
            _aluguel.CombustivelRestante = (NivelTanque)10;

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

        [TestMethod]
        public void Nao_deve_retornar_true_se_Aluguel_em_aberto()
        {
            //arrange
            _aluguel.Concluido = false;

            //action
            bool resultado = _validador.ValidarSeAluguelConcluido(_aluguel);

            //assert
            resultado.Should().BeFalse();
        }
    }
}
