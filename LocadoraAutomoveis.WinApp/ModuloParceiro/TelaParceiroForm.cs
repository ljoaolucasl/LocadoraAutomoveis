using LocadoraAutomoveis.Dominio.ModuloParceiro;
using LocadoraAutomoveis.WinApp.Compartilhado;
using LocadoraAutomoveis.WinApp.Extensions;

namespace LocadoraAutomoveis.WinApp.ModuloParceiro
{
    public partial class TelaParceiroForm : Form, ITelaBase<Parceiro>
    {
        public TelaParceiroForm()
        {
            InitializeComponent();

            this.ConfigurarDialog();
        }


    }
}
