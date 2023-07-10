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
            listBox1 = new ListBox();
            button2 = new Button();
            label6 = new Label();
            tbTitulo = new TextBox();
            checkRecuperacao = new CheckBox();
            cxRadio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericNumeroQuestoes).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(47, 66);
            label1.Name = "label1";
            label1.Size = new Size(45, 21);
            label1.TabIndex = 0;
            label1.Text = "Série";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(47, 111);
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
            cbDisciplina.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDisciplina.FormattingEnabled = true;
            cbDisciplina.Location = new Point(136, 113);
            cbDisciplina.Name = "cbDisciplina";
            cbDisciplina.Size = new Size(210, 23);
            cbDisciplina.TabIndex = 4;
            cbDisciplina.SelectedValueChanged += cbDisciplina_SelectedValueChanged;
            // 
            // cbMateria
            // 
            cbMateria.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMateria.Enabled = false;
            cbMateria.FormattingEnabled = true;
            cbMateria.Location = new Point(116, 155);
            cbMateria.Name = "cbMateria";
            cbMateria.Size = new Size(230, 23);
            cbMateria.TabIndex = 5;
            // 
            // cxRadio
            // 
            cxRadio.Controls.Add(radioSegunda);
            cxRadio.Controls.Add(radioPrimeira);
            cxRadio.Location = new Point(98, 52);
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
            radioPrimeira.Location = new Point(6, 14);
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
            label5.Location = new Point(31, 248);
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
            // listBox1
            // 
            listBox1.BackColor = SystemColors.InactiveCaption;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(31, 290);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(526, 319);
            listBox1.TabIndex = 13;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(391, 248);
            button2.Name = "button2";
            button2.Size = new Size(175, 36);
            button2.TabIndex = 14;
            button2.Text = "Gerar Questões";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(47, 23);
            label6.Name = "label6";
            label6.Size = new Size(49, 21);
            label6.TabIndex = 15;
            label6.Text = "Titulo";
            label6.Click += label6_Click;
            // 
            // tbTitulo
            // 
            tbTitulo.Location = new Point(102, 23);
            tbTitulo.Name = "tbTitulo";
            tbTitulo.Size = new Size(244, 23);
            tbTitulo.TabIndex = 16;
            // 
            // checkRecuperacao
            // 
            checkRecuperacao.AutoSize = true;
            checkRecuperacao.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            checkRecuperacao.Location = new Point(376, 113);
            checkRecuperacao.Name = "checkRecuperacao";
            checkRecuperacao.Size = new Size(162, 25);
            checkRecuperacao.TabIndex = 17;
            checkRecuperacao.Text = "Prova Recuperacao";
            checkRecuperacao.UseVisualStyleBackColor = true;
            checkRecuperacao.CheckedChanged += checkRecuperacao_CheckedChanged;
            // 
            // TelaTeste
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(599, 684);
            Controls.Add(checkRecuperacao);
            Controls.Add(tbTitulo);
            Controls.Add(label6);
            Controls.Add(button2);
            Controls.Add(listBox1);
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
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "TelaTeste";
            StartPosition = FormStartPosition.CenterScreen;
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
        private ListBox listBox1;
        private Button button2;
        private Label label6;
        private TextBox tbTitulo;
        private CheckBox checkRecuperacao;
    }
}