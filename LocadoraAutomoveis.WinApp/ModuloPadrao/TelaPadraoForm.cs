using FluentResults;
using LocadoraAutomoveis.Aplicacao.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloPadrao;
using LocadoraAutomoveis.WinApp.Compartilhado;

namespace LocadoraAutomoveis.WinApp.ModuloPadrao
{
    public partial class TelaPadraoForm : Form, ITelaBase<Padrao>
    {
        private Padrao _padrao;

        private Result _resultado;

        public event Func<Padrao, Result> OnGravarRegistro;

        public TelaPadraoForm()
        {
            InitializeComponent();
        }

        public Padrao? Entidade
        {
            get => _padrao;

            set
            {
                txtId.Text = Convert.ToString(value.ID);
                txtNome.Text = value.Nome;
                _padrao = value;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ValidarCampos(sender, e);

            if (_resultado.IsFailed)
                this.DialogResult = DialogResult.None;
        }

        private void ValidarCampos(object sender, EventArgs e)
        {
            ResetarErros();

            _padrao = new Padrao(txtNome.Text);

            if (_padrao.ID == 0)
                _padrao.ID = int.Parse(txtId.Text);

            _resultado = OnGravarRegistro(_padrao);

            if (_resultado.IsFailed)
                MostrarErros();
        }

        private void MostrarErros()
        {
            foreach (CustomError item in _resultado.Errors)
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
