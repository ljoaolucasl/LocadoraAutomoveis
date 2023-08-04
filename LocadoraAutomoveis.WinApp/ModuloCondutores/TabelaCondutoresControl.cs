using LocadoraAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloCondutores;
using LocadoraAutomoveis.WinApp.Compartilhado;
using LocadoraAutomoveis.WinApp.Extensions;

namespace LocadoraAutomoveis.WinApp.ModuloCondutores
{
    public partial class TabelaCondutoresControl : UserControl, ITabelaBase<Condutores>
    {
        public TabelaCondutoresControl()
        {
            InitializeComponent();

            gridCondutores.ConfigurarTabelaGrid("Número", "Nome Condutor", "Nome Cliente", "CPF", "CNH", "Validade");
        }

        public void AtualizarLista(List<Condutores> condutores)
        {
            gridCondutores.Rows.Clear();

            foreach (Condutores item in condutores)
            {
                DataGridViewRow row = new();
                row.CreateCells(gridCondutores, item.ID, item.Nome, item.Cliente.Nome, item.CPF, item.CNH, item.Validade);
                row.Cells[0].Tag = item;
                gridCondutores.Rows.Add(row);
            }

            gridCondutores.Columns[0].Visible = false;

            TelaPrincipalForm.AtualizarStatus($"Visualizando {condutores.Count} Categorias");
        }

        public DataGridView ObterGrid()
        {
            return gridCondutores;
        }

        public Condutores ObterRegistroSelecionado()
        {
            return (Condutores)gridCondutores.SelectedRows[0].Cells[0].Tag;
        }
    }
}
