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

        public event Func<Aluguel, Result> OnGravarRegistro;

        public event Func<Aluguel, Result> OnValidarEObterCupom;

        public event Func<Aluguel, decimal> OnCalcularAluguelPrevisto;

        public event Func<Aluguel, decimal> OnCalcularAluguelFinal;

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
            listTaxas.DataSource = taxaEServicos;
            listTaxas.DisplayMember = "Nome";
            listTaxas.ValueMember = "ID";

            cmbNivelTanque.DataSource = Enum.GetValues(typeof(NivelTanque)).Cast<NivelTanque>().ToList()
                .ConvertAll(x => x.ToDescriptionString());
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
            _aluguel.DataDevolucao = Convert.ToDateTime(dateDevolucao.Value);

            if (cmbNivelTanque.SelectedItem == null)
                _aluguel.CombustivelRestante = (NivelTanque)100;
            else
                _aluguel.CombustivelRestante = Utils.GetEnumValueFromDescription<NivelTanque>(cmbNivelTanque.SelectedItem as string);

            _aluguel.QuilometrosRodados = Convert.ToDecimal(txtKmPercorrida.Value);
            _aluguel.ListaTaxasEServicos = listTaxas.CheckedItems.Cast<TaxaEServico>().ToList();
            _aluguel.ValorTotal = Convert.ToDecimal(lbValorTotal.Text);
            _aluguel.Concluido = true;

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
                    case "ListaTaxasEServicos": lbErroTaxas.Text = item.ErrorMessage; lbErroTaxas.Visible = true; listTaxas.Focus(); break;
                    case "ValorTotal": lbErroValorTotal.Text = item.ErrorMessage; lbErroValorTotal.Visible = true; lblTextoValor.Focus(); break;
                }
            }
        }

        private void ResetarErros()
        {
            lbErroDataDevolucao.Visible = false;
            lbErroNivelTanque.Visible = false;
            lbErroKmPercorrida.Visible = false;
            lbErroTaxas.Visible = false;
            lbErroValorTotal.Visible = false;

            _resultado.Errors.Clear();
            _resultado.Reasons.Clear();
        }

        private void selecaoAutomaticaNumericUpDown_Enter(object sender, EventArgs e)
        {
            ((TextBox)((NumericUpDown)sender).Controls[1]).SelectAll();
        }

        private void selecaoAutomaticaNumericUpDown_Click(object sender, EventArgs e)
        {
            if (((NumericUpDown)sender).Controls[1].Text == "0,00" || ((NumericUpDown)sender).Controls[1].Text == "0")
                ((TextBox)((NumericUpDown)sender).Controls[1]).SelectAll();
        }

        private void atualizarValor_SelectedValueChanged(object sender, EventArgs e)
        {
            CalcularValorTotalDevolucao();
        }

        private void CalcularValorTotalDevolucao()
        {
            _aluguel = ObterAluguel();

            lbValorTotal.Text = OnCalcularAluguelFinal(_aluguel).ToString("F2");
        }
    }
}
