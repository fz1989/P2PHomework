using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Client
{
    class UesrInfo{
        string username, password;
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; } 
        }

    }
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //注册事件的处理
            while (true)
            {
                //生成loginForm
                LoginForm newLoginForm = new LoginForm();
                DialogResult newLoginFormResult = newLoginForm.ShowDialog();
                
                if (newLoginFormResult == DialogResult.OK)
                {
                    newLoginForm.Close();
                    newLoginForm.Dispose();
                    HomeForm newHomeFrom = new HomeForm();
                    Application.Run(newHomeFrom);
                    break;
                }
                //进入注册界面
                if (newLoginFormResult == DialogResult.Abort)
                {
                    newLoginForm.Close();
                    newLoginForm.Dispose();
                    RegistForm newRegistForm = new RegistForm();
                    DialogResult newRegistFormResult = newRegistForm.ShowDialog();
                    //注册成功转到登录界面
                    if (newRegistFormResult == DialogResult.OK)
                    {
                        newRegistForm.Close();
                        newRegistForm.Dispose();
                        continue;
                    }
                    //返回登录界面
                    if (newRegistFormResult == DialogResult.Retry)
                    {
                        continue;
                    }
                    break;
                }
                //点击退出
                break;
            }
        }
    }
}
