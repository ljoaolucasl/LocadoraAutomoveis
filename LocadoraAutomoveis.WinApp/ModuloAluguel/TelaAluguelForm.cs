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
            List<PlanoCobranca> planos, List<Condutor> condutores, List<Automovel> automoveis, List<Cupom> cupoms, List<TaxaEServico> taxaEServicos)
        {

        }

        public Aluguel? Entidade
        {
            get => _aluguel;

            set
            {
                cmbFuncionario.Text = value.Funcionario.ToString();
                cmbCliente.Text = value.Cliente.ToString();
                cmbGrupoAutomoveis.Text = value.CategoriaAutomoveis.ToString();
                cmbPlanoCobranca.Text = value.PlanoCobranca.ToString();
                cmbCondutor.Text = value.Condutor.ToString();
                cmbAutomovel.Text = value.Automovel.ToString();
                listTaxas.Text = value.ListaTaxasEServicos.ToString();
                txtCupom.Text = value.Cupom.ToString();

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

            return _aluguel;
        }

        private void MostrarErros()
        {
            foreach (CustomError item in _resultado.Errors)
            {
                switch (item.PropertyName)
                {

                }
            }
        }

        private void ResetarErros()
        {


            _resultado.Errors.Clear();
            _resultado.Reasons.Clear();
        }
    }
}
