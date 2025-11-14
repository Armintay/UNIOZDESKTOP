namespace UNIOZDESKTOP
{
    partial class AlterarSenha
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlterarSenha));
            pictureBox1 = new PictureBox();
            roundedPanel1 = new RoundedPanel();
            SalvarNovaSenha = new Label();
            roundedPanel2 = new RoundedPanel();
            txtNovaSenha = new TextBox();
            label1 = new Label();
            textBox1 = new TextBox();
            roundedPanel3 = new RoundedPanel();
            txtConfirmarSenha = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            roundedPanel1.SuspendLayout();
            roundedPanel2.SuspendLayout();
            roundedPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(846, 166);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(214, 185);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // roundedPanel1
            // 
            roundedPanel1.BackColor = Color.FromArgb(0, 48, 82);
            roundedPanel1.BorderColor = Color.Gray;
            roundedPanel1.BorderSize = 1;
            roundedPanel1.Controls.Add(SalvarNovaSenha);
            roundedPanel1.CornerRadius = 20;
            roundedPanel1.Location = new Point(766, 729);
            roundedPanel1.Name = "roundedPanel1";
            roundedPanel1.Size = new Size(329, 78);
            roundedPanel1.TabIndex = 1;
            // 
            // SalvarNovaSenha
            // 
            SalvarNovaSenha.AutoSize = true;
            SalvarNovaSenha.Font = new Font("Poppins", 25.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SalvarNovaSenha.ForeColor = SystemColors.ButtonFace;
            SalvarNovaSenha.Location = new Point(20, 2);
            SalvarNovaSenha.Name = "SalvarNovaSenha";
            SalvarNovaSenha.Size = new Size(288, 74);
            SalvarNovaSenha.TabIndex = 0;
            SalvarNovaSenha.Text = "CONFIRMAR";
            SalvarNovaSenha.TextAlign = ContentAlignment.MiddleCenter;
            SalvarNovaSenha.Click += label_Click;
            // 
            // roundedPanel2
            // 
            roundedPanel2.BorderColor = Color.Gray;
            roundedPanel2.BorderSize = 1;
            roundedPanel2.Controls.Add(txtNovaSenha);
            roundedPanel2.CornerRadius = 20;
            roundedPanel2.Location = new Point(681, 528);
            roundedPanel2.Name = "roundedPanel2";
            roundedPanel2.Size = new Size(532, 77);
            roundedPanel2.TabIndex = 2;
            // 
            // txtNovaSenha
            // 
            txtNovaSenha.BackColor = Color.FromArgb(0, 54, 109);
            txtNovaSenha.BorderStyle = BorderStyle.None;
            txtNovaSenha.Font = new Font("Poppins", 19.2F);
            txtNovaSenha.ForeColor = Color.White;
            txtNovaSenha.Location = new Point(3, 16);
            txtNovaSenha.Name = "txtNovaSenha";
            txtNovaSenha.PlaceholderText = "Digite a Senha Nova";
            txtNovaSenha.Size = new Size(526, 48);
            txtNovaSenha.TabIndex = 17;
            txtNovaSenha.TextAlign = HorizontalAlignment.Center;
            txtNovaSenha.TextChanged += txtNovaSenha_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Poppins", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(639, 421);
            label1.Name = "label1";
            label1.Size = new Size(629, 78);
            label1.TabIndex = 3;
            label1.Text = "Informe a Sua Nova Senha";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(0, 54, 109);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Poppins", 19.2F);
            textBox1.ForeColor = Color.White;
            textBox1.Location = new Point(3, 16);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Digite a Senha Novamente";
            textBox1.Size = new Size(526, 48);
            textBox1.TabIndex = 19;
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // roundedPanel3
            // 
            roundedPanel3.BorderColor = Color.Gray;
            roundedPanel3.BorderSize = 1;
            roundedPanel3.Controls.Add(txtConfirmarSenha);
            roundedPanel3.Controls.Add(textBox1);
            roundedPanel3.CornerRadius = 20;
            roundedPanel3.Location = new Point(681, 628);
            roundedPanel3.Name = "roundedPanel3";
            roundedPanel3.Size = new Size(535, 77);
            roundedPanel3.TabIndex = 20;
            // 
            // txtConfirmarSenha
            // 
            txtConfirmarSenha.BackColor = Color.FromArgb(0, 54, 109);
            txtConfirmarSenha.BorderStyle = BorderStyle.None;
            txtConfirmarSenha.Font = new Font("Poppins", 19.2F);
            txtConfirmarSenha.ForeColor = Color.White;
            txtConfirmarSenha.Location = new Point(3, 16);
            txtConfirmarSenha.Name = "txtConfirmarSenha";
            txtConfirmarSenha.PlaceholderText = "Digite a Senha Novamente";
            txtConfirmarSenha.Size = new Size(526, 48);
            txtConfirmarSenha.TabIndex = 17;
            txtConfirmarSenha.TextAlign = HorizontalAlignment.Center;
            // 
            // AlterarSenha
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 54, 109);
            ClientSize = new Size(1902, 1033);
            Controls.Add(roundedPanel3);
            Controls.Add(label1);
            Controls.Add(roundedPanel2);
            Controls.Add(roundedPanel1);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Name = "AlterarSenha";
            Text = "Token";
            WindowState = FormWindowState.Maximized;
            KeyDown += AlterarSenha_KeyDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            roundedPanel1.ResumeLayout(false);
            roundedPanel1.PerformLayout();
            roundedPanel2.ResumeLayout(false);
            roundedPanel2.PerformLayout();
            roundedPanel3.ResumeLayout(false);
            roundedPanel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private RoundedPanel roundedPanel1;
        private Label SalvarNovaSenha;
        private RoundedPanel roundedPanel2;
        private Label label1;
        private TextBox txtConfirmarSenha;
        private TextBox txtNovaSenha;
        private TextBox textBox1;
        private RoundedPanel roundedPanel3;
    }
}