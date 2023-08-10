using LocadoraAutomoveis.Dominio.ModuloCondutores;
using LocadoraAutomoveis.Dominio.ModuloCupom;
using LocadoraAutomoveis.WinApp.Extensions;

namespace LocadoraAutomoveis.WinApp.ModuloCupom
{
    public partial class TabelaCupomControl : UserControl, ITabelaBase<Cupom>
    {
        public TabelaCupomControl()
        {
            InitializeComponent();

            gridCupom.ConfigurarTabelaGrid("ID", "Nome", "Valor", "Data Validade", "Parceiro", "Usos");
        }

        public void AtualizarLista(List<Cupom> cupons)
        {
            gridCupom.Rows.Clear();

            foreach (Cupom item in cupons)
            {
                DataGridViewRow row = new();
                row.CreateCells(gridCupom, item.ID, item.Nome, $"R$ {item.Valor}", item.DataValidade.ToString("d"), item.Parceiro, item.QtdUsos > 0 ? item.QtdUsos : 0);
                row.Cells[0].Tag = item;
                gridCupom.Rows.Add(row);
            }

            gridCupom.Columns[0].Visible = false;
            string msg = cupons.Count >= 1 ? "Cupons" : "Cupom";
            TelaPrincipalForm.AtualizarStatus($"Visualizando {cupons.Count} {msg}");
        }

        public DataGridView ObterGrid()
        {
            return gridCupom;
        }

        public Cupom ObterRegistroSelecionado()
        {
            return (Cupom)gridCupom.SelectedRows[0].Cells[0].Tag;
        }
    }
}
