using LocadoraAutomoveis.Dominio.ModuloAluguel;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
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

        public void AtualizarLista(List<CategoriaAutomoveis> categorias)
        {
            gridCategoriaAutomoveis.Rows.Clear();

            foreach (CategoriaAutomoveis item in categorias)
            {
                DataGridViewRow row = new();
                row.CreateCells(gridCategoriaAutomoveis, item.ID, item.Nome);
                row.Cells[0].Tag = item;
                gridCategoriaAutomoveis.Rows.Add(row);
            }

            gridCategoriaAutomoveis.Columns[0].Visible = false;
            string msg = categorias.Count >= 1 ? "Categorias" : "Categoria";
            TelaPrincipalForm.AtualizarStatus($"Visualizando {categorias.Count} {msg}");
        }

        public DataGridView ObterGrid()
        {
            return gridCategoriaAutomoveis;
        }

        public CategoriaAutomoveis ObterRegistroSelecionado()
        {
            return (CategoriaAutomoveis)gridCategoriaAutomoveis.SelectedRows[0].Cells[0].Tag;
        }
    }
}
