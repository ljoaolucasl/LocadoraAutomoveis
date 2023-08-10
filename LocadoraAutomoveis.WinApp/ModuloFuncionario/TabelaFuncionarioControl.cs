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

        public void AtualizarLista(List<Funcionario> funcionarios)
        {
            gridFuncionario.Rows.Clear();

            foreach (Funcionario item in funcionarios)
            {
                DataGridViewRow row = new();
                row.CreateCells(gridFuncionario, item.ID, item.Nome, item.Admissao.ToString("d"), $"R$ {item.Salario}");
                row.Cells[0].Tag = item;
                gridFuncionario.Rows.Add(row);
            }

            gridFuncionario.Columns[0].Visible = false;
            string msg = funcionarios.Count >= 1 ? "Funcionários" : "Funcionário";
            TelaPrincipalForm.AtualizarStatus($"Visualizando {funcionarios.Count} {msg}");
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
