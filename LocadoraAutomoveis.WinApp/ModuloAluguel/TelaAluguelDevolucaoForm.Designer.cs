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
            lblTextoValor = new Label();
            label12 = new Label();
            btnCancelar = new Button();
            btnGravar = new Button();
            tbControlTaxasAdicionadas = new TabControl();
            tbTaxas = new TabPage();
            listTaxas = new CheckedListBox();
            lbErroFuncionario = new Label();
            lbErroCliente = new Label();
            txtCupom = new TextBox();
            label10 = new Label();
            datePrevistaRetorno = new DateTimePicker();
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
            lbErroDataDevolucao = new Label();
            dateDevolucao = new DateTimePicker();
            label13 = new Label();
            lbErroKmPercorrida = new Label();
            txtKmPercorrida = new NumericUpDown();
            label15 = new Label();
            lbErroNivelTanque = new Label();
            label17 = new Label();
            cmbNivelTanque = new ComboBox();
            lbValorTotal = new Label();
            tbControlTaxasAdicionadas.SuspendLayout();
            tbTaxas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtKmAutomovel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtKmPercorrida).BeginInit();
            SuspendLayout();
            // 
            // lbErroValorTotal
            // 
            lbErroValorTotal.AutoSize = true;
            lbErroValorTotal.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroValorTotal.Location = new Point(182, 654);
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
            lbErroTaxas.Location = new Point(448, 413);
            lbErroTaxas.Name = "lbErroTaxas";
            lbErroTaxas.Size = new Size(147, 15);
            lbErroTaxas.TabIndex = 127;
            lbErroTaxas.Text = "*Campo Taxas em branco*";
            lbErroTaxas.Visible = false;
            // 
            // lblTextoValor
            // 
            lblTextoValor.AutoSize = true;
            lblTextoValor.Location = new Point(178, 673);
            lblTextoValor.Name = "lblTextoValor";
            lblTextoValor.Size = new Size(20, 15);
            lblTextoValor.TabIndex = 125;
            lblTextoValor.Text = "R$";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(52, 673);
            label12.Name = "label12";
            label12.Size = new Size(109, 15);
            label12.TabIndex = 124;
            label12.Text = "Valor Total Previsto:";
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(584, 668);
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
            btnGravar.Location = new Point(493, 668);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(85, 37);
            btnGravar.TabIndex = 122;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // tbControlTaxasAdicionadas
            // 
            tbControlTaxasAdicionadas.Controls.Add(tbTaxas);
            tbControlTaxasAdicionadas.Location = new Point(45, 431);
            tbControlTaxasAdicionadas.Name = "tbControlTaxasAdicionadas";
            tbControlTaxasAdicionadas.SelectedIndex = 0;
            tbControlTaxasAdicionadas.Size = new Size(628, 210);
            tbControlTaxasAdicionadas.TabIndex = 121;
            // 
            // tbTaxas
            // 
            tbTaxas.Controls.Add(listTaxas);
            tbTaxas.Location = new Point(4, 24);
            tbTaxas.Name = "tbTaxas";
            tbTaxas.Padding = new Padding(3);
            tbTaxas.Size = new Size(620, 182);
            tbTaxas.TabIndex = 0;
            tbTaxas.Text = "Taxas Adicionais";
            tbTaxas.UseVisualStyleBackColor = true;
            // 
            // listTaxas
            // 
            listTaxas.Dock = DockStyle.Fill;
            listTaxas.FormattingEnabled = true;
            listTaxas.Location = new Point(3, 3);
            listTaxas.Name = "listTaxas";
            listTaxas.Size = new Size(614, 176);
            listTaxas.TabIndex = 138;
            listTaxas.SelectedValueChanged += atualizarValor_SelectedValueChanged;
            // 
            // lbErroFuncionario
            // 
            lbErroFuncionario.AutoSize = true;
            lbErroFuncionario.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroFuncionario.Location = new Point(136, 13);
            lbErroFuncionario.Name = "lbErroFuncionario";
            lbErroFuncionario.Size = new Size(0, 15);
            lbErroFuncionario.TabIndex = 113;
            lbErroFuncionario.Visible = false;
            // 
            // lbErroCliente
            // 
            lbErroCliente.AutoSize = true;
            lbErroCliente.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroCliente.Location = new Point(136, 68);
            lbErroCliente.Name = "lbErroCliente";
            lbErroCliente.Size = new Size(0, 15);
            lbErroCliente.TabIndex = 112;
            lbErroCliente.Visible = false;
            // 
            // txtCupom
            // 
            txtCupom.Enabled = false;
            txtCupom.Location = new Point(136, 288);
            txtCupom.Name = "txtCupom";
            txtCupom.Size = new Size(151, 23);
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
            // datePrevistaRetorno
            // 
            datePrevistaRetorno.Enabled = false;
            datePrevistaRetorno.Format = DateTimePickerFormat.Short;
            datePrevistaRetorno.Location = new Point(463, 243);
            datePrevistaRetorno.Name = "datePrevistaRetorno";
            datePrevistaRetorno.Size = new Size(154, 23);
            datePrevistaRetorno.TabIndex = 108;
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
            dateLocacao.Enabled = false;
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
            txtKmAutomovel.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
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
            cmbAutomovel.Enabled = false;
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
            cmbCondutor.Enabled = false;
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
            cmbPlanoCobranca.Enabled = false;
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
            cmbCategoriaAutomoveis.Enabled = false;
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
            cmbCliente.Enabled = false;
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
            cmbFuncionario.Enabled = false;
            cmbFuncionario.FormattingEnabled = true;
            cmbFuncionario.Location = new Point(136, 37);
            cmbFuncionario.Name = "cmbFuncionario";
            cmbFuncionario.Size = new Size(154, 23);
            cmbFuncionario.TabIndex = 91;
            // 
            // lbErroDataDevolucao
            // 
            lbErroDataDevolucao.AutoSize = true;
            lbErroDataDevolucao.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroDataDevolucao.Location = new Point(133, 316);
            lbErroDataDevolucao.Name = "lbErroDataDevolucao";
            lbErroDataDevolucao.Size = new Size(202, 15);
            lbErroDataDevolucao.TabIndex = 131;
            lbErroDataDevolucao.Text = "*Campo Data Devolução em branco*";
            lbErroDataDevolucao.Visible = false;
            // 
            // dateDevolucao
            // 
            dateDevolucao.Format = DateTimePickerFormat.Short;
            dateDevolucao.Location = new Point(133, 334);
            dateDevolucao.Name = "dateDevolucao";
            dateDevolucao.Size = new Size(154, 23);
            dateDevolucao.TabIndex = 130;
            dateDevolucao.ValueChanged += atualizarValor_SelectedValueChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(34, 340);
            label13.Name = "label13";
            label13.Size = new Size(93, 15);
            label13.TabIndex = 129;
            label13.Text = "Data Devolução:";
            // 
            // lbErroKmPercorrida
            // 
            lbErroKmPercorrida.AutoSize = true;
            lbErroKmPercorrida.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroKmPercorrida.Location = new Point(463, 316);
            lbErroKmPercorrida.Name = "lbErroKmPercorrida";
            lbErroKmPercorrida.Size = new Size(194, 15);
            lbErroKmPercorrida.TabIndex = 134;
            lbErroKmPercorrida.Text = "*Campo KM Percorrida em branco*";
            lbErroKmPercorrida.Visible = false;
            // 
            // txtKmPercorrida
            // 
            txtKmPercorrida.Location = new Point(463, 332);
            txtKmPercorrida.Name = "txtKmPercorrida";
            txtKmPercorrida.Size = new Size(120, 23);
            txtKmPercorrida.TabIndex = 133;
            txtKmPercorrida.ValueChanged += atualizarValor_SelectedValueChanged;
            txtKmPercorrida.Click += selecaoAutomaticaNumericUpDown_Click;
            txtKmPercorrida.Enter += selecaoAutomaticaNumericUpDown_Enter;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(372, 334);
            label15.Name = "label15";
            label15.Size = new Size(85, 15);
            label15.TabIndex = 132;
            label15.Text = "KM Percorrida:";
            // 
            // lbErroNivelTanque
            // 
            lbErroNivelTanque.AutoSize = true;
            lbErroNivelTanque.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroNivelTanque.Location = new Point(133, 364);
            lbErroNivelTanque.Name = "lbErroNivelTanque";
            lbErroNivelTanque.Size = new Size(182, 15);
            lbErroNivelTanque.TabIndex = 137;
            lbErroNivelTanque.Text = "*Campo Funcionário em branco*";
            lbErroNivelTanque.Visible = false;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(32, 382);
            label17.Name = "label17";
            label17.Size = new Size(95, 15);
            label17.TabIndex = 136;
            label17.Text = "Nível do Tanque:";
            // 
            // cmbNivelTanque
            // 
            cmbNivelTanque.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNivelTanque.FormattingEnabled = true;
            cmbNivelTanque.Location = new Point(133, 382);
            cmbNivelTanque.Name = "cmbNivelTanque";
            cmbNivelTanque.Size = new Size(154, 23);
            cmbNivelTanque.TabIndex = 135;
            cmbNivelTanque.SelectedValueChanged += atualizarValor_SelectedValueChanged;
            // 
            // lbValorTotal
            // 
            lbValorTotal.AutoSize = true;
            lbValorTotal.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbValorTotal.ForeColor = Color.Green;
            lbValorTotal.Location = new Point(204, 673);
            lbValorTotal.Name = "lbValorTotal";
            lbValorTotal.Size = new Size(15, 17);
            lbValorTotal.TabIndex = 138;
            lbValorTotal.Text = "0";
            lbValorTotal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // TelaAluguelDevolucaoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(699, 717);
            Controls.Add(lbValorTotal);
            Controls.Add(lbErroNivelTanque);
            Controls.Add(label17);
            Controls.Add(cmbNivelTanque);
            Controls.Add(lbErroKmPercorrida);
            Controls.Add(txtKmPercorrida);
            Controls.Add(label15);
            Controls.Add(lbErroDataDevolucao);
            Controls.Add(dateDevolucao);
            Controls.Add(label13);
            Controls.Add(lbErroValorTotal);
            Controls.Add(lbErroTaxas);
            Controls.Add(lblTextoValor);
            Controls.Add(label12);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(tbControlTaxasAdicionadas);
            Controls.Add(lbErroFuncionario);
            Controls.Add(lbErroCliente);
            Controls.Add(txtCupom);
            Controls.Add(label10);
            Controls.Add(datePrevistaRetorno);
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
            tbTaxas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtKmAutomovel).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtKmPercorrida).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbErroValorTotal;
        private Label lbErroTaxas;
        private Label lblTextoValor;
        private Label label12;
        private Button btnCancelar;
        private Button btnGravar;
        private TabControl tbControlTaxasAdicionadas;
        private TabPage tbTaxas;
        private Label lbErroFuncionario;
        private Label lbErroCliente;
        private TextBox txtCupom;
        private Label label10;
        private DateTimePicker datePrevistaRetorno;
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
        private Label lbErroDataDevolucao;
        private DateTimePicker dateDevolucao;
        private Label label13;
        private Label lbErroKmPercorrida;
        private NumericUpDown txtKmPercorrida;
        private Label label15;
        private Label lbErroNivelTanque;
        private Label label17;
        private ComboBox cmbNivelTanque;
        private CheckedListBox listTaxas;
        private Label lbValorTotal;
    }
}