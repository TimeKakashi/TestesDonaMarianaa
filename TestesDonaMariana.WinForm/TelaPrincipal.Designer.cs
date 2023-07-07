namespace TestesDonaMariana.WinForm
{
    partial class TelaPrincipal
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
            menuStrip1 = new MenuStrip();
            cadastrarToolStripMenuItem = new ToolStripMenuItem();
            disciplinaToolStripMenuItem = new ToolStripMenuItem();
            materiaToolStripMenuItem = new ToolStripMenuItem();
            questaoToolStripMenuItem = new ToolStripMenuItem();
            testeToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            btnInserir = new ToolStripButton();
            btnEditar = new ToolStripButton();
            btnExcluir = new ToolStripButton();
            btnFiltrar = new ToolStripButton();
            btnGerarGabarito = new ToolStripButton();
            btnDuplicar = new ToolStripButton();
            btnPdf = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripLabel1 = new ToolStripLabel();
            statusStrip1 = new StatusStrip();
            StatusLabel = new ToolStripStatusLabel();
            panelRegistros = new Panel();
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { cadastrarToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(716, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // cadastrarToolStripMenuItem
            // 
            cadastrarToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { disciplinaToolStripMenuItem, materiaToolStripMenuItem, questaoToolStripMenuItem, testeToolStripMenuItem });
            cadastrarToolStripMenuItem.Name = "cadastrarToolStripMenuItem";
            cadastrarToolStripMenuItem.Size = new Size(69, 20);
            cadastrarToolStripMenuItem.Text = "Cadastrar";
            // 
            // disciplinaToolStripMenuItem
            // 
            disciplinaToolStripMenuItem.Name = "disciplinaToolStripMenuItem";
            disciplinaToolStripMenuItem.Size = new Size(125, 22);
            disciplinaToolStripMenuItem.Text = "Disciplina";
            disciplinaToolStripMenuItem.Click += disciplinaToolStripMenuItem_Click;
            // 
            // materiaToolStripMenuItem
            // 
            materiaToolStripMenuItem.Name = "materiaToolStripMenuItem";
            materiaToolStripMenuItem.Size = new Size(125, 22);
            materiaToolStripMenuItem.Text = "Materia";
            materiaToolStripMenuItem.Click += materiaToolStripMenuItem_Click;
            // 
            // questaoToolStripMenuItem
            // 
            questaoToolStripMenuItem.Name = "questaoToolStripMenuItem";
            questaoToolStripMenuItem.Size = new Size(125, 22);
            questaoToolStripMenuItem.Text = "Questao";
            questaoToolStripMenuItem.Click += questaoToolStripMenuItem_Click;
            // 
            // testeToolStripMenuItem
            // 
            testeToolStripMenuItem.Name = "testeToolStripMenuItem";
            testeToolStripMenuItem.Size = new Size(125, 22);
            testeToolStripMenuItem.Text = "Teste";
            testeToolStripMenuItem.Click += testeToolStripMenuItem_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnInserir, btnEditar, btnExcluir, btnFiltrar, btnGerarGabarito, btnDuplicar, btnPdf, toolStripSeparator1, toolStripLabel1 });
            toolStrip1.Location = new Point(0, 24);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(716, 37);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnInserir
            // 
            btnInserir.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnInserir.Image = Properties.Resources.add_FILL0_wght400_GRAD0_opsz24__2_;
            btnInserir.ImageTransparentColor = Color.Magenta;
            btnInserir.Name = "btnInserir";
            btnInserir.Padding = new Padding(7);
            btnInserir.Size = new Size(34, 34);
            btnInserir.Text = "toolStripButton1";
            btnInserir.Click += btnInserir_Click;
            // 
            // btnEditar
            // 
            btnEditar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnEditar.Image = Properties.Resources.edit_FILL0_wght400_GRAD0_opsz24__1_;
            btnEditar.ImageTransparentColor = Color.Magenta;
            btnEditar.Name = "btnEditar";
            btnEditar.Padding = new Padding(7);
            btnEditar.Size = new Size(34, 34);
            btnEditar.Text = "toolStripButton2";
            btnEditar.Click += btnEditar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnExcluir.Image = Properties.Resources.delete_FILL0_wght400_GRAD0_opsz24__1_;
            btnExcluir.ImageTransparentColor = Color.Magenta;
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Padding = new Padding(7);
            btnExcluir.Size = new Size(34, 34);
            btnExcluir.Text = "toolStripButton3";
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnFiltrar
            // 
            btnFiltrar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnFiltrar.Image = Properties.Resources.filter_alt_FILL0_wght400_GRAD0_opsz24__1_;
            btnFiltrar.ImageTransparentColor = Color.Magenta;
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Padding = new Padding(7);
            btnFiltrar.Size = new Size(34, 34);
            btnFiltrar.Text = "toolStripButton4";
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // btnGerarGabarito
            // 
            btnGerarGabarito.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnGerarGabarito.Image = Properties.Resources.menu_book_FILL0_wght400_GRAD0_opsz24;
            btnGerarGabarito.ImageTransparentColor = Color.Magenta;
            btnGerarGabarito.Name = "btnGerarGabarito";
            btnGerarGabarito.Padding = new Padding(7);
            btnGerarGabarito.Size = new Size(34, 34);
            btnGerarGabarito.Text = "toolStripButton5";
            btnGerarGabarito.Click += btnGerarGabarito_Click;
            // 
            // btnDuplicar
            // 
            btnDuplicar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnDuplicar.Image = Properties.Resources.edit_FILL0_wght400_GRAD0_opsz24__1_;
            btnDuplicar.ImageTransparentColor = Color.Magenta;
            btnDuplicar.Name = "btnDuplicar";
            btnDuplicar.Size = new Size(23, 34);
            btnDuplicar.Text = "toolStripButton1";
            btnDuplicar.Click += btnDuplicar_Click;
            // 
            // btnPdf
            // 
            btnPdf.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnPdf.Image = Properties.Resources.picture_as_pdf_FILL0_wght400_GRAD0_opsz24;
            btnPdf.ImageTransparentColor = Color.Magenta;
            btnPdf.Name = "btnPdf";
            btnPdf.Padding = new Padding(7);
            btnPdf.Size = new Size(34, 34);
            btnPdf.Text = "toolStripButton6";
            btnPdf.Click += btnPdf_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 37);
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Padding = new Padding(5, 0, 0, 0);
            toolStripLabel1.Size = new Size(85, 34);
            toolStripLabel1.Text = "Tipo Cadastro";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { StatusLabel });
            statusStrip1.Location = new Point(0, 346);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(716, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(118, 17);
            StatusLabel.Text = "toolStripStatusLabel1";
            // 
            // panelRegistros
            // 
            panelRegistros.Dock = DockStyle.Fill;
            panelRegistros.Location = new Point(0, 61);
            panelRegistros.Name = "panelRegistros";
            panelRegistros.Size = new Size(716, 285);
            panelRegistros.TabIndex = 3;
            // 
            // TelaPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(716, 368);
            Controls.Add(panelRegistros);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "TelaPrincipal";
            Text = "Testes da Dona Mariana";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem cadastrarToolStripMenuItem;
        private ToolStripMenuItem disciplinaToolStripMenuItem;
        private ToolStripMenuItem materiaToolStripMenuItem;
        private ToolStripMenuItem questaoToolStripMenuItem;
        private ToolStripMenuItem testeToolStripMenuItem;
        private ToolStrip toolStrip1;
        private ToolStripButton btnInserir;
        private ToolStripButton btnEditar;
        private ToolStripButton btnExcluir;
        private ToolStripButton btnFiltrar;
        private ToolStripButton btnGerarGabarito;
        private ToolStripButton btnPdf;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripLabel toolStripLabel1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel StatusLabel;
        private Panel panelRegistros;
        private ToolStripButton btnDuplicar;
    }
}