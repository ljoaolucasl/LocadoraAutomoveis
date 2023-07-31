using LocadoraAutomoveis.Aplicacao.Servicos;
using LocadoraAutomoveis.Dominio.ModuloParceiro;
using LocadoraAutomoveis.WinApp.Compartilhado;

namespace LocadoraAutomoveis.WinApp.ModuloParceiro
{
    public class ControladorParceiro : ControladorBase<Parceiro, RepositorioParceiro,
        ServicoParceiro, TabelaParceiroControl, TelaParceiroForm, NoRepository, NoRepository>
    {
        public override DataGridView ObterTabela()
        {
            return (DataGridView)_tabela.Controls[0];
        }
    }
}
