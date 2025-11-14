namespace UNIOZDESKTOP
{
    partial class Login
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            pictureBox1 = new PictureBox();
            textSenha = new TextBox();
            label1 = new Label();
            Link_Recuperar = new LinkLabel();
            textRA = new TextBox();
            pictureBox4 = new PictureBox();
            pictureBox2 = new PictureBox();
            roundedPanel1 = new RoundedPanel();
            labelLogin = new Label();
            roundedPanel3 = new RoundedPanel();
            roundedPanel4 = new RoundedPanel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            roundedPanel1.SuspendLayout();
            roundedPanel3.SuspendLayout();
            roundedPanel4.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(874, 105);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(147, 112);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // textSenha
            // 
            textSenha.BackColor = Color.FromArgb(0, 54, 109);
            textSenha.BorderStyle = BorderStyle.None;
            textSenha.Font = new Font("Poppins", 19.8F);
            textSenha.ForeColor = Color.White;
            textSenha.Location = new Point(81, 5);
            textSenha.Name = "textSenha";
            textSenha.PasswordChar = '*';
            textSenha.PlaceholderText = "Digite Sua Senha";
            textSenha.Size = new Size(460, 50);
            textSenha.TabIndex = 0;
            textSenha.TextAlign = HorizontalAlignment.Center;
            textSenha.TextChanged += textSenha_TextChanged;
            textSenha.KeyDown += textSenha_KeyDown;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Poppins", 16.2F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(896, 246);
            label1.Name = "label1";
            label1.Size = new Size(100, 54);
            label1.TabIndex = 3;
            label1.Text = "Login";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Link_Recuperar
            // 
            Link_Recuperar.AutoSize = true;
            Link_Recuperar.Font = new Font("Poppins", 12F);
            Link_Recuperar.LinkBehavior = LinkBehavior.NeverUnderline;
            Link_Recuperar.LinkColor = Color.White;
            Link_Recuperar.Location = new Point(1094, 601);
            Link_Recuperar.Name = "Link_Recuperar";
            Link_Recuperar.Size = new Size(230, 36);
            Link_Recuperar.TabIndex = 2;
            Link_Recuperar.TabStop = true;
            Link_Recuperar.Text = "Esqueceu sua senha?";
            Link_Recuperar.LinkClicked += linkLabel1_LinkClicked;
            // 
            // textRA
            // 
            textRA.BackColor = Color.FromArgb(0, 54, 109);
            textRA.BorderStyle = BorderStyle.None;
            textRA.Font = new Font("Poppins", 19.8F);
            textRA.ForeColor = Color.White;
            textRA.Location = new Point(81, 5);
            textRA.Name = "textRA";
            textRA.PlaceholderText = "Digite seu RA";
            textRA.Size = new Size(460, 50);
            textRA.TabIndex = 0;
            textRA.Tag = "";
            textRA.TextAlign = HorizontalAlignment.Center;
            textRA.TextChanged += textRA_TextChanged;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(25, 5);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(50, 50);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 4;
            pictureBox4.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(25, 5);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(50, 50);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // roundedPanel1
            // 
            roundedPanel1.BackColor = Color.Transparent;
            roundedPanel1.BorderColor = Color.Gray;
            roundedPanel1.BorderSize = 1;
            roundedPanel1.Controls.Add(pictureBox4);
            roundedPanel1.Controls.Add(textSenha);
            roundedPanel1.CornerRadius = 20;
            roundedPanel1.Location = new Point(650, 449);
            roundedPanel1.Name = "roundedPanel1";
            roundedPanel1.Size = new Size(620, 60);
            roundedPanel1.TabIndex = 1;
            // 
            // labelLogin
            // 
            labelLogin.Anchor = AnchorStyles.None;
            labelLogin.BackColor = Color.Transparent;
            labelLogin.Cursor = Cursors.Hand;
            labelLogin.Font = new Font("Poppins", 25.8F);
            labelLogin.ForeColor = Color.Transparent;
            labelLogin.Location = new Point(9, -1);
            labelLogin.Name = "labelLogin";
            labelLogin.Size = new Size(237, 66);
            labelLogin.TabIndex = 0;
            labelLogin.Text = "ENTRAR";
            labelLogin.TextAlign = ContentAlignment.MiddleCenter;
            labelLogin.Click += labelLogin_Click;
            // 
            // roundedPanel3
            // 
            roundedPanel3.BackColor = Color.Transparent;
            roundedPanel3.BorderColor = Color.Gray;
            roundedPanel3.BorderSize = 1;
            roundedPanel3.Controls.Add(textRA);
            roundedPanel3.Controls.Add(pictureBox2);
            roundedPanel3.CornerRadius = 20;
            roundedPanel3.Location = new Point(650, 325);
            roundedPanel3.Name = "roundedPanel3";
            roundedPanel3.Size = new Size(620, 60);
            roundedPanel3.TabIndex = 0;
            // 
            // roundedPanel4
            // 
            roundedPanel4.BackColor = Color.FromArgb(0, 48, 82);
            roundedPanel4.BorderColor = Color.Gray;
            roundedPanel4.BorderSize = 1;
            roundedPanel4.Controls.Add(labelLogin);
            roundedPanel4.CornerRadius = 20;
            roundedPanel4.Location = new Point(836, 574);
            roundedPanel4.Name = "roundedPanel4";
            roundedPanel4.Size = new Size(252, 63);
            roundedPanel4.TabIndex = 9;
            roundedPanel4.Paint += roundedPanel4_Paint;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 54, 109);
            ClientSize = new Size(1902, 1033);
            Controls.Add(roundedPanel4);
            Controls.Add(roundedPanel3);
            Controls.Add(roundedPanel1);
            Controls.Add(Link_Recuperar);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            WindowState = FormWindowState.Maximized;
            Load += Login_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            roundedPanel1.ResumeLayout(false);
            roundedPanel1.PerformLayout();
            roundedPanel3.ResumeLayout(false);
            roundedPanel3.PerformLayout();
            roundedPanel4.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textSenha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel Link_Recuperar;
        public System.Windows.Forms.TextBox textRA;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private RoundedPanel roundedPanel1;
        private System.Windows.Forms.Label labelLogin;
        private RoundedPanel roundedPanel3;
        private RoundedPanel roundedPanel4;
    }
}