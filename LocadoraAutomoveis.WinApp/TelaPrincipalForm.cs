using LocadoraAutomoveis.Aplicacao.Servicos;
using LocadoraAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Dominio.ModuloCupom;
using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using LocadoraAutomoveis.Dominio.ModuloParceiro;
using LocadoraAutomoveis.Dominio.ModuloPlanosCobrancas;
using LocadoraAutomoveis.Dominio.ModuloTaxaEServico;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;
using LocadoraAutomoveis.Infraestrutura.Repositorios;
using LocadoraAutomoveis.WinApp.ModuloAutomovel;
using LocadoraAutomoveis.WinApp.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.WinApp.ModuloCupom;
using LocadoraAutomoveis.WinApp.ModuloCliente;
using LocadoraAutomoveis.WinApp.ModuloFuncionario;
using LocadoraAutomoveis.WinApp.ModuloParceiro;
using LocadoraAutomoveis.WinApp.ModuloPlanosCobrancas;
using LocadoraAutomoveis.WinApp.ModuloTaxaEServico;
using LocadoraAutomoveis.WinApp.ModuloCondutores;
using LocadoraAutomoveis.Dominio.ModuloCondutores;

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

        private RepositorioFuncionario _repositorioFuncionario;
        private ServicoFuncionario _servicoFuncionario;
        private TabelaFuncionarioControl _tabelaFuncionario;

        private RepositorioTaxaEServico _repositorioTaxaEServico;
        private ServicoTaxaEServico _servicoTaxaEServico;
        private TabelaTaxaEServicoControl _tabelaTaxaEServico;

        private RepositorioParceiro _repositorioParceiro;
        private ServicoParceiro _servicoParceiro;
        private TabelaParceiroControl _tabelaParceiro;

        private RepositorioAutomovel _repositorioAutomovel;
        private ServicoAutomovel _servicoAutomovel;
        private TabelaAutomovelControl _tabelaAutomovel;

        private RepositorioCliente _repositorioCliente;
        private ServicoCliente _servicoCliente;
        private TabelaClienteControl _tabelaCliente;

        private RepositorioCupom _repositorioCupom;
        private ServicoCupom _servicoCupom;
        private TabelaCupomControl _tabelaCupom;

        private RepositorioCondutores _repositorioCondutores;
        private ServicoCondutores _servicoCondutores;
        private TabelaCondutoresControl _tabelaCondutores;

        private RepositorioPlanosCobrancas _repositorioPlanosCobrancas;
        private ServicoPlanosCobrancas _servicoPlanosCobrancas;
        private TabelaPlanosCobrancasControl _tabelaPlanosCobrancas;

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

            _repositorioFuncionario = new RepositorioFuncionario(_contextoDb);
            _servicoFuncionario = new ServicoFuncionario(_repositorioFuncionario, new ValidadorFuncionario());
            _tabelaFuncionario = new TabelaFuncionarioControl();

            _repositorioTaxaEServico = new RepositorioTaxaEServico(_contextoDb);
            _servicoTaxaEServico = new ServicoTaxaEServico(_repositorioTaxaEServico, new ValidadorTaxaEServico());
            _tabelaTaxaEServico = new TabelaTaxaEServicoControl();

            _repositorioParceiro = new RepositorioParceiro(_contextoDb);
            _servicoParceiro = new ServicoParceiro(_repositorioParceiro, new ValidadorParceiro());
            _tabelaParceiro = new TabelaParceiroControl();

            _repositorioAutomovel = new RepositorioAutomovel(_contextoDb);
            _servicoAutomovel = new ServicoAutomovel(_repositorioAutomovel, new ValidadorAutomovel());
            _tabelaAutomovel = new TabelaAutomovelControl();

            _repositorioCliente = new RepositorioCliente(_contextoDb);
            _servicoCliente = new ServicoCliente(_repositorioCliente, new ValidadorCliente());
            _tabelaCliente = new TabelaClienteControl();

            _repositorioCupom = new RepositorioCupom(_contextoDb);
            _servicoCupom = new ServicoCupom(_repositorioCupom, new ValidadorCupom());
            _tabelaCupom = new TabelaCupomControl();

            _repositorioCondutores = new RepositorioCondutores(_contextoDb);
            _servicoCondutores = new ServicoCondutores(_repositorioCondutores, new ValidadorCondutores());
            _tabelaCondutores = new TabelaCondutoresControl();

            _repositorioPlanosCobrancas = new RepositorioPlanosCobrancas(_contextoDb);
            _servicoPlanosCobrancas = new ServicoPlanosCobrancas(_repositorioPlanosCobrancas, new ValidadorPlanosCobrancas());
            _tabelaPlanosCobrancas = new TabelaPlanosCobrancasControl();
        }

        #region BotoesTabelas
        private void btnCategoria_Click(object sender, EventArgs e)
        {
            _controladorBase = new ControladorCategoriaAutomoveis(_repositorioCategoria, _servicoCategoria, _tabelaCategoria);
            ConfigurarTelaPrincipal();
        }

        private void btnFuncionario_Click(object sender, EventArgs e)
        {
            _controladorBase = new ControladorFuncionario(_repositorioFuncionario, _servicoFuncionario, _tabelaFuncionario);
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

        private void btnAutomovel_Click(object sender, EventArgs e)
        {
            _controladorBase = new ControladorAutomovel(_repositorioAutomovel, _servicoAutomovel, _tabelaAutomovel, _servicoCategoria);
            ConfigurarTelaPrincipal();
        }

        private void btnFuncionario_Click_1(object sender, EventArgs e)
        {
            _controladorBase = new ControladorFuncionario(_repositorioFuncionario, _servicoFuncionario, _tabelaFuncionario);
            ConfigurarTelaPrincipal();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            _controladorBase = new ControladorCliente(_repositorioCliente, _servicoCliente, _tabelaCliente);
            ConfigurarTelaPrincipal();
        }

        private void btnCupom_Click(object sender, EventArgs e)
        {
            _controladorBase = new ControladorCupom(_repositorioCupom, _servicoCupom, _tabelaCupom, _servicoParceiro);
            ConfigurarTelaPrincipal();
        }

        private void btnCondutores_Click_1(object sender, EventArgs e)
        {
            _controladorBase = new ControladorCondutores(_repositorioCondutores, _servicoCondutores, _tabelaCondutores, _servicoCliente);
            ConfigurarTelaPrincipal();
        }

        private void btnPlanosCobrancas_Click(object sender, EventArgs e)
        {
            _controladorBase = new ControladorPlanosCobrancas(_repositorioPlanosCobrancas, _servicoPlanosCobrancas, _tabelaPlanosCobrancas, _servicoCategoria);
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
            coresBotoes.Add(_tabelaFuncionario.Controls[0], btnFuncionario);
            coresBotoes.Add(_tabelaTaxaEServico.Controls[0], btnTaxa);
            coresBotoes.Add(_tabelaParceiro.Controls[0], btnParceiro);
            coresBotoes.Add(_tabelaAutomovel.Controls[0], btnAutomovel);
            coresBotoes.Add(_tabelaCliente.Controls[0], btnCliente);
            coresBotoes.Add(_tabelaCupom.Controls[0], btnCupom);
            coresBotoes.Add(_tabelaCondutores.Controls[0], btnCondutores);
            coresBotoes.Add(_tabelaPlanosCobrancas.Controls[0], btnPlanosCobrancas);

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