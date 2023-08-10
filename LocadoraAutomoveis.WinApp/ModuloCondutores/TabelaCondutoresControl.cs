using LocadoraAutomoveis.Dominio.ModuloAutomovel;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Dominio.ModuloCondutores;
using LocadoraAutomoveis.WinApp.Compartilhado;
using LocadoraAutomoveis.WinApp.Extensions;

namespace LocadoraAutomoveis.WinApp.ModuloCondutores
{
    public partial class TabelaCondutoresControl : UserControl, ITabelaBase<Condutor>
    {
        public TabelaCondutoresControl()
        {
            InitializeComponent();

            gridCondutores.ConfigurarTabelaGrid("Número", "Nome Condutor", "Nome Cliente", "CPF", "CNH", "Validade");
        }

        public void AtualizarLista(List<Condutor> condutores)
        {
            gridCondutores.Rows.Clear();

            foreach (Condutor item in condutores)
            {
                DataGridViewRow row = new();
                row.CreateCells(gridCondutores, item.ID, item.Nome, item.Cliente.Nome, item.CPF, item.CNH, item.Validade.ToString("d"));
                row.Cells[0].Tag = item;
                gridCondutores.Rows.Add(row);
            }

            gridCondutores.Columns[0].Visible = false;
            string msg = condutores.Count >= 1 ? "Condutores" : "Condutor";
            TelaPrincipalForm.AtualizarStatus($"Visualizando {condutores.Count} {msg}");
        }

        public DataGridView ObterGrid()
        {
            return gridCondutores;
        }

        public Condutor ObterRegistroSelecionado()
        {
            return (Condutor)gridCondutores.SelectedRows[0].Cells[0].Tag;
        }
    }
}
