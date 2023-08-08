namespace LocadoraAutomoveis.WinApp
{
    partial class TelaPrincipalForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            barraBotoes = new ToolStrip();
            btnCondutores = new ToolStripButton();
            btnAutomovel = new ToolStripButton();
            btnFuncionario = new ToolStripButton();
            btnCategoria = new ToolStripButton();
            btnTaxa = new ToolStripButton();
            btnParceiro = new ToolStripButton();
            btnCupom = new ToolStripButton();
            btnPlanosCobrancas = new ToolStripButton();
            btnCliente = new ToolStripButton();
            barraAcoes = new ToolStrip();
            btnAdicionar = new ToolStripButton();
            btnEditar = new ToolStripButton();
            btnExcluir = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnFiltrar = new ToolStripButton();
            separadorBarra = new ToolStripSeparator();
            lbTipoCadastro = new ToolStripLabel();
            stripStatus = new StatusStrip();
            lbStatus = new ToolStripStatusLabel();
            plPrincipal = new Panel();
            btnAluguel = new ToolStripButton();
            barraBotoes.SuspendLayout();
            barraAcoes.SuspendLayout();
            stripStatus.SuspendLayout();
            SuspendLayout();
            // 
            // barraBotoes
            // 
            barraBotoes.BackColor = Color.Gainsboro;
            barraBotoes.Dock = DockStyle.Left;
            barraBotoes.GripMargin = new Padding(0);
            barraBotoes.GripStyle = ToolStripGripStyle.Hidden;
            barraBotoes.Items.AddRange(new ToolStripItem[] { btnCondutores, btnAutomovel, btnFuncionario, btnCategoria, btnTaxa, btnParceiro, btnCupom, btnPlanosCobrancas, btnAluguel, btnCliente });
            barraBotoes.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            barraBotoes.Location = new Point(0, 0);
            barraBotoes.Name = "barraBotoes";
            barraBotoes.Padding = new Padding(0);
            barraBotoes.RenderMode = ToolStripRenderMode.System;
            barraBotoes.Size = new Size(259, 626);
            barraBotoes.TabIndex = 0;
            barraBotoes.Text = "toolStrip1";
            // 
            // btnCondutores
            // 
            btnCondutores.BackColor = Color.Gainsboro;
            btnCondutores.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnCondutores.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnCondutores.ForeColor = Color.Black;
            btnCondutores.ImageTransparentColor = Color.Magenta;
            btnCondutores.Margin = new Padding(0);
            btnCondutores.Name = "btnCondutores";
            btnCondutores.Padding = new Padding(20, 10, 20, 10);
            btnCondutores.RightToLeft = RightToLeft.No;
            btnCondutores.Size = new Size(258, 42);
            btnCondutores.Text = "Condutores";
            btnCondutores.TextDirection = ToolStripTextDirection.Horizontal;
            btnCondutores.Click += btnCondutores_Click_1;
            // 
            // btnAutomovel
            // 
            btnAutomovel.BackColor = Color.Gainsboro;
            btnAutomovel.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnAutomovel.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnAutomovel.ForeColor = Color.Black;
            btnAutomovel.ImageTransparentColor = Color.Magenta;
            btnAutomovel.Margin = new Padding(0);
            btnAutomovel.Name = "btnAutomovel";
            btnAutomovel.Padding = new Padding(20, 10, 20, 10);
            btnAutomovel.RightToLeft = RightToLeft.No;
            btnAutomovel.Size = new Size(258, 42);
            btnAutomovel.Text = "Automóveis";
            btnAutomovel.TextDirection = ToolStripTextDirection.Horizontal;
            btnAutomovel.ToolTipText = "Automóveis";
            btnAutomovel.Click += btnAutomovel_Click;
            // 
            // btnFuncionario
            // 
            btnFuncionario.BackColor = Color.Gainsboro;
            btnFuncionario.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnFuncionario.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnFuncionario.ForeColor = Color.Black;
            btnFuncionario.ImageTransparentColor = Color.Magenta;
            btnFuncionario.Margin = new Padding(0);
            btnFuncionario.Name = "btnFuncionario";
            btnFuncionario.Padding = new Padding(20, 10, 20, 10);
            btnFuncionario.RightToLeft = RightToLeft.No;
            btnFuncionario.Size = new Size(258, 42);
            btnFuncionario.Text = "Funcionários";
            btnFuncionario.TextDirection = ToolStripTextDirection.Horizontal;
            btnFuncionario.ToolTipText = "Funcionários";
            btnFuncionario.Click += btnFuncionario_Click_1;
            // 
            // btnCategoria
            // 
            btnCategoria.BackColor = Color.Gainsboro;
            btnCategoria.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnCategoria.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnCategoria.ForeColor = Color.Black;
            btnCategoria.ImageTransparentColor = Color.Magenta;
            btnCategoria.Margin = new Padding(0);
            btnCategoria.Name = "btnCategoria";
            btnCategoria.Padding = new Padding(20, 10, 20, 10);
            btnCategoria.RightToLeft = RightToLeft.No;
            btnCategoria.Size = new Size(258, 42);
            btnCategoria.Text = "Categoria de Automóveis";
            btnCategoria.TextDirection = ToolStripTextDirection.Horizontal;
            btnCategoria.Click += btnCategoria_Click;
            // 
            // btnTaxa
            // 
            btnTaxa.BackColor = Color.Gainsboro;
            btnTaxa.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnTaxa.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnTaxa.ForeColor = Color.Black;
            btnTaxa.ImageTransparentColor = Color.Magenta;
            btnTaxa.Margin = new Padding(0);
            btnTaxa.Name = "btnTaxa";
            btnTaxa.Padding = new Padding(20, 10, 20, 10);
            btnTaxa.RightToLeft = RightToLeft.No;
            btnTaxa.Size = new Size(258, 42);
            btnTaxa.Text = "Taxa e Serviços";
            btnTaxa.TextDirection = ToolStripTextDirection.Horizontal;
            btnTaxa.ToolTipText = "Taxa e Serviços";
            btnTaxa.Click += btnTaxa_Click;
            // 
            // btnParceiro
            // 
            btnParceiro.BackColor = Color.Gainsboro;
            btnParceiro.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnParceiro.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnParceiro.ForeColor = Color.Black;
            btnParceiro.ImageTransparentColor = Color.Magenta;
            btnParceiro.Margin = new Padding(0);
            btnParceiro.Name = "btnParceiro";
            btnParceiro.Padding = new Padding(20, 10, 20, 10);
            btnParceiro.RightToLeft = RightToLeft.No;
            btnParceiro.Size = new Size(258, 42);
            btnParceiro.Text = "Parceiros";
            btnParceiro.TextDirection = ToolStripTextDirection.Horizontal;
            btnParceiro.ToolTipText = "Parceiros";
            btnParceiro.Click += btnParceiro_Click;
            // 
            // btnCupom
            // 
            btnCupom.BackColor = Color.Gainsboro;
            btnCupom.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnCupom.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnCupom.ForeColor = Color.Black;
            btnCupom.ImageTransparentColor = Color.Magenta;
            btnCupom.Margin = new Padding(0);
            btnCupom.Name = "btnCupom";
            btnCupom.Padding = new Padding(20, 10, 20, 10);
            btnCupom.RightToLeft = RightToLeft.No;
            btnCupom.Size = new Size(258, 42);
            btnCupom.Text = "Cupons";
            btnCupom.TextDirection = ToolStripTextDirection.Horizontal;
            btnCupom.ToolTipText = "Cupons";
            btnCupom.Click += btnCupom_Click;
            // 
            // btnPlanosCobrancas
            // 
            btnPlanosCobrancas.BackColor = Color.Gainsboro;
            btnPlanosCobrancas.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnPlanosCobrancas.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnPlanosCobrancas.ForeColor = Color.Black;
            btnPlanosCobrancas.ImageTransparentColor = Color.Magenta;
            btnPlanosCobrancas.Margin = new Padding(0);
            btnPlanosCobrancas.Name = "btnPlanosCobrancas";
            btnPlanosCobrancas.Padding = new Padding(20, 10, 20, 10);
            btnPlanosCobrancas.RightToLeft = RightToLeft.No;
            btnPlanosCobrancas.Size = new Size(258, 42);
            btnPlanosCobrancas.Text = "Planos de Cobranças";
            btnPlanosCobrancas.TextDirection = ToolStripTextDirection.Horizontal;
            btnPlanosCobrancas.ToolTipText = "Planos de Cobranças";
            btnPlanosCobrancas.Click += btnPlanosCobrancas_Click;
            // 
            // btnCliente
            // 
            btnCliente.BackColor = Color.Gainsboro;
            btnCliente.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnCliente.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnCliente.ForeColor = Color.Black;
            btnCliente.ImageTransparentColor = Color.Magenta;
            btnCliente.Margin = new Padding(0);
            btnCliente.Name = "btnCliente";
            btnCliente.Padding = new Padding(20, 10, 20, 10);
            btnCliente.RightToLeft = RightToLeft.No;
            btnCliente.Size = new Size(258, 42);
            btnCliente.Text = "Clientes";
            btnCliente.TextDirection = ToolStripTextDirection.Horizontal;
            btnCliente.Click += btnCliente_Click;
            // 
            // barraAcoes
            // 
            barraAcoes.AutoSize = false;
            barraAcoes.BackColor = Color.White;
            barraAcoes.GripStyle = ToolStripGripStyle.Hidden;
            barraAcoes.Items.AddRange(new ToolStripItem[] { btnAdicionar, btnEditar, btnExcluir, toolStripSeparator1, btnFiltrar, separadorBarra, lbTipoCadastro });
            barraAcoes.Location = new Point(259, 0);
            barraAcoes.Name = "barraAcoes";
            barraAcoes.Size = new Size(754, 53);
            barraAcoes.TabIndex = 1;
            // 
            // btnAdicionar
            // 
            btnAdicionar.BackColor = Color.FromArgb(80, 230, 80);
            btnAdicionar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdicionar.ImageScaling = ToolStripItemImageScaling.None;
            btnAdicionar.ImageTransparentColor = Color.Magenta;
            btnAdicionar.Margin = new Padding(10);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Padding = new Padding(5);
            btnAdicionar.Size = new Size(83, 33);
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.Click += btnAdd_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.FromArgb(80, 130, 230);
            btnEditar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnEditar.ImageScaling = ToolStripItemImageScaling.None;
            btnEditar.ImageTransparentColor = Color.Magenta;
            btnEditar.Margin = new Padding(10);
            btnEditar.Name = "btnEditar";
            btnEditar.Padding = new Padding(5);
            btnEditar.Size = new Size(59, 33);
            btnEditar.Text = "Editar";
            btnEditar.Click += btnEditar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.BackColor = Color.FromArgb(230, 80, 80);
            btnExcluir.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnExcluir.ImageScaling = ToolStripItemImageScaling.None;
            btnExcluir.ImageTransparentColor = Color.Magenta;
            btnExcluir.Margin = new Padding(10);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Padding = new Padding(5);
            btnExcluir.Size = new Size(65, 33);
            btnExcluir.Text = "Excluir";
            btnExcluir.Click += btnExcluir_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 53);
            // 
            // btnFiltrar
            // 
            btnFiltrar.BackColor = Color.FromArgb(230, 230, 80);
            btnFiltrar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnFiltrar.ImageScaling = ToolStripItemImageScaling.None;
            btnFiltrar.ImageTransparentColor = Color.Magenta;
            btnFiltrar.Margin = new Padding(10);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Padding = new Padding(5);
            btnFiltrar.Size = new Size(60, 33);
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // separadorBarra
            // 
            separadorBarra.Name = "separadorBarra";
            separadorBarra.Size = new Size(6, 53);
            // 
            // lbTipoCadastro
            // 
            lbTipoCadastro.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbTipoCadastro.Name = "lbTipoCadastro";
            lbTipoCadastro.Size = new Size(0, 50);
            // 
            // stripStatus
            // 
            stripStatus.Items.AddRange(new ToolStripItem[] { lbStatus });
            stripStatus.Location = new Point(259, 604);
            stripStatus.Name = "stripStatus";
            stripStatus.Size = new Size(754, 22);
            stripStatus.TabIndex = 2;
            stripStatus.Text = "statusStrip1";
            // 
            // lbStatus
            // 
            lbStatus.Name = "lbStatus";
            lbStatus.Size = new Size(0, 17);
            // 
            // plPrincipal
            // 
            plPrincipal.Dock = DockStyle.Fill;
            plPrincipal.Location = new Point(259, 53);
            plPrincipal.Name = "plPrincipal";
            plPrincipal.Size = new Size(754, 551);
            plPrincipal.TabIndex = 3;
            plPrincipal.ControlAdded += plPrincipal_ControlAdded;
            plPrincipal.ControlRemoved += plPrincipal_ControlRemoved;
            // 
            // btnAluguel
            // 
            btnAluguel.BackColor = Color.Gainsboro;
            btnAluguel.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnAluguel.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnAluguel.ForeColor = Color.Black;
            btnAluguel.ImageTransparentColor = Color.Magenta;
            btnAluguel.Margin = new Padding(0);
            btnAluguel.Name = "btnAluguel";
            btnAluguel.Padding = new Padding(20, 10, 20, 10);
            btnAluguel.RightToLeft = RightToLeft.No;
            btnAluguel.Size = new Size(258, 42);
            btnAluguel.Text = "Aluguéis";
            btnAluguel.TextDirection = ToolStripTextDirection.Horizontal;
            btnAluguel.ToolTipText = "Aluguéis";
            btnAluguel.Click += btnAluguel_Click;
            // 
            // TelaPrincipalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1013, 626);
            Controls.Add(plPrincipal);
            Controls.Add(barraAcoes);
            Controls.Add(stripStatus);
            Controls.Add(barraBotoes);
            Name = "TelaPrincipalForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Locadora de Automóveis";
            barraBotoes.ResumeLayout(false);
            barraBotoes.PerformLayout();
            barraAcoes.ResumeLayout(false);
            barraAcoes.PerformLayout();
            stripStatus.ResumeLayout(false);
            stripStatus.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip barraBotoes;
        private ToolStripButton btnCategoria;
        private ToolStrip barraAcoes;
        private ToolStripButton btnAdicionar;
        private ToolStripButton btnEditar;
        private ToolStripButton btnExcluir;
        private StatusStrip stripStatus;
        private ToolStripStatusLabel lbStatus;
        private ToolStripSeparator separadorBarra;
        private ToolStripLabel lbTipoCadastro;
        private Panel plPrincipal;
        private ToolStripButton btnTaxa;
        private ToolStripButton toolStripButton1;
        private ToolStripButton btnParceiro;
        private ToolStripButton btnFuncionario;
        private ToolStripButton btnAutomovel;
        private ToolStripButton btnFiltrar;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnCliente;
        private ToolStripButton btnCupom;
        private ToolStripButton btnCondutores;
        private ToolStripButton btnPlanosCobrancas;
        private ToolStripButton btnAluguel;
    }
}