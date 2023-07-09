namespace TestesDonaMariana.WinForm.ModuloDisciplina
{
    partial class TelaDisciplina
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
            tbNome = new TextBox();
            tbListaDeMateria = new TextBox();
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // tbNome
            // 
            tbNome.Enabled = false;
            tbNome.Location = new Point(133, 56);
            tbNome.Name = "tbNome";
            tbNome.Size = new Size(49, 23);
            tbNome.TabIndex = 5;
            // 
            // tbListaDeMateria
            // 
            tbListaDeMateria.Location = new Point(133, 102);
            tbListaDeMateria.Name = "tbListaDeMateria";
            tbListaDeMateria.Size = new Size(212, 23);
            tbListaDeMateria.TabIndex = 5;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ButtonFace;
            button1.DialogResult = DialogResult.OK;
            button1.Location = new Point(216, 216);
            button1.Name = "button1";
            button1.Size = new Size(75, 37);
            button1.TabIndex = 3;
            button1.Text = "Cadastrar ";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ButtonFace;
            button2.DialogResult = DialogResult.Cancel;
            button2.Location = new Point(297, 216);
            button2.Name = "button2";
            button2.Size = new Size(75, 37);
            button2.TabIndex = 4;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(35, 97);
            label1.Name = "label1";
            label1.Size = new Size(75, 28);
            label1.TabIndex = 5;
            label1.Text = "Nome :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(35, 51);
            label2.Name = "label2";
            label2.Size = new Size(38, 28);
            label2.TabIndex = 6;
            label2.Text = "Id :";
            // 
            // TelaDisciplina
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(384, 265);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(tbListaDeMateria);
            Controls.Add(tbNome);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "TelaDisciplina";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro Disciplina";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbNome;
        private TextBox tbListaDeMateria;
        private Button button1;
        private Button button2;
        private Label label1;
        private Label label2;
    }
}