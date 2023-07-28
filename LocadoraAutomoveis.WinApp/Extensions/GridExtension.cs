namespace LocadoraAutomoveis.WinApp.Extensions
{
    public static class GridExtension
    {
        public static void ConfigurarTabelaGrid(this DataGridView grid, params string[] addColumns)
        {
            List<DataGridViewColumn> colunas = new();

            for (int i = 0; i < addColumns.Length; i++)
            {
                DataGridViewTextBoxColumn coluna = new()
                {
                    Name = "Column" + i,
                    HeaderText = addColumns[i],
                };

                colunas.Add(coluna);
            }

            grid.Columns.AddRange(colunas.ToArray());

            ConfiguracaoPadrao(grid);
        }

        private static void ConfiguracaoPadrao(DataGridView grid)
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new();
            DataGridViewCellStyle dataGridViewCellStyle2 = new();
            DataGridViewCellStyle dataGridViewCellStyle3 = new();

            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeColumns = false;
            grid.AllowUserToResizeRows = false;

            dataGridViewCellStyle1.BackColor = Color.LightGray;
            dataGridViewCellStyle1.SelectionBackColor = Color.LightYellow;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;

            grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.BackgroundColor = SystemColors.Control;
            grid.MultiSelect = false;
            grid.RowHeadersVisible = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;

            grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.LightYellow;
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;

            grid.DefaultCellStyle = dataGridViewCellStyle3;
            grid.Dock = DockStyle.Fill;
            grid.ReadOnly = true;
        }
    }
}
