using LocadoraAutomoveis.Aplicacao.Servicos;
using LocadoraAutomoveis.Dominio.ModuloCupom;
using LocadoraAutomoveis.Infraestrutura.Repositorios;

namespace LocadoraAutomoveis.WinApp.ModuloCupom
{
    public class ControladorCupom : ControladorBase<Cupom, RepositorioCupom, ServicoCupom, TabelaCupomControl, TelaCupomForm, ServicoParceiro, NoService>
    {
        public ControladorCupom(RepositorioCupom repositorioCupom, ServicoCupom servicoCupom, TabelaCupomControl tabelaCupom, ServicoParceiro servicoParceiro) : base(repositorioCupom, servicoCupom, tabelaCupom, servicoParceiro)
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
