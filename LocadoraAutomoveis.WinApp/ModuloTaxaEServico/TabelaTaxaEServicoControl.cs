using LocadoraAutomoveis.Dominio.Extensions;
using LocadoraAutomoveis.Dominio.ModuloTaxaEServico;
using LocadoraAutomoveis.WinApp.Compartilhado;
using LocadoraAutomoveis.WinApp.Extensions;

namespace LocadoraAutomoveis.WinApp.ModuloTaxaEServico
{
    public partial class TabelaTaxaEServicoControl : UserControl, ITabelaBase<TaxaEServico>
    {
        public TabelaTaxaEServicoControl()
        {
            InitializeComponent();

            gridTaxaEServico.ConfigurarTabelaGrid("Número", "Nome", "Valor", "Tipo");
        }

        public void AtualizarLista(List<TaxaEServico> padroes)
        {
            gridTaxaEServico.Rows.Clear();

            foreach (TaxaEServico item in padroes)
            {
                DataGridViewRow row = new();
                row.CreateCells(gridTaxaEServico, item.ID, item.Nome, item.Valor, item.Tipo.ToDescriptionString());
                row.Cells[0].Tag = item;
                gridTaxaEServico.Rows.Add(row);
            }

            gridTaxaEServico.Columns[0].Visible = false;

            TelaPrincipalForm.AtualizarStatus($"Visualizando {padroes.Count} Padrões");
        }

        public TaxaEServico ObterRegistroSelecionado()
        {
            return (TaxaEServico)gridTaxaEServico.SelectedRows[0].Cells[0].Tag;
        }
    }
}
