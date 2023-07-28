using LocadoraAutomoveis.Dominio.ModuloPadrao;
using LocadoraAutomoveis.WinApp.Compartilhado;
using LocadoraAutomoveis.WinApp.Extensions;

namespace LocadoraAutomoveis.WinApp.ModuloPadrao
{
    public partial class TabelaPadraoControl : UserControl, ITabelaBase<Padrao>
    {
        public TabelaPadraoControl()
        {
            InitializeComponent();

            gridPadrao.ConfigurarTabelaGrid("Número", "Nome");
        }

        public void AtualizarLista(List<Padrao> padroes)
        {
            gridPadrao.Rows.Clear();

            foreach (Padrao item in padroes)
            {
                DataGridViewRow row = new();
                row.CreateCells(gridPadrao, item.ID, item.Nome);
                row.Cells[0].Tag = item;
                gridPadrao.Rows.Add(row);
            }

            TelaPrincipalForm.AtualizarStatus($"Visualizando {padroes.Count} Padrões");
        }

        public Padrao ObterRegistroSelecionado()
        {
            return (Padrao)gridPadrao.SelectedRows[0].Cells[0].Tag;
        }
    }
}
