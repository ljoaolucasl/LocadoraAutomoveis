using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.WinApp.Compartilhado;
using LocadoraAutomoveis.WinApp.Extensions;

namespace LocadoraAutomoveis.WinApp.ModuloCategoriaAutomoveis
{
    public partial class TabelaCategoriaAutomoveisControl : UserControl, ITabelaBase<CategoriaAutomoveis>
    {
        public TabelaCategoriaAutomoveisControl()
        {
            InitializeComponent();

            gridCategoriaAutomoveis.ConfigurarTabelaGrid("Número", "Nome");
        }

        public void AtualizarLista(List<CategoriaAutomoveis> padroes)
        {
            gridCategoriaAutomoveis.Rows.Clear();

            foreach (CategoriaAutomoveis item in padroes)
            {
                DataGridViewRow row = new();
                row.CreateCells(gridCategoriaAutomoveis, item.ID, item.Nome);
                row.Cells[0].Tag = item;
                gridCategoriaAutomoveis.Rows.Add(row);
            }

            gridCategoriaAutomoveis.Columns[0].Visible = false;

            TelaPrincipalForm.AtualizarStatus($"Visualizando {padroes.Count} Padrões");
        }

        public CategoriaAutomoveis ObterRegistroSelecionado()
        {
            return (CategoriaAutomoveis)gridCategoriaAutomoveis.SelectedRows[0].Cells[0].Tag;
        }
    }
}
