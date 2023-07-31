namespace LocadoraAutomoveis.WinApp.ModuloFuncionario
{
    partial class TelaFuncionarioForm
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
            lbDataAdmissao = new Label();
            lbSalario = new Label();
            txtNome = new TextBox();
            dateAdmissao = new DateTimePicker();
            btnCancelar = new Button();
            btnGravar = new Button();
            lbErroNome = new Label();
            lbErroAdmissao = new Label();
            lbErroSalario = new Label();
            txtSalario = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)txtSalario).BeginInit();
            SuspendLayout();
            // 
            // lbNome
            // 
            lbNome.AutoSize = true;
            lbNome.Location = new Point(44, 39);
            lbNome.Name = "lbNome";
            lbNome.Size = new Size(43, 15);
            lbNome.TabIndex = 0;
            lbNome.Text = "Nome:";
            // 
            // lbDataAdmissao
            // 
            lbDataAdmissao.AutoSize = true;
            lbDataAdmissao.Location = new Point(25, 92);
            lbDataAdmissao.Name = "lbDataAdmissao";
            lbDataAdmissao.Size = new Size(62, 15);
            lbDataAdmissao.TabIndex = 1;
            lbDataAdmissao.Text = "Admissão:";
            // 
            // lbSalario
            // 
            lbSalario.AutoSize = true;
            lbSalario.Location = new Point(42, 141);
            lbSalario.Name = "lbSalario";
            lbSalario.Size = new Size(45, 15);
            lbSalario.TabIndex = 2;
            lbSalario.Text = "Salário:";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(93, 39);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(327, 23);
            txtNome.TabIndex = 3;
            // 
            // dateAdmissao
            // 
            dateAdmissao.CustomFormat = "  /  /";
            dateAdmissao.Format = DateTimePickerFormat.Custom;
            dateAdmissao.Location = new Point(93, 86);
            dateAdmissao.Name = "dateAdmissao";
            dateAdmissao.Size = new Size(116, 23);
            dateAdmissao.TabIndex = 5;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(370, 185);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(85, 37);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(279, 185);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(85, 37);
            btnGravar.TabIndex = 6;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            // 
            // lbErroNome
            // 
            lbErroNome.AutoSize = true;
            lbErroNome.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroNome.Location = new Point(93, 21);
            lbErroNome.Name = "lbErroNome";
            lbErroNome.Size = new Size(152, 15);
            lbErroNome.TabIndex = 8;
            lbErroNome.Text = "*Campo Nome em branco*";
            // 
            // lbErroAdmissao
            // 
            lbErroAdmissao.AutoSize = true;
            lbErroAdmissao.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroAdmissao.Location = new Point(93, 68);
            lbErroAdmissao.Name = "lbErroAdmissao";
            lbErroAdmissao.Size = new Size(171, 15);
            lbErroAdmissao.TabIndex = 9;
            lbErroAdmissao.Text = "*Campo Admissão em branco*";
            // 
            // lbErroSalario
            // 
            lbErroSalario.AutoSize = true;
            lbErroSalario.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroSalario.Location = new Point(93, 120);
            lbErroSalario.Name = "lbErroSalario";
            lbErroSalario.Size = new Size(154, 15);
            lbErroSalario.TabIndex = 10;
            lbErroSalario.Text = "*Campo Salário em branco*";
            // 
            // txtSalario
            // 
            txtSalario.Location = new Point(93, 141);
            txtSalario.Name = "txtSalario";
            txtSalario.Size = new Size(120, 23);
            txtSalario.TabIndex = 11;
            // 
            // TelaFuncionarioForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(478, 234);
            Controls.Add(txtSalario);
            Controls.Add(lbErroSalario);
            Controls.Add(lbErroAdmissao);
            Controls.Add(lbErroNome);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(dateAdmissao);
            Controls.Add(txtNome);
            Controls.Add(lbSalario);
            Controls.Add(lbDataAdmissao);
            Controls.Add(lbNome);
            Name = "TelaFuncionarioForm";
            ShowIcon = false;
            Text = "Cadastro de Funcionário";
            ((System.ComponentModel.ISupportInitialize)txtSalario).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbNome;
        private Label lbDataAdmissao;
        private Label lbSalario;
        private TextBox txtNome;
        private DateTimePicker dateAdmissao;
        private Button btnCancelar;
        private Button btnGravar;
        private Label lbErroNome;
        private Label lbErroAdmissao;
        private Label lbErroSalario;
        private NumericUpDown txtSalario;
    }
}