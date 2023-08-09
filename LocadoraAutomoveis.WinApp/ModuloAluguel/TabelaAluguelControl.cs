using LocadoraAutomoveis.Dominio.Extensions;
using LocadoraAutomoveis.Dominio.ModuloAluguel;
using LocadoraAutomoveis.WinApp.Extensions;

namespace LocadoraAutomoveis.WinApp.ModuloAluguel
{
    public partial class TabelaAluguelControl : UserControl, ITabelaBase<Aluguel>
    {
        public TabelaAluguelControl()
        {
            InitializeComponent();

            gridAluguel.ConfigurarTabelaGrid("Número", "Condutor", "Automóvel", "Planos", "Data Locação", "Data Prevista", "Data Devolução", "Valor Total");
        }

        public void AtualizarLista(List<Aluguel> alugueis)
        {
            gridAluguel.Rows.Clear();

            foreach (Aluguel item in alugueis)
            {
                DataGridViewRow row = new();
                row.CreateCells(gridAluguel, item.ID, item.Condutor.Nome, item.Automovel.Placa, item.Plano.ToDescriptionString(), item.DataLocacao.ToString("d"), item.DataPrevistaRetorno.ToString("d"), item.DataDevolucao.HasValue ? item.DataDevolucao.Value.ToString("d") : "", item.ValorTotal.ToString("F2"));
                row.Cells[0].Tag = item;
                gridAluguel.Rows.Add(row);
            }

            gridAluguel.Columns[0].Visible = false;

            TelaPrincipalForm.AtualizarStatus($"Visualizando {alugueis.Count} Aluguéis");
        }

        public DataGridView ObterGrid()
        {
            return gridAluguel;
        }

        public Aluguel ObterRegistroSelecionado()
        {
            return (Aluguel)gridAluguel.SelectedRows[0].Cells[0].Tag;
        }
    }
}
