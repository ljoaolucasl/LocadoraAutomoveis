using LocadoraAutomoveis.Dominio.ModuloParceiro;

namespace LocadoraAutomoveis.WinApp.ModuloParceiro
{
    public class ControladorParceiro : ControladorBase<Parceiro, IRepositorioParceiro,
        IServicoParceiro, TabelaParceiroControl, TelaParceiroForm, NoService, NoService>
    {
        public ControladorParceiro(IRepositorioParceiro repositorioParceiro, IServicoParceiro servicoParceiro, TabelaParceiroControl tabelaParceiro) : base(repositorioParceiro, servicoParceiro, tabelaParceiro)
        {
        }

        protected override string TipoCadastro => "Parceiros";
    }
}
