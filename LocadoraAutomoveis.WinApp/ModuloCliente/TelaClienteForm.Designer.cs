namespace LocadoraAutomoveis.WinApp.ModuloCliente
{
    partial class TelaClienteForm
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
            lbErroNome = new Label();
            txtNome = new TextBox();
            lbNome = new Label();
            lbErroEmail = new Label();
            txtEmail = new TextBox();
            label2 = new Label();
            lbErroTelefone = new Label();
            label4 = new Label();
            label1 = new Label();
            rdbPessoaFisica = new RadioButton();
            rdbPessoaJuridica = new RadioButton();
            lbErroCPF = new Label();
            label5 = new Label();
            lbErroCNPJ = new Label();
            label6 = new Label();
            txtCidade = new TextBox();
            lbErroCidade = new Label();
            label9 = new Label();
            lbErroEstado = new Label();
            txtEstado = new TextBox();
            label11 = new Label();
            lbErroRua = new Label();
            txtRua = new TextBox();
            label8 = new Label();
            lbErroBairro = new Label();
            txtBairro = new TextBox();
            label12 = new Label();
            lbErroNumero = new Label();
            label10 = new Label();
            btnCancelar = new Button();
            btnGravar = new Button();
            txtNumero = new NumericUpDown();
            txtCPF = new MaskedTextBox();
            txtCNPJ = new MaskedTextBox();
            txtTelefone = new MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)txtNumero).BeginInit();
            SuspendLayout();
            // 
            // lbErroNome
            // 
            lbErroNome.AutoSize = true;
            lbErroNome.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroNome.Location = new Point(76, 14);
            lbErroNome.Name = "lbErroNome";
            lbErroNome.Size = new Size(152, 15);
            lbErroNome.TabIndex = 11;
            lbErroNome.Text = "*Campo Nome em branco*";
            lbErroNome.Visible = false;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(76, 32);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(290, 23);
            txtNome.TabIndex = 1;
            // 
            // lbNome
            // 
            lbNome.AutoSize = true;
            lbNome.Location = new Point(27, 32);
            lbNome.Name = "lbNome";
            lbNome.Size = new Size(43, 15);
            lbNome.TabIndex = 9;
            lbNome.Text = "Nome:";
            // 
            // lbErroEmail
            // 
            lbErroEmail.AutoSize = true;
            lbErroEmail.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroEmail.Location = new Point(76, 61);
            lbErroEmail.Name = "lbErroEmail";
            lbErroEmail.Size = new Size(153, 15);
            lbErroEmail.TabIndex = 14;
            lbErroEmail.Text = "*Campo E-mail em branco*";
            lbErroEmail.Visible = false;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(76, 79);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(290, 23);
            txtEmail.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 79);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 12;
            label2.Text = "E-mail:";
            // 
            // lbErroTelefone
            // 
            lbErroTelefone.AutoSize = true;
            lbErroTelefone.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroTelefone.Location = new Point(76, 109);
            lbErroTelefone.Name = "lbErroTelefone";
            lbErroTelefone.Size = new Size(163, 15);
            lbErroTelefone.TabIndex = 17;
            lbErroTelefone.Text = "*Campo Telefone em branco*";
            lbErroTelefone.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 130);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 15;
            label4.Text = "Telefone:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 173);
            label1.Name = "label1";
            label1.Size = new Size(89, 15);
            label1.TabIndex = 18;
            label1.Text = "Tipo de Cliente:";
            // 
            // rdbPessoaFisica
            // 
            rdbPessoaFisica.AutoSize = true;
            rdbPessoaFisica.Checked = true;
            rdbPessoaFisica.Location = new Point(124, 171);
            rdbPessoaFisica.Name = "rdbPessoaFisica";
            rdbPessoaFisica.Size = new Size(93, 19);
            rdbPessoaFisica.TabIndex = 4;
            rdbPessoaFisica.TabStop = true;
            rdbPessoaFisica.Text = "Pessoa Física";
            rdbPessoaFisica.UseVisualStyleBackColor = true;
            rdbPessoaFisica.CheckedChanged += rdbPessoaFisica_CheckedChanged;
            // 
            // rdbPessoaJuridica
            // 
            rdbPessoaJuridica.AutoSize = true;
            rdbPessoaJuridica.Location = new Point(262, 171);
            rdbPessoaJuridica.Name = "rdbPessoaJuridica";
            rdbPessoaJuridica.Size = new Size(104, 19);
            rdbPessoaJuridica.TabIndex = 5;
            rdbPessoaJuridica.Text = "Pessoa Jurídica";
            rdbPessoaJuridica.UseVisualStyleBackColor = true;
            rdbPessoaJuridica.CheckedChanged += rdbPessoaJuridica_CheckedChanged;
            // 
            // lbErroCPF
            // 
            lbErroCPF.AutoSize = true;
            lbErroCPF.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroCPF.Location = new Point(66, 206);
            lbErroCPF.Name = "lbErroCPF";
            lbErroCPF.Size = new Size(140, 15);
            lbErroCPF.TabIndex = 23;
            lbErroCPF.Text = "*Campo CPF em branco*";
            lbErroCPF.Visible = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(30, 227);
            label5.Name = "label5";
            label5.Size = new Size(31, 15);
            label5.TabIndex = 21;
            label5.Text = "CPF:";
            // 
            // lbErroCNPJ
            // 
            lbErroCNPJ.AutoSize = true;
            lbErroCNPJ.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroCNPJ.Location = new Point(234, 206);
            lbErroCNPJ.Name = "lbErroCNPJ";
            lbErroCNPJ.Size = new Size(146, 15);
            lbErroCNPJ.TabIndex = 26;
            lbErroCNPJ.Text = "*Campo CNPJ em branco*";
            lbErroCNPJ.Visible = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(202, 227);
            label6.Name = "label6";
            label6.Size = new Size(37, 15);
            label6.TabIndex = 24;
            label6.Text = "CNPJ:";
            // 
            // txtCidade
            // 
            txtCidade.Location = new Point(250, 284);
            txtCidade.Name = "txtCidade";
            txtCidade.Size = new Size(130, 23);
            txtCidade.TabIndex = 9;
            // 
            // lbErroCidade
            // 
            lbErroCidade.AutoSize = true;
            lbErroCidade.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroCidade.Location = new Point(237, 266);
            lbErroCidade.Name = "lbErroCidade";
            lbErroCidade.Size = new Size(156, 15);
            lbErroCidade.TabIndex = 33;
            lbErroCidade.Text = "*Campo Cidade em branco*";
            lbErroCidade.Visible = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(196, 287);
            label9.Name = "label9";
            label9.Size = new Size(47, 15);
            label9.TabIndex = 32;
            label9.Text = "Cidade:";
            // 
            // lbErroEstado
            // 
            lbErroEstado.AutoSize = true;
            lbErroEstado.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroEstado.Location = new Point(67, 266);
            lbErroEstado.Name = "lbErroEstado";
            lbErroEstado.Size = new Size(154, 15);
            lbErroEstado.TabIndex = 31;
            lbErroEstado.Text = "*Campo Estado em branco*";
            lbErroEstado.Visible = false;
            // 
            // txtEstado
            // 
            txtEstado.Location = new Point(67, 284);
            txtEstado.Name = "txtEstado";
            txtEstado.Size = new Size(107, 23);
            txtEstado.TabIndex = 8;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(16, 287);
            label11.Name = "label11";
            label11.Size = new Size(45, 15);
            label11.TabIndex = 29;
            label11.Text = "Estado:";
            // 
            // lbErroRua
            // 
            lbErroRua.AutoSize = true;
            lbErroRua.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroRua.Location = new Point(66, 375);
            lbErroRua.Name = "lbErroRua";
            lbErroRua.Size = new Size(139, 15);
            lbErroRua.TabIndex = 40;
            lbErroRua.Text = "*Campo Rua em branco*";
            lbErroRua.Visible = false;
            // 
            // txtRua
            // 
            txtRua.Location = new Point(66, 393);
            txtRua.Name = "txtRua";
            txtRua.Size = new Size(290, 23);
            txtRua.TabIndex = 11;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(30, 393);
            label8.Name = "label8";
            label8.Size = new Size(30, 15);
            label8.TabIndex = 38;
            label8.Text = "Rua:";
            // 
            // lbErroBairro
            // 
            lbErroBairro.AutoSize = true;
            lbErroBairro.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroBairro.Location = new Point(67, 322);
            lbErroBairro.Name = "lbErroBairro";
            lbErroBairro.Size = new Size(150, 15);
            lbErroBairro.TabIndex = 37;
            lbErroBairro.Text = "*Campo Bairro em branco*";
            lbErroBairro.Visible = false;
            // 
            // txtBairro
            // 
            txtBairro.Location = new Point(67, 340);
            txtBairro.Name = "txtBairro";
            txtBairro.Size = new Size(290, 23);
            txtBairro.TabIndex = 10;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(20, 340);
            label12.Name = "label12";
            label12.Size = new Size(41, 15);
            label12.TabIndex = 35;
            label12.Text = "Bairro:";
            // 
            // lbErroNumero
            // 
            lbErroNumero.AutoSize = true;
            lbErroNumero.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroNumero.Location = new Point(66, 431);
            lbErroNumero.Name = "lbErroNumero";
            lbErroNumero.Size = new Size(163, 15);
            lbErroNumero.TabIndex = 43;
            lbErroNumero.Text = "*Campo Número em branco*";
            lbErroNumero.Visible = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 449);
            label10.Name = "label10";
            label10.Size = new Size(54, 15);
            label10.TabIndex = 41;
            label10.Text = "Número:";
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(289, 508);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(85, 37);
            btnCancelar.TabIndex = 14;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(198, 508);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(85, 37);
            btnGravar.TabIndex = 13;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnAdd_Click;
            // 
            // txtNumero
            // 
            txtNumero.Location = new Point(67, 449);
            txtNumero.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            txtNumero.Name = "txtNumero";
            txtNumero.Size = new Size(120, 23);
            txtNumero.TabIndex = 12;
            txtNumero.Click += selecaoAutomaticaNumericUpDown_Click;
            txtNumero.Enter += selecaoAutomaticaNumericUpDown_Enter;
            // 
            // txtCPF
            // 
            txtCPF.Location = new Point(67, 227);
            txtCPF.Mask = "000,000,000-00";
            txtCPF.Name = "txtCPF";
            txtCPF.Size = new Size(85, 23);
            txtCPF.TabIndex = 6;
            // 
            // txtCNPJ
            // 
            txtCNPJ.Location = new Point(250, 227);
            txtCNPJ.Mask = "00,000,000/0000-00";
            txtCNPJ.Name = "txtCNPJ";
            txtCNPJ.Size = new Size(116, 23);
            txtCNPJ.TabIndex = 7;
            // 
            // txtTelefone
            // 
            txtTelefone.Location = new Point(76, 130);
            txtTelefone.Mask = "(00) 00000-0000";
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(98, 23);
            txtTelefone.TabIndex = 3;
            // 
            // TelaClienteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(401, 557);
            Controls.Add(txtTelefone);
            Controls.Add(txtCNPJ);
            Controls.Add(txtCPF);
            Controls.Add(txtNumero);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(lbErroNumero);
            Controls.Add(label10);
            Controls.Add(lbErroRua);
            Controls.Add(txtRua);
            Controls.Add(label8);
            Controls.Add(lbErroBairro);
            Controls.Add(txtBairro);
            Controls.Add(label12);
            Controls.Add(txtCidade);
            Controls.Add(lbErroCidade);
            Controls.Add(label9);
            Controls.Add(lbErroEstado);
            Controls.Add(txtEstado);
            Controls.Add(label11);
            Controls.Add(lbErroCNPJ);
            Controls.Add(label6);
            Controls.Add(lbErroCPF);
            Controls.Add(label5);
            Controls.Add(rdbPessoaJuridica);
            Controls.Add(rdbPessoaFisica);
            Controls.Add(label1);
            Controls.Add(lbErroTelefone);
            Controls.Add(label4);
            Controls.Add(lbErroEmail);
            Controls.Add(txtEmail);
            Controls.Add(label2);
            Controls.Add(lbErroNome);
            Controls.Add(txtNome);
            Controls.Add(lbNome);
            Name = "TelaClienteForm";
            ShowIcon = false;
            Text = "Cadastro de Cliente";
            ((System.ComponentModel.ISupportInitialize)txtNumero).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbErroNome;
        private TextBox txtNome;
        private Label lbNome;
        private Label lbErroEmail;
        private TextBox txtEmail;
        private Label label2;
        private Label lbErroTelefone;
        private Label label4;
        private Label label1;
        private RadioButton rdbPessoaFisica;
        private RadioButton rdbPessoaJuridica;
        private Label lbErroCPF;
        private MaskedTextBox txtCPF;
        private Label label5;
        private Label lbErroCNPJ;
        private Label label6;
        private MaskedTextBox txtCNPJ;
        private TextBox txtCidade;
        private Label lbErroCidade;
        private Label label9;
        private Label lbErroEstado;
        private TextBox txtEstado;
        private Label label11;
        private Label lbErroRua;
        private TextBox txtRua;
        private Label label8;
        private Label lbErroBairro;
        private TextBox txtBairro;
        private Label label12;
        private Label lbErroNumero;
        private Label label10;
        private Button btnCancelar;
        private Button btnGravar;
        private NumericUpDown txtNumero;
        private MaskedTextBox maskedTextBox1;
        private MaskedTextBox txtTelefone;
    }
}