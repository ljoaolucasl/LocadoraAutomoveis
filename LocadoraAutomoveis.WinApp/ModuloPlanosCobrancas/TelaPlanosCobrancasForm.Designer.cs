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
            cmbGrupoAutomoveis = new ComboBox();
            groupBox1 = new GroupBox();
            lbKmDisponiveis = new Label();
            lbPrecoKm = new Label();
            lbPrecoDiaria = new Label();
            lbTipoPlano = new Label();
            cmbTipoPlano = new ComboBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            btnCancelar = new Button();
            btnGravar = new Button();
            lbErroGrupoAutomoveis = new Label();
            txtPrecoDiaria = new TextBox();
            txtPrecoKm = new TextBox();
            txtKmDisponiveis = new TextBox();
            groupBox1.SuspendLayout();
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
            // cmbGrupoAutomoveis
            // 
            cmbGrupoAutomoveis.FormattingEnabled = true;
            cmbGrupoAutomoveis.Location = new Point(177, 36);
            cmbGrupoAutomoveis.Name = "cmbGrupoAutomoveis";
            cmbGrupoAutomoveis.Size = new Size(233, 23);
            cmbGrupoAutomoveis.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtKmDisponiveis);
            groupBox1.Controls.Add(txtPrecoKm);
            groupBox1.Controls.Add(txtPrecoDiaria);
            groupBox1.Controls.Add(lbKmDisponiveis);
            groupBox1.Controls.Add(lbPrecoKm);
            groupBox1.Controls.Add(lbPrecoDiaria);
            groupBox1.Controls.Add(lbTipoPlano);
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
            // lbKmDisponiveis
            // 
            lbKmDisponiveis.AutoSize = true;
            lbKmDisponiveis.ForeColor = Color.FromArgb(192, 0, 0);
            lbKmDisponiveis.Location = new Point(151, 157);
            lbKmDisponiveis.Name = "lbKmDisponiveis";
            lbKmDisponiveis.Size = new Size(92, 15);
            lbKmDisponiveis.TabIndex = 10;
            lbKmDisponiveis.Text = "*mensagemErro";
            // 
            // lbPrecoKm
            // 
            lbPrecoKm.AutoSize = true;
            lbPrecoKm.ForeColor = Color.FromArgb(192, 0, 0);
            lbPrecoKm.Location = new Point(151, 111);
            lbPrecoKm.Name = "lbPrecoKm";
            lbPrecoKm.Size = new Size(92, 15);
            lbPrecoKm.TabIndex = 9;
            lbPrecoKm.Text = "*mensagemErro";
            // 
            // lbPrecoDiaria
            // 
            lbPrecoDiaria.AutoSize = true;
            lbPrecoDiaria.ForeColor = Color.FromArgb(192, 0, 0);
            lbPrecoDiaria.Location = new Point(151, 65);
            lbPrecoDiaria.Name = "lbPrecoDiaria";
            lbPrecoDiaria.Size = new Size(92, 15);
            lbPrecoDiaria.TabIndex = 8;
            lbPrecoDiaria.Text = "*mensagemErro";
            // 
            // lbTipoPlano
            // 
            lbTipoPlano.AutoSize = true;
            lbTipoPlano.ForeColor = Color.FromArgb(192, 0, 0);
            lbTipoPlano.Location = new Point(151, 19);
            lbTipoPlano.Name = "lbTipoPlano";
            lbTipoPlano.Size = new Size(92, 15);
            lbTipoPlano.TabIndex = 7;
            lbTipoPlano.Text = "*mensagemErro";
            // 
            // cmbTipoPlano
            // 
            cmbTipoPlano.FormattingEnabled = true;
            cmbTipoPlano.Location = new Point(151, 38);
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
            label4.Location = new Point(62, 133);
            label4.Name = "label4";
            label4.Size = new Size(82, 15);
            label4.TabIndex = 3;
            label4.Text = "Preço por Km:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(72, 87);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 2;
            label3.Text = "Preço Diária:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(62, 41);
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
            // lbErroGrupoAutomoveis
            // 
            lbErroGrupoAutomoveis.AutoSize = true;
            lbErroGrupoAutomoveis.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroGrupoAutomoveis.Location = new Point(177, 18);
            lbErroGrupoAutomoveis.Name = "lbErroGrupoAutomoveis";
            lbErroGrupoAutomoveis.Size = new Size(92, 15);
            lbErroGrupoAutomoveis.TabIndex = 6;
            lbErroGrupoAutomoveis.Text = "*mensagemErro";
            // 
            // txtPrecoDiaria
            // 
            txtPrecoDiaria.Location = new Point(151, 83);
            txtPrecoDiaria.Name = "txtPrecoDiaria";
            txtPrecoDiaria.Size = new Size(205, 23);
            txtPrecoDiaria.TabIndex = 11;
            // 
            // txtPrecoKm
            // 
            txtPrecoKm.Location = new Point(151, 129);
            txtPrecoKm.Name = "txtPrecoKm";
            txtPrecoKm.Size = new Size(205, 23);
            txtPrecoKm.TabIndex = 12;
            // 
            // txtKmDisponiveis
            // 
            txtKmDisponiveis.Location = new Point(151, 175);
            txtKmDisponiveis.Name = "txtKmDisponiveis";
            txtKmDisponiveis.Size = new Size(205, 23);
            txtKmDisponiveis.TabIndex = 13;
            // 
            // TelaPlanosCobrancasForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(446, 415);
            Controls.Add(lbErroGrupoAutomoveis);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(groupBox1);
            Controls.Add(cmbGrupoAutomoveis);
            Controls.Add(label1);
            Name = "TelaPlanosCobrancasForm";
            Text = "Cadastro de Plano de Cobrança";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbGrupoAutomoveis;
        private GroupBox groupBox1;
        private ComboBox cmbTipoPlano;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button btnCancelar;
        private Button btnGravar;
        private Label lbErroGrupoAutomoveis;
        private Label lbKmDisponiveis;
        private Label lbPrecoKm;
        private Label lbPrecoDiaria;
        private Label lbTipoPlano;
        private TextBox txtKmDisponiveis;
        private TextBox txtPrecoKm;
        private TextBox txtPrecoDiaria;
    }
}