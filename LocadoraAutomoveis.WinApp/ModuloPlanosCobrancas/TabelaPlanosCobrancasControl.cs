using LocadoraAutomoveis.Dominio.ModuloPlanosCobrancas;
using LocadoraAutomoveis.WinApp.Extensions;

namespace LocadoraAutomoveis.WinApp.ModuloPlanosCobrancas
{
    public partial class TabelaPlanosCobrancasControl : UserControl, ITabelaBase<PlanoCobranca>
    {
        public TabelaPlanosCobrancasControl()
        {
            InitializeComponent();

            gridPlanosCobrancas.ConfigurarTabelaGrid("ID", "Categoria de Automóvel", "Diário - Valor/dia", "Diário - Valor/Km", "Livre - Valor/dia", "Controlador - Valor/dia", "Controlador - Valor/Km", "Controlador - Km Livre");
        }

        public void AtualizarLista(List<PlanoCobranca> planosCobrancas)
        {
            gridPlanosCobrancas.Rows.Clear();

            foreach (PlanoCobranca item in planosCobrancas)
            {
                DataGridViewRow row = new();
                row.CreateCells(gridPlanosCobrancas, item.ID, item.CategoriaAutomoveis.Nome, item.PlanoDiario_ValorDiario, item.PlanoDiario_ValorKm, item.PlanoLivre_ValorDiario, item.PlanoControlador_ValorDiario, item.PlanoControlador_ValorKm, item.PlanoControlador_LimiteKm);
                row.Cells[0].Tag = item;
                gridPlanosCobrancas.Rows.Add(row);
            }

            gridPlanosCobrancas.Columns[0].Visible = false;

            TelaPrincipalForm.AtualizarStatus($"Visualizando {planosCobrancas.Count} Planos de Cobrança");
        }

        public DataGridView ObterGrid()
        {
            return gridPlanosCobrancas;
        }

        public PlanoCobranca ObterRegistroSelecionado()
        {
            return (PlanoCobranca)gridPlanosCobrancas.SelectedRows[0].Cells[0].Tag;
        }
    }
}
