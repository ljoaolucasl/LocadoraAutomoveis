using FluentResults;
using LocadoraAutomoveis.Aplicacao.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloAluguel;
using LocadoraAutomoveis.Dominio.ModuloAutomoveis;
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
    public partial class TelaAluguelForm : Form, ITelaBase<Aluguel>
    {
        private Aluguel _aluguel;

        private Result _resultado;

        public event Func<Aluguel, Result> OnGravarRegistro;

        public TelaAluguelForm()
        {
            InitializeComponent();

            this.ConfigurarDialog();

            _resultado = new Result();

            _aluguel = new Aluguel();

            txtKmAutomovel.Controls[0].Visible = false;
        }

        public void CarregarDependencias(List<Funcionario> funcionarios, List<Cliente> clientes, List<CategoriaAutomoveis> categorias,
            List<PlanoCobranca> planos, List<Condutor> condutores, List<Automovel> automoveis, List<TaxaEServico> taxaEServicos)
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

            cmbPlanoCobranca.DataSource = planos;
            cmbPlanoCobranca.DisplayMember = "Nome";
            cmbPlanoCobranca.ValueMember = "ID";

            cmbCondutor.DataSource = condutores;
            cmbCondutor.DisplayMember = "Nome";
            cmbCondutor.ValueMember = "ID";

            cmbAutomovel.DataSource = automoveis;
            cmbAutomovel.DisplayMember = "Placa";
            cmbAutomovel.ValueMember = "ID";

            listTaxas.DataSource = taxaEServicos;
            listTaxas.DisplayMember = "Nome";
            listTaxas.ValueMember = "ID";
        }

        public Aluguel? Entidade
        {
            get => _aluguel;

            set
            {
                cmbFuncionario.Text = value.Funcionario.Nome;
                cmbCliente.Text = value.Cliente.Nome;
                cmbCategoriaAutomoveis.Text = value.CategoriaAutomoveis.Nome;
                cmbPlanoCobranca.Text = value.PlanoCobranca.CategoriaAutomoveis.Nome;
                cmbCondutor.Text = value.Condutor.Nome;
                cmbAutomovel.Text = value.Automovel.Placa;
                listTaxas.Items.Clear();
                listTaxas.Items.AddRange(value.ListaTaxasEServicos.ToArray());
                txtCupom.Text = value.Cupom.Nome;

                _aluguel = value;
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
                MostrarErros();
        }

        private Aluguel ObterAluguel()
        {
            _aluguel.Funcionario = cmbFuncionario.SelectedItem as Funcionario;
            _aluguel.Cliente = cmbCliente.SelectedItem as Cliente;
            _aluguel.CategoriaAutomoveis = cmbFuncionario.SelectedItem as CategoriaAutomoveis;
            _aluguel.PlanoCobranca = cmbPlanoCobranca.SelectedItem as PlanoCobranca;
            _aluguel.Condutor = cmbCondutor.SelectedItem as Condutor;
            _aluguel.Automovel = cmbAutomovel.SelectedItem as Automovel;
            _aluguel.DataLocacao = Convert.ToDateTime(dateLocacao.Value);
            _aluguel.DataDevolucao = Convert.ToDateTime(dateDevolucao.Value);
            _aluguel.QuilometrosRodados = Convert.ToDecimal(txtKmAutomovel.Value);
            _aluguel.Cupom.Valor = Convert.ToDecimal(txtCupom);
            _aluguel.ListaTaxasEServicos = listTaxas.SelectedItem as List<TaxaEServico>;
            _aluguel.ValorTotal = Convert.ToDecimal(lbValorTotal);

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
                    case "Condutor": lbErroCondutor.Text = item.ErrorMessage; lbErroCondutor.Visible = true; cmbCondutor.Focus(); break;
                    case "Automovel": lbErroAutomovel.Text = item.ErrorMessage; lbErroAutomovel.Visible = true; cmbAutomovel.Focus(); break;
                    case "DataLocacao": lbErroDataLocacao.Text = item.ErrorMessage; lbErroDataLocacao.Visible = true; dateLocacao.Focus(); break;
                    case "DataDevolucao": lbErroDataDevolucao.Text = item.ErrorMessage; lbErroDataDevolucao.Visible = true; dateDevolucao.Focus(); break;
                    case "KmAutomovel": lbErroKmAutomovel.Text = item.ErrorMessage; lbErroKmAutomovel.Visible = true; txtKmAutomovel.Focus(); break;
                    case "Cupom": lbErroCupom.Text = item.ErrorMessage; lbErroCupom.Visible = true; txtCupom.Focus(); break;
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
    }
}
