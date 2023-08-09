using LocadoraAutomoveis.Dominio.ModuloConfiguracao;
using LocadoraAutomoveis.WinApp.Extensions;

namespace LocadoraAutomoveis.WinApp.ModuloConfiguracao
{
    public partial class TelaConfiguracaoPrecosForm : Form
    {
        internal PrecoCombustivel configuracao;

        public TelaConfiguracaoPrecosForm()
        {
            InitializeComponent();

            this.ConfigurarDialog();
        }

        private void CarregarConfiguracoes()
        {
            txtGasolina.Value = configuracao.Gasolina;
            txtEtanol.Value = configuracao.Etanol;
            txtDiesel.Value = configuracao.Diesel;
            txtGas.Value = configuracao.Gas;
        }

        private void SalvarConfiguracoes()
        {
            configuracao.Gasolina = txtGasolina.Value;
            configuracao.Etanol = txtEtanol.Value;
            configuracao.Diesel = txtDiesel.Value;
            configuracao.Gas = txtGas.Value;
        }

        private void ConfigurarCampos()
        {
            CarregarConfiguracoes();

            txtGasolina.Controls[0].Visible = false;
            txtGas.Controls[0].Visible = false;
            txtDiesel.Controls[0].Visible = false;
            txtEtanol.Controls[0].Visible = false;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            SalvarConfiguracoes();
        }

        private void TelaConfiguracaoPrecosForm_Shown(object sender, EventArgs e)
        {
            ConfigurarCampos();
        }

        private void selecaoAutomaticaNumericUpDown_Enter(object sender, EventArgs e)
        {
            ((TextBox)((NumericUpDown)sender).Controls[1]).SelectAll();
        }

        private void selecaoAutomaticaNumericUpDown_Click(object sender, EventArgs e)
        {
            if (((NumericUpDown)sender).Controls[1].Text == "0,00")
                ((TextBox)((NumericUpDown)sender).Controls[1]).SelectAll();
        }
    }
}
