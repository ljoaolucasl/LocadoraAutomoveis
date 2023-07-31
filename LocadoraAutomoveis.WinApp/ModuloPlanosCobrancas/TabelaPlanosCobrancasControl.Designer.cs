namespace LocadoraAutomoveis.WinApp.ModuloPlanosCobrancas
{
    partial class TabelaPlanosCobrancasControl
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
            gridPlanosCobrancas = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gridPlanosCobrancas).BeginInit();
            SuspendLayout();
            // 
            // gridPlanosCobrancas
            // 
            gridPlanosCobrancas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridPlanosCobrancas.Dock = DockStyle.Fill;
            gridPlanosCobrancas.Location = new Point(0, 0);
            gridPlanosCobrancas.Name = "gridPlanosCobrancas";
            gridPlanosCobrancas.RowTemplate.Height = 25;
            gridPlanosCobrancas.Size = new Size(150, 150);
            gridPlanosCobrancas.TabIndex = 1;
            // 
            // TabelaPlanosCobrancasControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gridPlanosCobrancas);
            Name = "TabelaPlanosCobrancasControl";
            ((System.ComponentModel.ISupportInitialize)gridPlanosCobrancas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridPlanosCobrancas;
    }
}
