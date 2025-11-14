namespace UNIOZDESKTOP
{
    partial class FormChat
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
            btnClose = new Button();
            panelMessages = new FlowLayoutPanel();
            pnlTextInputArea = new Panel();
            txtInput = new TextBox();
            btnSend = new Button();
            panel1 = new Panel();
            textBox1 = new TextBox();
            pnlTextInputArea.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.Transparent;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Marlett", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 2);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(437, 12);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(34, 27);
            btnClose.TabIndex = 0;
            btnClose.Text = "r";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // panelMessages
            // 
            panelMessages.AutoScroll = true;
            panelMessages.BackColor = Color.White;
            panelMessages.FlowDirection = FlowDirection.TopDown;
            panelMessages.Location = new Point(0, 45);
            panelMessages.Name = "panelMessages";
            panelMessages.Size = new Size(483, 422);
            panelMessages.TabIndex = 1;
            panelMessages.WrapContents = false;
            panelMessages.Paint += panelMessages_Paint;
            // 
            // pnlTextInputArea
            // 
            pnlTextInputArea.Controls.Add(txtInput);
            pnlTextInputArea.Controls.Add(btnSend);
            pnlTextInputArea.Dock = DockStyle.Bottom;
            pnlTextInputArea.Location = new Point(0, 466);
            pnlTextInputArea.Name = "pnlTextInputArea";
            pnlTextInputArea.Size = new Size(483, 50);
            pnlTextInputArea.TabIndex = 0;
            // 
            // txtInput
            // 
            txtInput.Dock = DockStyle.Fill;
            txtInput.Font = new Font("Poppins", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtInput.Location = new Point(0, 0);
            txtInput.Multiline = true;
            txtInput.Name = "txtInput";
            txtInput.PlaceholderText = "Digite aqui!";
            txtInput.Size = new Size(403, 50);
            txtInput.TabIndex = 2;
            // 
            // btnSend
            // 
            btnSend.Dock = DockStyle.Right;
            btnSend.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSend.Location = new Point(403, 0);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(80, 50);
            btnSend.TabIndex = 0;
            btnSend.Text = "➤";
            btnSend.TextAlign = ContentAlignment.TopCenter;
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 54, 109);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(btnClose);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(483, 516);
            panel1.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(0, 54, 109);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Poppins", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.ForeColor = Color.White;
            textBox1.Location = new Point(12, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(409, 23);
            textBox1.TabIndex = 1;
            textBox1.Text = "Olá! Como posso ajudar?";
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // FormChat
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(483, 516);
            Controls.Add(pnlTextInputArea);
            Controls.Add(panelMessages);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormChat";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "FormChat";
            TopMost = true;
            Shown += FormChat_Shown;
            pnlTextInputArea.ResumeLayout(false);
            pnlTextInputArea.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnClose;
        private FlowLayoutPanel panelMessages;
        private Panel pnlTextInputArea;
        private Button btnSend;
        private TextBox txtInput;
        private Panel panel1;
        private TextBox textBox1;
    }
}