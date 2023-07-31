namespace LocadoraAutomoveis.WinApp.ModuloFuncionario
{
    partial class TabelaFuncionarioControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gridFuncionario = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gridFuncionario).BeginInit();
            SuspendLayout();
            // 
            // gridFuncionario
            // 
            gridFuncionario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridFuncionario.Dock = DockStyle.Fill;
            gridFuncionario.Location = new Point(0, 0);
            gridFuncionario.Name = "gridFuncionario";
            gridFuncionario.RowTemplate.Height = 25;
            gridFuncionario.Size = new Size(150, 150);
            gridFuncionario.TabIndex = 0;
            // 
            // TabelaFuncionarioControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gridFuncionario);
            Name = "TabelaFuncionarioControl";
            ((System.ComponentModel.ISupportInitialize)gridFuncionario).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridFuncionario;
    }
}
