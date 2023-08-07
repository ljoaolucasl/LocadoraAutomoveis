using FluentResults;
using LocadoraAutomoveis.Aplicacao.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloPlanosCobrancas;
using LocadoraAutomoveis.WinApp.Extensions;

namespace LocadoraAutomoveis.WinApp.ModuloPlanosCobrancas
{
    public partial class TelaPlanosCobrancasForm : Form, ITelaBase<PlanoCobranca>
    {
        private PlanoCobranca _planoCobranca;

        private Result _resultado;

        public event Func<PlanoCobranca, Result> OnGravarRegistro;
        public TelaPlanosCobrancasForm()
        {
            InitializeComponent();

            this.ConfigurarDialog();

            _resultado = new Result();

            _planoCobranca = new PlanoCobranca();

            numPrecoDiaria1.Controls[0].Visible = false;
            numPrecoKm1.Controls[0].Visible = false;
            numPrecoDiaria2.Controls[0].Visible = false;
            numPrecoKm2.Controls[0].Visible = false;
            numKmDisponivel2.Controls[0].Visible = false;
            numPrecoDiaria3.Controls[0].Visible = false;
        }

        public PlanoCobranca? Entidade
        {
            get => _planoCobranca;

            set
            {
                cmbCategoria.Text = value.CategoriaAutomoveis.Nome;
                numPrecoDiaria1.Value = value.PlanoDiario_ValorDiario;
                numPrecoKm1.Value = value.PlanoDiario_ValorKm;
                numPrecoDiaria2.Value = value.PlanoControlador_ValorDiario;
                numPrecoKm2.Value = value.PlanoControlador_ValorKm;
                numKmDisponivel2.Value = value.PlanoControlador_LimiteKm;
                numPrecoDiaria3.Value = value.PlanoLivre_ValorDiario;
                _planoCobranca = value;
            }
        }

        public void CarregarCategorias(List<CategoriaAutomoveis> categorias)
        {
            cmbCategoria.DataSource = categorias;
            cmbCategoria.DisplayMember = "Nome";
            cmbCategoria.ValueMember = "ID";
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

            _planoCobranca = ObterPlanoCobranca();

            _resultado = OnGravarRegistro(_planoCobranca);

            if (_resultado.IsFailed)
                MostrarErros();
        }

        private PlanoCobranca ObterPlanoCobranca()
        {
            _planoCobranca.CategoriaAutomoveis = cmbCategoria.SelectedItem as CategoriaAutomoveis;
            _planoCobranca.PlanoDiario_ValorDiario = numPrecoDiaria1.Value;
            _planoCobranca.PlanoDiario_ValorKm = numPrecoKm1.Value;
            _planoCobranca.PlanoControlador_ValorDiario = numPrecoDiaria2.Value;
            _planoCobranca.PlanoControlador_ValorKm = numPrecoKm2.Value;
            _planoCobranca.PlanoControlador_LimiteKm = (int)numKmDisponivel2.Value;
            _planoCobranca.PlanoLivre_ValorDiario = numPrecoDiaria3.Value;

            return _planoCobranca;
        }

        private void MostrarErros()
        {
            foreach (CustomError item in _resultado.Errors.Cast<CustomError>())
            {
                switch (item.PropertyName)
                {
                    case "CategoriaAutomoveis": lbErroCategoria.Text = item.ErrorMessage; lbErroCategoria.Visible = true; break;
                    case "PlanoDiario_ValorDiario": lbErroPrecoDiaria1.Text = item.ErrorMessage; lbErroPrecoDiaria1.Visible = true; break;
                    case "PlanoDiario_ValorKm": lbErroPrecoKm1.Text = item.ErrorMessage; lbErroPrecoKm1.Visible = true; break;
                    case "PlanoControlador_ValorDiario": lbErroPrecoDiaria2.Text = item.ErrorMessage; lbErroPrecoDiaria2.Visible = true; break;
                    case "PlanoControlador_ValorKm": lbErroPrecoKm2.Text = item.ErrorMessage; lbErroPrecoKm2.Visible = true; break;
                    case "PlanoControlador_LimiteKm": lbErroKmDisponivel2.Text = item.ErrorMessage; lbErroKmDisponivel2.Visible = true; break;
                    case "PlanoLivre_ValorDiario": lbErroPrecoDiaria3.Text = item.ErrorMessage; lbErroPrecoDiaria3.Visible = true; break;
                }
            }
        }

        private void ResetarErros()
        {
            lbErroCategoria.Visible = false;
            lbErroPrecoDiaria1.Visible = false;
            lbErroPrecoKm1.Visible = false;
            lbErroPrecoDiaria2.Visible = false;
            lbErroPrecoKm2.Visible = false;
            lbErroKmDisponivel2.Visible = false;
            lbErroPrecoDiaria3.Visible = false;

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
    }
}
