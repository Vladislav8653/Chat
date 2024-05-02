namespace Chat
{
    partial class NewClient
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
            IPPort = new Label();
            PortLabel = new Label();
            IP1 = new TextBox();
            Port1 = new TextBox();
            IP3 = new TextBox();
            IP2 = new TextBox();
            IP4 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            label4 = new Label();
            UserName = new TextBox();
            SuspendLayout();
            // 
            // IPPort
            // 
            IPPort.AutoSize = true;
            IPPort.Font = new Font("Sitka Subheading", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            IPPort.Location = new Point(21, 24);
            IPPort.Name = "IPPort";
            IPPort.Size = new Size(159, 49);
            IPPort.TabIndex = 2;
            IPPort.Text = "IP адрес:";
            // 
            // PortLabel
            // 
            PortLabel.AutoSize = true;
            PortLabel.Font = new Font("Sitka Subheading", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            PortLabel.Location = new Point(21, 82);
            PortLabel.Name = "PortLabel";
            PortLabel.Size = new Size(111, 49);
            PortLabel.TabIndex = 3;
            PortLabel.Text = "Порт:";
            // 
            // IP1
            // 
            IP1.Font = new Font("Sitka Subheading", 14F, FontStyle.Regular, GraphicsUnit.Point);
            IP1.Location = new Point(223, 36);
            IP1.MaxLength = 3;
            IP1.Name = "IP1";
            IP1.Size = new Size(50, 37);
            IP1.TabIndex = 1;
            // 
            // Port1
            // 
            Port1.Font = new Font("Sitka Subheading", 14F, FontStyle.Regular, GraphicsUnit.Point);
            Port1.Location = new Point(223, 94);
            Port1.MaxLength = 4;
            Port1.Name = "Port1";
            Port1.Size = new Size(76, 37);
            Port1.TabIndex = 5;
            // 
            // IP3
            // 
            IP3.Font = new Font("Sitka Subheading", 14F, FontStyle.Regular, GraphicsUnit.Point);
            IP3.Location = new Point(387, 36);
            IP3.MaxLength = 3;
            IP3.Name = "IP3";
            IP3.Size = new Size(50, 37);
            IP3.TabIndex = 3;
            // 
            // IP2
            // 
            IP2.Font = new Font("Sitka Subheading", 14F, FontStyle.Regular, GraphicsUnit.Point);
            IP2.Location = new Point(305, 36);
            IP2.MaxLength = 3;
            IP2.Name = "IP2";
            IP2.Size = new Size(50, 37);
            IP2.TabIndex = 2;
            // 
            // IP4
            // 
            IP4.Font = new Font("Sitka Subheading", 14F, FontStyle.Regular, GraphicsUnit.Point);
            IP4.Location = new Point(469, 37);
            IP4.MaxLength = 3;
            IP4.Name = "IP4";
            IP4.Size = new Size(50, 37);
            IP4.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(279, 42);
            label1.Name = "label1";
            label1.Size = new Size(20, 35);
            label1.TabIndex = 9;
            label1.Text = ".";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(361, 42);
            label2.Name = "label2";
            label2.Size = new Size(20, 35);
            label2.TabIndex = 10;
            label2.Text = ".";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(443, 42);
            label3.Name = "label3";
            label3.Size = new Size(20, 35);
            label3.TabIndex = 11;
            label3.Text = ".";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.InactiveBorder;
            button1.Font = new Font("Sitka Subheading", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(21, 202);
            button1.Name = "button1";
            button1.Size = new Size(506, 37);
            button1.TabIndex = 6;
            button1.Text = "Установить соединение";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Sitka Subheading", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(21, 137);
            label4.Name = "label4";
            label4.Size = new Size(188, 49);
            label4.TabIndex = 12;
            label4.Text = "Ваше имя:";
            // 
            // UserName
            // 
            UserName.Font = new Font("Sitka Subheading", 14F, FontStyle.Regular, GraphicsUnit.Point);
            UserName.Location = new Point(223, 146);
            UserName.MaxLength = 20;
            UserName.Name = "UserName";
            UserName.Size = new Size(296, 37);
            UserName.TabIndex = 13;
            // 
            // NewClient
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(551, 251);
            Controls.Add(UserName);
            Controls.Add(label4);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(IP4);
            Controls.Add(IP2);
            Controls.Add(IP3);
            Controls.Add(Port1);
            Controls.Add(IP1);
            Controls.Add(PortLabel);
            Controls.Add(IPPort);
            KeyPreview = true;
            Name = "NewClient";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NewClient";
            Activated += NewClient_Activated;
            Deactivate += NewClient_Deactivate;
            KeyDown += NewClient_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label IPPort;
        private Label PortLabel;
        private TextBox IP1;
        private TextBox Port1;
        private TextBox IP3;
        private TextBox IP2;
        private TextBox IP4;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private Label label4;
        private TextBox UserName;
    }
}