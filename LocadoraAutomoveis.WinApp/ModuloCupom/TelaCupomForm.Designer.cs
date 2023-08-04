namespace LocadoraAutomoveis.WinApp.ModuloCupom
{
    partial class TelaCupomForm
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
            btnCancelar = new Button();
            btnGravar = new Button();
            txtNome = new TextBox();
            label1 = new Label();
            label3 = new Label();
            dtpData = new DateTimePicker();
            lbErroData = new Label();
            label5 = new Label();
            cmbParceiro = new ComboBox();
            lbErroParceiro = new Label();
            numValor = new NumericUpDown();
            label7 = new Label();
            lbErroValor = new Label();
            ((System.ComponentModel.ISupportInitialize)numValor).BeginInit();
            SuspendLayout();
            // 
            // lbErroNome
            // 
            lbErroNome.AutoSize = true;
            lbErroNome.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroNome.Location = new Point(117, 28);
            lbErroNome.Name = "lbErroNome";
            lbErroNome.Size = new Size(92, 15);
            lbErroNome.TabIndex = 11;
            lbErroNome.Text = "*mensagemErro";
            lbErroNome.Visible = false;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(262, 260);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(85, 37);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(171, 260);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(85, 37);
            btnGravar.TabIndex = 5;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(117, 47);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(205, 23);
            txtNome.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(68, 46);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 7;
            label1.Text = "Nome:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(75, 94);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 14;
            label3.Text = "Valor:";
            // 
            // dtpData
            // 
            dtpData.Format = DateTimePickerFormat.Short;
            dtpData.Location = new Point(117, 139);
            dtpData.Name = "dtpData";
            dtpData.Size = new Size(139, 23);
            dtpData.TabIndex = 3;
            // 
            // lbErroData
            // 
            lbErroData.AutoSize = true;
            lbErroData.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroData.Location = new Point(117, 120);
            lbErroData.Name = "lbErroData";
            lbErroData.Size = new Size(92, 15);
            lbErroData.TabIndex = 16;
            lbErroData.Text = "*mensagemErro";
            lbErroData.Visible = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 142);
            label5.Name = "label5";
            label5.Size = new Size(97, 15);
            label5.TabIndex = 17;
            label5.Text = "Data de Validade:";
            // 
            // cmbParceiro
            // 
            cmbParceiro.FormattingEnabled = true;
            cmbParceiro.Location = new Point(117, 185);
            cmbParceiro.Name = "cmbParceiro";
            cmbParceiro.Size = new Size(205, 23);
            cmbParceiro.TabIndex = 4;
            // 
            // lbErroParceiro
            // 
            lbErroParceiro.AutoSize = true;
            lbErroParceiro.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroParceiro.Location = new Point(117, 166);
            lbErroParceiro.Name = "lbErroParceiro";
            lbErroParceiro.Size = new Size(92, 15);
            lbErroParceiro.TabIndex = 19;
            lbErroParceiro.Text = "*mensagemErro";
            lbErroParceiro.Visible = false;
            // 
            // numValor
            // 
            numValor.DecimalPlaces = 2;
            numValor.Location = new Point(117, 93);
            numValor.Name = "numValor";
            numValor.Size = new Size(141, 23);
            numValor.TabIndex = 2;
            numValor.ThousandsSeparator = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(58, 190);
            label7.Name = "label7";
            label7.Size = new Size(53, 15);
            label7.TabIndex = 21;
            label7.Text = "Parceiro:";
            // 
            // lbErroValor
            // 
            lbErroValor.AutoSize = true;
            lbErroValor.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroValor.Location = new Point(117, 75);
            lbErroValor.Name = "lbErroValor";
            lbErroValor.Size = new Size(92, 15);
            lbErroValor.TabIndex = 22;
            lbErroValor.Text = "*mensagemErro";
            lbErroValor.Visible = false;
            // 
            // TelaCupomForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(358, 309);
            Controls.Add(lbErroValor);
            Controls.Add(label7);
            Controls.Add(numValor);
            Controls.Add(lbErroParceiro);
            Controls.Add(cmbParceiro);
            Controls.Add(label5);
            Controls.Add(lbErroData);
            Controls.Add(dtpData);
            Controls.Add(label3);
            Controls.Add(lbErroNome);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(txtNome);
            Controls.Add(label1);
            Name = "TelaCupomForm";
            Text = "TelaCupomForm";
            ((System.ComponentModel.ISupportInitialize)numValor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbErroNome;
        private Button btnCancelar;
        private Button btnGravar;
        private TextBox txtNome;
        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private Label label3;
        private DateTimePicker dtpData;
        private Label lbErroData;
        private Label label5;
        private ComboBox cmbParceiro;
        private Label lbErroParceiro;
        private NumericUpDown numValor;
        private Label label7;
        private Label lbErroValor;
    }
}