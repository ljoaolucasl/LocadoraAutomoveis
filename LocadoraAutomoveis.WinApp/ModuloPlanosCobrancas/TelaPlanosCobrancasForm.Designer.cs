namespace LocadoraAutomoveis.WinApp.ModuloPlanosCobrancas
{
    partial class TelaPlanosCobrancasForm
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
            label1 = new Label();
            cmbCategoria = new ComboBox();
            btnCancelar = new Button();
            btnGravar = new Button();
            lbErroCategoria = new Label();
            tabPlanosCobrancas = new TabControl();
            tabPlanoCobrancaPage1 = new TabPage();
            lbTipoPlano = new Label();
            numPrecoKm1 = new NumericUpDown();
            numPrecoDiaria1 = new NumericUpDown();
            lbErroPrecoKm1 = new Label();
            lbErroPrecoDiaria1 = new Label();
            lbPrecoKm = new Label();
            label3 = new Label();
            label2 = new Label();
            tabPlanoCobrancaPage2 = new TabPage();
            label4 = new Label();
            numKmDisponivel2 = new NumericUpDown();
            numPrecoKm2 = new NumericUpDown();
            numPrecoDiaria2 = new NumericUpDown();
            lbErroKmDisponivel2 = new Label();
            lbErroPrecoKm2 = new Label();
            lbErroPrecoDiaria2 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            tabPlanoCobrancaPage3 = new TabPage();
            label13 = new Label();
            numPrecoDiaria3 = new NumericUpDown();
            lbErroPrecoDiaria3 = new Label();
            label19 = new Label();
            label20 = new Label();
            tabPlanosCobrancas.SuspendLayout();
            tabPlanoCobrancaPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPrecoKm1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrecoDiaria1).BeginInit();
            tabPlanoCobrancaPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numKmDisponivel2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrecoKm2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrecoDiaria2).BeginInit();
            tabPlanoCobrancaPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPrecoDiaria3).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 39);
            label1.Name = "label1";
            label1.Size = new Size(144, 15);
            label1.TabIndex = 0;
            label1.Text = "Categoria de Automóveis:";
            // 
            // cmbCategoria
            // 
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(177, 36);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(233, 23);
            cmbCategoria.TabIndex = 1;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(340, 366);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(85, 37);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(249, 366);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(85, 37);
            btnGravar.TabIndex = 9;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // lbErroCategoria
            // 
            lbErroCategoria.AutoSize = true;
            lbErroCategoria.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroCategoria.Location = new Point(177, 18);
            lbErroCategoria.Name = "lbErroCategoria";
            lbErroCategoria.Size = new Size(92, 15);
            lbErroCategoria.TabIndex = 6;
            lbErroCategoria.Text = "*mensagemErro";
            lbErroCategoria.Visible = false;
            // 
            // tabPlanosCobrancas
            // 
            tabPlanosCobrancas.Controls.Add(tabPlanoCobrancaPage1);
            tabPlanosCobrancas.Controls.Add(tabPlanoCobrancaPage2);
            tabPlanosCobrancas.Controls.Add(tabPlanoCobrancaPage3);
            tabPlanosCobrancas.Location = new Point(37, 83);
            tabPlanosCobrancas.Name = "tabPlanosCobrancas";
            tabPlanosCobrancas.SelectedIndex = 0;
            tabPlanosCobrancas.Size = new Size(388, 257);
            tabPlanosCobrancas.TabIndex = 2;
            // 
            // tabPlanoCobrancaPage1
            // 
            tabPlanoCobrancaPage1.BackColor = Color.White;
            tabPlanoCobrancaPage1.Controls.Add(lbTipoPlano);
            tabPlanoCobrancaPage1.Controls.Add(numPrecoKm1);
            tabPlanoCobrancaPage1.Controls.Add(numPrecoDiaria1);
            tabPlanoCobrancaPage1.Controls.Add(lbErroPrecoKm1);
            tabPlanoCobrancaPage1.Controls.Add(lbErroPrecoDiaria1);
            tabPlanoCobrancaPage1.Controls.Add(lbPrecoKm);
            tabPlanoCobrancaPage1.Controls.Add(label3);
            tabPlanoCobrancaPage1.Controls.Add(label2);
            tabPlanoCobrancaPage1.Location = new Point(4, 24);
            tabPlanoCobrancaPage1.Name = "tabPlanoCobrancaPage1";
            tabPlanoCobrancaPage1.Padding = new Padding(3);
            tabPlanoCobrancaPage1.Size = new Size(380, 229);
            tabPlanoCobrancaPage1.TabIndex = 0;
            tabPlanoCobrancaPage1.Text = "Plano Diário";
            // 
            // lbTipoPlano
            // 
            lbTipoPlano.AutoSize = true;
            lbTipoPlano.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbTipoPlano.Location = new Point(142, 62);
            lbTipoPlano.Name = "lbTipoPlano";
            lbTipoPlano.Size = new Size(73, 15);
            lbTipoPlano.TabIndex = 26;
            lbTipoPlano.Text = "Plano Diário";
            // 
            // numPrecoKm1
            // 
            numPrecoKm1.DecimalPlaces = 2;
            numPrecoKm1.Location = new Point(142, 142);
            numPrecoKm1.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            numPrecoKm1.Name = "numPrecoKm1";
            numPrecoKm1.Size = new Size(190, 23);
            numPrecoKm1.TabIndex = 4;
            numPrecoKm1.ThousandsSeparator = true;
            numPrecoKm1.Click += selecaoAutomaticaNumericUpDown_Click;
            numPrecoKm1.Enter += selecaoAutomaticaNumericUpDown_Enter;
            // 
            // numPrecoDiaria1
            // 
            numPrecoDiaria1.DecimalPlaces = 2;
            numPrecoDiaria1.Location = new Point(142, 98);
            numPrecoDiaria1.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            numPrecoDiaria1.Name = "numPrecoDiaria1";
            numPrecoDiaria1.Size = new Size(190, 23);
            numPrecoDiaria1.TabIndex = 3;
            numPrecoDiaria1.ThousandsSeparator = true;
            numPrecoDiaria1.Click += selecaoAutomaticaNumericUpDown_Click;
            numPrecoDiaria1.Enter += selecaoAutomaticaNumericUpDown_Enter;
            // 
            // lbErroPrecoKm1
            // 
            lbErroPrecoKm1.AutoSize = true;
            lbErroPrecoKm1.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroPrecoKm1.Location = new Point(143, 124);
            lbErroPrecoKm1.Name = "lbErroPrecoKm1";
            lbErroPrecoKm1.Size = new Size(92, 15);
            lbErroPrecoKm1.TabIndex = 21;
            lbErroPrecoKm1.Text = "*mensagemErro";
            lbErroPrecoKm1.Visible = false;
            // 
            // lbErroPrecoDiaria1
            // 
            lbErroPrecoDiaria1.AutoSize = true;
            lbErroPrecoDiaria1.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroPrecoDiaria1.Location = new Point(143, 80);
            lbErroPrecoDiaria1.Name = "lbErroPrecoDiaria1";
            lbErroPrecoDiaria1.Size = new Size(92, 15);
            lbErroPrecoDiaria1.TabIndex = 20;
            lbErroPrecoDiaria1.Text = "*mensagemErro";
            lbErroPrecoDiaria1.Visible = false;
            // 
            // lbPrecoKm
            // 
            lbPrecoKm.AutoSize = true;
            lbPrecoKm.Location = new Point(54, 148);
            lbPrecoKm.Name = "lbPrecoKm";
            lbPrecoKm.Size = new Size(82, 15);
            lbPrecoKm.TabIndex = 17;
            lbPrecoKm.Text = "Preço por Km:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(63, 105);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 15;
            label3.Text = "Preço Diária:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(53, 62);
            label2.Name = "label2";
            label2.Size = new Size(83, 15);
            label2.TabIndex = 14;
            label2.Text = "Tipo do Plano:";
            // 
            // tabPlanoCobrancaPage2
            // 
            tabPlanoCobrancaPage2.BackColor = Color.White;
            tabPlanoCobrancaPage2.Controls.Add(label4);
            tabPlanoCobrancaPage2.Controls.Add(numKmDisponivel2);
            tabPlanoCobrancaPage2.Controls.Add(numPrecoKm2);
            tabPlanoCobrancaPage2.Controls.Add(numPrecoDiaria2);
            tabPlanoCobrancaPage2.Controls.Add(lbErroKmDisponivel2);
            tabPlanoCobrancaPage2.Controls.Add(lbErroPrecoKm2);
            tabPlanoCobrancaPage2.Controls.Add(lbErroPrecoDiaria2);
            tabPlanoCobrancaPage2.Controls.Add(label9);
            tabPlanoCobrancaPage2.Controls.Add(label10);
            tabPlanoCobrancaPage2.Controls.Add(label11);
            tabPlanoCobrancaPage2.Controls.Add(label12);
            tabPlanoCobrancaPage2.Location = new Point(4, 24);
            tabPlanoCobrancaPage2.Name = "tabPlanoCobrancaPage2";
            tabPlanoCobrancaPage2.Padding = new Padding(3);
            tabPlanoCobrancaPage2.Size = new Size(380, 229);
            tabPlanoCobrancaPage2.TabIndex = 1;
            tabPlanoCobrancaPage2.Text = "Plano Controlador";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(168, 41);
            label4.Name = "label4";
            label4.Size = new Size(106, 15);
            label4.TabIndex = 37;
            label4.Text = "Plano Controlador";
            // 
            // numKmDisponivel2
            // 
            numKmDisponivel2.Location = new Point(168, 165);
            numKmDisponivel2.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            numKmDisponivel2.Name = "numKmDisponivel2";
            numKmDisponivel2.Size = new Size(201, 23);
            numKmDisponivel2.TabIndex = 7;
            numKmDisponivel2.ThousandsSeparator = true;
            numKmDisponivel2.Click += selecaoAutomaticaNumericUpDown_Click;
            numKmDisponivel2.Enter += selecaoAutomaticaNumericUpDown_Enter;
            // 
            // numPrecoKm2
            // 
            numPrecoKm2.DecimalPlaces = 2;
            numPrecoKm2.Location = new Point(168, 121);
            numPrecoKm2.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            numPrecoKm2.Name = "numPrecoKm2";
            numPrecoKm2.Size = new Size(201, 23);
            numPrecoKm2.TabIndex = 6;
            numPrecoKm2.ThousandsSeparator = true;
            numPrecoKm2.Click += selecaoAutomaticaNumericUpDown_Click;
            numPrecoKm2.Enter += selecaoAutomaticaNumericUpDown_Enter;
            // 
            // numPrecoDiaria2
            // 
            numPrecoDiaria2.DecimalPlaces = 2;
            numPrecoDiaria2.Location = new Point(168, 77);
            numPrecoDiaria2.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            numPrecoDiaria2.Name = "numPrecoDiaria2";
            numPrecoDiaria2.Size = new Size(201, 23);
            numPrecoDiaria2.TabIndex = 5;
            numPrecoDiaria2.ThousandsSeparator = true;
            numPrecoDiaria2.Click += selecaoAutomaticaNumericUpDown_Click;
            numPrecoDiaria2.Enter += selecaoAutomaticaNumericUpDown_Enter;
            // 
            // lbErroKmDisponivel2
            // 
            lbErroKmDisponivel2.AutoSize = true;
            lbErroKmDisponivel2.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroKmDisponivel2.Location = new Point(158, 147);
            lbErroKmDisponivel2.Name = "lbErroKmDisponivel2";
            lbErroKmDisponivel2.Size = new Size(92, 15);
            lbErroKmDisponivel2.TabIndex = 33;
            lbErroKmDisponivel2.Text = "*mensagemErro";
            lbErroKmDisponivel2.Visible = false;
            // 
            // lbErroPrecoKm2
            // 
            lbErroPrecoKm2.AutoSize = true;
            lbErroPrecoKm2.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroPrecoKm2.Location = new Point(168, 103);
            lbErroPrecoKm2.Name = "lbErroPrecoKm2";
            lbErroPrecoKm2.Size = new Size(92, 15);
            lbErroPrecoKm2.TabIndex = 32;
            lbErroPrecoKm2.Text = "*mensagemErro";
            lbErroPrecoKm2.Visible = false;
            // 
            // lbErroPrecoDiaria2
            // 
            lbErroPrecoDiaria2.AutoSize = true;
            lbErroPrecoDiaria2.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroPrecoDiaria2.Location = new Point(168, 59);
            lbErroPrecoDiaria2.Name = "lbErroPrecoDiaria2";
            lbErroPrecoDiaria2.Size = new Size(92, 15);
            lbErroPrecoDiaria2.TabIndex = 31;
            lbErroPrecoDiaria2.Text = "*mensagemErro";
            lbErroPrecoDiaria2.Visible = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(71, 164);
            label9.Name = "label9";
            label9.Size = new Size(91, 15);
            label9.TabIndex = 30;
            label9.Text = "Km Disponíveis:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 123);
            label10.Name = "label10";
            label10.Size = new Size(156, 15);
            label10.TabIndex = 29;
            label10.Text = "Preço por Km (Extrapolado):";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(89, 82);
            label11.Name = "label11";
            label11.Size = new Size(73, 15);
            label11.TabIndex = 28;
            label11.Text = "Preço Diária:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(79, 41);
            label12.Name = "label12";
            label12.Size = new Size(83, 15);
            label12.TabIndex = 27;
            label12.Text = "Tipo do Plano:";
            // 
            // tabPlanoCobrancaPage3
            // 
            tabPlanoCobrancaPage3.BackColor = Color.White;
            tabPlanoCobrancaPage3.Controls.Add(label13);
            tabPlanoCobrancaPage3.Controls.Add(numPrecoDiaria3);
            tabPlanoCobrancaPage3.Controls.Add(lbErroPrecoDiaria3);
            tabPlanoCobrancaPage3.Controls.Add(label19);
            tabPlanoCobrancaPage3.Controls.Add(label20);
            tabPlanoCobrancaPage3.Location = new Point(4, 24);
            tabPlanoCobrancaPage3.Name = "tabPlanoCobrancaPage3";
            tabPlanoCobrancaPage3.Padding = new Padding(3);
            tabPlanoCobrancaPage3.Size = new Size(380, 229);
            tabPlanoCobrancaPage3.TabIndex = 2;
            tabPlanoCobrancaPage3.Text = "Plano Livre";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label13.Location = new Point(141, 79);
            label13.Name = "label13";
            label13.Size = new Size(68, 15);
            label13.TabIndex = 48;
            label13.Text = "Plano Livre";
            // 
            // numPrecoDiaria3
            // 
            numPrecoDiaria3.DecimalPlaces = 2;
            numPrecoDiaria3.Location = new Point(141, 115);
            numPrecoDiaria3.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            numPrecoDiaria3.Name = "numPrecoDiaria3";
            numPrecoDiaria3.Size = new Size(184, 23);
            numPrecoDiaria3.TabIndex = 8;
            numPrecoDiaria3.ThousandsSeparator = true;
            numPrecoDiaria3.Click += selecaoAutomaticaNumericUpDown_Click;
            numPrecoDiaria3.Enter += selecaoAutomaticaNumericUpDown_Enter;
            // 
            // lbErroPrecoDiaria3
            // 
            lbErroPrecoDiaria3.AutoSize = true;
            lbErroPrecoDiaria3.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroPrecoDiaria3.Location = new Point(142, 97);
            lbErroPrecoDiaria3.Name = "lbErroPrecoDiaria3";
            lbErroPrecoDiaria3.Size = new Size(92, 15);
            lbErroPrecoDiaria3.TabIndex = 42;
            lbErroPrecoDiaria3.Text = "*mensagemErro";
            lbErroPrecoDiaria3.Visible = false;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(62, 122);
            label19.Name = "label19";
            label19.Size = new Size(73, 15);
            label19.TabIndex = 39;
            label19.Text = "Preço Diária:";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(52, 79);
            label20.Name = "label20";
            label20.Size = new Size(83, 15);
            label20.TabIndex = 38;
            label20.Text = "Tipo do Plano:";
            // 
            // TelaPlanosCobrancasForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(446, 415);
            Controls.Add(tabPlanosCobrancas);
            Controls.Add(lbErroCategoria);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(cmbCategoria);
            Controls.Add(label1);
            Name = "TelaPlanosCobrancasForm";
            Text = "Cadastro de Plano de Cobrança";
            tabPlanosCobrancas.ResumeLayout(false);
            tabPlanoCobrancaPage1.ResumeLayout(false);
            tabPlanoCobrancaPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPrecoKm1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrecoDiaria1).EndInit();
            tabPlanoCobrancaPage2.ResumeLayout(false);
            tabPlanoCobrancaPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numKmDisponivel2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrecoKm2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrecoDiaria2).EndInit();
            tabPlanoCobrancaPage3.ResumeLayout(false);
            tabPlanoCobrancaPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPrecoDiaria3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbCategoria;
        private Button btnCancelar;
        private Button btnGravar;
        private Label lbErroCategoria;
        private TabControl tabPlanosCobrancas;
        private TabPage tabPlanoCobrancaPage1;
        private TabPage tabPlanoCobrancaPage2;
        private TabPage tabPlanoCobrancaPage3;
        private Label lbTipoPlano;
        private NumericUpDown numPrecoKm1;
        private Label lbErroPrecoKm1;
        private Label lbErroPrecoDiaria1;
        private Label lbPrecoKm;
        private Label label3;
        private Label label2;
        private Label label4;
        private NumericUpDown numKmDisponivel2;
        private NumericUpDown numPrecoKm2;
        private NumericUpDown numPrecoDiaria2;
        private Label lbErroKmDisponivel2;
        private Label lbErroPrecoKm2;
        private Label lbErroPrecoDiaria2;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private NumericUpDown numPrecoDiaria3;
        private Label lbErroPrecoDiaria3;
        private Label label19;
        private Label label20;
        private NumericUpDown numPrecoDiaria1;
    }
}