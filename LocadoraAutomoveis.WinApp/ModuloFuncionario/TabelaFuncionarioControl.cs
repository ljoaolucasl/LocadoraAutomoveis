using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using LocadoraAutomoveis.WinApp.Extensions;

namespace LocadoraAutomoveis.WinApp.ModuloFuncionario
{
    public partial class TabelaFuncionarioControl : UserControl, ITabelaBase<Funcionario>
    {
        public TabelaFuncionarioControl()
        {
            InitializeComponent();

            gridFuncionario.ConfigurarTabelaGrid("Número", "Nome", "Admissão", "Salário");
        }

        public void AtualizarLista(List<Funcionario> padroes)
        {
            gridFuncionario.Rows.Clear();

            foreach (Funcionario item in padroes)
            {
                DataGridViewRow row = new();
                row.CreateCells(gridFuncionario, item.ID, item.Nome, item.Admissao.ToString("d"), item.Salario);
                row.Cells[0].Tag = item;
                gridFuncionario.Rows.Add(row);
            }

            gridFuncionario.Columns[0].Visible = false;

            TelaPrincipalForm.AtualizarStatus($"Visualizando {padroes.Count} Funcionário(s)");
        }

        public DataGridView ObterGrid()
        {
            return gridFuncionario;
        }

        public Funcionario ObterRegistroSelecionado()
        {
            return (Funcionario)gridFuncionario.SelectedRows[0].Cells[0].Tag;
        }
    }
}
