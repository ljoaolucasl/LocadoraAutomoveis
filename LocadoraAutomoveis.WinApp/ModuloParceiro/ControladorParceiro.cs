using LocadoraAutomoveis.Aplicacao.Servicos;
using LocadoraAutomoveis.Dominio.ModuloParceiro;
using LocadoraAutomoveis.Infraestrutura.Repositorios;
using LocadoraAutomoveis.WinApp.Compartilhado;

namespace LocadoraAutomoveis.WinApp.ModuloParceiro
{
    public class ControladorParceiro : ControladorBase<Parceiro, RepositorioParceiro,
        ServicoParceiro, TabelaParceiroControl, TelaParceiroForm, NoService, NoService>
    {
        public ControladorParceiro(RepositorioParceiro repositorioParceiro, ServicoParceiro servicoParceiro, TabelaParceiroControl tabelaParceiro) : base(repositorioParceiro, servicoParceiro, tabelaParceiro)
        {
        }

        protected override string TipoCadastro => "Parceiros";
    }
}
