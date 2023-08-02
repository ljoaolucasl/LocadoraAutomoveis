namespace LocadoraAutomoveis.WinApp.ModuloTaxaEServico
{
    partial class TabelaTaxaEServicoControl
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
            gridTaxaEServico = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gridTaxaEServico).BeginInit();
            SuspendLayout();
            // 
            // gridTaxaEServico
            // 
            gridTaxaEServico.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridTaxaEServico.Location = new Point(0, 0);
            gridTaxaEServico.Name = "gridTaxaEServico";
            gridTaxaEServico.RowTemplate.Height = 25;
            gridTaxaEServico.Size = new Size(150, 150);
            gridTaxaEServico.TabIndex = 0;
            // 
            // TabelaTaxaEServicoControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gridTaxaEServico);
            Name = "TabelaTaxaEServicoControl";
            ((System.ComponentModel.ISupportInitialize)gridTaxaEServico).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridTaxaEServico;
    }
}
