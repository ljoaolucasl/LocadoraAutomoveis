using FluentResults;
using LocadoraAutomoveis.Aplicacao.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using LocadoraAutomoveis.WinApp.Compartilhado;
using LocadoraAutomoveis.WinApp.Extensions;
using System.Windows.Forms;

namespace LocadoraAutomoveis.WinApp.ModuloFuncionario
{
    public partial class TelaFuncionarioForm : Form, ITelaBase<Funcionario>
    {
        private Funcionario _funcionario;

        private Result _resultado;

        public event Func<Funcionario, Result> OnGravarRegistro;

        public TelaFuncionarioForm()
        {
            InitializeComponent();
        }

        public Funcionario? Entidade
        {
            get => _funcionario;

            set
            {
                //txtId.Text = Convert.ToString(value.ID);
                txtNome.Text = value.Nome;
                dateAdmissao.Text = value.Admissao.ToString();
                txtSalario.Text = value.Salario.ToString();
                _funcionario = value;
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

            var salario = Convert.ToInt32(txtSalario.Text);
            _funcionario = new Funcionario(txtNome.Text, Convert.ToDateTime(dateAdmissao), Convert.ToDecimal(txtSalario.Text));

            //if (_categoria.ID == 0)
            //    _categoria.ID = int.Parse(txtId.Text);

            _resultado = OnGravarRegistro(_funcionario);

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
                    case "Admissao": lbErroAdmissao.Text = item.ErrorMessage; lbErroAdmissao.Visible = true; break;
                    case "Salario": lbErroSalario.Text = item.ErrorMessage; lbErroSalario.Visible = true; break;
                }
            }
        }

        private void ResetarErros()
        {
            lbErroNome.Visible = false;
            lbErroAdmissao.Visible = false;
            lbErroSalario.Visible = false;

            _resultado.Errors.Clear();
            _resultado.Reasons.Clear();
        }
    }
}
