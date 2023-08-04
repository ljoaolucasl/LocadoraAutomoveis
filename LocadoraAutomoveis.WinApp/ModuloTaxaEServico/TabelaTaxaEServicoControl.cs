using LocadoraAutomoveis.Dominio.Extensions;
using LocadoraAutomoveis.Dominio.ModuloTaxaEServico;
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

        public void AtualizarLista(List<TaxaEServico> taxas)
        {
            gridTaxaEServico.Rows.Clear();

            foreach (TaxaEServico item in taxas)
            {
                DataGridViewRow row = new();
                row.CreateCells(gridTaxaEServico, item.ID, item.Nome, "R$" + item.Valor.ToString("F2"), item.Tipo.ToDescriptionString());
                row.Cells[0].Tag = item;
                gridTaxaEServico.Rows.Add(row);
            }

            gridTaxaEServico.Columns[0].Visible = false;

            TelaPrincipalForm.AtualizarStatus($"Visualizando {taxas.Count} Taxas e Serviços");
        }

        public DataGridView ObterGrid()
        {
            return gridTaxaEServico;
        }

        public TaxaEServico ObterRegistroSelecionado()
        {
            return (TaxaEServico)gridTaxaEServico.SelectedRows[0].Cells[0].Tag;
        }
    }
}
