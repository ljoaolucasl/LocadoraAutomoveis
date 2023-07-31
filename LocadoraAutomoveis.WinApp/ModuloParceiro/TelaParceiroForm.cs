using FluentResults;
using LocadoraAutomoveis.Aplicacao.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloPadrao;
using LocadoraAutomoveis.Dominio.ModuloParceiro;
using LocadoraAutomoveis.WinApp.Compartilhado;
using LocadoraAutomoveis.WinApp.Extensions;

namespace LocadoraAutomoveis.WinApp.ModuloParceiro
{
    public partial class TelaParceiroForm : Form, ITelaBase<Parceiro>
    {
        private Parceiro _parceiro;

        private Result _resultado;

        public event Func<Parceiro, Result> OnGravarRegistro;

        public TelaParceiroForm()
        {
            InitializeComponent();

            this.ConfigurarDialog();
        }

        public Parceiro? Entidade
        {
            get => _parceiro;

            set
            {
                txtNome.Text = value.Nome;
                _padrao = value;
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            ValidarCampos(sender, e);

            if (_resultado.IsFailed)
                this.DialogResult = DialogResult.None;
        }

        private void ValidarCampos(object sender, EventArgs e)
        {
            ResetarErros();

            _parceiro = new Parceiro(txtNome.Text);

            //if (_parceiro.ID == 0)
            //    _parceiro.ID = int.Parse(txtId.Text);

            _resultado = OnGravarRegistro(_parceiro);

            if (_resultado.IsFailed)
                MostrarErros();
        }

        private void MostrarErros()
        {
            foreach (CustomError item in _resultado.Errors.Cast<CustomError>())
            {
                switch (item.PropertyName)
                {
                    case "Nome": lbErroNome.Text = item.ErrorMessage; lbErroNome.Visible = true; break;
                }
            }
        }

        private void ResetarErros()
        {
            lbErroNome.Visible = false;

            _resultado.Errors.Clear();
            _resultado.Reasons.Clear();
        }
    }
}
