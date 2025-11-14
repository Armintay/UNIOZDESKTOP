namespace UNIOZDESKTOP
{
    partial class TelaInicial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaInicial));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel1 = new Panel();
            pbLogout = new PictureBox();
            linkLabel2 = new LinkLabel();
            linkNovoChamado = new LinkLabel();
            panel2 = new Panel();
            linkLabel3 = new LinkLabel();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            panel3 = new Panel();
            panel4 = new Panel();
            label2 = new Label();
            label1 = new Label();
            roundedPanel1 = new RoundedPanel();
            pictureBox3 = new PictureBox();
            textBox1 = new TextBox();
            dataGridView1 = new DataGridView();
            panel5 = new Panel();
            label3 = new Label();
            picChatIcon = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogout).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            roundedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picChatIcon).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.White;
            panel1.Controls.Add(pbLogout);
            panel1.Controls.Add(linkLabel2);
            panel1.Controls.Add(linkNovoChamado);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(linkLabel3);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1902, 112);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // pbLogout
            // 
            pbLogout.Cursor = Cursors.Hand;
            pbLogout.Image = Properties.Resources.arrow;
            pbLogout.Location = new Point(1819, 38);
            pbLogout.Name = "pbLogout";
            pbLogout.Size = new Size(44, 40);
            pbLogout.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogout.TabIndex = 8;
            pbLogout.TabStop = false;
            pbLogout.Click += pbLogout_Click;
            // 
            // linkLabel2
            // 
            linkLabel2.ActiveLinkColor = Color.FromArgb(0, 54, 109);
            linkLabel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            linkLabel2.Cursor = Cursors.Hand;
            linkLabel2.Font = new Font("Poppins", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabel2.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabel2.LinkColor = Color.Black;
            linkLabel2.Location = new Point(58, 36);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(222, 40);
            linkLabel2.TabIndex = 6;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "MEUS CHAMADOS";
            linkLabel2.VisitedLinkColor = Color.Black;
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // linkNovoChamado
            // 
            linkNovoChamado.ActiveLinkColor = Color.FromArgb(0, 54, 109);
            linkNovoChamado.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            linkNovoChamado.Cursor = Cursors.Hand;
            linkNovoChamado.Font = new Font("Poppins", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkNovoChamado.LinkBehavior = LinkBehavior.NeverUnderline;
            linkNovoChamado.LinkColor = Color.Black;
            linkNovoChamado.Location = new Point(311, 36);
            linkNovoChamado.Name = "linkNovoChamado";
            linkNovoChamado.Size = new Size(223, 40);
            linkNovoChamado.TabIndex = 5;
            linkNovoChamado.TabStop = true;
            linkNovoChamado.Text = "NOVO CHAMADO";
            linkNovoChamado.VisitedLinkColor = Color.Black;
            linkNovoChamado.LinkClicked += linkLabel1_LinkClicked;
            // 
            // panel2
            // 
            panel2.Location = new Point(0, 108);
            panel2.Name = "panel2";
            panel2.Size = new Size(1728, 294);
            panel2.TabIndex = 1;
            // 
            // linkLabel3
            // 
            linkLabel3.ActiveLinkColor = Color.FromArgb(0, 54, 109);
            linkLabel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            linkLabel3.Cursor = Cursors.Hand;
            linkLabel3.Font = new Font("Poppins", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabel3.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabel3.LinkColor = Color.Black;
            linkLabel3.Location = new Point(1517, 38);
            linkLabel3.Name = "linkLabel3";
            linkLabel3.Size = new Size(296, 40);
            linkLabel3.TabIndex = 7;
            linkLabel3.TabStop = true;
            linkLabel3.Text = "Meu Perfil";
            linkLabel3.VisitedLinkColor = Color.Black;
            linkLabel3.LinkClicked += linkLabel3_LinkClicked;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(1464, 38);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(47, 38);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(666, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(572, 112);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.Controls.Add(panel4);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(roundedPanel1);
            panel3.Location = new Point(0, 111);
            panel3.Name = "panel3";
            panel3.Size = new Size(1921, 291);
            panel3.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.Location = new Point(0, 297);
            panel4.Name = "panel4";
            panel4.Size = new Size(1709, 308);
            panel4.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Poppins", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(711, 123);
            label2.Name = "label2";
            label2.Size = new Size(493, 26);
            label2.TabIndex = 2;
            label2.Text = "Envie uma mensagem para nosso chatbot que ele lhe auxiliará!";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Poppins", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(741, 70);
            label1.Name = "label1";
            label1.Size = new Size(429, 53);
            label1.TabIndex = 1;
            label1.Text = "Está precisando de ajuda ?";
            // 
            // roundedPanel1
            // 
            roundedPanel1.BorderColor = Color.Gray;
            roundedPanel1.BorderSize = 1;
            roundedPanel1.Controls.Add(pictureBox3);
            roundedPanel1.Controls.Add(textBox1);
            roundedPanel1.CornerRadius = 20;
            roundedPanel1.Location = new Point(654, 167);
            roundedPanel1.Name = "roundedPanel1";
            roundedPanel1.Size = new Size(586, 56);
            roundedPanel1.TabIndex = 0;
            roundedPanel1.Paint += roundedPanel1_Paint;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(27, 16);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(24, 24);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.BackColor = Color.FromArgb(0, 54, 109);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Poppins", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.ForeColor = Color.White;
            textBox1.ImeMode = ImeMode.NoControl;
            textBox1.Location = new Point(57, 13);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Descreva seu problema";
            textBox1.Size = new Size(496, 27);
            textBox1.TabIndex = 1;
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.BackgroundColor = Color.FromArgb(235, 236, 238);
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Poppins", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Poppins", 12F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.DimGray;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.GridColor = Color.LightGray;
            dataGridView1.Location = new Point(0, 408);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1902, 545);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.Sorted += dataGridView1_Sorted;
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel5.BackColor = Color.White;
            panel5.Controls.Add(label3);
            panel5.Location = new Point(0, 951);
            panel5.Name = "panel5";
            panel5.Size = new Size(1902, 82);
            panel5.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Poppins", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(28, 58, 80);
            label3.Location = new Point(594, 0);
            label3.Name = "label3";
            label3.Size = new Size(660, 82);
            label3.TabIndex = 0;
            label3.Text = "UNIVERSIDADE DE OSASCO";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picChatIcon
            // 
            picChatIcon.BackColor = Color.White;
            picChatIcon.BackgroundImageLayout = ImageLayout.Center;
            picChatIcon.Cursor = Cursors.Hand;
            picChatIcon.Image = Properties.Resources.chatbot;
            picChatIcon.Location = new Point(1774, 871);
            picChatIcon.Name = "picChatIcon";
            picChatIcon.Size = new Size(85, 74);
            picChatIcon.SizeMode = PictureBoxSizeMode.Zoom;
            picChatIcon.TabIndex = 4;
            picChatIcon.TabStop = false;
            picChatIcon.Click += picChatIcon_Click;
            // 
            // TelaInicial
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 54, 109);
            ClientSize = new Size(1902, 1033);
            Controls.Add(picChatIcon);
            Controls.Add(panel5);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "TelaInicial";
            Text = "Inicio";
            WindowState = FormWindowState.Maximized;
            Load += TelaInicial_Load;
            Resize += TelaInicial_Resize;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbLogout).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            roundedPanel1.ResumeLayout(false);
            roundedPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picChatIcon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private LinkLabel linkLabel3;
        private LinkLabel linkLabel2;
        private LinkLabel linkNovoChamado;
        private Panel panel2;
        private Panel panel3;
        private RoundedPanel roundedPanel1;
        private PictureBox pictureBox3;
        private TextBox textBox1;
        private Label label2;
        private Label label1;
        private Panel panel4;
        private DataGridView dataGridView1;
        private Panel panel5;
        private Label label3;
        private PictureBox picChatIcon;
        private PictureBox pbLogout;
    }
}