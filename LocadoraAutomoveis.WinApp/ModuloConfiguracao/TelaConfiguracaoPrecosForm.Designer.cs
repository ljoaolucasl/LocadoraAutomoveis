namespace LocadoraAutomoveis.WinApp.ModuloConfiguracao
{
    partial class TelaConfiguracaoPrecosForm
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
            txtGasolina = new NumericUpDown();
            btnCancelar = new Button();
            btnGravar = new Button();
            txtDiesel = new NumericUpDown();
            label2 = new Label();
            txtEtanol = new NumericUpDown();
            label3 = new Label();
            txtGas = new NumericUpDown();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)txtGasolina).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDiesel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEtanol).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtGas).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 48);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 0;
            label1.Text = "Gasolina:";
            // 
            // txtGasolina
            // 
            txtGasolina.DecimalPlaces = 2;
            txtGasolina.Location = new Point(99, 46);
            txtGasolina.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            txtGasolina.Name = "txtGasolina";
            txtGasolina.Size = new Size(219, 23);
            txtGasolina.TabIndex = 1;
            txtGasolina.Click += selecaoAutomaticaNumericUpDown_Click;
            txtGasolina.Enter += selecaoAutomaticaNumericUpDown_Enter;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(285, 223);
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
            btnGravar.Location = new Point(194, 223);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(85, 37);
            btnGravar.TabIndex = 5;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // txtDiesel
            // 
            txtDiesel.DecimalPlaces = 2;
            txtDiesel.Location = new Point(99, 84);
            txtDiesel.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            txtDiesel.Name = "txtDiesel";
            txtDiesel.Size = new Size(219, 23);
            txtDiesel.TabIndex = 2;
            txtDiesel.Click += selecaoAutomaticaNumericUpDown_Click;
            txtDiesel.Enter += selecaoAutomaticaNumericUpDown_Enter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(52, 86);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 126;
            label2.Text = "Diesel:";
            // 
            // txtEtanol
            // 
            txtEtanol.DecimalPlaces = 2;
            txtEtanol.Location = new Point(99, 122);
            txtEtanol.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            txtEtanol.Name = "txtEtanol";
            txtEtanol.Size = new Size(219, 23);
            txtEtanol.TabIndex = 3;
            txtEtanol.Click += selecaoAutomaticaNumericUpDown_Click;
            txtEtanol.Enter += selecaoAutomaticaNumericUpDown_Enter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(52, 124);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 128;
            label3.Text = "Etanol:";
            // 
            // txtGas
            // 
            txtGas.DecimalPlaces = 2;
            txtGas.Location = new Point(99, 160);
            txtGas.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            txtGas.Name = "txtGas";
            txtGas.Size = new Size(219, 23);
            txtGas.TabIndex = 4;
            txtGas.Click += selecaoAutomaticaNumericUpDown_Click;
            txtGas.Enter += selecaoAutomaticaNumericUpDown_Enter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(64, 162);
            label4.Name = "label4";
            label4.Size = new Size(29, 15);
            label4.TabIndex = 130;
            label4.Text = "Gás:";
            // 
            // TelaConfiguracaoPrecosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 272);
            Controls.Add(txtGas);
            Controls.Add(label4);
            Controls.Add(txtEtanol);
            Controls.Add(label3);
            Controls.Add(txtDiesel);
            Controls.Add(label2);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(txtGasolina);
            Controls.Add(label1);
            Name = "TelaConfiguracaoPrecosForm";
            Text = "Configuração de Preços";
            Shown += TelaConfiguracaoPrecosForm_Shown;
            ((System.ComponentModel.ISupportInitialize)txtGasolina).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtDiesel).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEtanol).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtGas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private NumericUpDown txtGasolina;
        private Button btnCancelar;
        private Button btnGravar;
        private NumericUpDown txtDiesel;
        private Label label2;
        private NumericUpDown txtEtanol;
        private Label label3;
        private NumericUpDown txtGas;
        private Label label4;
    }
}