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
            btnPadrao = new ToolStripButton();
            barraAcoes = new ToolStrip();
            btnAdicionar = new ToolStripButton();
            btnEditar = new ToolStripButton();
            btnExcluir = new ToolStripButton();
            separadorBarra = new ToolStripSeparator();
            lbTipoCadastro = new ToolStripLabel();
            stripStatus = new StatusStrip();
            lbStatus = new ToolStripStatusLabel();
            plPrincipal = new Panel();
            barraBotoes.SuspendLayout();
            barraAcoes.SuspendLayout();
            stripStatus.SuspendLayout();
            SuspendLayout();
            // 
            // barraBotoes
            // 
            barraBotoes.BackColor = Color.FromArgb(0, 165, 100);
            barraBotoes.GripStyle = ToolStripGripStyle.Hidden;
            barraBotoes.Items.AddRange(new ToolStripItem[] { btnPadrao });
            barraBotoes.LayoutStyle = ToolStripLayoutStyle.Flow;
            barraBotoes.Location = new Point(0, 0);
            barraBotoes.Name = "barraBotoes";
            barraBotoes.Size = new Size(1013, 58);
            barraBotoes.TabIndex = 0;
            barraBotoes.Text = "toolStrip1";
            // 
            // btnPadrao
            // 
            btnPadrao.BackColor = Color.FromArgb(0, 165, 100);
            btnPadrao.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnPadrao.Font = new Font("Tahoma", 15F, FontStyle.Regular, GraphicsUnit.Point);
            btnPadrao.ForeColor = Color.White;
            btnPadrao.ImageTransparentColor = Color.Magenta;
            btnPadrao.Margin = new Padding(0);
            btnPadrao.Name = "btnPadrao";
            btnPadrao.Padding = new Padding(15);
            btnPadrao.RightToLeft = RightToLeft.No;
            btnPadrao.Size = new Size(106, 58);
            btnPadrao.Text = "Padrão";
            btnPadrao.TextDirection = ToolStripTextDirection.Horizontal;
            btnPadrao.ToolTipText = "Padrão";
            btnPadrao.Click += btnPadrao_Click;
            btnPadrao.MouseEnter += btnColor_MouseEnter;
            btnPadrao.MouseLeave += btnColor_MouseLeave;
            // 
            // barraAcoes
            // 
            barraAcoes.BackColor = Color.White;
            barraAcoes.GripStyle = ToolStripGripStyle.Hidden;
            barraAcoes.Items.AddRange(new ToolStripItem[] { btnAdicionar, btnEditar, btnExcluir, separadorBarra, lbTipoCadastro });
            barraAcoes.Location = new Point(0, 58);
            barraAcoes.Name = "barraAcoes";
            barraAcoes.Size = new Size(1013, 53);
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
            stripStatus.Location = new Point(0, 604);
            stripStatus.Name = "stripStatus";
            stripStatus.Size = new Size(1013, 22);
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
            plPrincipal.Location = new Point(0, 111);
            plPrincipal.Name = "plPrincipal";
            plPrincipal.Size = new Size(1013, 493);
            plPrincipal.TabIndex = 3;
            plPrincipal.ControlAdded += plPrincipal_ControlAdded;
            plPrincipal.ControlRemoved += plPrincipal_ControlRemoved;
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
            Text = "Padrao";
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
        private ToolStripButton btnPadrao;
        private ToolStrip barraAcoes;
        private ToolStripButton btnAdicionar;
        private ToolStripButton btnEditar;
        private ToolStripButton btnExcluir;
        private StatusStrip stripStatus;
        private ToolStripStatusLabel lbStatus;
        private ToolStripSeparator separadorBarra;
        private ToolStripLabel lbTipoCadastro;
        private Panel plPrincipal;
    }
}