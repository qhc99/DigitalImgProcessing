namespace opencv
{
    partial class VideoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openCameraButton = new System.Windows.Forms.Button();
            this.closeCameraButton = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 480);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // openCameraButton
            // 
            this.openCameraButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.openCameraButton.Location = new System.Drawing.Point(657, 334);
            this.openCameraButton.Name = "openCameraButton";
            this.openCameraButton.Size = new System.Drawing.Size(87, 34);
            this.openCameraButton.TabIndex = 1;
            this.openCameraButton.Text = "开启摄像头";
            this.openCameraButton.UseVisualStyleBackColor = true;
            this.openCameraButton.Click += new System.EventHandler(this.openCameraButton_Click);
            // 
            // closeCameraButton
            // 
            this.closeCameraButton.Enabled = false;
            this.closeCameraButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.closeCameraButton.Location = new System.Drawing.Point(657, 374);
            this.closeCameraButton.Name = "closeCameraButton";
            this.closeCameraButton.Size = new System.Drawing.Size(87, 34);
            this.closeCameraButton.TabIndex = 2;
            this.closeCameraButton.Text = "关闭摄像头";
            this.closeCameraButton.UseVisualStyleBackColor = true;
            this.closeCameraButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "人脸检测",
            "人眼检测",
            "证件照检测"});
            this.checkedListBox1.Location = new System.Drawing.Point(657, 270);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(101, 58);
            this.checkedListBox1.TabIndex = 3;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileButton
            // 
            this.openFileButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.openFileButton.Location = new System.Drawing.Point(657, 414);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(87, 35);
            this.openFileButton.TabIndex = 4;
            this.openFileButton.Text = "打开文件";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.openVideoFile_Click);
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.saveButton.Location = new System.Drawing.Point(658, 455);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(86, 32);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "保存处理×";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // VideoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 499);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.openFileButton);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.closeCameraButton);
            this.Controls.Add(this.openCameraButton);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "VideoForm";
            this.Text = "视频处理";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CameraPopUp_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button openCameraButton;
        private System.Windows.Forms.Button closeCameraButton;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button saveButton;
    }
}