using LocadoraAutomoveis.Dominio.ModuloCupom;
using LocadoraAutomoveis.Dominio.ModuloParceiro;

namespace LocadoraAutomoveis.WinApp.ModuloCupom
{
    public class ControladorCupom : ControladorBase<Cupom, IRepositorioCupom, IServicoCupom, TabelaCupomControl, TelaCupomForm, IServicoParceiro, NoService>
    {
        public ControladorCupom(IRepositorioCupom repositorioCupom, IServicoCupom servicoCupom, TabelaCupomControl tabelaCupom, IServicoParceiro servicoParceiro) : base(repositorioCupom, servicoCupom, tabelaCupom, servicoParceiro)
        {
            OnComandosAdicionaisAddAndEdit += ObterDependencias;
        }

        private void ObterDependencias(TelaCupomForm tela, Cupom cupom)
        {
            var parceiros = _servico2.SelecionarTodosOsRegistros();

            tela.CarregarParceiros(parceiros);
        }

        protected override string TipoCadastro => "Cupons";
    }
}
