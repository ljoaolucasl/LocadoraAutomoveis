using FluentResults;
using LocadoraAutomoveis.Aplicacao.Compartilhado;
using LocadoraAutomoveis.Dominio.Extensions;
using LocadoraAutomoveis.Dominio.ModuloAluguel;
using LocadoraAutomoveis.Dominio.ModuloAutomovel;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Dominio.ModuloCondutores;
using LocadoraAutomoveis.Dominio.ModuloCupom;
using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using LocadoraAutomoveis.Dominio.ModuloPlanosCobrancas;
using LocadoraAutomoveis.Dominio.ModuloTaxaEServico;
using LocadoraAutomoveis.WinApp.Extensions;

namespace LocadoraAutomoveis.WinApp.ModuloAluguel
{
    public partial class TelaAluguelForm : Form, ITelaAluguel
    {
        private Aluguel _aluguel;

        private Result _resultado;

        public event Func<Aluguel, Result> OnGravarRegistro;

        public event Func<Aluguel, Result> OnValidarEObterCupom;

        public event Func<Aluguel, decimal> OnCalcularAluguelPrevisto;

        public event Func<Aluguel, decimal> OnCalcularAluguelFinal;

        private List<Automovel> automoveis;

        private List<Condutor> condutores;

        private List<PlanoCobranca> planosCobrancas;

        public TelaAluguelForm()
        {
            InitializeComponent();

            this.ConfigurarDialog();

            _resultado = new Result();

            _aluguel = new Aluguel();

            txtKmAutomovel.Controls[0].Visible = false;
        }

        public void CarregarDependencias(List<Funcionario> funcionarios, List<Cliente> clientes, List<CategoriaAutomoveis> categorias,
            List<PlanoCobranca> planosCobrancas, List<Condutor> condutores, List<Automovel> automoveis, List<TaxaEServico> taxaEServicos)
        {
            cmbFuncionario.DataSource = funcionarios;
            cmbFuncionario.DisplayMember = "Nome";
            cmbFuncionario.ValueMember = "ID";

            cmbCliente.DataSource = clientes;
            cmbCliente.DisplayMember = "Nome";
            cmbCliente.ValueMember = "ID";

            cmbCategoriaAutomoveis.DataSource = categorias;
            cmbCategoriaAutomoveis.DisplayMember = "Nome";
            cmbCategoriaAutomoveis.ValueMember = "ID";

            cmbPlanoCobranca.DataSource = Enum.GetValues<TipoPlano>()
                            .Select(plano => plano.ToDescriptionString())
                            .ToList();

            this.condutores = new List<Condutor>(condutores);

            this.automoveis = new List<Automovel>(automoveis);

            this.planosCobrancas = new List<PlanoCobranca>(planosCobrancas);

            listTaxas.DataSource = taxaEServicos;
            listTaxas.DisplayMember = "Nome";
            listTaxas.ValueMember = "ID";

            if (cmbCategoriaAutomoveis.SelectedItem is CategoriaAutomoveis categoriaEscolhida)
                cmbAutomovel.DataSource = automoveis.FindAll(x => x.Categoria.ID == categoriaEscolhida.ID);
            cmbAutomovel.DisplayMember = "Placa";
            cmbAutomovel.ValueMember = "ID";

            if (cmbCliente.SelectedItem is Cliente clienteEscolhido)
                cmbCondutor.DataSource = condutores.FindAll(x => x.Cliente.ID == clienteEscolhido.ID);
            cmbCondutor.DisplayMember = "Nome";
            cmbCondutor.ValueMember = "ID";

            if (cmbAutomovel.SelectedItem is Automovel automovelEscolhido)
                txtKmAutomovel.Value = automovelEscolhido.Quilometragem;
        }

