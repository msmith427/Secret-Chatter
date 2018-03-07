namespace SecretChatter
{
    partial class Form1
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
            this.messageLog = new System.Windows.Forms.TextBox();
            this.inputUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.inputText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.inputPassword = new System.Windows.Forms.TextBox();
            this.inputIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonSend = new System.Windows.Forms.Button();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // messageLog
            // 
            this.messageLog.Location = new System.Drawing.Point(12, 12);
            this.messageLog.Multiline = true;
            this.messageLog.Name = "messageLog";
            this.messageLog.ReadOnly = true;
            this.messageLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.messageLog.Size = new System.Drawing.Size(497, 381);
            this.messageLog.TabIndex = 0;
            // 
            // inputUsername
            // 
            this.inputUsername.Location = new System.Drawing.Point(515, 29);
            this.inputUsername.Name = "inputUsername";
            this.inputUsername.Size = new System.Drawing.Size(255, 22);
            this.inputUsername.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(515, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username";
            // 
            // inputText
            // 
            this.inputText.Location = new System.Drawing.Point(12, 399);
            this.inputText.Name = "inputText";
            this.inputText.Size = new System.Drawing.Size(416, 22);
            this.inputText.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(515, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password";
            // 
            // inputPassword
            // 
            this.inputPassword.Location = new System.Drawing.Point(515, 74);
            this.inputPassword.Name = "inputPassword";
            this.inputPassword.Size = new System.Drawing.Size(255, 22);
            this.inputPassword.TabIndex = 5;
            // 
            // inputIP
            // 
            this.inputIP.Location = new System.Drawing.Point(515, 119);
            this.inputIP.Name = "inputIP";
            this.inputIP.Size = new System.Drawing.Size(255, 22);
            this.inputIP.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(515, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "IP Address";
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(434, 399);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 8;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(513, 147);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(75, 23);
            this.buttonConnect.TabIndex = 9;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 433);
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
            this.Name = "Form1";
            this.Text = "SecretChat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox messageLog;
        private System.Windows.Forms.TextBox inputUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox inputText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox inputPassword;
        private System.Windows.Forms.TextBox inputIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button buttonConnect;
    }
}

