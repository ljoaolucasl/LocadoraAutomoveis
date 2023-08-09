using LocadoraAutomoveis.Dominio.Configuracoes;
using LocadoraAutomoveis.WinApp.Extensions;

namespace LocadoraAutomoveis.WinApp.Compartilhado.TelaConfiguracao
{
    public partial class TelaConfiguracaoPrecosForm : Form
    {
        private readonly IRepositorioConfiguracao _repositorioConfiguracao;

        public TelaConfiguracaoPrecosForm(IRepositorioConfiguracao repositorioConfiguracao)
        {
            _repositorioConfiguracao = repositorioConfiguracao;

            InitializeComponent();

            this.ConfigurarDialog();

            ConfigurarCampos();
        }

        private void CarregarConfiguracoes()
        {
            PrecoCombustivel configuracao = _repositorioConfiguracao.ObterConfiguracaoPrecos();

            txtGasolina.Value = configuracao.Gasolina;
            txtEtanol.Value = configuracao.Etanol;
            txtDiesel.Value = configuracao.Diesel;
            txtGas.Value = configuracao.Gas;
        }

        private void SalvarConfiguracoes()
        {
            var configuracao = new PrecoCombustivel
            {
                Gasolina = txtGasolina.Value,
                Etanol = txtEtanol.Value,
                Diesel = txtDiesel.Value,
                Gas = txtGas.Value,
            };

            _repositorioConfiguracao.SalvarConfiguracoesPrecos(configuracao);
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
    }
}