        public Aluguel? Entidade
        {
            get => _aluguel;

            set
            {
                cmbFuncionario.Text = value.Funcionario.Nome;
                cmbCliente.Text = value.Cliente.Nome;
                cmbCategoriaAutomoveis.Text = value.CategoriaAutomoveis.Nome;
                cmbPlanoCobranca.Text = value.Plano.ToDescriptionString();
                cmbCondutor.Text = value.Condutor.Nome;
                cmbAutomovel.Text = value.Automovel.Placa;
                value.Automovel.Alugado = false;
                for (int i = 0; i < value.ListaTaxasEServicos.Count; i++)
                {
                    for (int j = 0; j < listTaxas.Items.Count; j++)
                    {
                        if (listTaxas.Items[j] == value.ListaTaxasEServicos[i])
                            listTaxas.SetItemChecked(j, true);
                    }
                }
                txtCupom.Text = value.Cupom == null ? "" : value.Cupom.Nome;
                dateLocacao.Value = value.DataLocacao;
                datePrevistaRetorno.Value = value.DataPrevistaRetorno;
                _aluguel = value;
            }
        }

        private void btnCupom_Click(object sender, EventArgs e)
        {
            ResetarErros();

            _aluguel.Cupom = txtCupom.Text == "" ? null : new Cupom() { Nome = txtCupom.Text };

            _resultado = OnValidarEObterCupom(_aluguel);

            CalcularValorTotal();

            if (_resultado.IsFailed)
            {
                MostrarErros();
                return;
            }
            else if (_aluguel.Cupom != null)
            {
                lbErroCupom.Text = "Cupom aplicado!";
                lbErroCupom.Visible = true;
                lbErroCupom.ForeColor = Color.Green;
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

            _aluguel = ObterAluguel();

            _resultado = OnGravarRegistro(_aluguel);

            if (_resultado.IsFailed)
            {
                _aluguel.Automovel.Alugado = false;
                MostrarErros();
            }
        }

        private Aluguel ObterAluguel()
        {
            _aluguel.Funcionario = cmbFuncionario.SelectedItem as Funcionario;
            _aluguel.Cliente = cmbCliente.SelectedItem as Cliente;
            _aluguel.CategoriaAutomoveis = cmbCategoriaAutomoveis.SelectedItem as CategoriaAutomoveis;

            if (cmbCategoriaAutomoveis.SelectedItem is CategoriaAutomoveis categoriaEscolhida)
                _aluguel.PlanoCobranca = planosCobrancas.Find(p => p.CategoriaAutomoveis.ID == categoriaEscolhida.ID);

            if (cmbPlanoCobranca.SelectedItem == null)
                _aluguel.Plano = (TipoPlano)100;
            else
                _aluguel.Plano = Utils.GetEnumValueFromDescription<TipoPlano>(cmbPlanoCobranca.SelectedItem as string);

            _aluguel.Condutor = cmbCondutor.SelectedItem as Condutor;
            _aluguel.Automovel = cmbAutomovel.SelectedItem as Automovel;
            _aluguel.ListaTaxasEServicos = listTaxas.CheckedItems.Cast<TaxaEServico>().ToList();
            _aluguel.DataLocacao = dateLocacao.Value;
            _aluguel.DataPrevistaRetorno = datePrevistaRetorno.Value;
            _aluguel.ValorTotal = Convert.ToDecimal(lbValorTotal.Text);
            _aluguel.Concluido = false;

            return _aluguel;
        }

        private void MostrarErros()
        {
            foreach (CustomError item in _resultado.Errors)
            {
                switch (item.PropertyName)
                {
                    case "Funcionario": lbErroFuncionario.Text = item.ErrorMessage; lbErroFuncionario.Visible = true; cmbFuncionario.Focus(); break;
                    case "Cliente": lbErroCliente.Text = item.ErrorMessage; lbErroCliente.Visible = true; cmbCliente.Focus(); break;
                    case "CategoriaAutomoveis": lbErroGrupoAutomoveis.Text = item.ErrorMessage; lbErroGrupoAutomoveis.Visible = true; cmbCategoriaAutomoveis.Focus(); break;
                    case "PlanoCobranca": lbErroPlanoCobranca.Text = item.ErrorMessage; lbErroPlanoCobranca.Visible = true; cmbPlanoCobranca.Focus(); break;
                    case "Plano": lbErroPlanoCobranca.Text = item.ErrorMessage; lbErroPlanoCobranca.Visible = true; cmbPlanoCobranca.Focus(); break;
                    case "Condutor": lbErroCondutor.Text = item.ErrorMessage; lbErroCondutor.Visible = true; cmbCondutor.Focus(); break;
                    case "Automovel": lbErroAutomovel.Text = item.ErrorMessage; lbErroAutomovel.Visible = true; cmbAutomovel.Focus(); break;
                    case "DataLocacao": lbErroDataLocacao.Text = item.ErrorMessage; lbErroDataLocacao.Visible = true; dateLocacao.Focus(); break;
                    case "DataDevolucao": lbErroDataDevolucao.Text = item.ErrorMessage; lbErroDataDevolucao.Visible = true; datePrevistaRetorno.Focus(); break;
                    case "KmAutomovel": lbErroKmAutomovel.Text = item.ErrorMessage; lbErroKmAutomovel.Visible = true; txtKmAutomovel.Focus(); break;
                    case "Cupom": lbErroCupom.Text = item.ErrorMessage; lbErroCupom.Visible = true; lbErroCupom.ForeColor = Color.FromArgb(192, 0, 0); txtCupom.Focus(); break;
                    case "Taxas": lbErroTaxas.Text = item.ErrorMessage; lbErroTaxas.Visible = true; listTaxas.Focus(); break;
                    case "ValorTotal": lbErroValorTotal.Text = item.ErrorMessage; lbErroValorTotal.Visible = true; lbValorTotal.Focus(); break;
                }
            }
        }

        private void ResetarErros()
        {
            lbErroFuncionario.Visible = false;
            lbErroCliente.Visible = false;
            lbErroGrupoAutomoveis.Visible = false;
            lbErroPlanoCobranca.Visible = false;
            lbErroCondutor.Visible = false;
            lbErroAutomovel.Visible = false;
            lbErroDataLocacao.Visible = false;
            lbErroDataDevolucao.Visible = false;
            lbErroKmAutomovel.Visible = false;
            lbErroCupom.Visible = false;
            lbErroTaxas.Visible = false;
            lbErroValorTotal.Visible = false;

            _resultado.Errors.Clear();
            _resultado.Reasons.Clear();
        }

        private void cmbAutomovel_SelectedValueChanged(object sender, EventArgs e)
        {
            txtKmAutomovel.Value = 0;

            if (cmbAutomovel.SelectedItem is Automovel automovelEscolhido)
                txtKmAutomovel.Value = automovelEscolhido.Quilometragem;
        }

        private void cmbCategoriaAutomoveis_SelectedValueChanged(object sender, EventArgs e)
        {
            cmbAutomovel.SelectedIndex = -1;

            if (cmbCategoriaAutomoveis.SelectedItem is CategoriaAutomoveis categoriaEscolhida)
                cmbAutomovel.DataSource = automoveis.FindAll(x => x.Categoria.ID == categoriaEscolhida.ID);
            cmbAutomovel.DisplayMember = "Placa";
            cmbAutomovel.ValueMember = "ID";
        }

        private void cmbCliente_SelectedValueChanged(object sender, EventArgs e)
        {
            cmbCondutor.SelectedIndex = -1;

            if (cmbCliente.SelectedItem is Cliente clienteEscolhido)
                cmbCondutor.DataSource = condutores.FindAll(x => x.Cliente.ID == clienteEscolhido.ID);
            cmbCondutor.DisplayMember = "Nome";
            cmbCondutor.ValueMember = "ID";
        }

        private void TelaAluguelForm_Shown(object sender, EventArgs e)
        {
            cmbAutomovel.SelectedValueChanged += cmbAutomovel_SelectedValueChanged;
            cmbCliente.SelectedValueChanged += cmbCliente_SelectedValueChanged;
            cmbCategoriaAutomoveis.SelectedValueChanged += cmbCategoriaAutomoveis_SelectedValueChanged;
        }

        private void atualizarValor_SelectedValueChanged(object sender, EventArgs e)
        {
            CalcularValorTotal();
        }
        private void listTaxas_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CalcularValorTotal();
        }

        private void CalcularValorTotal()
        {
            _aluguel = ObterAluguel();

            lbValorTotal.Text = OnCalcularAluguelPrevisto(_aluguel).ToString("F2");
        }

    }
}