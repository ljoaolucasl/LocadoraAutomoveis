using LocadoraAutomoveis.Aplicacao.Servicos;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;
using LocadoraAutomoveis.Infraestrutura.Repositorios;
using LocadoraAutomoveis.WinApp.Compartilhado;
using LocadoraAutomoveis.WinApp.ModuloCategoriaAutomoveis;

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

        public TelaPrincipalForm()
        {
            InitializeComponent();

            _telaPrincipal = this;

            ConfigurarInstancias();

            ConfigurarBotoesDicionario();
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
        }

        #region BotoesTabelas
        private void btnCategoria_Click(object sender, EventArgs e)
        {
            _controladorBase = new ControladorCategoriaAutomoveis(_repositorioCategoria, _servicoCategoria, _tabelaCategoria);
            ConfigurarTelaPrincipal();
        }
        #endregion

        #region CRUD
        private void btnAdd_Click(object sender, EventArgs e)
        {
            _controladorBase.Adicionar();
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
            _grid = _controladorBase.ObterTabela();
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

        private void ConfigurarBotoesDicionario()
        {
            coresBotoes.Add(_tabelaCategoria.Controls[0], btnCategoria);
        }

        private void btnColor_MouseEnter(object sender, EventArgs e)
        {
            ToolStripButton btn = (ToolStripButton)sender;
            btn.ForeColor = Color.Black;
        }

        private void btnColor_MouseLeave(object sender, EventArgs e)
        {
            ToolStripButton btn = (ToolStripButton)sender;
            btn.ForeColor = Color.White;
        }

        private void plPrincipal_ControlAdded(object sender, ControlEventArgs e)
        {
            coresBotoes.TryGetValue(e.Control, out ToolStripButton btn);

            btn.BackColor = Color.White;
            btn.ForeColor = Color.Black;
            btn.MouseLeave -= btnColor_MouseLeave;
        }

        private void plPrincipal_ControlRemoved(object sender, ControlEventArgs e)
        {
            coresBotoes.TryGetValue(e.Control.Controls[0], out ToolStripButton btn);

            btn.BackColor = Color.FromArgb(0, 165, 100);
            btn.ForeColor = Color.White;
            btn.MouseLeave += btnColor_MouseLeave;
        }
        #endregion
    }
}