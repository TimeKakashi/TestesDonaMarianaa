namespace TestesDonaMariana.WinForm.ModuloTeste
{
    partial class TelaTeste
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            cbDisciplina = new ComboBox();
            cbMateria = new ComboBox();
            cxRadio = new GroupBox();
            radioSegunda = new RadioButton();
            radioPrimeira = new RadioButton();
            numericNumeroQuestoes = new NumericUpDown();
            label5 = new Label();
            button1 = new Button();
            button3 = new Button();
            cxRadio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericNumeroQuestoes).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(47, 46);
            label1.Name = "label1";
            label1.Size = new Size(45, 21);
            label1.TabIndex = 0;
            label1.Text = "Série";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(47, 97);
            label2.Name = "label2";
            label2.Size = new Size(77, 21);
            label2.TabIndex = 1;
            label2.Text = "Disciplina";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(31, 202);
            label3.Name = "label3";
            label3.Size = new Size(137, 21);
            label3.TabIndex = 3;
            label3.Text = "Número Questões";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(47, 153);
            label4.Name = "label4";
            label4.Size = new Size(63, 21);
            label4.TabIndex = 2;
            label4.Text = "Matéria";
            // 
            // cbDisciplina
            // 
            cbDisciplina.FormattingEnabled = true;
            cbDisciplina.Location = new Point(130, 99);
            cbDisciplina.Name = "cbDisciplina";
            cbDisciplina.Size = new Size(149, 23);
            cbDisciplina.TabIndex = 4;
            // 
            // cbMateria
            // 
            cbMateria.FormattingEnabled = true;
            cbMateria.Location = new Point(116, 155);
            cbMateria.Name = "cbMateria";
            cbMateria.Size = new Size(149, 23);
            cbMateria.TabIndex = 5;
            // 
            // cxRadio
            // 
            cxRadio.Controls.Add(radioSegunda);
            cxRadio.Controls.Add(radioPrimeira);
            cxRadio.Location = new Point(104, 35);
            cxRadio.Name = "cxRadio";
            cxRadio.Size = new Size(216, 39);
            cxRadio.TabIndex = 6;
            cxRadio.TabStop = false;
            // 
            // radioSegunda
            // 
            radioSegunda.AutoSize = true;
            radioSegunda.Location = new Point(109, 14);
            radioSegunda.Name = "radioSegunda";
            radioSegunda.Size = new Size(99, 19);
            radioSegunda.TabIndex = 1;
            radioSegunda.TabStop = true;
            radioSegunda.Text = "Segunda Serie";
            radioSegunda.UseVisualStyleBackColor = true;
            // 
            // radioPrimeira
            // 
            radioPrimeira.AutoSize = true;
            radioPrimeira.Location = new Point(6, 12);
            radioPrimeira.Name = "radioPrimeira";
            radioPrimeira.Size = new Size(97, 19);
            radioPrimeira.TabIndex = 0;
            radioPrimeira.TabStop = true;
            radioPrimeira.Text = "Primeira Serie";
            radioPrimeira.UseVisualStyleBackColor = true;
            // 
            // numericNumeroQuestoes
            // 
            numericNumeroQuestoes.Location = new Point(174, 205);
            numericNumeroQuestoes.Name = "numericNumeroQuestoes";
            numericNumeroQuestoes.Size = new Size(53, 23);
            numericNumeroQuestoes.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(31, 247);
            label5.Name = "label5";
            label5.Size = new Size(93, 28);
            label5.TabIndex = 9;
            label5.Text = "Questôes";
            // 
            // button1
            // 
            button1.DialogResult = DialogResult.OK;
            button1.Location = new Point(391, 632);
            button1.Name = "button1";
            button1.Size = new Size(91, 40);
            button1.TabIndex = 10;
            button1.Text = "Cadastrar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.DialogResult = DialogResult.Cancel;
            button3.Location = new Point(488, 632);
            button3.Name = "button3";
            button3.Size = new Size(88, 40);
            button3.TabIndex = 12;
            button3.Text = "Cancelar";
            button3.UseVisualStyleBackColor = true;
            // 
            // TelaTeste
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(599, 684);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(numericNumeroQuestoes);
            Controls.Add(cxRadio);
            Controls.Add(cbMateria);
            Controls.Add(cbDisciplina);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TelaTeste";
            Text = "Cadastro de Teste";
            cxRadio.ResumeLayout(false);
            cxRadio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericNumeroQuestoes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox cbDisciplina;
        private ComboBox cbMateria;
        private GroupBox cxRadio;
        private RadioButton radioSegunda;
        private RadioButton radioPrimeira;
        private NumericUpDown numericNumeroQuestoes;
        private Label label5;
        private Button button1;
        private Button button3;
    }
}