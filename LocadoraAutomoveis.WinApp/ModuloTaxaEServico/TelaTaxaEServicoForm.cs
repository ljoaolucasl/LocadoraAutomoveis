using FluentResults;
using LocadoraAutomoveis.Aplicacao.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloTaxaEServico;
using LocadoraAutomoveis.WinApp.Extensions;

namespace LocadoraAutomoveis.WinApp.ModuloTaxaEServico
{
    public partial class TelaTaxaEServicoForm : Form, ITelaBase<TaxaEServico>
    {
        private TaxaEServico _taxa;

        private Result _resultado;

        public event Func<TaxaEServico, Result> OnGravarRegistro;

        public TelaTaxaEServicoForm()
        {
            InitializeComponent();

            this.ConfigurarDialog();

            txtValor.Controls[0].Visible = false;

            _resultado = new Result();

            _taxa = new TaxaEServico();
        }

        public TaxaEServico? Entidade
        {
            get => _taxa;

            set
            {
                txtNome.Text = value.Nome;
                txtValor.Value = value.Valor;
                rdDiaria.Checked = value.Tipo == Tipo.Diario;
                _taxa = value;
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

            _taxa = ObterTaxaEServico();

            _resultado = OnGravarRegistro(_taxa);

            if (_resultado.IsFailed)
                MostrarErros();
        }

        private TaxaEServico ObterTaxaEServico()
        {
            _taxa.Nome = txtNome.Text;
            _taxa.Valor = txtValor.Value;
            _taxa.Tipo = rdDiaria.Checked ? Tipo.Diario : Tipo.CalculoFixo;

            return _taxa;
        }

        private void MostrarErros()
        {
            foreach (CustomError item in _resultado.Errors)
            {
                switch (item.PropertyName)
                {
                    case "Nome": lbErroNome.Text = item.ErrorMessage; lbErroNome.Visible = true; txtNome.Focus(); break;
                    case "Valor": lbErroValor.Text = item.ErrorMessage; lbErroValor.Visible = true; txtValor.Focus(); break;
                }
            }
        }

        private void ResetarErros()
        {
            lbErroNome.Visible = false;
            lbErroValor.Visible = false;

            _resultado.Errors.Clear();
            _resultado.Reasons.Clear();
        }

        private void txtValor_Enter(object sender, EventArgs e)
        {
            ((TextBox)txtValor.Controls[1]).SelectAll();
        }

        private void txtValor_Click(object sender, EventArgs e)
        {
            if (txtValor.Controls[1].Text == "0,00")
                ((TextBox)txtValor.Controls[1]).SelectAll();
        }
    }
}
