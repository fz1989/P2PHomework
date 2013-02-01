using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Client
{
    public partial class HomeForm : Form
    {
        public UesrInfo userinfo;
        Thread newListenThread;
        public HomeForm()
        {
            userinfo = new UesrInfo();
            InitializeComponent();
        }

        private void ListenThread()
        {
            Listen newListen = new Listen();
            newListen.setUserInfo(userinfo);
            newListen.BeginListen();
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            getUpload();
            openFileDialog = new OpenFileDialog();
            newListenThread = new Thread(ListenThread);
            newListenThread.Start();
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
            int len = tmp.Length - 1;
            string[,] info = new string[len, 1];
            UploadGridView.ColumnCount = 1;
            UploadGridView.RowCount = len;
            for (int i = 0; i < UploadGridView.RowCount; i++)
            {
                string[] buff = tmp[i].Split('&');
                for (int j = 0; j < UploadGridView.ColumnCount; j++)
                {
                    info[i, j] = buff[j];
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
            int len = tmp.Length - 1;
            string[,] info = new string[len, 4];
            ResourceGridView.ColumnCount = 4;
            ResourceGridView.RowCount = len;
            for (int i = 0; i < ResourceGridView.RowCount; i++)
            {
                string[] buff = tmp[i].Split('&');
                for (int j = 0; j < ResourceGridView.ColumnCount; j++)
                {
                    info[i, j] = buff[j];
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
                byte[] bytes = Encoding.Default.GetBytes(filepath);
                filepath = Convert.ToBase64String(bytes);
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

        private void GetDownLoadThread()
        {
            if (ResourceGridView.SelectedRows.Count != 0)
            {
                string requierFilename = ResourceGridView.CurrentRow.Cells[0].Value.ToString();
                string requireUser = ResourceGridView.CurrentRow.Cells[2].Value.ToString();
                PostData Require = new PostData();
                Require.InData = "action=download" +
                                "&&username=" + userinfo.UserName +
                                "&&password=" + userinfo.Password +
                                "&&requireuser=" + requireUser +
                                "&&filename=" + requierFilename;
                string response = Require.postPackge();
                string[] tmp = response.Split('&');
                GetFile getFile = new GetFile();
                getFile.IpAddress = tmp[0];
                getFile.Port = tmp[1];
                getFile.FileName = tmp[2];
                getFile.FilePath = tmp[3];
                byte[] outputb = Convert.FromBase64String(getFile.FilePath);
                getFile.FilePath = Encoding.Default.GetString(outputb);
                MessageBox.Show(getFile.FilePath);
                if (getFile.DownloadFile())
                {
                    MessageBox.Show(requierFilename + "已经下载完成！");
                }
                else
                {
                    MessageBox.Show(requierFilename + "下载失败！");
                }
            }
        }
        private void DownloadButton_Click(object sender, EventArgs e)
        {
            Thread newDownLoadThread = new Thread(GetDownLoadThread);
            newDownLoadThread.Start();
        }

        private void HomeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            PostData Require = new PostData();
            Require.InData = "action=logoff" +
                            "&&username=" + userinfo.UserName +
                            "&&password=" + userinfo.Password;
            string response = Require.postPackge();
            if (response.Equals("SUCCESS"))
            {
                MessageBox.Show("下线成功！");
                return;
            }
            newListenThread.Abort();
        }

    }
}
