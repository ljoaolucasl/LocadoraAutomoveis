namespace LocadoraAutomoveis.WinApp.ModuloPadrao
{
    partial class TelaPadraoForm
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
            txtId = new TextBox();
            txtNome = new TextBox();
            btnAdd = new Button();
            lbErroNome = new Label();
            SuspendLayout();
            // 
            // txtId
            // 
            txtId.Location = new Point(33, 30);
            txtId.Name = "txtId";
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 0;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(33, 77);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(100, 23);
            txtNome.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(45, 140);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "button1";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // lbErroNome
            // 
            lbErroNome.AutoSize = true;
            lbErroNome.ForeColor = Color.Red;
            lbErroNome.Location = new Point(45, 59);
            lbErroNome.Name = "lbErroNome";
            lbErroNome.Size = new Size(92, 15);
            lbErroNome.TabIndex = 3;
            lbErroNome.Text = "*MensagemErro";
            // 
            // TelaPadraoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lbErroNome);
            Controls.Add(btnAdd);
            Controls.Add(txtNome);
            Controls.Add(txtId);
            Name = "TelaPadraoForm";
            Text = "TelaPadraoForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtId;
        private TextBox txtNome;
        private Button btnAdd;
        private Label lbErroNome;
    }
}