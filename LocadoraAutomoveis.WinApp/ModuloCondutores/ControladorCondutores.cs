using LocadoraAutomoveis.Aplicacao.Servicos;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Dominio.ModuloCondutores;

namespace LocadoraAutomoveis.WinApp.ModuloCondutores
{
    public class ControladorCondutores : ControladorBase<Condutor, IRepositorioCondutores, IServicoCondutor, TabelaCondutoresControl, TelaCondutoresForm, IServicoCliente, NoService>
    {
        public ControladorCondutores(IRepositorioCondutores _repositorio, IServicoCondutor _servico, TabelaCondutoresControl _tabela, IServicoCliente _repositorio2) : base(_repositorio, _servico, _tabela, _repositorio2)
        {
            OnComandosAdicionaisAddAndEdit += ObterDependencias;
        }

        protected override string TipoCadastro => "Funcionários";

        private void ObterDependencias(TelaCondutoresForm tela, Condutor condutor)
        {
            var clientes = _servico2.SelecionarTodosOsRegistros();

            tela.CarregarClientes(clientes);
        }
    }
}
