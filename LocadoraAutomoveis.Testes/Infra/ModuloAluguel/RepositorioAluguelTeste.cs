using FizzWare.NBuilder;
using LocadoraAutomoveis.Dominio.ModuloAluguel;
using LocadoraAutomoveis.Dominio.ModuloAutomovel;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Dominio.ModuloCondutores;
using LocadoraAutomoveis.Dominio.ModuloCupom;
using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using LocadoraAutomoveis.Dominio.ModuloPlanosCobrancas;
using LocadoraAutomoveis.Dominio.ModuloTaxaEServico;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;
using LocadoraAutomoveis.Infraestrutura.Repositorios;

namespace LocadoraAutomoveis.Testes.Infra.ModuloAluguel
{
    [TestClass]
    public class RepositorioAluguelTeste
    {
        private RepositorioAluguel _repositorioAluguel;

        private ContextoDados _contexto;

        private Aluguel _aluguel;

        [TestInitialize]
        public void Setup()
        {
            _contexto = new LocadoraAutomoveisDesignFactory().CreateDbContext(null);

            _repositorioAluguel = new RepositorioAluguel(_contexto);

            _contexto.RemoveRange(_repositorioAluguel.SelecionarTodos());

            BuilderSetup.SetCreatePersistenceMethod<Aluguel>(_repositorioAluguel.Inserir);

            Funcionario funcionario = new();
            Cliente cliente = new();
            CategoriaAutomoveis categoria = new();
            PlanoCobranca plano = new();
            Condutor condutor = new();
            Automovel automovel = new();
            Cupom cupom = new();
            List<TaxaEServico> listTaxa = new();
            DateTime dataLocacao = DateTime.Now;
            DateTime dataPrevista = dataLocacao.AddDays(1);
            DateTime dataDevolucao = dataLocacao.AddDays(2);
            decimal quilometrosRodados = 100;
            NivelTanque nivelTanque = NivelTanque.MeioTanque;
            decimal valorTotal = 1000;

            _aluguel = new Aluguel(funcionario, cliente, categoria, plano, condutor, automovel, cupom, listTaxa, dataLocacao, dataPrevista, dataDevolucao, quilometrosRodados, nivelTanque, valorTotal, true);
        }

        [TestMethod]
        public void Deve_adicionar_um_Aluguel()
        {
            //action
            _repositorioAluguel.Inserir(_aluguel);

            //assert
            _repositorioAluguel.SelecionarPorID(_aluguel.ID).Should().Be(_aluguel);
        }

        [TestMethod]
        public void Deve_editar_um_Aluguel()
        {
            //arrange
            _repositorioAluguel.Inserir(_aluguel);
            var aluguel2 = _repositorioAluguel.SelecionarPorID(_aluguel.ID);
            aluguel2.DataPrevistaRetorno = new DateTime(2023, 8, 10);

            //action
            _repositorioAluguel.Editar(aluguel2);

            //assert
            var aluguelSelecionado = _repositorioAluguel.SelecionarPorID(_aluguel.ID);
            _repositorioAluguel.SelecionarTodos().Should().HaveCount(1);
            aluguelSelecionado.Should().Be(aluguel2);
        }

        [TestMethod]
        public void Deve_excluir_um_Aluguel()
        {
            //arrange
            _repositorioAluguel.Inserir(_aluguel);
            var aluguelSelecionado = _repositorioAluguel.SelecionarPorID(_aluguel.ID);

            //action
            _repositorioAluguel.Excluir(aluguelSelecionado);

            //assert
            _repositorioAluguel.SelecionarTodos().Should().HaveCount(0);
        }

