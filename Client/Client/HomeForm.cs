using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Client
{
    public partial class HomeForm : Form
    {
        public UesrInfo userinfo;
        public HomeForm()
        {
            userinfo = new UesrInfo();
            InitializeComponent();
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            getUpload();
            openFileDialog = new OpenFileDialog();
        }

        private void getUpload()
        {
            PostData Require = new PostData();
            Require.InData = "action=upload" + 
                            "&&username=" + userinfo.UserName + 
                            "&&password=" + userinfo.Password;
            string response = Require.postPackge();
            //ResourceGridView.Dispose();
            string[] tmp = response.Split('#');
            int len = tmp.Length;
            string[,] info = new string[len, 1];
            info[0, 0] = "文件名";
            UploadGridView.ColumnCount = 1;
            UploadGridView.RowCount = len;
            for (int i = 0; i + 1 < UploadGridView.RowCount; i++)
            {
                string[] buff = tmp[i].Split('&');
                for (int j = 0; j < UploadGridView.ColumnCount; j++)
                {
                    info[i + 1, j] = buff[j];
                }
            }
            for (int i = 0; i < UploadGridView.RowCount; i++)
            {
                for (int j = 0; j < UploadGridView.ColumnCount; j++)
                {
                    UploadGridView.Rows[i].Cells[j].Value = info[i, j];
                }
            }
            UploadGridView.Show();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            PostData Require = new PostData();
            Require.InData = "action=search" + 
                            "&&username=" + userinfo.UserName + 
                            "&&password=" + userinfo.Password +
                            "&&filename=" + SearchInput.Text;
            string response = Require.postPackge();
            //ResourceGridView.Dispose();
            string[] tmp = response.Split('#');
            int len = tmp.Length;
            string[,] info = new string[len, 4];
            info[0, 0] = "文件名";
            info[0, 1] = "文件大小";
            info[0, 2] = "用户名";
            info[0, 3] = "在线状态";
            ResourceGridView.ColumnCount = 4;
            ResourceGridView.RowCount = len;
            for (int i = 0; i + 1 < ResourceGridView.RowCount; i++)
            {
                string[] buff = tmp[i].Split('&');
                for (int j = 0; j < ResourceGridView.ColumnCount; j++)
                {
                    info[i + 1, j] = buff[j];
                }
            }
            for (int i = 0; i < ResourceGridView.RowCount; i++)
            {
                for (int j = 0; j < ResourceGridView.ColumnCount; j++)
                {
                    ResourceGridView.Rows[i].Cells[j].Value = info[i, j];
                }
            }
            ResourceGridView.Show();
        }

        private void CancelShareButton_Click(object sender, EventArgs e)
        {
            if (UploadGridView.SelectedRows.Count != 0)
            {
                string filename = UploadGridView.CurrentRow.Cells[0].Value.ToString();
                PostData Require = new PostData();
                Require.InData = "action=canclesharefile" +
                                "&&username=" + userinfo.UserName +
                                "&&password=" + userinfo.Password +
                                "&&filename=" + filename;
                string response = Require.postPackge();
                if (response.Equals("SUCCESS"))
                {
                    MessageBox.Show("取消分享" + filename + "成功！");
                    getUpload();
                    return;
                }
            }
        }

        private void ShareButton_Click(object sender, EventArgs e)
        {
            DialogResult openFileResult = openFileDialog.ShowDialog();
            if (openFileResult == DialogResult.OK)
            {
                string filepath = openFileDialog.FileName;
                FileInfo fileinfo = new FileInfo(openFileDialog.FileName);
                string filesize = fileinfo.Length / 1024 + "KB";
                string filename = openFileDialog.SafeFileName;
                PostData Require = new PostData();
                Require.InData = "action=sharefile" +
                                "&&username=" + userinfo.UserName +
                                "&&password=" + userinfo.Password +
                                "&&filename=" + filename +
                                "&&filesize=" + filesize +
                                "&&filepath=" + filepath;
                string response = Require.postPackge();
                if (response.Equals("SUCCESS"))
                {
                    MessageBox.Show("分享成功！");
                    getUpload();
                    return;
                }
                if (response.Equals("EXIST"))
                {
                    MessageBox.Show("文件已经存在！");
                    return;
                }
            }
        }

    }
}
