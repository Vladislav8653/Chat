namespace Chat
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            Client1PictuteBox = new PictureBox();
            ClientPanel = new Panel();
            AddUserButton = new PictureBox();
            Client1Name = new Label();
            CreateChatBtn = new Button();
            LabelChats = new Label();
            SendBtn = new Button();
            MessageTextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)Client1PictuteBox).BeginInit();
            ClientPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AddUserButton).BeginInit();
            SuspendLayout();
            // 
            // Client1PictuteBox
            // 
            Client1PictuteBox.BackColor = Color.OldLace;
            Client1PictuteBox.Location = new Point(12, 83);
            Client1PictuteBox.Name = "Client1PictuteBox";
            Client1PictuteBox.Size = new Size(366, 70);
            Client1PictuteBox.TabIndex = 0;
            Client1PictuteBox.TabStop = false;
            Client1PictuteBox.Visible = false;
            Client1PictuteBox.Click += Client1PictuteBox_Click;
            // 
            // ClientPanel
            // 
            ClientPanel.BackColor = SystemColors.ControlDark;
            ClientPanel.Controls.Add(AddUserButton);
            ClientPanel.Controls.Add(Client1Name);
            ClientPanel.Controls.Add(Client1PictuteBox);
            ClientPanel.Controls.Add(CreateChatBtn);
            ClientPanel.Controls.Add(LabelChats);
            ClientPanel.Location = new Point(0, -2);
            ClientPanel.Name = "ClientPanel";
            ClientPanel.Size = new Size(394, 686);
            ClientPanel.TabIndex = 1;
            // 
            // AddUserButton
            // 
            AddUserButton.Image = (Image)resources.GetObject("AddUserButton.Image");
            AddUserButton.Location = new Point(12, 11);
            AddUserButton.Name = "AddUserButton";
            AddUserButton.Size = new Size(47, 49);
            AddUserButton.SizeMode = PictureBoxSizeMode.StretchImage;
            AddUserButton.TabIndex = 5;
            AddUserButton.TabStop = false;
            AddUserButton.Visible = false;
            AddUserButton.Click += AddUserButton_Click;
            // 
            // Client1Name
            // 
            Client1Name.AutoSize = true;
            Client1Name.Font = new Font("Sitka Subheading", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            Client1Name.Location = new Point(22, 93);
            Client1Name.Name = "Client1Name";
            Client1Name.Size = new Size(0, 49);
            Client1Name.TabIndex = 4;
            // 
            // CreateChatBtn
            // 
            CreateChatBtn.BackColor = Color.LightCoral;
            CreateChatBtn.Font = new Font("Sitka Subheading", 12F, FontStyle.Regular, GraphicsUnit.Point);
            CreateChatBtn.Location = new Point(12, 636);
            CreateChatBtn.Name = "CreateChatBtn";
            CreateChatBtn.Size = new Size(366, 37);
            CreateChatBtn.TabIndex = 2;
            CreateChatBtn.Text = "Подключиться к серверу";
            CreateChatBtn.UseVisualStyleBackColor = false;
            CreateChatBtn.Click += CreateChatBtn_Click;
            // 
            // LabelChats
            // 
            LabelChats.AutoSize = true;
            LabelChats.Font = new Font("Sitka Subheading", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            LabelChats.Location = new Point(145, 11);
            LabelChats.Name = "LabelChats";
            LabelChats.Size = new Size(104, 49);
            LabelChats.TabIndex = 1;
            LabelChats.Text = "Чаты";
            // 
            // SendBtn
            // 
            SendBtn.Enabled = false;
            SendBtn.Font = new Font("Sitka Subheading", 12F, FontStyle.Regular, GraphicsUnit.Point);
            SendBtn.Location = new Point(1052, 634);
            SendBtn.Name = "SendBtn";
            SendBtn.Size = new Size(134, 37);
            SendBtn.TabIndex = 2;
            SendBtn.Text = "Отправить";
            SendBtn.UseVisualStyleBackColor = true;
            SendBtn.Click += SendBtn_Click;
            // 
            // MessageTextBox
            // 
            MessageTextBox.Font = new Font("Sitka Subheading", 14F, FontStyle.Regular, GraphicsUnit.Point);
            MessageTextBox.Location = new Point(410, 634);
            MessageTextBox.Name = "MessageTextBox";
            MessageTextBox.Size = new Size(636, 37);
            MessageTextBox.TabIndex = 3;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1198, 683);
            Controls.Add(MessageTextBox);
            Controls.Add(SendBtn);
            Controls.Add(ClientPanel);
            KeyPreview = true;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Чат";
            FormClosing += Form1_FormClosing;
            KeyDown += MainForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)Client1PictuteBox).EndInit();
            ClientPanel.ResumeLayout(false);
            ClientPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)AddUserButton).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox Client1PictuteBox;
        private Panel ClientPanel;
        private Button CreateChatBtn;
        private Label LabelChats;
        private Button SendBtn;
        private TextBox MessageTextBox;
        private Label Client1Name;
        private PictureBox AddUserButton;
    }
}