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
    public class CalculoAluguelTeste
    {
        private Aluguel _aluguel;
        private CalculoAluguel _calculoAluguel;

        [TestInitialize]
        public void Setup()
        {

            Funcionario funcionario = new();
            Cliente cliente = new();
            CategoriaAutomoveis categoria = new();
            PlanoCobranca plano = new();
            Condutor condutor = new() { Validade = DateTime.Now.AddDays(1) };
            Automovel automovel = new() { Alugado = false };
            Cupom cupom = new();
            _calculoAluguel = new CalculoAluguel();
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
        public void Primeiro_Teste()
        {
            decimal resultado = _calculoAluguel.CalcularValorTotalInicial(_aluguel);

            decimal valorEsperado = 0;

            Assert.AreEqual(valorEsperado, resultado);
        }
    }
}
