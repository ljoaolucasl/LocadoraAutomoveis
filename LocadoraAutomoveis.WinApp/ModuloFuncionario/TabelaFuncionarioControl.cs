using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using LocadoraAutomoveis.WinApp.Compartilhado;
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
                row.CreateCells(gridFuncionario, item.ID, item.Nome, item.Admissao, item.Salario);
                row.Cells[0].Tag = item;
                gridFuncionario.Rows.Add(row);
            }

            TelaPrincipalForm.AtualizarStatus($"Visualizando {padroes.Count} Padrões");
        }

        public Funcionario ObterRegistroSelecionado()
        {
            return (Funcionario)gridFuncionario.SelectedRows[0].Cells[0].Tag;
        }
    }
}
