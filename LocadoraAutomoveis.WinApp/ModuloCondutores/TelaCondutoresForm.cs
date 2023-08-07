using FluentResults;
using LocadoraAutomoveis.Aplicacao.Compartilhado;
using LocadoraAutomoveis.Dominio.Extensions;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Dominio.ModuloCondutores;
using LocadoraAutomoveis.WinApp.Compartilhado;
using LocadoraAutomoveis.WinApp.Extensions;
using System.Collections.Generic;
using System.Runtime.InteropServices.ObjectiveC;

namespace LocadoraAutomoveis.WinApp.ModuloCondutores
{
    public partial class TelaCondutoresForm : Form, ITelaBase<Condutor>
    {
        private Condutor _condutores;

        private Result _resultado;

        public event Func<Condutor, Result> OnGravarRegistro;

        public TelaCondutoresForm()
        {
            InitializeComponent();

            this.ConfigurarDialog();

            _resultado = new Result();

            _condutores = new Condutor();
        }

        public void CarregarClientes(List<Cliente> listClientes)
        {
            cmbCliente.DataSource = listClientes;
            cmbCliente.DisplayMember = "Nome";
            cmbCliente.ValueMember = "ID";
        }

        public Condutor? Entidade
        {
            get => _condutores;

            set
            {
                cmbCliente.Text = value.Cliente.ToString();
                chkClienteCondutor.Checked = value.TipoCondutor == true;
                txtNome.Text = value.Nome;
                txtEmail.Text = value.Email;
                txtTelefone.Text = value.Telefone;
                txtCPF.Text = value.CPF;
                txtCNH.Text = value.CNH;
                dateValidade.Text = value.Validade.ToString();
                _condutores = value;
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

            _condutores = ObterCondutores();

            _resultado = OnGravarRegistro(_condutores);

            if (_resultado.IsFailed)
                MostrarErros();
        }

        private Condutor ObterCondutores()
        {
            _condutores.Cliente = cmbCliente.SelectedItem as Cliente;
            _condutores.TipoCondutor = chkClienteCondutor.Checked ? true : false;
            _condutores.Nome = txtNome.Text;
            _condutores.Email = txtEmail.Text;
            _condutores.Telefone = txtTelefone.Text;
            _condutores.CPF = txtCPF.Text;
            _condutores.CNH = txtCNH.Text;
            _condutores.Validade = Convert.ToDateTime(dateValidade.Value);

            return _condutores;
        }

        private void MostrarErros()
        {
            foreach (CustomError item in _resultado.Errors)
            {
                switch (item.PropertyName)
                {
                    case "Cliente": lbErroCliente.Text = item.ErrorMessage; lbErroCliente.Visible = true; cmbCliente.Focus(); break;
                    case "Nome": lbErroNome.Text = item.ErrorMessage; lbErroNome.Visible = true; txtNome.Focus(); break;
                    case "Email": lbErroEmail.Text = item.ErrorMessage; lbErroEmail.Visible = true; txtEmail.Focus(); break;
                    case "Telefone": lbErroTelefone.Text = item.ErrorMessage; lbErroTelefone.Visible = true; txtTelefone.Focus(); break;
                    case "CPF": lbErroCPF.Text = item.ErrorMessage; lbErroCPF.Visible = true; txtCPF.Focus(); break;
                    case "CNH": lbErroCNH.Text = item.ErrorMessage; lbErroCNH.Visible = true; txtCNH.Focus(); break;
                    case "Validade": lbErroValidade.Text = item.ErrorMessage; lbErroValidade.Visible = true; lbErroValidade.Focus(); break;
                }
            }
        }

        private void ResetarErros()
        {
            lbErroCliente.Visible = false;
            lbErroNome.Visible = false;
            lbErroEmail.Visible = false;
            lbErroTelefone.Visible = false;
            lbErroCPF.Visible = false;
            lbErroCNH.Visible = false;
            lbErroValidade.Visible = false;

            _resultado.Errors.Clear();
            _resultado.Reasons.Clear();
        }

        private void chkClienteCondutor_CheckedChanged(object sender, EventArgs e)
        {
            Cliente cliente = cmbCliente.SelectedItem as Cliente;

            if (chkClienteCondutor.Checked)
            {
                txtNome.Text = cliente.Nome;
                txtEmail.Text = cliente.Email;
                txtTelefone.Text = cliente.Telefone;
                txtCPF.Text = cliente.Documento;

                txtNome.Enabled = false;
                txtEmail.Enabled = false;
                txtTelefone.Enabled = false;
                txtCPF.Enabled = false;

            }
            else
            {
                txtNome.Enabled = true;
                txtEmail.Enabled = true;
                txtTelefone.Enabled = true;
                txtCPF.Enabled = true;

                txtNome.Text = "";
                txtEmail.Text = "";
                txtTelefone.Text = "";
                txtCPF.Text = "";
            }
        }

        public void HabilitarCampos(bool ehHabilitado)
        {
            chkClienteCondutor.Checked = !ehHabilitado;
            chkClienteCondutor.Enabled = !ehHabilitado;

            txtNome.Enabled = ehHabilitado;
            txtEmail.Enabled = ehHabilitado;
            txtTelefone.Enabled = ehHabilitado;
            txtCPF.Enabled = ehHabilitado;
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cliente cliente = cmbCliente.SelectedItem as Cliente;

            if (cliente.TipoCliente == TipoDocumento.CPF)
            {
                HabilitarCampos(false);
            }
            else
            {
                HabilitarCampos(true);
            }
        }
    }
}
