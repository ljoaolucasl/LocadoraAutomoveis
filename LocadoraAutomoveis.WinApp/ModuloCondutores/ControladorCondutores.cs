using LocadoraAutomoveis.Aplicacao.Servicos;
using LocadoraAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloCondutores;
using LocadoraAutomoveis.Infraestrutura.Repositorios;
using LocadoraAutomoveis.WinApp.Compartilhado;
using LocadoraAutomoveis.WinApp.ModuloAutomovel;

namespace LocadoraAutomoveis.WinApp.ModuloCondutores
{
    public class ControladorCondutores : ControladorBase<Condutor, RepositorioCondutores, ServicoCondutores, TabelaCondutoresControl, TelaCondutoresForm, ServicoCliente, NoService>
    {
        public ControladorCondutores(RepositorioCondutores _repositorio, ServicoCondutores _servico, TabelaCondutoresControl _tabela, ServicoCliente _repositorio2) : base(_repositorio, _servico, _tabela, _repositorio2)
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
