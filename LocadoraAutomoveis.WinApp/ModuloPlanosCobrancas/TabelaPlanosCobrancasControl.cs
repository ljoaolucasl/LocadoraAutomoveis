using LocadoraAutomoveis.Dominio.ModuloParceiro;
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
                row.CreateCells(gridPlanosCobrancas, item.ID, item.CategoriaAutomoveis.Nome, $"R$ {item.PlanoDiario_ValorDiario}", $"R$ {item.PlanoDiario_ValorKm}", $"R$ {item.PlanoLivre_ValorDiario}", $"R$ {item.PlanoControlador_ValorDiario}", $"R$ {item.PlanoControlador_ValorKm}", item.PlanoControlador_LimiteKm);
                row.Cells[0].Tag = item;
                gridPlanosCobrancas.Rows.Add(row);
            }

            gridPlanosCobrancas.Columns[0].Visible = false;
            string msg = planosCobrancas.Count >= 1 ? "Planos de Cobranças" : "Plano de Cobrança";
            TelaPrincipalForm.AtualizarStatus($"Visualizando {planosCobrancas.Count} {msg}");
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
