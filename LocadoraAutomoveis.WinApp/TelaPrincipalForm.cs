using LocadoraAutomoveis.WinApp.Compartilhado.Injection;
using LocadoraAutomoveis.WinApp.ModuloAluguel;
using LocadoraAutomoveis.WinApp.ModuloAutomovel;
using LocadoraAutomoveis.WinApp.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.WinApp.ModuloCliente;
using LocadoraAutomoveis.WinApp.ModuloCondutores;
using LocadoraAutomoveis.WinApp.ModuloCupom;
using LocadoraAutomoveis.WinApp.ModuloFuncionario;
using LocadoraAutomoveis.WinApp.ModuloParceiro;
using LocadoraAutomoveis.WinApp.ModuloPlanosCobrancas;
using LocadoraAutomoveis.WinApp.ModuloTaxaEServico;

namespace LocadoraAutomoveis.WinApp
{
    public partial class TelaPrincipalForm : Form
    {
        private static TelaPrincipalForm _telaPrincipal;

        private IControladorBase _controladorBase;

        private DataGridView _grid;

        private readonly IoC injecao;

        public TelaPrincipalForm()
        {
            InitializeComponent();

            _telaPrincipal = this;

            injecao = new IoC_DependencyInjection();

            ConfigurarBotoes();
        }

        public static void AtualizarStatus(string status)
        {
            _telaPrincipal.lbStatus.Text = status;
        }

        #region BotoesTabelas
        private void btnAluguel_Click(object sender, EventArgs e)
        {
            _controladorBase = injecao.Get<ControladorAluguel>();
            ConfigurarTelaPrincipal();
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            _controladorBase = injecao.Get<ControladorCategoriaAutomoveis>();
            ConfigurarTelaPrincipal();
        }

        private void btnFuncionario_Click(object sender, EventArgs e)
        {
            _controladorBase = injecao.Get<ControladorFuncionario>();
            ConfigurarTelaPrincipal();
        }

        private void btnTaxa_Click(object sender, EventArgs e)
        {
            _controladorBase = injecao.Get<ControladorTaxaEServico>();
            ConfigurarTelaPrincipal();
        }

        private void btnParceiro_Click(object sender, EventArgs e)
        {
            _controladorBase = injecao.Get<ControladorParceiro>();
            ConfigurarTelaPrincipal();
        }

        private void btnAutomovel_Click(object sender, EventArgs e)
        {
            _controladorBase = injecao.Get<ControladorAutomovel>();
            ConfigurarTelaPrincipal();
        }

        private void btnFuncionario_Click_1(object sender, EventArgs e)
        {
            _controladorBase = injecao.Get<ControladorFuncionario>();
            ConfigurarTelaPrincipal();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            _controladorBase = injecao.Get<ControladorCliente>();
            ConfigurarTelaPrincipal();
        }

        private void btnCupom_Click(object sender, EventArgs e)
        {
            _controladorBase = injecao.Get<ControladorCupom>();
            ConfigurarTelaPrincipal();
        }

        private void btnCondutores_Click_1(object sender, EventArgs e)
        {
            _controladorBase = injecao.Get<ControladorCondutores>();
            ConfigurarTelaPrincipal();
        }

        private void btnPlanosCobrancas_Click(object sender, EventArgs e)
        {
            _controladorBase = injecao.Get<ControladorPlanosCobrancas>();
            ConfigurarTelaPrincipal();
        }
        #endregion

        #region CRUD
        private void btnAdd_Click(object sender, EventArgs e)
        {
            _controladorBase.Inserir();
            ResetarBotoes();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            _controladorBase.Editar();
            ResetarBotoes();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            _controladorBase.Excluir();
            ResetarBotoes();
        }
        #endregion

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (_controladorBase is ControladorAutomovel)
                (_controladorBase as ControladorAutomovel).Filtrar();
        }

        private void btnDevolucao_Click(object sender, EventArgs e)
        {
            if (_controladorBase is ControladorAluguel)
                (_controladorBase as ControladorAluguel).Devolver();
        }

        #region ConfiguracoesIniciais
        private void ConfigurarTelaPrincipal()
        {
            ConfigurarToolTips();
            InicializarTabela();
            ResetarBotoes();
        }

        private void InicializarTabela()
        {
            _grid = _controladorBase.ObterGrid();
            _grid.Dock = DockStyle.Fill;

            plPrincipal.Controls.Clear();
            plPrincipal.Controls.Add(_grid);
            _controladorBase.CarregarRegistros();
        }

