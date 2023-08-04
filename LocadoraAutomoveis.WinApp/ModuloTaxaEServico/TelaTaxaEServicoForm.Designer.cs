namespace LocadoraAutomoveis.WinApp.ModuloTaxaEServico
{
    partial class TelaTaxaEServicoForm
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
            lbNome = new Label();
            lbErroValor = new Label();
            lbValor = new Label();
            txtValor = new NumericUpDown();
            groupBox1 = new GroupBox();
            rdDiaria = new RadioButton();
            rdFixo = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)txtValor).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // lbErroNome
            // 
            lbErroNome.AutoSize = true;
            lbErroNome.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroNome.Location = new Point(77, 37);
            lbErroNome.Name = "lbErroNome";
            lbErroNome.Size = new Size(92, 15);
            lbErroNome.TabIndex = 9;
            lbErroNome.Text = "*mensagemErro";
            lbErroNome.Visible = false;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(302, 227);
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
            btnGravar.Location = new Point(211, 227);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(85, 37);
            btnGravar.TabIndex = 5;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnAdd_Click;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(77, 55);
            txtNome.MaxLength = 100;
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(248, 23);
            txtNome.TabIndex = 1;
            // 
            // lbNome
            // 
            lbNome.AutoSize = true;
            lbNome.Location = new Point(28, 58);
            lbNome.Name = "lbNome";
            lbNome.Size = new Size(43, 15);
            lbNome.TabIndex = 5;
            lbNome.Text = "Nome:";
            // 
            // lbErroValor
            // 
            lbErroValor.AutoSize = true;
            lbErroValor.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroValor.Location = new Point(77, 85);
            lbErroValor.Name = "lbErroValor";
            lbErroValor.Size = new Size(92, 15);
            lbErroValor.TabIndex = 12;
            lbErroValor.Text = "*mensagemErro";
            lbErroValor.Visible = false;
            // 
            // lbValor
            // 
            lbValor.AutoSize = true;
            lbValor.Location = new Point(31, 106);
            lbValor.Name = "lbValor";
            lbValor.Size = new Size(40, 15);
            lbValor.TabIndex = 10;
            lbValor.Text = "Preço:";
            // 
            // txtValor
            // 
            txtValor.DecimalPlaces = 2;
            txtValor.ImeMode = ImeMode.NoControl;
            txtValor.Location = new Point(77, 103);
            txtValor.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(120, 23);
            txtValor.TabIndex = 2;
            txtValor.ThousandsSeparator = true;
            txtValor.Click += txtValor_Click;
            txtValor.Enter += txtValor_Enter;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rdDiaria);
            groupBox1.Controls.Add(rdFixo);
            groupBox1.Location = new Point(40, 141);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(303, 60);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "Plano de Cálculo";
            // 
            // rdDiaria
            // 
            rdDiaria.AutoSize = true;
            rdDiaria.Location = new Point(121, 25);
            rdDiaria.Name = "rdDiaria";
            rdDiaria.Size = new Size(109, 19);
            rdDiaria.TabIndex = 4;
            rdDiaria.TabStop = true;
            rdDiaria.Text = "Cobrança Diária";
            rdDiaria.UseVisualStyleBackColor = true;
            // 
            // rdFixo
            // 
            rdFixo.AutoSize = true;
            rdFixo.Checked = true;
            rdFixo.Location = new Point(14, 25);
            rdFixo.Name = "rdFixo";
            rdFixo.Size = new Size(80, 19);
            rdFixo.TabIndex = 3;
            rdFixo.TabStop = true;
            rdFixo.Text = "Preço Fixo";
            rdFixo.UseVisualStyleBackColor = true;
            // 
            // TelaTaxaEServicoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(399, 276);
            Controls.Add(groupBox1);
            Controls.Add(txtValor);
            Controls.Add(lbErroValor);
            Controls.Add(lbValor);
            Controls.Add(lbErroNome);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(txtNome);
            Controls.Add(lbNome);
            Name = "TelaTaxaEServicoForm";
            Text = "Cadastro de Taxa e Serviço";
            ((System.ComponentModel.ISupportInitialize)txtValor).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbErroNome;
        private Button btnCancelar;
        private Button btnGravar;
        private TextBox txtNome;
        private Label lbNome;
        private Label lbErroValor;
        private Label lbValor;
        private NumericUpDown txtValor;
        private GroupBox groupBox1;
        private RadioButton rdDiaria;
        private RadioButton rdFixo;
    }
}