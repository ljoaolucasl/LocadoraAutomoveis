using FluentResults;
using LocadoraAutomoveis.Dominio.ModuloAutomovel;
using LocadoraAutomoveis.Dominio.ModuloTaxaEServico;

namespace LocadoraAutomoveis.WinApp.ModuloTaxaEServico
{
    public class ControladorTaxaEServico : ControladorBase<TaxaEServico, IRepositorioTaxaEServico, IServicoTaxaEServico, TabelaTaxaEServicoControl, TelaTaxaEServicoForm, NoService, NoService>
    {
        public ControladorTaxaEServico(IRepositorioTaxaEServico _repositorio, IServicoTaxaEServico _servico, TabelaTaxaEServicoControl _tabela) : base(_repositorio, _servico, _tabela)
        {
            OnVerificar += ObterDisponibilidade;
        }

        protected override string TipoCadastro => "Taxas e Serviços";

        public Result ObterDisponibilidade(TaxaEServico taxa)
        {
            return _servico.VerificarDisponibilidade(taxa);
        }
    }
}
