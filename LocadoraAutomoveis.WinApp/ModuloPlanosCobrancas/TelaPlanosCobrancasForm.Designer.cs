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
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            btnCancelar = new Button();
            btnGravar = new Button();
            lbErroCategoria = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numKmDisponivel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrecoKm).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrecoDiaria).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 39);
            label1.Name = "label1";
            label1.Size = new Size(126, 15);
            label1.TabIndex = 0;
            label1.Text = "Grupo de Automóveis:";
            // 
            // cmbCategoria
            // 
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(177, 36);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(233, 23);
            cmbCategoria.TabIndex = 1;
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
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(35, 81);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(375, 225);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Configuaração de Planos";
            // 
            // numKmDisponivel
            // 
            numKmDisponivel.DecimalPlaces = 2;
            numKmDisponivel.Location = new Point(151, 177);
            numKmDisponivel.Name = "numKmDisponivel";
            numKmDisponivel.Size = new Size(206, 23);
            numKmDisponivel.TabIndex = 13;
            // 
            // numPrecoKm
            // 
            numPrecoKm.DecimalPlaces = 2;
            numPrecoKm.Location = new Point(151, 133);
            numPrecoKm.Name = "numPrecoKm";
            numPrecoKm.Size = new Size(206, 23);
            numPrecoKm.TabIndex = 12;
            // 
            // numPrecoDiaria
            // 
            numPrecoDiaria.DecimalPlaces = 2;
            numPrecoDiaria.Location = new Point(151, 89);
            numPrecoDiaria.Name = "numPrecoDiaria";
            numPrecoDiaria.Size = new Size(206, 23);
            numPrecoDiaria.TabIndex = 11;
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
            // 
            // cmbTipoPlano
            // 
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
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(63, 135);
            label4.Name = "label4";
            label4.Size = new Size(82, 15);
            label4.TabIndex = 3;
            label4.Text = "Preço por Km:";
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
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(340, 366);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(85, 37);
            btnCancelar.TabIndex = 5;
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
            btnGravar.TabIndex = 4;
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
            // 
            // TelaPlanosCobrancasForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(446, 415);
            Controls.Add(lbErroCategoria);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(groupBox1);
            Controls.Add(cmbCategoria);
            Controls.Add(label1);
            Name = "TelaPlanosCobrancasForm";
            Text = "Cadastro de Plano de Cobrança";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numKmDisponivel).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrecoKm).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrecoDiaria).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbCategoria;
        private GroupBox groupBox1;
        private ComboBox cmbTipoPlano;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button btnCancelar;
        private Button btnGravar;
        private Label lbErroCategoria;
        private Label lbErroKmDisponivel;
        private Label lbErroPrecoKm;
        private Label lbErroPrecoDiaria;
        private Label lbErroTipoPlano;
        private NumericUpDown numKmDisponivel;
        private NumericUpDown numPrecoKm;
        private NumericUpDown numPrecoDiaria;
    }
}