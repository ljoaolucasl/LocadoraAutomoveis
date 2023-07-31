using FluentResults;
using LocadoraAutomoveis.Dominio.ModuloPlanosCobrancas;

namespace LocadoraAutomoveis.WinApp.ModuloPlanosCobrancas
{
    public partial class TelaPlanosCobrancasForm : Form, ITelaBase<PlanoCobranca>
    {
        private PlanoCobranca _planoCobranca;

        private Result _resultado;

        public event Func<PlanoCobranca, Result> OnGravarRegistro;
        public TelaPlanosCobrancasForm()
        {
            InitializeComponent();
        }

        public PlanoCobranca? Entidade
        {
            get => throw new NotImplementedException();

            set
            {

            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            ValidarCampos(sender, e);

            if (_resultado.IsFailed)
                this.DialogResult = DialogResult.None;
        }

        //private void ValidarCampos(object sender, EventArgs e)
        //{
        //    ResetarErros();

        //    _planoCobranca = new PlanoCobranca(txtNome.Text);

        //    _resultado = OnGravarRegistro(_planoCobranca);

        //    if (_resultado.IsFailed)
        //        MostrarErros();
        //}
    }
}
