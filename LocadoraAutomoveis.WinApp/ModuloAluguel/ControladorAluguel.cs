using LocadoraAutomoveis.Dominio.ModuloAluguel;

namespace LocadoraAutomoveis.WinApp.ModuloAluguel
{
    public class ControladorAluguel : ControladorBase<Aluguel, IRepositorioAluguel, IServicoAluguel, TabelaAluguelControl, TelaAluguelForm, NoService, NoService>
    {
        public ControladorAluguel(IRepositorioAluguel _repositorio, IServicoAluguel _servico, TabelaAluguelControl _tabela) : base(_repositorio, _servico, _tabela)
        {
            OnComandosAdicionaisAddAndEdit += ObterDependencias;
        }

        protected override string TipoCadastro => "Aluguéis";

        private void ObterDependencias(ITelaAluguel tela, Aluguel aluguel)
        {
            var funcionarios = _servico.servicoFuncionario.SelecionarTodosOsRegistros();
            var clientes = _servico.servicoCliente.SelecionarTodosOsRegistros();
            var categorias = _servico.servicoCategoriaAutomoveis.SelecionarTodosOsRegistros();
            var planos = _servico.servicoPlanosCobrancas.SelecionarTodosOsRegistros();
            var condutores = _servico.servicoCondutores.SelecionarTodosOsRegistros();
            var automoveis = _servico.servicoAutomovel.SelecionarTodosOsRegistros();
            var taxas = _servico.servicoTaxaEServico.SelecionarTodosOsRegistros();

            tela.CarregarDependencias(funcionarios, clientes, categorias, planos, condutores, automoveis, taxas);
        }
    }
}
