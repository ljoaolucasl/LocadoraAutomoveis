using LocadoraAutomoveis.Aplicacao.Servicos;
using LocadoraAutomoveis.Dominio.ModuloCupom;
using LocadoraAutomoveis.Infraestrutura.Repositorios;
using LocadoraAutomoveis.WinApp.Compartilhado;

namespace LocadoraAutomoveis.WinApp.ModuloCupom
{
    public class ControladorCupom : ControladorBase<Cupom, RepositorioCupom, ServicoCupom, TabelaCupomControl, TelaCupomForm, RepositorioParceiro, NoRepository>
    {
        public ControladorCupom(RepositorioCupom repositorioCupom, ServicoCupom servicoCupom, TabelaCupomControl tabelaCupom, RepositorioParceiro repositorioParceiro) : base(repositorioCupom, servicoCupom, tabelaCupom, repositorioParceiro)
        {

        }
    }
}
