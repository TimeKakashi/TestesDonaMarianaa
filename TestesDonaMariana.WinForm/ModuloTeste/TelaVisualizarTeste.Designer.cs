namespace TestesDonaMariana.WinForm.ModuloTeste
{
    partial class TelaVisualizarTeste
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
            lBtitulo = new Label();
            lBdisciplina = new Label();
            lBmateria = new Label();
            lBquestoes = new ListBox();
            button1 = new Button();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(52, 34);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 0;
            label1.Text = "Titulo:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(52, 72);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 1;
            label2.Text = "Disciplina:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(52, 112);
            label3.Name = "label3";
            label3.Size = new Size(50, 15);
            label3.TabIndex = 2;
            label3.Text = "Matéria:";
            // 
            // lBtitulo
            // 
            lBtitulo.AutoSize = true;
            lBtitulo.Location = new Point(122, 34);
            lBtitulo.Name = "lBtitulo";
            lBtitulo.Size = new Size(38, 15);
            lBtitulo.TabIndex = 3;
            lBtitulo.Text = "label4";
            // 
            // lBdisciplina
            // 
            lBdisciplina.AutoSize = true;
            lBdisciplina.Location = new Point(122, 72);
            lBdisciplina.Name = "lBdisciplina";
            lBdisciplina.Size = new Size(38, 15);
            lBdisciplina.TabIndex = 4;
            lBdisciplina.Text = "label5";
            // 
            // lBmateria
            // 
            lBmateria.AutoSize = true;
            lBmateria.Location = new Point(122, 112);
            lBmateria.Name = "lBmateria";
            lBmateria.Size = new Size(38, 15);
            lBmateria.TabIndex = 5;
            lBmateria.Text = "label6";
            // 
            // lBquestoes
            // 
            lBquestoes.FormattingEnabled = true;
            lBquestoes.ItemHeight = 15;
            lBquestoes.Location = new Point(52, 173);
            lBquestoes.Name = "lBquestoes";
            lBquestoes.Size = new Size(325, 244);
            lBquestoes.TabIndex = 6;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ButtonHighlight;
            button1.DialogResult = DialogResult.Cancel;
            button1.Location = new Point(318, 423);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 7;
            button1.Text = "Fechar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(52, 155);
            label4.Name = "label4";
            label4.Size = new Size(127, 15);
            label4.TabIndex = 8;
            label4.Text = "Questões Selecionadas";
            // 
            // TelaVisualizarTeste
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(409, 458);
            Controls.Add(label4);
            Controls.Add(button1);
            Controls.Add(lBquestoes);
            Controls.Add(lBmateria);
            Controls.Add(lBdisciplina);
            Controls.Add(lBtitulo);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TelaVisualizarTeste";
            Text = "TelaVisualizarTeste";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label lBtitulo;
        private Label lBdisciplina;
        private Label lBmateria;
        private ListBox lBquestoes;
        private Button button1;
        private Label label4;
    }
}