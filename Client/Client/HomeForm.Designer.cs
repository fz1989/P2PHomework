namespace Client
{
    partial class HomeForm
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
            this.UploadLabel = new System.Windows.Forms.Label();
            this.UploadGridView = new System.Windows.Forms.DataGridView();
            this.ResourceLabel = new System.Windows.Forms.Label();
            this.CancelShareButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ShareButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.SearchInput = new System.Windows.Forms.TextBox();
            this.ResourceGridView = new System.Windows.Forms.DataGridView();
            this.DownloadButton = new System.Windows.Forms.Button();
            this.uploadFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceFileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uploadUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.onLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.UploadGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResourceGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // UploadLabel
            // 
            this.UploadLabel.AutoSize = true;
            this.UploadLabel.Location = new System.Drawing.Point(320, 23);
            this.UploadLabel.Name = "UploadLabel";
            this.UploadLabel.Size = new System.Drawing.Size(53, 12);
            this.UploadLabel.TabIndex = 1;
            this.UploadLabel.Text = "上传列表";
            // 
            // UploadGridView
            // 
            this.UploadGridView.AllowUserToAddRows = false;
            this.UploadGridView.AllowUserToDeleteRows = false;
            this.UploadGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.UploadGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UploadGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.uploadFileName});
            this.UploadGridView.Location = new System.Drawing.Point(322, 45);
            this.UploadGridView.Name = "UploadGridView";
            this.UploadGridView.ReadOnly = true;
            this.UploadGridView.RowTemplate.Height = 23;
            this.UploadGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.UploadGridView.Size = new System.Drawing.Size(185, 150);
            this.UploadGridView.TabIndex = 2;
            // 
            // ResourceLabel
            // 
            this.ResourceLabel.AutoSize = true;
            this.ResourceLabel.Location = new System.Drawing.Point(13, 18);
            this.ResourceLabel.Name = "ResourceLabel";
            this.ResourceLabel.Size = new System.Drawing.Size(53, 12);
            this.ResourceLabel.TabIndex = 3;
            this.ResourceLabel.Text = "搜索资源";
            // 
            // CancelShareButton
            // 
            this.CancelShareButton.Location = new System.Drawing.Point(432, 210);
            this.CancelShareButton.Name = "CancelShareButton";
            this.CancelShareButton.Size = new System.Drawing.Size(75, 23);
            this.CancelShareButton.TabIndex = 4;
            this.CancelShareButton.Text = "取消分享";
            this.CancelShareButton.UseVisualStyleBackColor = true;
            this.CancelShareButton.Click += new System.EventHandler(this.CancelShareButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // ShareButton
            // 
            this.ShareButton.Location = new System.Drawing.Point(322, 210);
            this.ShareButton.Name = "ShareButton";
            this.ShareButton.Size = new System.Drawing.Size(75, 23);
            this.ShareButton.TabIndex = 5;
            this.ShareButton.Text = "分享文件";
            this.ShareButton.UseVisualStyleBackColor = true;
            this.ShareButton.Click += new System.EventHandler(this.ShareButton_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(227, 13);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 23);
            this.SearchButton.TabIndex = 6;
            this.SearchButton.Text = "搜索";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // SearchInput
            // 
            this.SearchInput.Location = new System.Drawing.Point(72, 14);
            this.SearchInput.Name = "SearchInput";
            this.SearchInput.Size = new System.Drawing.Size(149, 21);
            this.SearchInput.TabIndex = 7;
            // 
            // ResourceGridView
            // 
            this.ResourceGridView.AllowUserToAddRows = false;
            this.ResourceGridView.AllowUserToDeleteRows = false;
            this.ResourceGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResourceGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.resourceFileName,
            this.resourceFileSize,
            this.uploadUsername,
            this.onLine});
            this.ResourceGridView.Location = new System.Drawing.Point(12, 45);
            this.ResourceGridView.Name = "ResourceGridView";
            this.ResourceGridView.ReadOnly = true;
            this.ResourceGridView.RowTemplate.Height = 23;
            this.ResourceGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ResourceGridView.Size = new System.Drawing.Size(290, 150);
            this.ResourceGridView.TabIndex = 8;
            // 
            // DownloadButton
            // 
            this.DownloadButton.Location = new System.Drawing.Point(12, 209);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(75, 23);
            this.DownloadButton.TabIndex = 9;
            this.DownloadButton.Text = "下载文件";
            this.DownloadButton.UseVisualStyleBackColor = true;
            this.DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // uploadFileName
            // 
            this.uploadFileName.HeaderText = "文件名";
            this.uploadFileName.Name = "uploadFileName";
            this.uploadFileName.ReadOnly = true;
            // 
            // resourceFileName
            // 
            this.resourceFileName.HeaderText = "文件名";
            this.resourceFileName.Name = "resourceFileName";
            this.resourceFileName.ReadOnly = true;
            // 
            // resourceFileSize
            // 
            this.resourceFileSize.HeaderText = "文件大小";
            this.resourceFileSize.Name = "resourceFileSize";
            this.resourceFileSize.ReadOnly = true;
            // 
            // uploadUsername
            // 
            this.uploadUsername.HeaderText = "用户名";
            this.uploadUsername.Name = "uploadUsername";
            this.uploadUsername.ReadOnly = true;
            // 
            // onLine
            // 
            this.onLine.HeaderText = "在线状态";
            this.onLine.Name = "onLine";
            this.onLine.ReadOnly = true;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 293);
            this.Controls.Add(this.DownloadButton);
            this.Controls.Add(this.ResourceGridView);
            this.Controls.Add(this.SearchInput);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.ShareButton);
            this.Controls.Add(this.CancelShareButton);
            this.Controls.Add(this.ResourceLabel);
            this.Controls.Add(this.UploadGridView);
            this.Controls.Add(this.UploadLabel);
            this.Name = "HomeForm";
            this.Text = "HomeForm";
            this.Load += new System.EventHandler(this.HomeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UploadGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResourceGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UploadLabel;
        private System.Windows.Forms.DataGridView UploadGridView;
        private System.Windows.Forms.Label ResourceLabel;
        private System.Windows.Forms.Button CancelShareButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button ShareButton;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.TextBox SearchInput;
        private System.Windows.Forms.DataGridView ResourceGridView;
        private System.Windows.Forms.Button DownloadButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn uploadFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceFileSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn uploadUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn onLine;
    }
}