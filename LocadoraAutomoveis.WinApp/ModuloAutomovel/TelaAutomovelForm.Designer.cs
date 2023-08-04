namespace LocadoraAutomoveis.WinApp.ModuloAutomovel
{
    partial class TelaAutomovelForm
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
            lbErroCategoria = new Label();
            btnCancelar = new Button();
            btnGravar = new Button();
            lbNome = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtModelo = new TextBox();
            txtMarca = new TextBox();
            txtCor = new TextBox();
            cbCategoria = new ComboBox();
            btnBuscar = new Button();
            pbImagem = new PictureBox();
            cbCombustivel = new ComboBox();
            txtLitros = new NumericUpDown();
            txtQuilometragem = new NumericUpDown();
            label7 = new Label();
            lbErroQuilometragem = new Label();
            lbErroLitros = new Label();
            lbErroCombustivel = new Label();
            lbErroCor = new Label();
            lbErroMarca = new Label();
            lbErroModelo = new Label();
            lbErroImagem = new Label();
            buscarDialog = new OpenFileDialog();
            lbErroPlaca = new Label();
            label9 = new Label();
            lbErroAno = new Label();
            label10 = new Label();
            txtAno = new NumericUpDown();
            txtPlaca = new MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)pbImagem).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtLitros).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtQuilometragem).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtAno).BeginInit();
            SuspendLayout();
            // 
            // lbErroCategoria
            // 
            lbErroCategoria.AutoSize = true;
            lbErroCategoria.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroCategoria.Location = new Point(171, 159);
            lbErroCategoria.Name = "lbErroCategoria";
            lbErroCategoria.Size = new Size(92, 15);
            lbErroCategoria.TabIndex = 9;
            lbErroCategoria.Text = "*mensagemErro";
            lbErroCategoria.Visible = false;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(418, 491);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(85, 37);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(327, 491);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(85, 37);
            btnGravar.TabIndex = 11;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnAdd_Click;
            // 
            // lbNome
            // 
            lbNome.AutoSize = true;
            lbNome.Location = new Point(23, 180);
            lbNome.Name = "lbNome";
            lbNome.Size = new Size(144, 15);
            lbNome.TabIndex = 5;
            lbNome.Text = "Categoria de Automóveis:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(111, 85);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 10;
            label1.Text = "Imagem:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(114, 224);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 11;
            label2.Text = "Modelo:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(124, 268);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 12;
            label3.Text = "Marca:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(326, 268);
            label4.Name = "label4";
            label4.Size = new Size(29, 15);
            label4.TabIndex = 13;
            label4.Text = "Cor:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(47, 356);
            label5.Name = "label5";
            label5.Size = new Size(119, 15);
            label5.TabIndex = 14;
            label5.Text = "Tipo de Combustível:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(42, 399);
            label6.Name = "label6";
            label6.Size = new Size(124, 15);
            label6.TabIndex = 15;
            label6.Text = "Capacidade em Litros:";
            // 
            // txtModelo
            // 
            txtModelo.Location = new Point(171, 221);
            txtModelo.MaxLength = 100;
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(139, 23);
            txtModelo.TabIndex = 3;
            // 
            // txtMarca
            // 
            txtMarca.Location = new Point(171, 265);
            txtMarca.MaxLength = 100;
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(139, 23);
            txtMarca.TabIndex = 5;
            // 
            // txtCor
            // 
            txtCor.Location = new Point(361, 265);
            txtCor.MaxLength = 100;
            txtCor.Name = "txtCor";
            txtCor.Size = new Size(120, 23);
            txtCor.TabIndex = 6;
            // 
            // cbCategoria
            // 
            cbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCategoria.FormattingEnabled = true;
            cbCategoria.Location = new Point(171, 177);
            cbCategoria.Name = "cbCategoria";
            cbCategoria.Size = new Size(164, 23);
            cbCategoria.TabIndex = 2;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(416, 76);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 33);
            btnBuscar.TabIndex = 1;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // pbImagem
            // 
            pbImagem.BackColor = Color.White;
            pbImagem.BorderStyle = BorderStyle.FixedSingle;
            pbImagem.Location = new Point(171, 39);
            pbImagem.Name = "pbImagem";
            pbImagem.Size = new Size(229, 117);
            pbImagem.SizeMode = PictureBoxSizeMode.Zoom;
            pbImagem.TabIndex = 24;
            pbImagem.TabStop = false;
            // 
            // cbCombustivel
            // 
            cbCombustivel.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCombustivel.FormattingEnabled = true;
            cbCombustivel.Location = new Point(171, 353);
            cbCombustivel.Name = "cbCombustivel";
            cbCombustivel.Size = new Size(121, 23);
            cbCombustivel.TabIndex = 8;
            // 
            // txtLitros
            // 
            txtLitros.Location = new Point(171, 397);
            txtLitros.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            txtLitros.Name = "txtLitros";
            txtLitros.Size = new Size(120, 23);
            txtLitros.TabIndex = 9;
            txtLitros.Click += selecaoAutomaticaNumericUpDown_Click;
            txtLitros.Enter += selecaoAutomaticaNumericUpDown_Enter;
            // 
            // txtQuilometragem
            // 
            txtQuilometragem.Location = new Point(171, 441);
            txtQuilometragem.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            txtQuilometragem.Name = "txtQuilometragem";
            txtQuilometragem.Size = new Size(120, 23);
            txtQuilometragem.TabIndex = 10;
            txtQuilometragem.Click += selecaoAutomaticaNumericUpDown_Click;
            txtQuilometragem.Enter += selecaoAutomaticaNumericUpDown_Enter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(72, 443);
            label7.Name = "label7";
            label7.Size = new Size(94, 15);
            label7.TabIndex = 27;
            label7.Text = "Quilometragem:";
            // 
            // lbErroQuilometragem
            // 
            lbErroQuilometragem.AutoSize = true;
            lbErroQuilometragem.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroQuilometragem.Location = new Point(171, 423);
            lbErroQuilometragem.Name = "lbErroQuilometragem";
            lbErroQuilometragem.Size = new Size(92, 15);
            lbErroQuilometragem.TabIndex = 29;
            lbErroQuilometragem.Text = "*mensagemErro";
            lbErroQuilometragem.Visible = false;
            // 
            // lbErroLitros
            // 
            lbErroLitros.AutoSize = true;
            lbErroLitros.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroLitros.Location = new Point(171, 379);
            lbErroLitros.Name = "lbErroLitros";
            lbErroLitros.Size = new Size(92, 15);
            lbErroLitros.TabIndex = 30;
            lbErroLitros.Text = "*mensagemErro";
            lbErroLitros.Visible = false;
            // 
            // lbErroCombustivel
            // 
            lbErroCombustivel.AutoSize = true;
            lbErroCombustivel.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroCombustivel.Location = new Point(172, 335);
            lbErroCombustivel.Name = "lbErroCombustivel";
            lbErroCombustivel.Size = new Size(92, 15);
            lbErroCombustivel.TabIndex = 31;
            lbErroCombustivel.Text = "*mensagemErro";
            lbErroCombustivel.Visible = false;
            // 
            // lbErroCor
            // 
            lbErroCor.AutoSize = true;
            lbErroCor.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroCor.Location = new Point(361, 247);
            lbErroCor.Name = "lbErroCor";
            lbErroCor.Size = new Size(92, 15);
            lbErroCor.TabIndex = 32;
            lbErroCor.Text = "*mensagemErro";
            lbErroCor.Visible = false;
            // 
            // lbErroMarca
            // 
            lbErroMarca.AutoSize = true;
            lbErroMarca.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroMarca.Location = new Point(171, 247);
            lbErroMarca.Name = "lbErroMarca";
            lbErroMarca.Size = new Size(92, 15);
            lbErroMarca.TabIndex = 33;
            lbErroMarca.Text = "*mensagemErro";
            lbErroMarca.Visible = false;
            // 
            // lbErroModelo
            // 
            lbErroModelo.AutoSize = true;
            lbErroModelo.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroModelo.Location = new Point(173, 203);
            lbErroModelo.Name = "lbErroModelo";
            lbErroModelo.Size = new Size(92, 15);
            lbErroModelo.TabIndex = 34;
            lbErroModelo.Text = "*mensagemErro";
            lbErroModelo.Visible = false;
            // 
            // lbErroImagem
            // 
            lbErroImagem.AutoSize = true;
            lbErroImagem.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroImagem.Location = new Point(171, 21);
            lbErroImagem.Name = "lbErroImagem";
            lbErroImagem.Size = new Size(92, 15);
            lbErroImagem.TabIndex = 35;
            lbErroImagem.Text = "*mensagemErro";
            lbErroImagem.Visible = false;
            // 
            // buscarDialog
            // 
            buscarDialog.Filter = "Arquivos de Imagem|*.jpg;*.png;*.gif|Todos os arquivos|*.*";
            buscarDialog.Title = "Selecione uma foto do carro";
            // 
            // lbErroPlaca
            // 
            lbErroPlaca.AutoSize = true;
            lbErroPlaca.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroPlaca.Location = new Point(171, 291);
            lbErroPlaca.Name = "lbErroPlaca";
            lbErroPlaca.Size = new Size(92, 15);
            lbErroPlaca.TabIndex = 38;
            lbErroPlaca.Text = "*mensagemErro";
            lbErroPlaca.Visible = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(128, 312);
            label9.Name = "label9";
            label9.Size = new Size(38, 15);
            label9.TabIndex = 36;
            label9.Text = "Placa:";
            // 
            // lbErroAno
            // 
            lbErroAno.AutoSize = true;
            lbErroAno.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroAno.Location = new Point(361, 203);
            lbErroAno.Name = "lbErroAno";
            lbErroAno.Size = new Size(92, 15);
            lbErroAno.TabIndex = 41;
            lbErroAno.Text = "*mensagemErro";
            lbErroAno.Visible = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(323, 224);
            label10.Name = "label10";
            label10.Size = new Size(32, 15);
            label10.TabIndex = 39;
            label10.Text = "Ano:";
            // 
            // txtAno
            // 
            txtAno.Location = new Point(361, 222);
            txtAno.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            txtAno.Name = "txtAno";
            txtAno.Size = new Size(120, 23);
            txtAno.TabIndex = 4;
            txtAno.Click += selecaoAutomaticaNumericUpDown_Click;
            txtAno.Enter += selecaoAutomaticaNumericUpDown_Enter;
            // 
            // txtPlaca
            // 
            txtPlaca.Location = new Point(173, 309);
            txtPlaca.Mask = "LLL-0A00";
            txtPlaca.Name = "txtPlaca";
            txtPlaca.Size = new Size(118, 23);
            txtPlaca.TabIndex = 42;
            // 
            // TelaAutomovelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(515, 540);
            Controls.Add(txtPlaca);
            Controls.Add(txtAno);
            Controls.Add(lbErroAno);
            Controls.Add(label10);
            Controls.Add(lbErroPlaca);
            Controls.Add(label9);
            Controls.Add(lbErroImagem);
            Controls.Add(lbErroModelo);
            Controls.Add(lbErroMarca);
            Controls.Add(lbErroCor);
            Controls.Add(lbErroCombustivel);
            Controls.Add(lbErroLitros);
            Controls.Add(lbErroQuilometragem);
            Controls.Add(txtQuilometragem);
            Controls.Add(label7);
            Controls.Add(txtLitros);
            Controls.Add(cbCombustivel);
            Controls.Add(pbImagem);
            Controls.Add(btnBuscar);
            Controls.Add(cbCategoria);
            Controls.Add(txtCor);
            Controls.Add(txtMarca);
            Controls.Add(txtModelo);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lbErroCategoria);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(lbNome);
            Name = "TelaAutomovelForm";
            Text = "Cadastro de Automóvel";
            ((System.ComponentModel.ISupportInitialize)pbImagem).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtLitros).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtQuilometragem).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtAno).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbErroCategoria;
        private Button btnCancelar;
        private Button btnGravar;
        private Label lbNome;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtModelo;
        private TextBox txtMarca;
        private TextBox txtCor;
        private Button btnBuscar;
        private PictureBox pbImagem;
        private NumericUpDown txtLitros;
        private NumericUpDown txtQuilometragem;
        private Label label7;
        private Label lbErroQuilometragem;
        private Label lbErroLitros;
        private Label lbErroCombustivel;
        private Label lbErroCor;
        private Label lbErroMarca;
        private Label lbErroModelo;
        private Label lbErroImagem;
        private OpenFileDialog buscarDialog;
        private Label lbErroPlaca;
        private MaskedTextBox txtPlaca;
        private Label label9;
        private Label lbErroAno;
        private Label label10;
        private NumericUpDown txtAno;
        private ComboBox cbCategoria;
        private ComboBox cbCombustivel;
    }
}