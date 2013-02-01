using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace Client
{
    public partial class LoginForm : Form
    {
        public UesrInfo userinfo;
        public LoginForm()
        {
            userinfo = new UesrInfo();
            InitializeComponent();
        }

        private void RegistButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                userinfo.UserName = userNameInput.Text;
                userinfo.Password = PasswordInput.Text;
                IPHostEntry ipe = Dns.GetHostEntry(Dns.GetHostName());
                string ipaddress = "219.245.98.140";//here we need modify
                string port = PortInput.Text;
                userinfo.Port = port;
                userinfo.IpAddress = ipaddress;
                PostData Require = new PostData();
                Require.InData = "action=login" +
                                "&&username=" + userinfo.UserName +
                                "&&password=" + userinfo.Password +
                                "&&ipaddress=" + ipaddress +
                                "&&port=" + port;
                string response = Require.postPackge();
                if (response.Equals("SUCCESS"))
                {
                    MessageBox.Show("登录成功！");
                    this.DialogResult = DialogResult.OK;
                    return;
                }
                if (response.Equals("WRONG") || response.Equals("NOTEXIST"))
                {
                    MessageBox.Show("错误的用户名或密码！");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
                                   
            
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            PasswordInput.UseSystemPasswordChar = true;
        }

    }
}
