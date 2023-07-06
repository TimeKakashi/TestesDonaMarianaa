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
            gbRadio.SuspendLayout();
            SuspendLayout();
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(25, 9);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(43, 15);
            lblNome.TabIndex = 0;
            lblNome.Text = "Nome:";
            // 
            // lblDisciplina
            // 
            lblDisciplina.AutoSize = true;
            lblDisciplina.Location = new Point(12, 50);
            lblDisciplina.Name = "lblDisciplina";
            lblDisciplina.Size = new Size(61, 15);
            lblDisciplina.TabIndex = 1;
            lblDisciplina.Text = "Disciplina:";
            // 
            // lblSerie
            // 
            lblSerie.AutoSize = true;
            lblSerie.Location = new Point(25, 94);
            lblSerie.Name = "lblSerie";
            lblSerie.Size = new Size(35, 15);
            lblSerie.TabIndex = 2;
            lblSerie.Text = "Série:";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.DialogResult = DialogResult.OK;
            button1.Location = new Point(326, 96);
            button1.Name = "button1";
            button1.Size = new Size(90, 31);
            button1.TabIndex = 3;
            button1.Text = "Cadastrar";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.Location = new Point(422, 96);
            button2.Name = "button2";
            button2.Size = new Size(90, 31);
            button2.TabIndex = 4;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(74, 6);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(155, 23);
            textBox1.TabIndex = 5;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(74, 47);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(155, 23);
            comboBox1.TabIndex = 6;
            // 
            // primeiraSerie
            // 
            primeiraSerie.AutoSize = true;
            primeiraSerie.Location = new Point(1, 22);
            primeiraSerie.Name = "primeiraSerie";
            primeiraSerie.Size = new Size(97, 19);
            primeiraSerie.TabIndex = 7;
            primeiraSerie.TabStop = true;
            primeiraSerie.Text = "Primeira Série";
            primeiraSerie.UseVisualStyleBackColor = true;
            // 
            // SegundSerie
            // 
            SegundSerie.AutoSize = true;
            SegundSerie.Location = new Point(101, 22);
            SegundSerie.Name = "SegundSerie";
            SegundSerie.Size = new Size(99, 19);
            SegundSerie.TabIndex = 8;
            SegundSerie.TabStop = true;
            SegundSerie.Text = "Segunda Série";
            SegundSerie.UseVisualStyleBackColor = true;
            SegundSerie.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // gbRadio
            // 
            gbRadio.Controls.Add(SegundSerie);
            gbRadio.Controls.Add(primeiraSerie);
            gbRadio.Location = new Point(74, 68);
            gbRadio.Name = "gbRadio";
            gbRadio.Size = new Size(200, 51);
            gbRadio.TabIndex = 9;
            gbRadio.TabStop = false;
            // 
            // TelaMateria
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(514, 131);
            Controls.Add(gbRadio);
            Controls.Add(comboBox1);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(lblSerie);
            Controls.Add(lblDisciplina);
            Controls.Add(lblNome);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "TelaMateria";
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
    }
}