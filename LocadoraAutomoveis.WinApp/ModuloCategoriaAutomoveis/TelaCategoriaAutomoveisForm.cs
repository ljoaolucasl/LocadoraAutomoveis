using FluentResults;
using LocadoraAutomoveis.Aplicacao.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.WinApp.Compartilhado;

namespace LocadoraAutomoveis.WinApp.ModuloCategoriaAutomoveis
{
    public partial class TelaCategoriaAutomoveisForm : Form, ITelaBase<CategoriaAutomoveis>
    {
        private CategoriaAutomoveis _categoria;

        private Result _resultado;

        public event Func<CategoriaAutomoveis, Result> OnGravarRegistro;

        public TelaCategoriaAutomoveisForm()
        {
            InitializeComponent();
        }

        public CategoriaAutomoveis? Entidade
        {
            get => _categoria;

            set
            {
                //txtId.Text = Convert.ToString(value.ID);
                txtNome.Text = value.Nome;
                _categoria = value;
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

            _categoria = new CategoriaAutomoveis(txtNome.Text);

            //if (_categoria.ID == 0)
            //    _categoria.ID = int.Parse(txtId.Text);

            _resultado = OnGravarRegistro(_categoria);

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
