using LocadoraAutomoveis.Aplicacao.Servicos;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloParceiro;
using LocadoraAutomoveis.Dominio.ModuloTaxaEServico;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;
using LocadoraAutomoveis.Infraestrutura.Repositorios;
using LocadoraAutomoveis.WinApp.Compartilhado;
using LocadoraAutomoveis.WinApp.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.WinApp.ModuloParceiro;
using LocadoraAutomoveis.WinApp.ModuloTaxaEServico;

namespace LocadoraAutomoveis.WinApp
{
    public partial class TelaPrincipalForm : Form
    {
        private static TelaPrincipalForm _telaPrincipal;

        private ContextoDados _contextoDb;

        private IControladorBase _controladorBase;

        private DataGridView _grid;

        private RepositorioCategoriaAutomoveis _repositorioCategoria;
        private ServicoCategoriaAutomoveis _servicoCategoria;
        private TabelaCategoriaAutomoveisControl _tabelaCategoria;

        private RepositorioTaxaEServico _repositorioTaxaEServico;
        private ServicoTaxaEServico _servicoTaxaEServico;
        private TabelaTaxaEServicoControl _tabelaTaxaEServico;

        private RepositorioParceiro _repositorioParceiro;
        private ServicoParceiro _servicoParceiro;
        private TabelaParceiroControl _tabelaParceiro;

        public TelaPrincipalForm()
        {
            InitializeComponent();

            _telaPrincipal = this;

            ConfigurarInstancias();

            ConfigurarBotoes();
        }

        public static void AtualizarStatus(string status)
        {
            _telaPrincipal.lbStatus.Text = status;
        }

        private void ConfigurarInstancias()
        {
            _contextoDb = new LocadoraAutomoveisDesignFactory().CreateDbContext(null);

            _repositorioCategoria = new RepositorioCategoriaAutomoveis(_contextoDb);
            _servicoCategoria = new ServicoCategoriaAutomoveis(_repositorioCategoria, new ValidadorCategoriaAutomoveis());
            _tabelaCategoria = new TabelaCategoriaAutomoveisControl();

            _repositorioTaxaEServico = new RepositorioTaxaEServico(_contextoDb);
            _servicoTaxaEServico = new ServicoTaxaEServico(_repositorioTaxaEServico, new ValidadorTaxaEServico());
            _tabelaTaxaEServico = new TabelaTaxaEServicoControl();

            _repositorioParceiro = new RepositorioParceiro(_contextoDb);
            _servicoParceiro = new ServicoParceiro(_repositorioParceiro, new ValidadorParceiro());
            _tabelaParceiro = new TabelaParceiroControl();
        }

        #region BotoesTabelas
        private void btnCategoria_Click(object sender, EventArgs e)
        {
            _controladorBase = new ControladorCategoriaAutomoveis(_repositorioCategoria, _servicoCategoria, _tabelaCategoria);
            ConfigurarTelaPrincipal();
        }

        private void btnTaxa_Click(object sender, EventArgs e)
        {
            _controladorBase = new ControladorTaxaEServico(_repositorioTaxaEServico, _servicoTaxaEServico, _tabelaTaxaEServico);
            ConfigurarTelaPrincipal();
        }

        private void btnParceiro_Click(object sender, EventArgs e)
        {
            _controladorBase = new ControladorParceiro(_repositorioParceiro, _servicoParceiro, _tabelaParceiro);
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
            coresBotoes.Add(_tabelaCategoria.Controls[0], btnCategoria);
            coresBotoes.Add(_tabelaTaxaEServico.Controls[0], btnTaxa);

            btnCategoria.MouseEnter += btnColor_MouseEnter;
            btnCategoria.MouseLeave += btnColor_MouseLeave;

            btnTaxa.MouseEnter += btnColor_MouseEnter;
            btnTaxa.MouseLeave += btnColor_MouseLeave;
            coresBotoes.Add(_tabelaParceiro.Controls[0], btnParceiro);
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