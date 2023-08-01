using LocadoraAutomoveis.Aplicacao.Servicos;
using LocadoraAutomoveis.Dominio.ModuloTaxaEServico;
using LocadoraAutomoveis.Infraestrutura.Repositorios;
using LocadoraAutomoveis.WinApp.Compartilhado;

namespace LocadoraAutomoveis.WinApp.ModuloTaxaEServico
{
    public class ControladorTaxaEServico : ControladorBase<TaxaEServico, RepositorioTaxaEServico, ServicoTaxaEServico, TabelaTaxaEServicoControl, TelaTaxaEServicoForm, NoRepository, NoRepository>
    {
        public ControladorTaxaEServico(RepositorioTaxaEServico _repositorio, ServicoTaxaEServico _servico, TabelaTaxaEServicoControl _tabela) : base(_repositorio, _servico, _tabela)
        {
        }

        public override DataGridView ObterTabela()
        {
            return (DataGridView)_tabela.Controls[0];
        }
    }
}
