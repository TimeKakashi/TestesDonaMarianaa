namespace TestesDonaMariana.WinForm.ModuloMateria
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
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
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
            lblSerie.Location = new Point(33, 96);
            lblSerie.Name = "lblSerie";
            lblSerie.Size = new Size(35, 15);
            lblSerie.TabIndex = 2;
            lblSerie.Text = "Série:";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
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
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(74, 96);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(97, 19);
            radioButton1.TabIndex = 7;
            radioButton1.TabStop = true;
            radioButton1.Text = "Primeira Série";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(174, 96);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(99, 19);
            radioButton2.TabIndex = 8;
            radioButton2.TabStop = true;
            radioButton2.Text = "Segunda Série";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // TelaMateria
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(514, 131);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
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
    }
}