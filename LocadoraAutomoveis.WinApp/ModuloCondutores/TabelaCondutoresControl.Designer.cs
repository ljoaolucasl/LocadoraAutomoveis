namespace LocadoraAutomoveis.WinApp.ModuloCondutores
{
    partial class TabelaCondutoresControl
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
            gridCondutores = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gridCondutores).BeginInit();
            SuspendLayout();
            // 
            // gridCondutores
            // 
            gridCondutores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridCondutores.Dock = DockStyle.Fill;
            gridCondutores.Location = new Point(0, 0);
            gridCondutores.Name = "gridCondutores";
            gridCondutores.RowTemplate.Height = 25;
            gridCondutores.Size = new Size(150, 150);
            gridCondutores.TabIndex = 0;
            // 
            // TabelaCondutoresControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gridCondutores);
            Name = "TabelaCondutoresControl";
            ((System.ComponentModel.ISupportInitialize)gridCondutores).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridCondutores;
    }
}
