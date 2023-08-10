namespace LocadoraAutomoveis.WinApp.ModuloAutomovel
{
    partial class TelaFiltroAutomovelForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnCancelar = new Button();
            btnAplicar = new Button();
            cbCategoria = new ComboBox();
            lbNome = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(283, 148);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(85, 37);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAplicar
            // 
            btnAplicar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAplicar.DialogResult = DialogResult.OK;
            btnAplicar.Location = new Point(192, 148);
            btnAplicar.Name = "btnAplicar";
            btnAplicar.Size = new Size(85, 37);
            btnAplicar.TabIndex = 2;
            btnAplicar.Text = "Aplicar";
            btnAplicar.UseVisualStyleBackColor = true;
            btnAplicar.Click += btnAplicar_Click;
            // 
            // cbCategoria
            // 
            cbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCategoria.FormattingEnabled = true;
            cbCategoria.Location = new Point(178, 80);
            cbCategoria.Name = "cbCategoria";
            cbCategoria.Size = new Size(164, 23);
            cbCategoria.TabIndex = 1;
            // 
            // lbNome
            // 
            lbNome.AutoSize = true;
            lbNome.Location = new Point(30, 83);
            lbNome.Name = "lbNome";
            lbNome.Size = new Size(144, 15);
            lbNome.TabIndex = 16;
            lbNome.Text = "Categoria de Automóveis:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(59, 9);
            label1.Name = "label1";
            label1.Size = new Size(259, 21);
            label1.TabIndex = 17;
            label1.Text = "Filtrar Automóveis por Categoria";
            // 
            // TelaFiltroAutomovelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(380, 197);
            Controls.Add(label1);
            Controls.Add(cbCategoria);
            Controls.Add(lbNome);
            Controls.Add(btnCancelar);
            Controls.Add(btnAplicar);
            Name = "TelaFiltroAutomovelForm";
            Text = "Filtro de Automóvel";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnAplicar;
        private Label lbNome;
        private Label label1;
        private ComboBox cbCategoria;
    }
}