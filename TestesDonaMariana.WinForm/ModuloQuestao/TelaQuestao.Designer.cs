namespace TestesDonaMariana.WinForm.ModuloQuestao
{
    partial class TelaQuestao
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
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            cbMateria = new ComboBox();
            txTitulo = new TextBox();
            txAlternativaA = new TextBox();
            txAlternativaB = new TextBox();
            txAlternativaC = new TextBox();
            txAlternativaD = new TextBox();
            cbAlternativaCorreta = new ComboBox();
            btnGravar = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 30);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 0;
            label1.Text = "Matéria";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 72);
            label2.Name = "label2";
            label2.Size = new Size(37, 15);
            label2.TabIndex = 1;
            label2.Text = "Tìtulo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 155);
            label3.Name = "label3";
            label3.Size = new Size(74, 15);
            label3.TabIndex = 3;
            label3.Text = "Alternativa B";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 113);
            label4.Name = "label4";
            label4.Size = new Size(75, 15);
            label4.TabIndex = 2;
            label4.Text = "Alternativa A";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 197);
            label8.Name = "label8";
            label8.Size = new Size(75, 15);
            label8.TabIndex = 4;
            label8.Text = "Alternativa C";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 240);
            label7.Name = "label7";
            label7.Size = new Size(75, 15);
            label7.TabIndex = 5;
            label7.Text = "Alternativa D";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 286);
            label6.Name = "label6";
            label6.Size = new Size(106, 15);
            label6.TabIndex = 6;
            label6.Text = "Alternativa Correta";
            // 
            // cbMateria
            // 
            cbMateria.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMateria.FormattingEnabled = true;
            cbMateria.Location = new Point(79, 27);
            cbMateria.Name = "cbMateria";
            cbMateria.Size = new Size(120, 23);
            cbMateria.TabIndex = 7;
            // 
            // txTitulo
            // 
            txTitulo.Location = new Point(79, 69);
            txTitulo.Name = "txTitulo";
            txTitulo.Size = new Size(356, 23);
            txTitulo.TabIndex = 8;
            // 
            // txAlternativaA
            // 
            txAlternativaA.Location = new Point(117, 113);
            txAlternativaA.Name = "txAlternativaA";
            txAlternativaA.Size = new Size(318, 23);
            txAlternativaA.TabIndex = 9;
            // 
            // txAlternativaB
            // 
            txAlternativaB.Location = new Point(117, 155);
            txAlternativaB.Name = "txAlternativaB";
            txAlternativaB.Size = new Size(318, 23);
            txAlternativaB.TabIndex = 10;
            // 
            // txAlternativaC
            // 
            txAlternativaC.Location = new Point(117, 197);
            txAlternativaC.Name = "txAlternativaC";
            txAlternativaC.Size = new Size(318, 23);
            txAlternativaC.TabIndex = 11;
            // 
            // txAlternativaD
            // 
            txAlternativaD.Location = new Point(117, 240);
            txAlternativaD.Name = "txAlternativaD";
            txAlternativaD.Size = new Size(318, 23);
            txAlternativaD.TabIndex = 12;
            // 
            // cbAlternativaCorreta
            // 
            cbAlternativaCorreta.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAlternativaCorreta.FormattingEnabled = true;
            cbAlternativaCorreta.Location = new Point(144, 278);
            cbAlternativaCorreta.Name = "cbAlternativaCorreta";
            cbAlternativaCorreta.Size = new Size(131, 23);
            cbAlternativaCorreta.TabIndex = 13;
            // 
            // btnGravar
            // 
            btnGravar.BackColor = SystemColors.ButtonHighlight;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(320, 314);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(97, 33);
            btnGravar.TabIndex = 14;
            btnGravar.Text = "Cadastrar";
            btnGravar.UseVisualStyleBackColor = false;
            btnGravar.Click += btnGravar_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ButtonHighlight;
            button2.DialogResult = DialogResult.Cancel;
            button2.Location = new Point(423, 314);
            button2.Name = "button2";
            button2.Size = new Size(92, 33);
            button2.TabIndex = 15;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = false;
            // 
            // TelaQuestao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(522, 364);
            Controls.Add(button2);
            Controls.Add(btnGravar);
            Controls.Add(cbAlternativaCorreta);
            Controls.Add(txAlternativaD);
            Controls.Add(txAlternativaC);
            Controls.Add(txAlternativaB);
            Controls.Add(txAlternativaA);
            Controls.Add(txTitulo);
            Controls.Add(cbMateria);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "TelaQuestao";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Questão";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label8;
        private Label label7;
        private Label label6;
        private ComboBox cbMateria;
        private TextBox txTitulo;
        private TextBox txAlternativaA;
        private TextBox txAlternativaB;
        private TextBox txAlternativaC;
        private TextBox txAlternativaD;
        private ComboBox cbAlternativaCorreta;
        private Button btnGravar;
        private Button button2;
    }
}