namespace LocadoraAutomoveis.WinApp.ModuloPadrao
{
    partial class TabelaPadraoControl
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
            gridPadrao = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gridPadrao).BeginInit();
            SuspendLayout();
            // 
            // gridPadrao
            // 
            gridPadrao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridPadrao.Location = new Point(0, 0);
            gridPadrao.Name = "gridPadrao";
            gridPadrao.RowTemplate.Height = 25;
            gridPadrao.Size = new Size(150, 150);
            gridPadrao.TabIndex = 0;
            // 
            // UserControl1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gridPadrao);
            Name = "UserControl1";
            ((System.ComponentModel.ISupportInitialize)gridPadrao).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridPadrao;
    }
}
