using FluentResults;
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

        public Parceiro? Entidade { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event Func<Parceiro, Result> OnGravarRegistro;
    }
}
