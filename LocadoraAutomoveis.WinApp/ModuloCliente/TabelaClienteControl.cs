using LocadoraAutomoveis.Dominio.Extensions;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.WinApp.Compartilhado;
using LocadoraAutomoveis.WinApp.Extensions;

namespace LocadoraAutomoveis.WinApp.ModuloCliente
{
    public partial class TabelaClienteControl : UserControl, ITabelaBase<Cliente>
    {
        public TabelaClienteControl()
        {
            InitializeComponent();

            gridCliente.ConfigurarTabelaGrid("Id", "Nome", "Telefone", "Email", "Tipo Cliente", "Documento");
        }

        public void AtualizarLista(List<Cliente> padroes)
        {
            gridCliente.Rows.Clear();

            foreach (Cliente item in padroes)
            {
                DataGridViewRow row = new();
                row.CreateCells(gridCliente, item.ID, item.Nome, item.Telefone, item.Email,
                               item.TipoCliente.ToDescriptionString(), item.Documento);
                row.Cells[0].Tag = item;
                gridCliente.Rows.Add(row);
            }

            gridCliente.Columns[0].Visible = false;

            TelaPrincipalForm.AtualizarStatus($"Visualizando {padroes.Count} Cliente(s)");
        }

        public DataGridView ObterGrid()
        {
            return gridCliente;
        }

        public Cliente ObterRegistroSelecionado()
        {
            return (Cliente)gridCliente.SelectedRows[0].Cells[0].Tag;
        }
    }
}
