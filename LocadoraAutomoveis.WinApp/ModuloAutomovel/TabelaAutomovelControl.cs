using LocadoraAutomoveis.Dominio.Extensions;
using LocadoraAutomoveis.Dominio.ModuloAutomovel;
using LocadoraAutomoveis.WinApp.Extensions;

namespace LocadoraAutomoveis.WinApp.ModuloAutomovel
{
    public partial class TabelaAutomovelControl : UserControl, ITabelaBase<Automovel>
    {
        public TabelaAutomovelControl()
        {
            InitializeComponent();

            gridAutomovel.ConfigurarTabelaGrid("Número", "Placa", "Marca", "Cor", "Modelo", "Combustível", "Categoria");
        }

        public void AtualizarLista(List<Automovel> automoveis)
        {
            gridAutomovel.Rows.Clear();

            foreach (Automovel item in automoveis)
            {
                DataGridViewRow row = new();
                row.CreateCells(gridAutomovel, item.ID, item.Placa, item.Marca, item.Cor, item.Modelo, item.TipoCombustivel.ToDescriptionString(), item.Categoria.Nome);
                row.Cells[0].Tag = item;
                gridAutomovel.Rows.Add(row);
            }

            gridAutomovel.Columns[0].Visible = false;

            TelaPrincipalForm.AtualizarStatus($"Visualizando {automoveis.Count} Automóveis");
        }

        public DataGridView ObterGrid()
        {
            return gridAutomovel;
        }

        public Automovel ObterRegistroSelecionado()
        {
            return (Automovel)gridAutomovel.SelectedRows[0].Cells[0].Tag;
        }
    }
}
