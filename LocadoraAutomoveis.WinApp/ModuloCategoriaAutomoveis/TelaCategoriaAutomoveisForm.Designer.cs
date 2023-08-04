namespace LocadoraAutomoveis.WinApp.ModuloCategoriaAutomoveis
{
    partial class TelaCategoriaAutomoveisForm
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
            lbNome = new Label();
            txtNome = new TextBox();
            btnGravar = new Button();
            btnCancelar = new Button();
            lbErroNome = new Label();
            SuspendLayout();
            // 
            // lbNome
            // 
            lbNome.AutoSize = true;
            lbNome.Location = new Point(24, 62);
            lbNome.Name = "lbNome";
            lbNome.Size = new Size(43, 15);
            lbNome.TabIndex = 0;
            lbNome.Text = "Nome:";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(73, 59);
            txtNome.MaxLength = 100;
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(248, 23);
            txtNome.TabIndex = 1;
            // 
            // btnGravar
            // 
            btnGravar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(182, 130);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(85, 37);
            btnGravar.TabIndex = 2;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(273, 130);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(85, 37);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // lbErroNome
            // 
            lbErroNome.AutoSize = true;
            lbErroNome.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroNome.Location = new Point(73, 41);
            lbErroNome.Name = "lbErroNome";
            lbErroNome.Size = new Size(92, 15);
            lbErroNome.TabIndex = 4;
            lbErroNome.Text = "*mensagemErro";
            lbErroNome.Visible = false;
            // 
            // TelaCategoriaAutomoveisForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(370, 179);
            Controls.Add(lbErroNome);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(txtNome);
            Controls.Add(lbNome);
            Name = "TelaCategoriaAutomoveisForm";
            Text = "Cadastro de Categoria de Automóvel";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbNome;
        private TextBox txtNome;
        private Button btnGravar;
        private Button btnCancelar;
        private Label lbErroNome;
    }
}