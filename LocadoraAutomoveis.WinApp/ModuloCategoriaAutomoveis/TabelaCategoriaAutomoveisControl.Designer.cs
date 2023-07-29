namespace LocadoraAutomoveis.WinApp.ModuloCategoriaAutomoveis
{
    partial class TabelaCategoriaAutomoveisControl
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
            gridCategoriaAutomoveis = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gridCategoriaAutomoveis).BeginInit();
            SuspendLayout();
            // 
            // gridCategoriaAutomoveis
            // 
            gridCategoriaAutomoveis.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridCategoriaAutomoveis.Location = new Point(0, 0);
            gridCategoriaAutomoveis.Name = "gridCategoriaAutomoveis";
            gridCategoriaAutomoveis.RowTemplate.Height = 25;
            gridCategoriaAutomoveis.Size = new Size(150, 150);
            gridCategoriaAutomoveis.TabIndex = 0;
            // 
            // TabelaCategoriaAutomoveisControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gridCategoriaAutomoveis);
            Name = "TabelaCategoriaAutomoveisControl";
            ((System.ComponentModel.ISupportInitialize)gridCategoriaAutomoveis).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridCategoriaAutomoveis;
    }
}
