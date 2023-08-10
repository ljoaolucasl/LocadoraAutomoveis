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

        #region Previsao
        [TestMethod]
        public void Deve_Calcular_Total_Inicial()
        {
            _aluguel.DataLocacao = new DateTime(2023, 8, 10);
            _aluguel.DataPrevistaRetorno = new DateTime(2023, 8, 20);

            _aluguel.PlanoCobranca = new PlanoCobranca(10, 10, 10, 10, 10, 10, _aluguel.CategoriaAutomoveis);

            _aluguel.Automovel.CapacidadeCombustivel = 10;
            _aluguel.Automovel.TipoCombustivel = TipoCombustível.Gasolina;

            _aluguel.CombustivelRestante = NivelTanque.MeioTanque;

            _aluguel.ListaTaxasEServicos = new List<TaxaEServico>() { new TaxaEServico() { Valor = 10 }, new TaxaEServico() { Valor = 10 }, new TaxaEServico() { Valor = 10 } };
            _aluguel.PlanoCobranca = new PlanoCobranca(10, 10, 10, 10, 10, 10, _aluguel.CategoriaAutomoveis);
            _aluguel.Plano = TipoPlano.Controlador;

            _aluguel.Cupom = new Cupom() { Valor = 10 };

            decimal resultado = _calculoAluguel.CalcularValorTotalInicial(_aluguel);

            decimal valorEsperado = 120;

            Assert.AreEqual(valorEsperado, resultado);
        }
        #endregion
    }
}
