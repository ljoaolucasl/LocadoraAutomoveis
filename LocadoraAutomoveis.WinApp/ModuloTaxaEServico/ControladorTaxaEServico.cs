using LocadoraAutomoveis.Dominio.ModuloTaxaEServico;

namespace LocadoraAutomoveis.WinApp.ModuloTaxaEServico
{
    public class ControladorTaxaEServico : ControladorBase<TaxaEServico, IRepositorioTaxaEServico, IServicoTaxaEServico, TabelaTaxaEServicoControl, TelaTaxaEServicoForm, NoService, NoService>
    {
        public ControladorTaxaEServico(IRepositorioTaxaEServico _repositorio, IServicoTaxaEServico _servico, TabelaTaxaEServicoControl _tabela) : base(_repositorio, _servico, _tabela)
        {
        }

        protected override string TipoCadastro => "Taxas e Serviços";
    }
}