        private void ConfigurarToolTips()
        {
            lbTipoCadastro.Text = _controladorBase.ObterTipoCadastro();

            btnAdicionar.ToolTipText = _controladorBase.ToolTipAdicionar;
            btnEditar.ToolTipText = _controladorBase.ToolTipEditar;
            btnExcluir.ToolTipText = _controladorBase.ToolTipExcluir;
            barraAcoes.Visible = true;
        }

        private void ResetarBotoes()
        {
            bool temLinhaSelecionada = _grid.SelectedRows.Count > 0;

            btnEditar.Enabled = temLinhaSelecionada;
            btnExcluir.Enabled = temLinhaSelecionada;
        }
        #endregion

        #region CoresDinamicasBotoes
        private readonly Dictionary<Control, ToolStripButton> coresBotoes = new();

        private void ConfigurarBotoes()
        {
            coresBotoes.Add(injecao.Get<TabelaCategoriaAutomoveisControl>().Controls[0], btnCategoria);
            coresBotoes.Add(injecao.Get<TabelaFuncionarioControl>().Controls[0], btnFuncionario);
            coresBotoes.Add(injecao.Get<TabelaTaxaEServicoControl>().Controls[0], btnTaxa);
            coresBotoes.Add(injecao.Get<TabelaParceiroControl>().Controls[0], btnParceiro);
            coresBotoes.Add(injecao.Get<TabelaAutomovelControl>().Controls[0], btnAutomovel);
            coresBotoes.Add(injecao.Get<TabelaClienteControl>().Controls[0], btnCliente);
            coresBotoes.Add(injecao.Get<TabelaCupomControl>().Controls[0], btnCupom);
            coresBotoes.Add(injecao.Get<TabelaCondutoresControl>().Controls[0], btnCondutores);
            coresBotoes.Add(injecao.Get<TabelaPlanosCobrancasControl>().Controls[0], btnPlanosCobrancas);
            coresBotoes.Add(injecao.Get<TabelaAluguelControl>().Controls[0], btnAluguel);

            btnCategoria.MouseEnter += btnColor_MouseEnter;
            btnCategoria.MouseLeave += btnColor_MouseLeave;

            btnTaxa.MouseEnter += btnColor_MouseEnter;
            btnTaxa.MouseLeave += btnColor_MouseLeave;

            btnParceiro.MouseEnter += btnColor_MouseEnter;
            btnParceiro.MouseLeave += btnColor_MouseLeave;

            btnFuncionario.MouseEnter += btnColor_MouseEnter;
            btnFuncionario.MouseLeave += btnColor_MouseLeave;

            btnAutomovel.MouseEnter += btnColor_MouseEnter;
            btnAutomovel.MouseLeave += btnColor_MouseLeave;

            btnCliente.MouseEnter += btnColor_MouseEnter;
            btnCliente.MouseLeave += btnColor_MouseLeave;

            btnCupom.MouseEnter += btnColor_MouseEnter;
            btnCupom.MouseLeave += btnColor_MouseLeave;

            btnCondutores.MouseEnter += btnColor_MouseEnter;
            btnCondutores.MouseLeave += btnColor_MouseLeave;

            btnPlanosCobrancas.MouseEnter += btnColor_MouseEnter;
            btnPlanosCobrancas.MouseLeave += btnColor_MouseLeave;

            btnAluguel.MouseEnter += btnColor_MouseEnter;
            btnAluguel.MouseLeave += btnColor_MouseLeave;
        }

        private void btnColor_MouseEnter(object sender, EventArgs e)
        {
            ToolStripButton btn = (ToolStripButton)sender;
            btn.BackColor = Color.White;
            btn.ForeColor = Color.Black;
        }

        private void btnColor_MouseLeave(object sender, EventArgs e)
        {
            ToolStripButton btn = (ToolStripButton)sender;
            btn.BackColor = Color.Gainsboro;
            btn.ForeColor = Color.Black;
        }

        private void plPrincipal_ControlAdded(object sender, ControlEventArgs e)
        {
            coresBotoes.TryGetValue(e.Control, out ToolStripButton btn);

            btn.BackColor = Color.DimGray;
            btn.ForeColor = Color.White;
            btn.MouseLeave -= btnColor_MouseLeave;
            btn.MouseEnter -= btnColor_MouseEnter;
        }

        private void plPrincipal_ControlRemoved(object sender, ControlEventArgs e)
        {
            coresBotoes.TryGetValue(e.Control, out ToolStripButton btn);

            btn.BackColor = Color.Gainsboro;
            btn.ForeColor = Color.Black;
            btn.MouseLeave += btnColor_MouseLeave;
            btn.MouseEnter += btnColor_MouseEnter;
        }

        #endregion

    }
}