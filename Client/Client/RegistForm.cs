using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class RegistForm : Form
    {
        UesrInfo userInfo;
        public RegistForm()
        {
            userInfo = new UesrInfo();
            InitializeComponent();
        }

        private void RegistForm_Load(object sender, EventArgs e)
        {
            RegistPasswordInput.UseSystemPasswordChar = true;
            ConfigPasswordInput.UseSystemPasswordChar = true;
         
        }

        private void RegistUserButton_Click(object sender, EventArgs e)
        {
            try
            {
                userInfo.UserName = RegistNameInput.Text;
                userInfo.Password = RegistPasswordInput.Text;
                string configPassword = ConfigPasswordInput.Text;
                if (userInfo.UserName.Equals("") 
                    || userInfo.Password.Equals("") 
                    || configPassword.Equals("")) 
                {
                    MessageBox.Show("输入不能为空");   
                }
                else if (!userInfo.Password.Equals(configPassword))
                {
                    MessageBox.Show("密码和确认密码必须一致！");
                }
                else
                {
                    PostData Require = new PostData();
                    Require.InData = "action=regist" +
                                     "&&username=" + userInfo.UserName +
                                     "&&password=" + userInfo.Password;
                    string respose = Require.postPackge();
                    if (respose.Equals("SUCCESS"))
                    {
                        MessageBox.Show("注册成功！");
                        this.DialogResult = DialogResult.OK;
                        return;
                    }
                    else if (respose.Equals("EXIST"))
                    {
                        MessageBox.Show("用户名已经存在！");
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void RegistLoginButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
        }
    }
}
