﻿namespace TestesDonaMariana.WinForm.ModuloMateria
{
    partial class TelaMateria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaMateria));
            lblNome = new Label();
            lblDisciplina = new Label();
            lblSerie = new Label();
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            primeiraSerie = new RadioButton();
            SegundSerie = new RadioButton();
            gbRadio = new GroupBox();
            label1 = new Label();
            txId = new TextBox();
            gbRadio.SuspendLayout();
            SuspendLayout();
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(12, 55);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(43, 15);
            lblNome.TabIndex = 0;
            lblNome.Text = "Nome:";
            // 
            // lblDisciplina
            // 
            lblDisciplina.AutoSize = true;
            lblDisciplina.Location = new Point(12, 87);
            lblDisciplina.Name = "lblDisciplina";
            lblDisciplina.Size = new Size(61, 15);
            lblDisciplina.TabIndex = 1;
            lblDisciplina.Text = "Disciplina:";
            // 
            // lblSerie
            // 
            lblSerie.AutoSize = true;
            lblSerie.Location = new Point(12, 120);
            lblSerie.Name = "lblSerie";
            lblSerie.Size = new Size(35, 15);
            lblSerie.TabIndex = 2;
            lblSerie.Text = "Série:";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.BackColor = SystemColors.ButtonHighlight;
            button1.DialogResult = DialogResult.OK;
            button1.Location = new Point(159, 187);
            button1.Name = "button1";
            button1.Size = new Size(90, 31);
            button1.TabIndex = 4;
            button1.Text = "Cadastrar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.BackColor = SystemColors.ButtonHighlight;
            button2.DialogResult = DialogResult.Cancel;
            button2.Location = new Point(255, 187);
            button2.Name = "button2";
            button2.Size = new Size(90, 31);
            button2.TabIndex = 5;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.ButtonHighlight;
            textBox1.Location = new Point(94, 52);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(155, 23);
            textBox1.TabIndex = 0;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(94, 84);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(155, 23);
            comboBox1.TabIndex = 1;
            // 
            // primeiraSerie
            // 
            primeiraSerie.AutoSize = true;
            primeiraSerie.BackColor = SystemColors.Control;
            primeiraSerie.Location = new Point(6, 17);
            primeiraSerie.Name = "primeiraSerie";
            primeiraSerie.Size = new Size(97, 19);
            primeiraSerie.TabIndex = 2;
            primeiraSerie.Text = "Primeira Série";
            primeiraSerie.UseVisualStyleBackColor = false;
            // 
            // SegundSerie
            // 
            SegundSerie.AutoSize = true;
            SegundSerie.BackColor = SystemColors.Control;
            SegundSerie.Location = new Point(106, 17);
            SegundSerie.Name = "SegundSerie";
            SegundSerie.Size = new Size(99, 19);
            SegundSerie.TabIndex = 3;
            SegundSerie.TabStop = true;
            SegundSerie.Text = "Segunda Série";
            SegundSerie.UseVisualStyleBackColor = false;
            SegundSerie.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // gbRadio
            // 
            gbRadio.Controls.Add(SegundSerie);
            gbRadio.Controls.Add(primeiraSerie);
            gbRadio.Location = new Point(94, 108);
            gbRadio.Name = "gbRadio";
            gbRadio.Size = new Size(220, 43);
            gbRadio.TabIndex = 9;
            gbRadio.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(17, 15);
            label1.TabIndex = 10;
            label1.Text = "Id";
            // 
            // txId
            // 
            txId.BackColor = SystemColors.ButtonHighlight;
            txId.Enabled = false;
            txId.Location = new Point(94, 18);
            txId.Name = "txId";
            txId.Size = new Size(155, 23);
            txId.TabIndex = 11;
            // 
            // TelaMateria
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(347, 222);
            Controls.Add(txId);
            Controls.Add(label1);
            Controls.Add(gbRadio);
            Controls.Add(comboBox1);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(lblSerie);
            Controls.Add(lblDisciplina);
            Controls.Add(lblNome);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "TelaMateria";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Matéria";
            gbRadio.ResumeLayout(false);
            gbRadio.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNome;
        private Label lblDisciplina;
        private Label lblSerie;
        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton primeiraSerie;
        private RadioButton SegundSerie;
        private GroupBox gbRadio;
        private Label label1;
        private TextBox txId;
    }
}