        [TestMethod]
        public void Deve_selecionar_por_ID_um_Aluguel()
        {
            //arrange
            _repositorioAluguel.Inserir(_aluguel);

            //action
            var aluguelSelecionado = _repositorioAluguel.SelecionarPorID(_aluguel.ID);

            //assert
            aluguelSelecionado.Should().Be(_aluguel);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_automoveis()
        {
            //arrange
            var funcionario1 = Builder<Funcionario>.CreateNew().Build();
            var cliente1 = Builder<Cliente>.CreateNew().Build();
            var categoria1 = Builder<CategoriaAutomoveis>.CreateNew().Build();
            var plano1 = Builder<PlanoCobranca>.CreateNew().Build();
            var condutor1 = Builder<Condutor>.CreateNew().Build();
            var automovel1 = Builder<Automovel>.CreateNew().Build();
            var cupom1 = Builder<Cupom>.CreateNew().Build();
            var taxas1 = Builder<List<TaxaEServico>>.CreateNew().Build();
            DateTime dataLocacao = DateTime.Now;
            DateTime dataPrevista = dataLocacao.AddDays(1);
            DateTime dataDevolucao = dataLocacao.AddDays(2);
            decimal quilometrosRodados = 100;
            NivelTanque nivelTanque = NivelTanque.MeioTanque;
            decimal valorTotal = 1000;

            Aluguel aluguel1 = new(funcionario1, cliente1, categoria1, plano1, condutor1, automovel1, cupom1, taxas1, dataLocacao, dataPrevista, dataDevolucao, quilometrosRodados, nivelTanque, valorTotal, false);
            Aluguel aluguel2 = new(funcionario1, cliente1, categoria1, plano1, condutor1, automovel1, cupom1, taxas1, new DateTime(2023, 8, 5), new DateTime(2023, 8, 6), new DateTime(2023, 8, 6), quilometrosRodados, nivelTanque, valorTotal, false);
            Aluguel aluguel3 = new(funcionario1, cliente1, categoria1, plano1, condutor1, automovel1, cupom1, taxas1, new DateTime(2023, 8, 5), new DateTime(2023, 8, 6), new DateTime(2023, 8, 6), quilometrosRodados, nivelTanque, valorTotal, false);
            Aluguel aluguel4 = new(funcionario1, cliente1, categoria1, plano1, condutor1, automovel1, cupom1, taxas1, new DateTime(2023, 8, 5), new DateTime(2023, 8, 6), new DateTime(2023, 8, 6), quilometrosRodados, nivelTanque, valorTotal, false);

            _repositorioAluguel.Inserir(aluguel1);
            _repositorioAluguel.Inserir(aluguel2);
            _repositorioAluguel.Inserir(aluguel3);
            _repositorioAluguel.Inserir(aluguel4);

            //action
            var listaAluguels = _repositorioAluguel.SelecionarTodos();

            //assert
            listaAluguels[0].Should().Be(aluguel1);
            listaAluguels[3].Should().Be(aluguel4);
            listaAluguels.Should().HaveCount(4);
        }

        [TestMethod]
        public void Deve_retornar_true_se_Aluguel_existe_validacao()
        {
            //arrange
            _repositorioAluguel.Inserir(_aluguel);
            var aluguel2 = new Aluguel(_aluguel.Funcionario, _aluguel.Cliente, _aluguel.CategoriaAutomoveis, _aluguel.PlanoCobranca, _aluguel.Condutor, _aluguel.Automovel,
                _aluguel.Cupom, _aluguel.ListaTaxasEServicos, _aluguel.DataLocacao, _aluguel.DataPrevistaRetorno, _aluguel.DataDevolucao, _aluguel.QuilometrosRodados, _aluguel.CombustivelRestante, _aluguel.ValorTotal, _aluguel.Concluido);

            //action
            bool resultado = _repositorioAluguel.Existe(aluguel2);

            //assert
            resultado.Should().BeTrue();
        }

        [TestMethod]
        public void Deve_retornar_false_se_Aluguel_equals_e_ID_igual_validacao()
        {
            //arrange
            _repositorioAluguel.Inserir(_aluguel);
            var aluguel2 = _repositorioAluguel.SelecionarPorID(_aluguel.ID);

            //action
            bool resultado = _repositorioAluguel.Existe(aluguel2);

            //assert
            resultado.Should().BeFalse();
        }

        [TestMethod]
        public void Deve_verificar_se_Aluguel_existe_exclusao()
        {
            //arrange
            _repositorioAluguel.Inserir(_aluguel);
            var aluguel2 = _repositorioAluguel.SelecionarPorID(_aluguel.ID);

            //action
            bool resultado = _repositorioAluguel.Existe(aluguel2, true);

            //assert
            resultado.Should().BeTrue();
        }
    }
}
