namespace UNIOZDESKTOP
{
    partial class RecuperarSenha
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecuperarSenha));
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            roundedPanel1 = new RoundedPanel();
            txtRA = new TextBox();
            roundedPanel2 = new RoundedPanel();
            txtEmail = new TextBox();
            roundedPanel3 = new RoundedPanel();
            txtTelefone = new TextBox();
            roundedPanel4 = new RoundedPanel();
            Validacao_token = new TextBox();
            roundedPanel5 = new RoundedPanel();
            Confirm_dados = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            roundedPanel1.SuspendLayout();
            roundedPanel2.SuspendLayout();
            roundedPanel3.SuspendLayout();
            roundedPanel4.SuspendLayout();
            roundedPanel5.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(188, 119);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(401, 501);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label2
            // 
            label2.Font = new Font("Poppins", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(260, 742);
            label2.Name = "label2";
            label2.Size = new Size(236, 87);
            label2.TabIndex = 6;
            label2.Text = "Senha";
            // 
            // label1
            // 
            label1.Font = new Font("Poppins", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(188, 651);
            label1.Name = "label1";
            label1.Size = new Size(401, 91);
            label1.TabIndex = 5;
            label1.Text = "Recuperar";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Poppins", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(1116, 119);
            label3.Name = "label3";
            label3.Size = new Size(460, 70);
            label3.TabIndex = 11;
            label3.Text = "Confirme seus dados";
            // 
            // roundedPanel1
            // 
            roundedPanel1.BorderColor = Color.Gray;
            roundedPanel1.BorderSize = 1;
            roundedPanel1.Controls.Add(txtRA);
            roundedPanel1.CornerRadius = 20;
            roundedPanel1.Location = new Point(1054, 213);
            roundedPanel1.Name = "roundedPanel1";
            roundedPanel1.Size = new Size(600, 77);
            roundedPanel1.TabIndex = 0;
            // 
            // txtRA
            // 
            txtRA.BackColor = Color.FromArgb(0, 54, 109);
            txtRA.BorderStyle = BorderStyle.None;
            txtRA.Font = new Font("Poppins", 19.8F);
            txtRA.ForeColor = Color.White;
            txtRA.Location = new Point(43, 14);
            txtRA.Name = "txtRA";
            txtRA.PlaceholderText = "Digite Seu RA";
            txtRA.Size = new Size(517, 50);
            txtRA.TabIndex = 0;
            txtRA.TextAlign = HorizontalAlignment.Center;
            txtRA.TextChanged += txtRA_TextChanged;
            // 
            // roundedPanel2
            // 
            roundedPanel2.BorderColor = Color.Gray;
            roundedPanel2.BorderSize = 1;
            roundedPanel2.Controls.Add(txtEmail);
            roundedPanel2.CornerRadius = 20;
            roundedPanel2.Location = new Point(1054, 350);
            roundedPanel2.Name = "roundedPanel2";
            roundedPanel2.Size = new Size(600, 77);
            roundedPanel2.TabIndex = 1;
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.FromArgb(0, 54, 109);
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Font = new Font("Poppins", 19.8F);
            txtEmail.ForeColor = Color.White;
            txtEmail.Location = new Point(62, 11);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Digite Seu E-mail";
            txtEmail.Size = new Size(498, 50);
            txtEmail.TabIndex = 0;
            txtEmail.TextAlign = HorizontalAlignment.Center;
            // 
            // roundedPanel3
            // 
            roundedPanel3.BorderColor = Color.Gray;
            roundedPanel3.BorderSize = 1;
            roundedPanel3.Controls.Add(txtTelefone);
            roundedPanel3.CornerRadius = 20;
            roundedPanel3.Location = new Point(1054, 492);
            roundedPanel3.Name = "roundedPanel3";
            roundedPanel3.Size = new Size(600, 77);
            roundedPanel3.TabIndex = 2;
            // 
            // txtTelefone
            // 
            txtTelefone.BackColor = Color.FromArgb(0, 54, 109);
            txtTelefone.BorderStyle = BorderStyle.None;
            txtTelefone.Font = new Font("Poppins", 19.8F);
            txtTelefone.ForeColor = Color.White;
            txtTelefone.Location = new Point(62, 14);
            txtTelefone.Name = "txtTelefone";
            txtTelefone.PlaceholderText = "Digite Seu Telefone";
            txtTelefone.Size = new Size(498, 50);
            txtTelefone.TabIndex = 0;
            txtTelefone.TextAlign = HorizontalAlignment.Center;
            // 
            // roundedPanel4
            // 
            roundedPanel4.BorderColor = Color.Gray;
            roundedPanel4.BorderSize = 1;
            roundedPanel4.Controls.Add(Validacao_token);
            roundedPanel4.CornerRadius = 20;
            roundedPanel4.Location = new Point(1054, 637);
            roundedPanel4.Name = "roundedPanel4";
            roundedPanel4.Size = new Size(600, 77);
            roundedPanel4.TabIndex = 3;
            // 
            // Validacao_token
            // 
            Validacao_token.BackColor = Color.FromArgb(0, 54, 109);
            Validacao_token.BorderStyle = BorderStyle.None;
            Validacao_token.Font = new Font("Poppins", 19.8F);
            Validacao_token.ForeColor = Color.White;
            Validacao_token.Location = new Point(62, 11);
            Validacao_token.Name = "Validacao_token";
            Validacao_token.PlaceholderText = "Digite o Token de Validação";
            Validacao_token.Size = new Size(498, 50);
            Validacao_token.TabIndex = 0;
            Validacao_token.TextAlign = HorizontalAlignment.Center;
            Validacao_token.TextChanged += Validacao_token_TextChanged;
            // 
            // roundedPanel5
            // 
            roundedPanel5.BackColor = Color.FromArgb(0, 48, 82);
            roundedPanel5.BorderColor = Color.Transparent;
            roundedPanel5.BorderSize = 1;
            roundedPanel5.Controls.Add(Confirm_dados);
            roundedPanel5.CornerRadius = 20;
            roundedPanel5.Location = new Point(1224, 771);
            roundedPanel5.Name = "roundedPanel5";
            roundedPanel5.Size = new Size(320, 76);
            roundedPanel5.TabIndex = 4;
            // 
            // Confirm_dados
            // 
            Confirm_dados.AutoSize = true;
            Confirm_dados.Cursor = Cursors.Hand;
            Confirm_dados.Font = new Font("Poppins", 25.8F);
            Confirm_dados.ForeColor = Color.White;
            Confirm_dados.Location = new Point(23, 0);
            Confirm_dados.Name = "Confirm_dados";
            Confirm_dados.Size = new Size(280, 76);
            Confirm_dados.TabIndex = 0;
            Confirm_dados.Text = "CONFIRMAR";
            Confirm_dados.Click += Confirm_dados_Click;
            // 
            // RecuperarSenha
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 54, 109);
            ClientSize = new Size(1902, 1033);
            Controls.Add(roundedPanel5);
            Controls.Add(roundedPanel4);
            Controls.Add(roundedPanel3);
            Controls.Add(roundedPanel2);
            Controls.Add(roundedPanel1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Name = "RecuperarSenha";
            Text = "RecuperarSenha";
            WindowState = FormWindowState.Maximized;
            KeyDown += RecuperarSenha_KeyDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            roundedPanel1.ResumeLayout(false);
            roundedPanel1.PerformLayout();
            roundedPanel2.ResumeLayout(false);
            roundedPanel2.PerformLayout();
            roundedPanel3.ResumeLayout(false);
            roundedPanel3.PerformLayout();
            roundedPanel4.ResumeLayout(false);
            roundedPanel4.PerformLayout();
            roundedPanel5.ResumeLayout(false);
            roundedPanel5.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label2;
        private Label label1;
        private Label label3;
        private RoundedPanel roundedPanel1;
        private RoundedPanel roundedPanel2;
        private RoundedPanel roundedPanel3;
        private RoundedPanel roundedPanel4;
        private TextBox txtRA;
        private TextBox txtEmail;
        private TextBox txtTelefone;
        private TextBox Validacao_token;
        private RoundedPanel roundedPanel5;
        private Label Confirm_dados;
    }
}