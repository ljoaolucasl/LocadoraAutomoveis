using LocadoraAutomoveis.Dominio.ModuloAluguel;
using LocadoraAutomoveis.Dominio.ModuloAutomovel;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Dominio.ModuloCondutores;
using LocadoraAutomoveis.Dominio.ModuloConfiguracao;
using LocadoraAutomoveis.Dominio.ModuloCupom;
using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using LocadoraAutomoveis.Dominio.ModuloPlanosCobrancas;
using LocadoraAutomoveis.Dominio.ModuloTaxaEServico;

namespace LocadoraAutomoveis.Testes.Dominio.ModuloAluguel
{
    [TestClass]
    public class CalculoAluguelTeste
    {
        private Aluguel _aluguel;
        private CalculoAluguel _calculoAluguel;

        [TestInitialize]
        public void Setup()
        {
            _calculoAluguel = new CalculoAluguel();

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

        #region Devolucao
        [TestMethod]
        public void Deve_calcular_valor_total_devolucao_plano_controlador()
        {
            //arrange
            _aluguel.DataPrevistaRetorno = new DateTime(2023, 8, 20);
            _aluguel.DataLocacao = new DateTime(2023, 8, 10);
            _aluguel.DataDevolucao = new DateTime(2023, 8, 30);

            _aluguel.Automovel.Quilometragem = 100;
            _aluguel.Automovel.CapacidadeCombustivel = 10;
            _aluguel.Automovel.TipoCombustivel = TipoCombustível.Gasolina;

            _aluguel.CombustivelRestante = NivelTanque.MeioTanque;

            _aluguel.QuilometrosRodados = 50;
            _aluguel.ListaTaxasEServicos = new List<TaxaEServico>() { new TaxaEServico() { Valor = 10 }, new TaxaEServico() { Valor = 10 }, new TaxaEServico() { Valor = 10 } };
            _aluguel.PlanoCobranca = new PlanoCobranca(10, 10, 10, 10, 10, 10, _aluguel.CategoriaAutomoveis);
            _aluguel.Plano = TipoPlano.Controlador;

            _aluguel.Cupom = new Cupom() { Valor = 10 };

            PrecoCombustivel precos = new()
            {
                Gasolina = 5,
                Diesel = 5,
                Etanol = 5,
                Gas = 5
            };

            //action
            decimal resultado = _calculoAluguel.CalcularValorTotalDevolucao(_aluguel, precos);

            //assert
            decimal valorEsperado = 1099.5m;
            Assert.AreEqual(valorEsperado, resultado);
        }

        [TestMethod]
        public void Deve_calcular_valor_total_devolucao_plano_livre()
        {
            //arrange
            _aluguel.DataPrevistaRetorno = new DateTime(2023, 8, 20);
            _aluguel.DataLocacao = new DateTime(2023, 8, 10);
            _aluguel.DataDevolucao = new DateTime(2023, 8, 30);

            _aluguel.Automovel.Quilometragem = 100;
            _aluguel.Automovel.CapacidadeCombustivel = 10;
            _aluguel.Automovel.TipoCombustivel = TipoCombustível.Gasolina;

            _aluguel.CombustivelRestante = NivelTanque.MeioTanque;

            _aluguel.QuilometrosRodados = 50;
            _aluguel.ListaTaxasEServicos = new List<TaxaEServico>() { new TaxaEServico() { Valor = 10 }, new TaxaEServico() { Valor = 10 }, new TaxaEServico() { Valor = 10 } };
            _aluguel.PlanoCobranca = new PlanoCobranca(10, 10, 10, 10, 10, 10, _aluguel.CategoriaAutomoveis);
            _aluguel.Plano = TipoPlano.Livre;

            _aluguel.Cupom = new Cupom() { Valor = 10 };

            PrecoCombustivel precos = new()
            {
                Gasolina = 5,
                Diesel = 5,
                Etanol = 5,
                Gas = 5
            };

            //action
            decimal resultado = _calculoAluguel.CalcularValorTotalDevolucao(_aluguel, precos);

            //assert
            decimal valorEsperado = 659.5m;
            Assert.AreEqual(valorEsperado, resultado);
        }

        [TestMethod]
        public void Deve_calcular_valor_total_devolucao_plano_diario()
        {
            //arrange
            _aluguel.DataPrevistaRetorno = new DateTime(2023, 8, 20);
            _aluguel.DataLocacao = new DateTime(2023, 8, 10);
            _aluguel.DataDevolucao = new DateTime(2023, 8, 30);

            _aluguel.Automovel.Quilometragem = 100;
            _aluguel.Automovel.CapacidadeCombustivel = 10;
            _aluguel.Automovel.TipoCombustivel = TipoCombustível.Gasolina;

            _aluguel.CombustivelRestante = NivelTanque.MeioTanque;

            _aluguel.QuilometrosRodados = 50;
            _aluguel.ListaTaxasEServicos = new List<TaxaEServico>() { new TaxaEServico() { Valor = 10 }, new TaxaEServico() { Valor = 10 }, new TaxaEServico() { Valor = 10 } };
            _aluguel.PlanoCobranca = new PlanoCobranca(10, 10, 10, 10, 10, 10, _aluguel.CategoriaAutomoveis);
            _aluguel.Plano = TipoPlano.Diario;

            _aluguel.Cupom = new Cupom() { Valor = 10 };

            PrecoCombustivel precos = new()
            {
                Gasolina = 5,
                Diesel = 5,
                Etanol = 5,
                Gas = 5
            };

            //action
            decimal resultado = _calculoAluguel.CalcularValorTotalDevolucao(_aluguel, precos);

            //assert
            decimal valorEsperado = 1209.5m;
            Assert.AreEqual(valorEsperado, resultado);
        }

        [TestMethod]
        public void Deve_calcular_valor_total_devolucao_tanque_vazio()
        {
            //arrange
            _aluguel.DataPrevistaRetorno = new DateTime(2023, 8, 20);
            _aluguel.DataLocacao = new DateTime(2023, 8, 10);
            _aluguel.DataDevolucao = new DateTime(2023, 8, 30);

            _aluguel.Automovel.Quilometragem = 100;
            _aluguel.Automovel.CapacidadeCombustivel = 10;
            _aluguel.Automovel.TipoCombustivel = TipoCombustível.Gasolina;

            _aluguel.CombustivelRestante = NivelTanque.Vazio;

            _aluguel.QuilometrosRodados = 50;
            _aluguel.ListaTaxasEServicos = new List<TaxaEServico>() { new TaxaEServico() { Valor = 10 }, new TaxaEServico() { Valor = 10 }, new TaxaEServico() { Valor = 10 } };
            _aluguel.PlanoCobranca = new PlanoCobranca(10, 10, 10, 10, 10, 10, _aluguel.CategoriaAutomoveis);
            _aluguel.Plano = TipoPlano.Livre;

            _aluguel.Cupom = new Cupom() { Valor = 10 };

            PrecoCombustivel precos = new()
            {
                Gasolina = 5,
                Diesel = 5,
                Etanol = 5,
                Gas = 5
            };

            //action
            decimal resultado = _calculoAluguel.CalcularValorTotalDevolucao(_aluguel, precos);

            //assert
            decimal valorEsperado = 687;
            Assert.AreEqual(valorEsperado, resultado);
        }

        [TestMethod]
        public void Deve_calcular_valor_total_devolucao_tanque_um_quarto()
        {
            //arrange
            _aluguel.DataPrevistaRetorno = new DateTime(2023, 8, 20);
            _aluguel.DataLocacao = new DateTime(2023, 8, 10);
            _aluguel.DataDevolucao = new DateTime(2023, 8, 30);

            _aluguel.Automovel.Quilometragem = 100;
            _aluguel.Automovel.CapacidadeCombustivel = 10;
            _aluguel.Automovel.TipoCombustivel = TipoCombustível.Gasolina;

            _aluguel.CombustivelRestante = NivelTanque.UmQuarto;

            _aluguel.QuilometrosRodados = 50;
            _aluguel.ListaTaxasEServicos = new List<TaxaEServico>() { new TaxaEServico() { Valor = 10 }, new TaxaEServico() { Valor = 10 }, new TaxaEServico() { Valor = 10 } };
            _aluguel.PlanoCobranca = new PlanoCobranca(10, 10, 10, 10, 10, 10, _aluguel.CategoriaAutomoveis);
            _aluguel.Plano = TipoPlano.Livre;

            _aluguel.Cupom = new Cupom() { Valor = 10 };

            PrecoCombustivel precos = new()
            {
                Gasolina = 5,
                Diesel = 5,
                Etanol = 5,
                Gas = 5
            };

            //action
            decimal resultado = _calculoAluguel.CalcularValorTotalDevolucao(_aluguel, precos);

            //assert
            decimal valorEsperado = 673.25m;
            Assert.AreEqual(valorEsperado, resultado);
        }

        [TestMethod]
        public void Deve_calcular_valor_total_devolucao_tanque_tres_quartos()
        {
            //arrange
            _aluguel.DataPrevistaRetorno = new DateTime(2023, 8, 20);
            _aluguel.DataLocacao = new DateTime(2023, 8, 10);
            _aluguel.DataDevolucao = new DateTime(2023, 8, 30);

            _aluguel.Automovel.Quilometragem = 100;
            _aluguel.Automovel.CapacidadeCombustivel = 10;
            _aluguel.Automovel.TipoCombustivel = TipoCombustível.Gasolina;

            _aluguel.CombustivelRestante = NivelTanque.TresQuartos;

            _aluguel.QuilometrosRodados = 50;
            _aluguel.ListaTaxasEServicos = new List<TaxaEServico>() { new TaxaEServico() { Valor = 10 }, new TaxaEServico() { Valor = 10 }, new TaxaEServico() { Valor = 10 } };
            _aluguel.PlanoCobranca = new PlanoCobranca(10, 10, 10, 10, 10, 10, _aluguel.CategoriaAutomoveis);
            _aluguel.Plano = TipoPlano.Livre;

            _aluguel.Cupom = new Cupom() { Valor = 10 };

            PrecoCombustivel precos = new()
            {
                Gasolina = 5,
                Diesel = 5,
                Etanol = 5,
                Gas = 5
            };

            //action
            decimal resultado = _calculoAluguel.CalcularValorTotalDevolucao(_aluguel, precos);

            //assert
            decimal valorEsperado = 645.75m;
            Assert.AreEqual(valorEsperado, resultado);
        }

        [TestMethod]
        public void Deve_calcular_valor_total_devolucao_tanque_cheio()
        {
            //arrange
            _aluguel.DataPrevistaRetorno = new DateTime(2023, 8, 20);
            _aluguel.DataLocacao = new DateTime(2023, 8, 10);
            _aluguel.DataDevolucao = new DateTime(2023, 8, 30);

            _aluguel.Automovel.Quilometragem = 100;
            _aluguel.Automovel.CapacidadeCombustivel = 10;
            _aluguel.Automovel.TipoCombustivel = TipoCombustível.Gasolina;

            _aluguel.CombustivelRestante = NivelTanque.Cheio;

            _aluguel.QuilometrosRodados = 50;
            _aluguel.ListaTaxasEServicos = new List<TaxaEServico>() { new TaxaEServico() { Valor = 10 }, new TaxaEServico() { Valor = 10 }, new TaxaEServico() { Valor = 10 } };
            _aluguel.PlanoCobranca = new PlanoCobranca(10, 10, 10, 10, 10, 10, _aluguel.CategoriaAutomoveis);
            _aluguel.Plano = TipoPlano.Livre;

            _aluguel.Cupom = new Cupom() { Valor = 10 };

            PrecoCombustivel precos = new()
            {
                Gasolina = 5,
                Diesel = 5,
                Etanol = 5,
                Gas = 5
            };

            //action
            decimal resultado = _calculoAluguel.CalcularValorTotalDevolucao(_aluguel, precos);

            //assert
            decimal valorEsperado = 632m;
            Assert.AreEqual(valorEsperado, resultado);
        }
        #endregion

        [TestMethod]
        public void Primeiro_Teste()
        {
            decimal resultado = _calculoAluguel.CalcularValorTotalInicial(_aluguel);

            decimal valorEsperado = 0;

            Assert.AreEqual(valorEsperado, resultado);
        }
    }
}
