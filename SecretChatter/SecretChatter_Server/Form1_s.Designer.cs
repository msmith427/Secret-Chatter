namespace SecretChatter_Server
{
    partial class Form1_s
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
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonSend = new System.Windows.Forms.Button();
            this.inputIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.inputPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.inputText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.inputUsername = new System.Windows.Forms.TextBox();
            this.messageLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(385, 120);
            this.buttonConnect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(56, 19);
            this.buttonConnect.TabIndex = 19;
            this.buttonConnect.Text = "wait-now";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(326, 325);
            this.buttonSend.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(56, 19);
            this.buttonSend.TabIndex = 18;
            this.buttonSend.Text = "Update";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // inputIP
            // 
            this.inputIP.Location = new System.Drawing.Point(386, 98);
            this.inputIP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.inputIP.Name = "inputIP";
            this.inputIP.ReadOnly = true;
            this.inputIP.Size = new System.Drawing.Size(192, 20);
            this.inputIP.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(386, 81);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "IP Address";
            // 
            // inputPassword
            // 
            this.inputPassword.Location = new System.Drawing.Point(386, 61);
            this.inputPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.inputPassword.Name = "inputPassword";
            this.inputPassword.ReadOnly = true;
            this.inputPassword.Size = new System.Drawing.Size(192, 20);
            this.inputPassword.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(386, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Password";
            // 
            // inputText
            // 
            this.inputText.Location = new System.Drawing.Point(9, 325);
            this.inputText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.inputText.Name = "inputText";
            this.inputText.Size = new System.Drawing.Size(313, 20);
            this.inputText.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(386, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Username";
            // 
            // inputUsername
            // 
            this.inputUsername.Location = new System.Drawing.Point(386, 24);
            this.inputUsername.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.inputUsername.Name = "inputUsername";
            this.inputUsername.ReadOnly = true;
            this.inputUsername.Size = new System.Drawing.Size(192, 20);
            this.inputUsername.TabIndex = 11;
            this.inputUsername.Text = "Steven";
            // 
            // messageLog
            // 
            this.messageLog.Location = new System.Drawing.Point(9, 11);
            this.messageLog.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.messageLog.Multiline = true;
            this.messageLog.Name = "messageLog";
            this.messageLog.ReadOnly = true;
            this.messageLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.messageLog.Size = new System.Drawing.Size(374, 310);
            this.messageLog.TabIndex = 10;
            // 
            // Form1_s
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 352);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.inputIP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.inputPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inputText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputUsername);
            this.Controls.Add(this.messageLog);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1_s";
            this.Text = "ChatServer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox inputIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox inputPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox inputText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox inputUsername;
        private System.Windows.Forms.TextBox messageLog;
    }
}

