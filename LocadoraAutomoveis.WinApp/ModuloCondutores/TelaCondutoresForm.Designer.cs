namespace LocadoraAutomoveis.WinApp.ModuloCondutores
{
    partial class TelaCondutoresForm
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
            txtTelefone = new MaskedTextBox();
            lbErroTelefone = new Label();
            label4 = new Label();
            lbErroEmail = new Label();
            txtEmail = new TextBox();
            label2 = new Label();
            lbErroNome = new Label();
            txtNome = new TextBox();
            lbNome = new Label();
            cmbCliente = new ComboBox();
            label1 = new Label();
            chkClienteCondutor = new CheckBox();
            txtCPF = new MaskedTextBox();
            lbErroCPF = new Label();
            label5 = new Label();
            lbErroCNH = new Label();
            label6 = new Label();
            txtCNH = new TextBox();
            lbErroValidade = new Label();
            dateValidade = new DateTimePicker();
            lbValidade = new Label();
            btnCancelar = new Button();
            btnGravar = new Button();
            lbErroCliente = new Label();
            SuspendLayout();
            // 
            // txtTelefone
            // 
            txtTelefone.Location = new Point(65, 208);
            txtTelefone.Mask = "(00) 00000-0000";
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(98, 23);
            txtTelefone.TabIndex = 58;
            // 
            // lbErroTelefone
            // 
            lbErroTelefone.AutoSize = true;
            lbErroTelefone.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroTelefone.Location = new Point(65, 187);
            lbErroTelefone.Name = "lbErroTelefone";
            lbErroTelefone.Size = new Size(163, 15);
            lbErroTelefone.TabIndex = 57;
            lbErroTelefone.Text = "*Campo Telefone em branco*";
            lbErroTelefone.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(5, 211);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 56;
            label4.Text = "Telefone:";
            // 
            // lbErroEmail
            // 
            lbErroEmail.AutoSize = true;
            lbErroEmail.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroEmail.Location = new Point(65, 139);
            lbErroEmail.Name = "lbErroEmail";
            lbErroEmail.Size = new Size(153, 15);
            lbErroEmail.TabIndex = 55;
            lbErroEmail.Text = "*Campo E-mail em branco*";
            lbErroEmail.Visible = false;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(65, 157);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(299, 23);
            txtEmail.TabIndex = 54;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 157);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 53;
            label2.Text = "E-mail:";
            // 
            // lbErroNome
            // 
            lbErroNome.AutoSize = true;
            lbErroNome.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroNome.Location = new Point(65, 92);
            lbErroNome.Name = "lbErroNome";
            lbErroNome.Size = new Size(152, 15);
            lbErroNome.TabIndex = 52;
            lbErroNome.Text = "*Campo Nome em branco*";
            lbErroNome.Visible = false;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(65, 110);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(299, 23);
            txtNome.TabIndex = 51;
            // 
            // lbNome
            // 
            lbNome.AutoSize = true;
            lbNome.Location = new Point(16, 110);
            lbNome.Name = "lbNome";
            lbNome.Size = new Size(43, 15);
            lbNome.TabIndex = 50;
            lbNome.Text = "Nome:";
            // 
            // cmbCliente
            // 
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(65, 25);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(299, 23);
            cmbCliente.TabIndex = 59;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 28);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 60;
            label1.Text = "Cliente:";
            // 
            // chkClienteCondutor
            // 
            chkClienteCondutor.AutoSize = true;
            chkClienteCondutor.Location = new Point(74, 65);
            chkClienteCondutor.Name = "chkClienteCondutor";
            chkClienteCondutor.Size = new Size(126, 19);
            chkClienteCondutor.TabIndex = 61;
            chkClienteCondutor.Text = "Cliente é Condutor";
            chkClienteCondutor.UseVisualStyleBackColor = true;
            chkClienteCondutor.CheckedChanged += chkClienteCondutor_CheckedChanged;
            // 
            // txtCPF
            // 
            txtCPF.Location = new Point(241, 208);
            txtCPF.Mask = "000,000,000-00";
            txtCPF.Name = "txtCPF";
            txtCPF.Size = new Size(85, 23);
            txtCPF.TabIndex = 64;
            // 
            // lbErroCPF
            // 
            lbErroCPF.AutoSize = true;
            lbErroCPF.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroCPF.Location = new Point(241, 187);
            lbErroCPF.Name = "lbErroCPF";
            lbErroCPF.Size = new Size(140, 15);
            lbErroCPF.TabIndex = 63;
            lbErroCPF.Text = "*Campo CPF em branco*";
            lbErroCPF.Visible = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(204, 211);
            label5.Name = "label5";
            label5.Size = new Size(31, 15);
            label5.TabIndex = 62;
            label5.Text = "CPF:";
            // 
            // lbErroCNH
            // 
            lbErroCNH.AutoSize = true;
            lbErroCNH.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroCNH.Location = new Point(65, 239);
            lbErroCNH.Name = "lbErroCNH";
            lbErroCNH.Size = new Size(145, 15);
            lbErroCNH.TabIndex = 66;
            lbErroCNH.Text = "*Campo CNH em branco*";
            lbErroCNH.Visible = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(23, 260);
            label6.Name = "label6";
            label6.Size = new Size(36, 15);
            label6.TabIndex = 65;
            label6.Text = "CNH:";
            // 
            // txtCNH
            // 
            txtCNH.Location = new Point(65, 257);
            txtCNH.Name = "txtCNH";
            txtCNH.Size = new Size(98, 23);
            txtCNH.TabIndex = 67;
            // 
            // lbErroValidade
            // 
            lbErroValidade.AutoSize = true;
            lbErroValidade.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroValidade.Location = new Point(65, 292);
            lbErroValidade.Name = "lbErroValidade";
            lbErroValidade.Size = new Size(171, 15);
            lbErroValidade.TabIndex = 70;
            lbErroValidade.Text = "*Campo Admissão em branco*";
            lbErroValidade.Visible = false;
            // 
            // dateValidade
            // 
            dateValidade.CustomFormat = "";
            dateValidade.Format = DateTimePickerFormat.Short;
            dateValidade.Location = new Point(65, 310);
            dateValidade.Name = "dateValidade";
            dateValidade.Size = new Size(116, 23);
            dateValidade.TabIndex = 69;
            // 
            // lbValidade
            // 
            lbValidade.AutoSize = true;
            lbValidade.Location = new Point(8, 316);
            lbValidade.Name = "lbValidade";
            lbValidade.Size = new Size(54, 15);
            lbValidade.TabIndex = 68;
            lbValidade.Text = "Validade:";
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(294, 372);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(85, 37);
            btnCancelar.TabIndex = 72;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(203, 372);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(85, 37);
            btnGravar.TabIndex = 71;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            // 
            // lbErroCliente
            // 
            lbErroCliente.AutoSize = true;
            lbErroCliente.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroCliente.Location = new Point(65, 7);
            lbErroCliente.Name = "lbErroCliente";
            lbErroCliente.Size = new Size(156, 15);
            lbErroCliente.TabIndex = 73;
            lbErroCliente.Text = "*Campo Cliente em branco*";
            lbErroCliente.Visible = false;
            // 
            // TelaCondutoresForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(391, 421);
            Controls.Add(lbErroCliente);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(lbErroValidade);
            Controls.Add(dateValidade);
            Controls.Add(lbValidade);
            Controls.Add(txtCNH);
            Controls.Add(lbErroCNH);
            Controls.Add(label6);
            Controls.Add(txtCPF);
            Controls.Add(lbErroCPF);
            Controls.Add(label5);
            Controls.Add(chkClienteCondutor);
            Controls.Add(label1);
            Controls.Add(cmbCliente);
            Controls.Add(txtTelefone);
            Controls.Add(lbErroTelefone);
            Controls.Add(label4);
            Controls.Add(lbErroEmail);
            Controls.Add(txtEmail);
            Controls.Add(label2);
            Controls.Add(lbErroNome);
            Controls.Add(txtNome);
            Controls.Add(lbNome);
            Name = "TelaCondutoresForm";
            Text = "TelaCondutoresForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaskedTextBox txtTelefone;
        private Label lbErroTelefone;
        private Label label4;
        private Label lbErroEmail;
        private TextBox txtEmail;
        private Label label2;
        private Label lbErroNome;
        private TextBox txtNome;
        private Label lbNome;
        private ComboBox cmbCliente;
        private Label label1;
        private CheckBox chkClienteCondutor;
        private MaskedTextBox txtCPF;
        private Label lbErroCPF;
        private Label label5;
        private Label lbErroCNH;
        private Label label6;
        private TextBox txtCNH;
        private Label lbErroValidade;
        private DateTimePicker dateValidade;
        private Label lbValidade;
        private Button btnCancelar;
        private Button btnGravar;
        private Label lbErroCliente;
    }
}