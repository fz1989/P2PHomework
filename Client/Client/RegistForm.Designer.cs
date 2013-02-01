namespace Client
{
    partial class RegistForm
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
            this.RigistName = new System.Windows.Forms.Label();
            this.RegistNameInput = new System.Windows.Forms.TextBox();
            this.RegistPassword = new System.Windows.Forms.Label();
            this.RegistPasswordInput = new System.Windows.Forms.TextBox();
            this.RegistUserButton = new System.Windows.Forms.Button();
            this.ConfigPassword = new System.Windows.Forms.Label();
            this.ConfigPasswordInput = new System.Windows.Forms.TextBox();
            this.RegistLoginButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RigistName
            // 
            this.RigistName.AutoSize = true;
            this.RigistName.Location = new System.Drawing.Point(50, 48);
            this.RigistName.Name = "RigistName";
            this.RigistName.Size = new System.Drawing.Size(65, 12);
            this.RigistName.TabIndex = 0;
            this.RigistName.Text = "注册用户名";
            // 
            // RegistNameInput
            // 
            this.RegistNameInput.Location = new System.Drawing.Point(136, 39);
            this.RegistNameInput.Name = "RegistNameInput";
            this.RegistNameInput.Size = new System.Drawing.Size(100, 21);
            this.RegistNameInput.TabIndex = 1;
            // 
            // RegistPassword
            // 
            this.RegistPassword.AutoSize = true;
            this.RegistPassword.Location = new System.Drawing.Point(62, 86);
            this.RegistPassword.Name = "RegistPassword";
            this.RegistPassword.Size = new System.Drawing.Size(53, 12);
            this.RegistPassword.TabIndex = 2;
            this.RegistPassword.Text = "用户密码";
            // 
            // RegistPasswordInput
            // 
            this.RegistPasswordInput.Location = new System.Drawing.Point(136, 77);
            this.RegistPasswordInput.Name = "RegistPasswordInput";
            this.RegistPasswordInput.Size = new System.Drawing.Size(100, 21);
            this.RegistPasswordInput.TabIndex = 3;
            // 
            // RegistUserButton
            // 
            this.RegistUserButton.Location = new System.Drawing.Point(161, 165);
            this.RegistUserButton.Name = "RegistUserButton";
            this.RegistUserButton.Size = new System.Drawing.Size(75, 23);
            this.RegistUserButton.TabIndex = 4;
            this.RegistUserButton.Text = "注册";
            this.RegistUserButton.UseVisualStyleBackColor = true;
            this.RegistUserButton.Click += new System.EventHandler(this.RegistUserButton_Click);
            // 
            // ConfigPassword
            // 
            this.ConfigPassword.AutoSize = true;
            this.ConfigPassword.Location = new System.Drawing.Point(62, 129);
            this.ConfigPassword.Name = "ConfigPassword";
            this.ConfigPassword.Size = new System.Drawing.Size(53, 12);
            this.ConfigPassword.TabIndex = 5;
            this.ConfigPassword.Text = "确认密码";
            // 
            // ConfigPasswordInput
            // 
            this.ConfigPasswordInput.Location = new System.Drawing.Point(136, 120);
            this.ConfigPasswordInput.Name = "ConfigPasswordInput";
            this.ConfigPasswordInput.Size = new System.Drawing.Size(100, 21);
            this.ConfigPasswordInput.TabIndex = 6;
            // 
            // RegistLoginButton
            // 
            this.RegistLoginButton.Location = new System.Drawing.Point(52, 164);
            this.RegistLoginButton.Name = "RegistLoginButton";
            this.RegistLoginButton.Size = new System.Drawing.Size(75, 23);
            this.RegistLoginButton.TabIndex = 7;
            this.RegistLoginButton.Text = "返回登陆";
            this.RegistLoginButton.UseVisualStyleBackColor = true;
            this.RegistLoginButton.Click += new System.EventHandler(this.RegistLoginButton_Click);
            // 
            // RegistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.RegistLoginButton);
            this.Controls.Add(this.ConfigPasswordInput);
            this.Controls.Add(this.ConfigPassword);
            this.Controls.Add(this.RegistUserButton);
            this.Controls.Add(this.RegistPasswordInput);
            this.Controls.Add(this.RegistPassword);
            this.Controls.Add(this.RegistNameInput);
            this.Controls.Add(this.RigistName);
            this.Name = "RegistForm";
            this.Text = "RegistForm";
            this.Load += new System.EventHandler(this.RegistForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label RigistName;
        private System.Windows.Forms.TextBox RegistNameInput;
        private System.Windows.Forms.Label RegistPassword;
        private System.Windows.Forms.TextBox RegistPasswordInput;
        private System.Windows.Forms.Button RegistUserButton;
        private System.Windows.Forms.Label ConfigPassword;
        private System.Windows.Forms.TextBox ConfigPasswordInput;
        private System.Windows.Forms.Button RegistLoginButton;
    }
}