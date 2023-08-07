namespace LocadoraAutomoveis.WinApp.ModuloAluguel
{
    partial class TelaAluguelDevolucaoForm
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
            lbErroValorTotal = new Label();
            lbErroTaxas = new Label();
            lbErroCupom = new Label();
            lbValorTotal = new Label();
            label12 = new Label();
            btnCancelar = new Button();
            btnGravar = new Button();
            tbControlTaxasAdicionadas = new TabControl();
            tbTaxas = new TabPage();
            lbErroKmAutomovel = new Label();
            lbErroAutomovel = new Label();
            lbErroCondutor = new Label();
            lbErroDataDevolucao = new Label();
            lbErroDataLocacao = new Label();
            lbErroPlanoCobranca = new Label();
            lbErroGrupoAutomoveis = new Label();
            lbErroFuncionario = new Label();
            lbErroCliente = new Label();
            txtCupom = new TextBox();
            label10 = new Label();
            dateDevolucao = new DateTimePicker();
            label9 = new Label();
            dateLocacao = new DateTimePicker();
            txtKmAutomovel = new NumericUpDown();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            cmbAutomovel = new ComboBox();
            label5 = new Label();
            cmbCondutor = new ComboBox();
            label4 = new Label();
            cmbPlanoCobranca = new ComboBox();
            label3 = new Label();
            cmbCategoriaAutomoveis = new ComboBox();
            label2 = new Label();
            cmbCliente = new ComboBox();
            label1 = new Label();
            cmbFuncionario = new ComboBox();
            label11 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label13 = new Label();
            tbControlTaxasAdicionadas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtKmAutomovel).BeginInit();
            SuspendLayout();
            // 
            // lbErroValorTotal
            // 
            lbErroValorTotal.AutoSize = true;
            lbErroValorTotal.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroValorTotal.Location = new Point(174, 611);
            lbErroValorTotal.Name = "lbErroValorTotal";
            lbErroValorTotal.Size = new Size(173, 15);
            lbErroValorTotal.TabIndex = 128;
            lbErroValorTotal.Text = "*Campo Valor Total em branco*";
            lbErroValorTotal.Visible = false;
            // 
            // lbErroTaxas
            // 
            lbErroTaxas.AutoSize = true;
            lbErroTaxas.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroTaxas.Location = new Point(518, 380);
            lbErroTaxas.Name = "lbErroTaxas";
            lbErroTaxas.Size = new Size(147, 15);
            lbErroTaxas.TabIndex = 127;
            lbErroTaxas.Text = "*Campo Taxas em branco*";
            lbErroTaxas.Visible = false;
            // 
            // lbErroCupom
            // 
            lbErroCupom.AutoSize = true;
            lbErroCupom.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroCupom.Location = new Point(133, 270);
            lbErroCupom.Name = "lbErroCupom";
            lbErroCupom.Size = new Size(159, 15);
            lbErroCupom.TabIndex = 126;
            lbErroCupom.Text = "*Campo Cupom em branco*";
            lbErroCupom.Visible = false;
            // 
            // lbValorTotal
            // 
            lbValorTotal.AutoSize = true;
            lbValorTotal.Location = new Point(170, 630);
            lbValorTotal.Name = "lbValorTotal";
            lbValorTotal.Size = new Size(20, 15);
            lbValorTotal.TabIndex = 125;
            lbValorTotal.Text = "R$";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(44, 630);
            label12.Name = "label12";
            label12.Size = new Size(109, 15);
            label12.TabIndex = 124;
            label12.Text = "Valor Total Previsto:";
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(573, 642);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(85, 37);
            btnCancelar.TabIndex = 123;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(482, 642);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(85, 37);
            btnGravar.TabIndex = 122;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            // 
            // tbControlTaxasAdicionadas
            // 
            tbControlTaxasAdicionadas.Controls.Add(tbTaxas);
            tbControlTaxasAdicionadas.Location = new Point(37, 398);
            tbControlTaxasAdicionadas.Name = "tbControlTaxasAdicionadas";
            tbControlTaxasAdicionadas.SelectedIndex = 0;
            tbControlTaxasAdicionadas.Size = new Size(628, 210);
            tbControlTaxasAdicionadas.TabIndex = 121;
            // 
            // tbTaxas
            // 
            tbTaxas.Location = new Point(4, 24);
            tbTaxas.Name = "tbTaxas";
            tbTaxas.Padding = new Padding(3);
            tbTaxas.Size = new Size(620, 182);
            tbTaxas.TabIndex = 0;
            tbTaxas.Text = "Taxas Adicionais";
            tbTaxas.UseVisualStyleBackColor = true;
            // 
            // lbErroKmAutomovel
            // 
            lbErroKmAutomovel.AutoSize = true;
            lbErroKmAutomovel.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroKmAutomovel.Location = new Point(463, 167);
            lbErroKmAutomovel.Name = "lbErroKmAutomovel";
            lbErroKmAutomovel.Size = new Size(199, 15);
            lbErroKmAutomovel.TabIndex = 120;
            lbErroKmAutomovel.Text = "*Campo KM Automóvel em branco*";
            lbErroKmAutomovel.Visible = false;
            // 
            // lbErroAutomovel
            // 
            lbErroAutomovel.AutoSize = true;
            lbErroAutomovel.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroAutomovel.Location = new Point(463, 119);
            lbErroAutomovel.Name = "lbErroAutomovel";
            lbErroAutomovel.Size = new Size(178, 15);
            lbErroAutomovel.TabIndex = 119;
            lbErroAutomovel.Text = "*Campo Automóvel em branco*";
            lbErroAutomovel.Visible = false;
            // 
            // lbErroCondutor
            // 
            lbErroCondutor.AutoSize = true;
            lbErroCondutor.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroCondutor.Location = new Point(463, 63);
            lbErroCondutor.Name = "lbErroCondutor";
            lbErroCondutor.Size = new Size(170, 15);
            lbErroCondutor.TabIndex = 118;
            lbErroCondutor.Text = "*Campo Condutor em branco*";
            lbErroCondutor.Visible = false;
            // 
            // lbErroDataDevolucao
            // 
            lbErroDataDevolucao.AutoSize = true;
            lbErroDataDevolucao.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroDataDevolucao.Location = new Point(463, 225);
            lbErroDataDevolucao.Name = "lbErroDataDevolucao";
            lbErroDataDevolucao.Size = new Size(202, 15);
            lbErroDataDevolucao.TabIndex = 117;
            lbErroDataDevolucao.Text = "*Campo Data Devolução em branco*";
            lbErroDataDevolucao.Visible = false;
            // 
            // lbErroDataLocacao
            // 
            lbErroDataLocacao.AutoSize = true;
            lbErroDataLocacao.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroDataLocacao.Location = new Point(136, 221);
            lbErroDataLocacao.Name = "lbErroDataLocacao";
            lbErroDataLocacao.Size = new Size(190, 15);
            lbErroDataLocacao.TabIndex = 116;
            lbErroDataLocacao.Text = "*Campo Data Locação em branco*";
            lbErroDataLocacao.Visible = false;
            // 
            // lbErroPlanoCobranca
            // 
            lbErroPlanoCobranca.AutoSize = true;
            lbErroPlanoCobranca.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroPlanoCobranca.Location = new Point(136, 167);
            lbErroPlanoCobranca.Name = "lbErroPlanoCobranca";
            lbErroPlanoCobranca.Size = new Size(219, 15);
            lbErroPlanoCobranca.TabIndex = 115;
            lbErroPlanoCobranca.Text = "*Campo Plano de Cobrança em branco*";
            lbErroPlanoCobranca.Visible = false;
            // 
            // lbErroGrupoAutomoveis
            // 
            lbErroGrupoAutomoveis.AutoSize = true;
            lbErroGrupoAutomoveis.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroGrupoAutomoveis.Location = new Point(136, 116);
            lbErroGrupoAutomoveis.Name = "lbErroGrupoAutomoveis";
            lbErroGrupoAutomoveis.Size = new Size(235, 15);
            lbErroGrupoAutomoveis.TabIndex = 114;
            lbErroGrupoAutomoveis.Text = "*Campo Grupo de Automóveis em branco*";
            lbErroGrupoAutomoveis.Visible = false;
            // 
            // lbErroFuncionario
            // 
            lbErroFuncionario.AutoSize = true;
            lbErroFuncionario.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroFuncionario.Location = new Point(136, 13);
            lbErroFuncionario.Name = "lbErroFuncionario";
            lbErroFuncionario.Size = new Size(182, 15);
            lbErroFuncionario.TabIndex = 113;
            lbErroFuncionario.Text = "*Campo Funcionário em branco*";
            lbErroFuncionario.Visible = false;
            // 
            // lbErroCliente
            // 
            lbErroCliente.AutoSize = true;
            lbErroCliente.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroCliente.Location = new Point(136, 68);
            lbErroCliente.Name = "lbErroCliente";
            lbErroCliente.Size = new Size(156, 15);
            lbErroCliente.TabIndex = 112;
            lbErroCliente.Text = "*Campo Cliente em branco*";
            lbErroCliente.Visible = false;
            // 
            // txtCupom
            // 
            txtCupom.Location = new Point(136, 288);
            txtCupom.Name = "txtCupom";
            txtCupom.Size = new Size(106, 23);
            txtCupom.TabIndex = 110;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(80, 291);
            label10.Name = "label10";
            label10.Size = new Size(50, 15);
            label10.TabIndex = 109;
            label10.Text = "Cupom:";
            // 
            // dateDevolucao
            // 
            dateDevolucao.Format = DateTimePickerFormat.Short;
            dateDevolucao.Location = new Point(463, 243);
            dateDevolucao.Name = "dateDevolucao";
            dateDevolucao.Size = new Size(154, 23);
            dateDevolucao.TabIndex = 108;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(347, 247);
            label9.Name = "label9";
            label9.Size = new Size(110, 15);
            label9.TabIndex = 107;
            label9.Text = "Devolução Prevista:";
            // 
            // dateLocacao
            // 
            dateLocacao.Format = DateTimePickerFormat.Short;
            dateLocacao.Location = new Point(136, 239);
            dateLocacao.Name = "dateLocacao";
            dateLocacao.Size = new Size(154, 23);
            dateLocacao.TabIndex = 106;
            // 
            // txtKmAutomovel
            // 
            txtKmAutomovel.Enabled = false;
            txtKmAutomovel.Location = new Point(463, 184);
            txtKmAutomovel.Name = "txtKmAutomovel";
            txtKmAutomovel.Size = new Size(120, 23);
            txtKmAutomovel.TabIndex = 105;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(49, 243);
            label8.Name = "label8";
            label8.Size = new Size(81, 15);
            label8.TabIndex = 104;
            label8.Text = "Data Locação:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(350, 187);
            label7.Name = "label7";
            label7.Size = new Size(107, 15);
            label7.TabIndex = 103;
            label7.Text = "KM do Automóvel:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(388, 140);
            label6.Name = "label6";
            label6.Size = new Size(69, 15);
            label6.TabIndex = 102;
            label6.Text = "Automóvel:";
            // 
            // cmbAutomovel
            // 
            cmbAutomovel.FormattingEnabled = true;
            cmbAutomovel.Location = new Point(463, 137);
            cmbAutomovel.Name = "cmbAutomovel";
            cmbAutomovel.Size = new Size(121, 23);
            cmbAutomovel.TabIndex = 101;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(396, 89);
            label5.Name = "label5";
            label5.Size = new Size(61, 15);
            label5.TabIndex = 100;
            label5.Text = "Condutor:";
            // 
            // cmbCondutor
            // 
            cmbCondutor.FormattingEnabled = true;
            cmbCondutor.Location = new Point(463, 86);
            cmbCondutor.Name = "cmbCondutor";
            cmbCondutor.Size = new Size(121, 23);
            cmbCondutor.TabIndex = 99;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 187);
            label4.Name = "label4";
            label4.Size = new Size(110, 15);
            label4.TabIndex = 98;
            label4.Text = "Plano de Cobrança:";
            // 
            // cmbPlanoCobranca
            // 
            cmbPlanoCobranca.FormattingEnabled = true;
            cmbPlanoCobranca.Location = new Point(136, 184);
            cmbPlanoCobranca.Name = "cmbPlanoCobranca";
            cmbPlanoCobranca.Size = new Size(154, 23);
            cmbPlanoCobranca.TabIndex = 97;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(4, 137);
            label3.Name = "label3";
            label3.Size = new Size(126, 15);
            label3.TabIndex = 96;
            label3.Text = "Grupo de Automóveis:";
            // 
            // cmbCategoriaAutomoveis
            // 
            cmbCategoriaAutomoveis.FormattingEnabled = true;
            cmbCategoriaAutomoveis.Location = new Point(136, 134);
            cmbCategoriaAutomoveis.Name = "cmbCategoriaAutomoveis";
            cmbCategoriaAutomoveis.Size = new Size(154, 23);
            cmbCategoriaAutomoveis.TabIndex = 95;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(83, 89);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 94;
            label2.Text = "Cliente:";
            // 
            // cmbCliente
            // 
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(136, 86);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(154, 23);
            cmbCliente.TabIndex = 93;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(57, 40);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 92;
            label1.Text = "Funcionário:";
            // 
            // cmbFuncionario
            // 
            cmbFuncionario.FormattingEnabled = true;
            cmbFuncionario.Location = new Point(136, 37);
            cmbFuncionario.Name = "cmbFuncionario";
            cmbFuncionario.Size = new Size(154, 23);
            cmbFuncionario.TabIndex = 91;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.ForeColor = Color.FromArgb(192, 0, 0);
            label11.Location = new Point(133, 325);
            label11.Name = "label11";
            label11.Size = new Size(190, 15);
            label11.TabIndex = 131;
            label11.Text = "*Campo Data Locação em branco*";
            label11.Visible = false;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(133, 343);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(154, 23);
            dateTimePicker1.TabIndex = 130;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(46, 349);
            label13.Name = "label13";
            label13.Size = new Size(81, 15);
            label13.TabIndex = 129;
            label13.Text = "Data Locação:";
            // 
            // TelaAluguelDevolucaoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 717);
            Controls.Add(label11);
            Controls.Add(dateTimePicker1);
            Controls.Add(label13);
            Controls.Add(lbErroValorTotal);
            Controls.Add(lbErroTaxas);
            Controls.Add(lbErroCupom);
            Controls.Add(lbValorTotal);
            Controls.Add(label12);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(tbControlTaxasAdicionadas);
            Controls.Add(lbErroKmAutomovel);
            Controls.Add(lbErroAutomovel);
            Controls.Add(lbErroCondutor);
            Controls.Add(lbErroDataDevolucao);
            Controls.Add(lbErroDataLocacao);
            Controls.Add(lbErroPlanoCobranca);
            Controls.Add(lbErroGrupoAutomoveis);
            Controls.Add(lbErroFuncionario);
            Controls.Add(lbErroCliente);
            Controls.Add(txtCupom);
            Controls.Add(label10);
            Controls.Add(dateDevolucao);
            Controls.Add(label9);
            Controls.Add(dateLocacao);
            Controls.Add(txtKmAutomovel);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(cmbAutomovel);
            Controls.Add(label5);
            Controls.Add(cmbCondutor);
            Controls.Add(label4);
            Controls.Add(cmbPlanoCobranca);
            Controls.Add(label3);
            Controls.Add(cmbCategoriaAutomoveis);
            Controls.Add(label2);
            Controls.Add(cmbCliente);
            Controls.Add(label1);
            Controls.Add(cmbFuncionario);
            Name = "TelaAluguelDevolucaoForm";
            ShowIcon = false;
            Text = "Registro de Devolução do Aluguel";
            tbControlTaxasAdicionadas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtKmAutomovel).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbErroValorTotal;
        private Label lbErroTaxas;
        private Label lbErroCupom;
        private Label lbValorTotal;
        private Label label12;
        private Button btnCancelar;
        private Button btnGravar;
        private TabControl tbControlTaxasAdicionadas;
        private TabPage tbTaxas;
        private Label lbErroKmAutomovel;
        private Label lbErroAutomovel;
        private Label lbErroCondutor;
        private Label lbErroDataDevolucao;
        private Label lbErroDataLocacao;
        private Label lbErroPlanoCobranca;
        private Label lbErroGrupoAutomoveis;
        private Label lbErroFuncionario;
        private Label lbErroCliente;
        private TextBox txtCupom;
        private Label label10;
        private DateTimePicker dateDevolucao;
        private Label label9;
        private DateTimePicker dateLocacao;
        private NumericUpDown txtKmAutomovel;
        private Label label8;
        private Label label7;
        private Label label6;
        private ComboBox cmbAutomovel;
        private Label label5;
        private ComboBox cmbCondutor;
        private Label label4;
        private ComboBox cmbPlanoCobranca;
        private Label label3;
        private ComboBox cmbCategoriaAutomoveis;
        private Label label2;
        private ComboBox cmbCliente;
        private Label label1;
        private ComboBox cmbFuncionario;
        private Label label11;
        private DateTimePicker dateTimePicker1;
        private Label label13;
    }
}