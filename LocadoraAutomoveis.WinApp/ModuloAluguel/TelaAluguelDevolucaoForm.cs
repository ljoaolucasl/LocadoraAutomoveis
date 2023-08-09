using FluentResults;
using LocadoraAutomoveis.Aplicacao.Compartilhado;
using LocadoraAutomoveis.Dominio.Extensions;
using LocadoraAutomoveis.Dominio.ModuloAluguel;
using LocadoraAutomoveis.Dominio.ModuloAutomovel;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Dominio.ModuloCondutores;
using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using LocadoraAutomoveis.Dominio.ModuloPlanosCobrancas;
using LocadoraAutomoveis.Dominio.ModuloTaxaEServico;
using LocadoraAutomoveis.WinApp.Extensions;

namespace LocadoraAutomoveis.WinApp.ModuloAluguel
{
    public partial class TelaAluguelDevolucaoForm : Form, ITelaAluguel
    {
        private Aluguel _aluguel;

        private Result _resultado;

        private List<PlanoCobranca> planosCobrancas;

        public event Func<Aluguel, Result> OnGravarRegistro;

        public event Func<Aluguel, Result> OnValidarEObterCupom;

        public TelaAluguelDevolucaoForm()
        {
            InitializeComponent();

            this.ConfigurarDialog();

            _resultado = new Result();

            _aluguel = new Aluguel();

            txtKmPercorrida.Controls[0].Visible = false;
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

            this.planosCobrancas = new List<PlanoCobranca>(planosCobrancas);

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
                cmbPlanoCobranca.Text = value.Plano.ToDescriptionString();
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

            if (cmbCategoriaAutomoveis.SelectedItem is CategoriaAutomoveis categoriaEscolhida)
                _aluguel.PlanoCobranca = planosCobrancas.Find(p => p.CategoriaAutomoveis.ID == categoriaEscolhida.ID);

            if (cmbPlanoCobranca.SelectedItem == null)
                _aluguel.Plano = (TipoPlano)100;
            else
            _aluguel.Plano = Utils.GetEnumValueFromDescription<TipoPlano>(cmbPlanoCobranca.SelectedItem as string);

            _aluguel.Condutor = cmbCondutor.SelectedItem as Condutor;
            _aluguel.Automovel = cmbAutomovel.SelectedItem as Automovel;
            _aluguel.DataLocacao = Convert.ToDateTime(dateLocacao.Value);
            _aluguel.DataDevolucao = Convert.ToDateTime(dateDevolucao.Value);
            _aluguel.DataPrevistaRetorno = Convert.ToDateTime(datePrevistaRetorno.Value);
            _aluguel.CombustivelRestante = Utils.GetEnumValueFromDescription<NivelTanque>(cmbNivelTanque.SelectedItem as string);
            _aluguel.QuilometrosRodados = Convert.ToDecimal(txtKmPercorrida.Value);
            _aluguel.Automovel.Quilometragem = Convert.ToDecimal(txtKmAutomovel.Value);
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
                    case "DataDevolucao": lbErroDataDevolucao.Text = item.ErrorMessage; lbErroDataDevolucao.Visible = true; dateDevolucao.Focus(); break;
                    case "KmPercorrida": lbErroKmPercorrida.Text = item.ErrorMessage; lbErroKmPercorrida.Visible = true; txtKmPercorrida.Focus(); break;
                    case "TipoCombustivel": lbErroNivelTanque.Text = item.ErrorMessage; lbErroNivelTanque.Visible = true; cmbNivelTanque.Focus(); break;
                    case "Cupom": lbErroCupom.Text = item.ErrorMessage; lbErroCupom.Visible = true; txtCupom.Focus(); break;
                    case "Taxas": lbErroTaxas.Text = item.ErrorMessage; lbErroTaxas.Visible = true; listTaxas.Focus(); break;
                    case "ValorTotal": lbErroValorTotal.Text = item.ErrorMessage; lbErroValorTotal.Visible = true; lbValorTotal.Focus(); break;
                }
            }
        }

        private void ResetarErros()
        {
            lbErroDataDevolucao.Visible = false;
            lbErroNivelTanque.Visible = false;
            lbErroKmPercorrida.Visible = false;
            lbErroCupom.Visible = false;
            lbErroTaxas.Visible = false;
            lbErroValorTotal.Visible = false;

            _resultado.Errors.Clear();
            _resultado.Reasons.Clear();
        }
    }
}
