using FluentResults;
using LocadoraAutomoveis.Aplicacao.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloCupom;
using LocadoraAutomoveis.Dominio.ModuloParceiro;
using LocadoraAutomoveis.WinApp.Compartilhado;
using LocadoraAutomoveis.WinApp.Extensions;

namespace LocadoraAutomoveis.WinApp.ModuloCupom
{
    public partial class TelaCupomForm : Form, ITelaBase<Cupom>
    {
        private Cupom _cupom;

        private Result _resultado;

        public event Func<Cupom, Result> OnGravarRegistro;

        public TelaCupomForm()
        {
            InitializeComponent();

            this.ConfigurarDialog();

            _resultado = new Result();

            _cupom = new Cupom();
        }

        public Cupom? Entidade
        {
            get => _cupom;

            set
            {
                txtNome.Text = value.Nome;
                numValor.Value = value.Valor;
                dtpData.Value = value.DataValidade;
                cmbParceiro.Text = value.Parceiro.Nome;
                _cupom = value;
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
            _cupom = ObterCupom();

            _resultado = OnGravarRegistro(_cupom);

            if (_resultado.IsFailed)
                MostrarErros();
        }

        private Cupom ObterCupom()
        {
            _cupom.Nome = txtNome.Text;
            _cupom.Valor = numValor.Value;
            _cupom.DataValidade = dtpData.Value;
            _cupom.Parceiro = cmbParceiro.SelectedValue as Parceiro;

            return _cupom;
        }

        private void MostrarErros()
        {
            foreach (CustomError item in _resultado.Errors.Cast<CustomError>())
            {
                switch (item.PropertyName)
                {
                    case "Nome": lbErroNome.Text = item.ErrorMessage; lbErroNome.Visible = true; break;
                    case "Valor": lbErroValor.Text = item.ErrorMessage; lbErroValor.Visible = true; break;
                    case "DataValidade": lbErroData.Text = item.ErrorMessage; lbErroData.Visible = true; break;
                    case "Parceiro": lbErroParceiro.Text = item.ErrorMessage; lbErroParceiro.Visible = true; break;
                }
            }
        }

        private void ResetarErros()
        {
            lbErroNome.Visible = false;
            lbErroValor.Visible = false;
            lbErroData.Visible = false;
            lbErroParceiro.Visible = false;

            _resultado.Errors.Clear();
            _resultado.Reasons.Clear();
        }
    }
}
