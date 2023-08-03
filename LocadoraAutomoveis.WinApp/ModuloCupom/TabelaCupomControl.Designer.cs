namespace LocadoraAutomoveis.WinApp.ModuloCupom
{
    partial class TabelaCupomControl
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
            gridCupom = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gridCupom).BeginInit();
            SuspendLayout();
            // 
            // gridCupom
            // 
            gridCupom.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridCupom.Dock = DockStyle.Fill;
            gridCupom.Location = new Point(0, 0);
            gridCupom.Name = "gridCupom";
            gridCupom.RowTemplate.Height = 25;
            gridCupom.Size = new Size(150, 150);
            gridCupom.TabIndex = 0;
            // 
            // TabelaCupomControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gridCupom);
            Name = "TabelaCupomControl";
            ((System.ComponentModel.ISupportInitialize)gridCupom).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridCupom;
    }
}
