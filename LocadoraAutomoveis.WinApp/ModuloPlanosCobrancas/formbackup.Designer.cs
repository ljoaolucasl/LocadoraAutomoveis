namespace LocadoraAutomoveis.WinApp.ModuloPlanosCobrancas
{
    partial class formbackup
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
            groupBox1 = new GroupBox();
            numKmDisponivel = new NumericUpDown();
            numPrecoKm = new NumericUpDown();
            numPrecoDiaria = new NumericUpDown();
            lbErroKmDisponivel = new Label();
            lbErroPrecoKm = new Label();
            lbErroPrecoDiaria = new Label();
            lbErroTipoPlano = new Label();
            cmbTipoPlano = new ComboBox();
            label5 = new Label();
            lbPrecoKm = new Label();
            label3 = new Label();
            label2 = new Label();
            tabPlanoCobranca = new TabControl();
            tabPlanoCobrancaPage1 = new TabPage();
            label1 = new Label();
            tabPlanoCobrancaPage2 = new TabPage();
            tabPlanoCobrancaPage3 = new TabPage();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numKmDisponivel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrecoKm).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrecoDiaria).BeginInit();
            tabPlanoCobranca.SuspendLayout();
            tabPlanoCobrancaPage1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(numKmDisponivel);
            groupBox1.Controls.Add(numPrecoKm);
            groupBox1.Controls.Add(numPrecoDiaria);
            groupBox1.Controls.Add(lbErroKmDisponivel);
            groupBox1.Controls.Add(lbErroPrecoKm);
            groupBox1.Controls.Add(lbErroPrecoDiaria);
            groupBox1.Controls.Add(lbErroTipoPlano);
            groupBox1.Controls.Add(cmbTipoPlano);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(lbPrecoKm);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(49, 54);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(375, 225);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "c";
            // 
            // numKmDisponivel
            // 
            numKmDisponivel.Location = new Point(151, 177);
            numKmDisponivel.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            numKmDisponivel.Name = "numKmDisponivel";
            numKmDisponivel.Size = new Size(206, 23);
            numKmDisponivel.TabIndex = 13;
            numKmDisponivel.ThousandsSeparator = true;
            // 
            // numPrecoKm
            // 
            numPrecoKm.DecimalPlaces = 2;
            numPrecoKm.Location = new Point(151, 133);
            numPrecoKm.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            numPrecoKm.Name = "numPrecoKm";
            numPrecoKm.Size = new Size(206, 23);
            numPrecoKm.TabIndex = 12;
            numPrecoKm.ThousandsSeparator = true;
            // 
            // numPrecoDiaria
            // 
            numPrecoDiaria.DecimalPlaces = 2;
            numPrecoDiaria.Location = new Point(151, 89);
            numPrecoDiaria.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            numPrecoDiaria.Name = "numPrecoDiaria";
            numPrecoDiaria.Size = new Size(206, 23);
            numPrecoDiaria.TabIndex = 11;
            numPrecoDiaria.ThousandsSeparator = true;
            // 
            // lbErroKmDisponivel
            // 
            lbErroKmDisponivel.AutoSize = true;
            lbErroKmDisponivel.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroKmDisponivel.Location = new Point(152, 159);
            lbErroKmDisponivel.Name = "lbErroKmDisponivel";
            lbErroKmDisponivel.Size = new Size(92, 15);
            lbErroKmDisponivel.TabIndex = 10;
            lbErroKmDisponivel.Text = "*mensagemErro";
            lbErroKmDisponivel.Visible = false;
            // 
            // lbErroPrecoKm
            // 
            lbErroPrecoKm.AutoSize = true;
            lbErroPrecoKm.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroPrecoKm.Location = new Point(152, 115);
            lbErroPrecoKm.Name = "lbErroPrecoKm";
            lbErroPrecoKm.Size = new Size(92, 15);
            lbErroPrecoKm.TabIndex = 9;
            lbErroPrecoKm.Text = "*mensagemErro";
            lbErroPrecoKm.Visible = false;
            // 
            // lbErroPrecoDiaria
            // 
            lbErroPrecoDiaria.AutoSize = true;
            lbErroPrecoDiaria.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroPrecoDiaria.Location = new Point(152, 71);
            lbErroPrecoDiaria.Name = "lbErroPrecoDiaria";
            lbErroPrecoDiaria.Size = new Size(92, 15);
            lbErroPrecoDiaria.TabIndex = 8;
            lbErroPrecoDiaria.Text = "*mensagemErro";
            lbErroPrecoDiaria.Visible = false;
            // 
            // lbErroTipoPlano
            // 
            lbErroTipoPlano.AutoSize = true;
            lbErroTipoPlano.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroTipoPlano.Location = new Point(152, 27);
            lbErroTipoPlano.Name = "lbErroTipoPlano";
            lbErroTipoPlano.Size = new Size(92, 15);
            lbErroTipoPlano.TabIndex = 7;
            lbErroTipoPlano.Text = "*mensagemErro";
            lbErroTipoPlano.Visible = false;
            // 
            // cmbTipoPlano
            // 
            cmbTipoPlano.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoPlano.FormattingEnabled = true;
            cmbTipoPlano.Location = new Point(152, 45);
            cmbTipoPlano.Name = "cmbTipoPlano";
            cmbTipoPlano.Size = new Size(205, 23);
            cmbTipoPlano.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(54, 179);
            label5.Name = "label5";
            label5.Size = new Size(91, 15);
            label5.TabIndex = 4;
            label5.Text = "Km Disponíveis:";
            // 
            // lbPrecoKm
            // 
            lbPrecoKm.AutoSize = true;
            lbPrecoKm.Location = new Point(63, 135);
            lbPrecoKm.Name = "lbPrecoKm";
            lbPrecoKm.Size = new Size(82, 15);
            lbPrecoKm.TabIndex = 3;
            lbPrecoKm.Text = "Preço por Km:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(72, 91);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 2;
            label3.Text = "Preço Diária:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(62, 48);
            label2.Name = "label2";
            label2.Size = new Size(83, 15);
            label2.TabIndex = 1;
            label2.Text = "Tipo do Plano:";
            // 
            // tabPlanoCobranca
            // 
            tabPlanoCobranca.Controls.Add(tabPlanoCobrancaPage1);
            tabPlanoCobranca.Controls.Add(tabPlanoCobrancaPage2);
            tabPlanoCobranca.Controls.Add(tabPlanoCobrancaPage3);
            tabPlanoCobranca.Location = new Point(430, 154);
            tabPlanoCobranca.Name = "tabPlanoCobranca";
            tabPlanoCobranca.SelectedIndex = 0;
            tabPlanoCobranca.Size = new Size(372, 249);
            tabPlanoCobranca.TabIndex = 8;
            // 
            // tabPlanoCobrancaPage1
            // 
            tabPlanoCobrancaPage1.Controls.Add(label1);
            tabPlanoCobrancaPage1.Location = new Point(4, 24);
            tabPlanoCobrancaPage1.Name = "tabPlanoCobrancaPage1";
            tabPlanoCobrancaPage1.Padding = new Padding(3);
            tabPlanoCobrancaPage1.Size = new Size(364, 221);
            tabPlanoCobrancaPage1.TabIndex = 0;
            tabPlanoCobrancaPage1.Text = "tabPage1";
            tabPlanoCobrancaPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 22);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // tabPlanoCobrancaPage2
            // 
            tabPlanoCobrancaPage2.Location = new Point(4, 24);
            tabPlanoCobrancaPage2.Name = "tabPlanoCobrancaPage2";
            tabPlanoCobrancaPage2.Padding = new Padding(3);
            tabPlanoCobrancaPage2.Size = new Size(364, 221);
            tabPlanoCobrancaPage2.TabIndex = 1;
            tabPlanoCobrancaPage2.Text = "tabPage2";
            tabPlanoCobrancaPage2.UseVisualStyleBackColor = true;
            // 
            // tabPlanoCobrancaPage3
            // 
            tabPlanoCobrancaPage3.Location = new Point(4, 24);
            tabPlanoCobrancaPage3.Name = "tabPlanoCobrancaPage3";
            tabPlanoCobrancaPage3.Padding = new Padding(3);
            tabPlanoCobrancaPage3.Size = new Size(364, 221);
            tabPlanoCobrancaPage3.TabIndex = 2;
            tabPlanoCobrancaPage3.Text = "tabPage3";
            tabPlanoCobrancaPage3.UseVisualStyleBackColor = true;
            // 
            // formbackup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabPlanoCobranca);
            Controls.Add(groupBox1);
            Name = "formbackup";
            Text = "formbackup";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numKmDisponivel).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrecoKm).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrecoDiaria).EndInit();
            tabPlanoCobranca.ResumeLayout(false);
            tabPlanoCobrancaPage1.ResumeLayout(false);
            tabPlanoCobrancaPage1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private NumericUpDown numKmDisponivel;
        private NumericUpDown numPrecoKm;
        private NumericUpDown numPrecoDiaria;
        private Label lbErroKmDisponivel;
        private Label lbErroPrecoKm;
        private Label lbErroPrecoDiaria;
        private Label lbErroTipoPlano;
        private ComboBox cmbTipoPlano;
        private Label label5;
        private Label lbPrecoKm;
        private Label label3;
        private Label label2;
        private TabControl tabPlanoCobranca;
        private TabPage tabPlanoCobrancaPage1;
        private Label label1;
        private TabPage tabPlanoCobrancaPage2;
        private TabPage tabPlanoCobrancaPage3;
    }
}