namespace Client
{
    partial class LoginForm
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
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.userNameInput = new System.Windows.Forms.TextBox();
            this.PasswordInput = new System.Windows.Forms.TextBox();
            this.LoginButton = new System.Windows.Forms.Button();
            this.RegistButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.PortInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.Location = new System.Drawing.Point(59, 48);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(53, 12);
            this.UserNameLabel.TabIndex = 0;
            this.UserNameLabel.Text = "用户名：";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(59, 96);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(41, 12);
            this.PasswordLabel.TabIndex = 1;
            this.PasswordLabel.Text = "密码：";
            // 
            // userNameInput
            // 
            this.userNameInput.Location = new System.Drawing.Point(134, 39);
            this.userNameInput.Name = "userNameInput";
            this.userNameInput.Size = new System.Drawing.Size(100, 21);
            this.userNameInput.TabIndex = 2;
            // 
            // PasswordInput
            // 
            this.PasswordInput.Location = new System.Drawing.Point(134, 87);
            this.PasswordInput.Name = "PasswordInput";
            this.PasswordInput.Size = new System.Drawing.Size(100, 21);
            this.PasswordInput.TabIndex = 3;
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(61, 183);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(75, 23);
            this.LoginButton.TabIndex = 4;
            this.LoginButton.Text = "登录";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // RegistButton
            // 
            this.RegistButton.Location = new System.Drawing.Point(159, 183);
            this.RegistButton.Name = "RegistButton";
            this.RegistButton.Size = new System.Drawing.Size(75, 23);
            this.RegistButton.TabIndex = 5;
            this.RegistButton.Text = "注册";
            this.RegistButton.UseVisualStyleBackColor = true;
            this.RegistButton.Click += new System.EventHandler(this.RegistButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(110, 227);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 6;
            this.ExitButton.Text = "退出";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "端口号：";
            // 
            // PortInput
            // 
            this.PortInput.Location = new System.Drawing.Point(134, 127);
            this.PortInput.Name = "PortInput";
            this.PortInput.Size = new System.Drawing.Size(100, 21);
            this.PortInput.TabIndex = 8;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.PortInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.RegistButton);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.PasswordInput);
            this.Controls.Add(this.userNameInput);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UserNameLabel);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox userNameInput;
        private System.Windows.Forms.TextBox PasswordInput;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Button RegistButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PortInput;
    }
}