using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloPlanosCobrancas;
using LocadoraAutomoveis.WinApp.Extensions;

namespace LocadoraAutomoveis.WinApp.ModuloPlanosCobrancas
{
    public partial class TabelaPlanosCobrancasControl : UserControl, ITabelaBase<PlanoCobranca>
    {
        public TabelaPlanosCobrancasControl()
        {
            InitializeComponent();

            gridPlanosCobrancas.ConfigurarTabelaGrid("Número, Nome, Valor/Dia, Valor/Km Rodado, Km livre, Tipo do Plano");
        }

        public void AtualizarLista(List<PlanoCobranca> padroes)
        {
            gridPlanosCobrancas.Rows.Clear();

            foreach (PlanoCobranca item in padroes)
            {
                DataGridViewRow row = new();
                row.CreateCells(gridPlanosCobrancas, item.ID, item.Nome);
                row.Cells[0].Tag = item;
                gridPlanosCobrancas.Rows.Add(row);
            }

            TelaPrincipalForm.AtualizarStatus($"Visualizando {padroes.Count} Padrões");
        }

        public PlanoCobranca ObterRegistroSelecionado()
        {
            throw new NotImplementedException();
        }
    }
}
