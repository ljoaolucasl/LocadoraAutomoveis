using LocadoraAutomoveis.Dominio.ModuloParceiro;
using LocadoraAutomoveis.WinApp.Compartilhado;

namespace LocadoraAutomoveis.WinApp.ModuloParceiro
{
    public partial class TabelaParceiroControl : UserControl, ITabelaBase<Parceiro>
    {
        public TabelaParceiroControl()
        {
            InitializeComponent();
        }

        public void AtualizarLista(List<Parceiro> registros)
        {
            throw new NotImplementedException();
        }

        public Parceiro ObterRegistroSelecionado()
        {
            throw new NotImplementedException();
        }
    }
}
