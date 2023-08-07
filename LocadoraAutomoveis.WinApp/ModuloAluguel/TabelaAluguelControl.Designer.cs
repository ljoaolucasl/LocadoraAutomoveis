namespace LocadoraAutomoveis.WinApp.ModuloAluguel
{
    partial class TabelaAluguelControl
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
            gridAluguel = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gridAluguel).BeginInit();
            SuspendLayout();
            // 
            // gridAluguel
            // 
            gridAluguel.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridAluguel.Location = new Point(0, 0);
            gridAluguel.Name = "gridAluguel";
            gridAluguel.RowTemplate.Height = 25;
            gridAluguel.Size = new Size(150, 150);
            gridAluguel.TabIndex = 0;
            // 
            // TabelaAluguelControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gridAluguel);
            Name = "TabelaAluguelControl";
            ((System.ComponentModel.ISupportInitialize)gridAluguel).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridAluguel;
    }
}
