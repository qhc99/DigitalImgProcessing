namespace opencv
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.figure1_label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.upButton = new System.Windows.Forms.Button();
            this.downButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.file = new System.Windows.Forms.ToolStripMenuItem();
            this.file_open = new System.Windows.Forms.ToolStripMenuItem();
            this.file_save_second = new System.Windows.Forms.ToolStripMenuItem();
            this.file_save_first = new System.Windows.Forms.ToolStripMenuItem();
            this.pre_process = new System.Windows.Forms.ToolStripMenuItem();
            this.pre_gray = new System.Windows.Forms.ToolStripMenuItem();
            this.add_noise = new System.Windows.Forms.ToolStripMenuItem();
            this.add_gaussian_noise = new System.Windows.Forms.ToolStripMenuItem();
            this.add_uni_noise = new System.Windows.Forms.ToolStripMenuItem();
            this.de_noise = new System.Windows.Forms.ToolStripMenuItem();
            this.median_blur = new System.Windows.Forms.ToolStripMenuItem();
            this.average_blur = new System.Windows.Forms.ToolStripMenuItem();
            this.gaussian_blur = new System.Windows.Forms.ToolStripMenuItem();
            this.fortify = new System.Windows.Forms.ToolStripMenuItem();
            this.edge = new System.Windows.Forms.ToolStripMenuItem();
            this.seg = new System.Windows.Forms.ToolStripMenuItem();
            this.DFT = new System.Windows.Forms.ToolStripMenuItem();
            this.wavelet = new System.Windows.Forms.ToolStripMenuItem();
            this.feature_detect = new System.Windows.Forms.ToolStripMenuItem();
            this.object_recognize = new System.Windows.Forms.ToolStripMenuItem();
            this.color_fortify = new System.Windows.Forms.ToolStripMenuItem();
            this.clearButton = new System.Windows.Forms.Button();
            this.leftButton = new System.Windows.Forms.Button();
            this.rightButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(68, 54);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(340, 340);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(467, 54);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(340, 340);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // figure1_label
            // 
            this.figure1_label.AutoSize = true;
            this.figure1_label.Location = new System.Drawing.Point(193, 29);
            this.figure1_label.Name = "figure1_label";
            this.figure1_label.Size = new System.Drawing.Size(90, 17);
            this.figure1_label.TabIndex = 5;
            this.figure1_label.Text = "第 0 行 第 0 列";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(592, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "第 0 行 第 0 列";
            // 
            // upButton
            // 
            this.upButton.Enabled = false;
            this.upButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.upButton.Location = new System.Drawing.Point(831, 179);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(45, 45);
            this.upButton.TabIndex = 7;
            this.upButton.Text = "↑";
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Click += new System.EventHandler(this.UpButton_Click);
            // 
            // downButton
            // 
            this.downButton.Enabled = false;
            this.downButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.downButton.Location = new System.Drawing.Point(831, 237);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(45, 45);
            this.downButton.TabIndex = 8;
            this.downButton.Text = "↓";
            this.downButton.UseVisualStyleBackColor = true;
            this.downButton.Click += new System.EventHandler(this.DownButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.file,
            this.pre_process,
            this.add_noise,
            this.de_noise,
            this.fortify,
            this.edge,
            this.seg,
            this.DFT,
            this.wavelet,
            this.feature_detect,
            this.object_recognize,
            this.color_fortify});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(910, 25);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // file
            // 
            this.file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.file_open,
            this.file_save_second,
            this.file_save_first});
            this.file.Name = "file";
            this.file.Size = new System.Drawing.Size(44, 21);
            this.file.Text = "文件";
            // 
            // file_open
            // 
            this.file_open.Name = "file_open";
            this.file_open.Size = new System.Drawing.Size(160, 22);
            this.file_open.Text = "打开";
            this.file_open.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // file_save_second
            // 
            this.file_save_second.Enabled = false;
            this.file_save_second.Name = "file_save_second";
            this.file_save_second.Size = new System.Drawing.Size(160, 22);
            this.file_save_second.Text = "保存第二张图片";
            this.file_save_second.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // file_save_first
            // 
            this.file_save_first.Enabled = false;
            this.file_save_first.Name = "file_save_first";
            this.file_save_first.Size = new System.Drawing.Size(160, 22);
            this.file_save_first.Text = "保存第一张图片";
            this.file_save_first.Click += new System.EventHandler(this.SaveButton_first_Click);
            // 
            // pre_process
            // 
            this.pre_process.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pre_gray});
            this.pre_process.Enabled = false;
            this.pre_process.Name = "pre_process";
            this.pre_process.Size = new System.Drawing.Size(68, 21);
            this.pre_process.Text = "格式转换";
            // 
            // pre_gray
            // 
            this.pre_gray.Name = "pre_gray";
            this.pre_gray.Size = new System.Drawing.Size(112, 22);
            this.pre_gray.Text = "灰度化";
            this.pre_gray.Click += new System.EventHandler(this.GrayButton_Click);
            // 
            // add_noise
            // 
            this.add_noise.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.add_gaussian_noise,
            this.add_uni_noise});
            this.add_noise.Enabled = false;
            this.add_noise.Name = "add_noise";
            this.add_noise.Size = new System.Drawing.Size(56, 21);
            this.add_noise.Text = "加噪声";
            // 
            // add_gaussian_noise
            // 
            this.add_gaussian_noise.Name = "add_gaussian_noise";
            this.add_gaussian_noise.Size = new System.Drawing.Size(124, 22);
            this.add_gaussian_noise.Text = "高斯噪声";
            this.add_gaussian_noise.Click += new System.EventHandler(this.AddGaussianNoise_Click);
            // 
            // add_uni_noise
            // 
            this.add_uni_noise.Name = "add_uni_noise";
            this.add_uni_noise.Size = new System.Drawing.Size(124, 22);
            this.add_uni_noise.Text = "均匀噪声";
            this.add_uni_noise.Click += new System.EventHandler(this.AddUniformNoise_Click);
            // 
            // de_noise
            // 
            this.de_noise.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.median_blur,
            this.average_blur,
            this.gaussian_blur});
            this.de_noise.Enabled = false;
            this.de_noise.Name = "de_noise";
            this.de_noise.Size = new System.Drawing.Size(56, 21);
            this.de_noise.Text = "去噪声";
            // 
            // median_blur
            // 
            this.median_blur.Name = "median_blur";
            this.median_blur.Size = new System.Drawing.Size(124, 22);
            this.median_blur.Text = "中值滤波";
            this.median_blur.Click += new System.EventHandler(this.MedianBlur_Click);
            // 
            // average_blur
            // 
            this.average_blur.Name = "average_blur";
            this.average_blur.Size = new System.Drawing.Size(124, 22);
            this.average_blur.Text = "均值滤波";
            this.average_blur.Click += new System.EventHandler(this.AverageBlur_Click);
            // 
            // gaussian_blur
            // 
            this.gaussian_blur.Name = "gaussian_blur";
            this.gaussian_blur.Size = new System.Drawing.Size(124, 22);
            this.gaussian_blur.Text = "高斯滤波";
            // 
            // fortify
            // 
            this.fortify.Enabled = false;
            this.fortify.Name = "fortify";
            this.fortify.Size = new System.Drawing.Size(44, 21);
            this.fortify.Text = "增强";
            // 
            // edge
            // 
            this.edge.Enabled = false;
            this.edge.Name = "edge";
            this.edge.Size = new System.Drawing.Size(68, 21);
            this.edge.Text = "边缘检测";
            // 
            // seg
            // 
            this.seg.Enabled = false;
            this.seg.Name = "seg";
            this.seg.Size = new System.Drawing.Size(44, 21);
            this.seg.Text = "分割";
            // 
            // DFT
            // 
            this.DFT.Enabled = false;
            this.DFT.Name = "DFT";
            this.DFT.Size = new System.Drawing.Size(80, 21);
            this.DFT.Text = "傅里叶变换";
            // 
            // wavelet
            // 
            this.wavelet.Enabled = false;
            this.wavelet.Name = "wavelet";
            this.wavelet.Size = new System.Drawing.Size(68, 21);
            this.wavelet.Text = "小波变换";
            // 
            // feature_detect
            // 
            this.feature_detect.Enabled = false;
            this.feature_detect.Name = "feature_detect";
            this.feature_detect.Size = new System.Drawing.Size(68, 21);
            this.feature_detect.Text = "特征提取";
            // 
            // object_recognize
            // 
            this.object_recognize.Enabled = false;
            this.object_recognize.Name = "object_recognize";
            this.object_recognize.Size = new System.Drawing.Size(68, 21);
            this.object_recognize.Text = "目标识别";
            // 
            // color_fortify
            // 
            this.color_fortify.Enabled = false;
            this.color_fortify.Name = "color_fortify";
            this.color_fortify.Size = new System.Drawing.Size(68, 21);
            this.color_fortify.Text = "彩色处理";
            // 
            // clearButton
            // 
            this.clearButton.Enabled = false;
            this.clearButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.clearButton.Location = new System.Drawing.Point(384, 400);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(102, 38);
            this.clearButton.TabIndex = 13;
            this.clearButton.Text = "清除此行图片";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // leftButton
            // 
            this.leftButton.Enabled = false;
            this.leftButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.leftButton.Location = new System.Drawing.Point(216, 400);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(45, 45);
            this.leftButton.TabIndex = 14;
            this.leftButton.Text = "←";
            this.leftButton.UseVisualStyleBackColor = true;
            this.leftButton.Click += new System.EventHandler(this.Left_Click);
            // 
            // rightButton
            // 
            this.rightButton.Enabled = false;
            this.rightButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rightButton.Location = new System.Drawing.Point(615, 398);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(45, 45);
            this.rightButton.TabIndex = 15;
            this.rightButton.Text = "→";
            this.rightButton.UseVisualStyleBackColor = true;
            this.rightButton.Click += new System.EventHandler(this.Right_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 450);
            this.Controls.Add(this.rightButton);
            this.Controls.Add(this.leftButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.downButton);
            this.Controls.Add(this.upButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.figure1_label);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "图像处理工具箱";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label figure1_label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem file;
        private System.Windows.Forms.ToolStripMenuItem file_open;
        private System.Windows.Forms.ToolStripMenuItem file_save_second;
        private System.Windows.Forms.ToolStripMenuItem file_save_first;
        private System.Windows.Forms.ToolStripMenuItem add_noise;
        private System.Windows.Forms.ToolStripMenuItem de_noise;
        private System.Windows.Forms.ToolStripMenuItem fortify;
        private System.Windows.Forms.ToolStripMenuItem edge;
        private System.Windows.Forms.ToolStripMenuItem seg;
        private System.Windows.Forms.ToolStripMenuItem DFT;
        private System.Windows.Forms.ToolStripMenuItem pre_process;
        private System.Windows.Forms.ToolStripMenuItem pre_gray;
        private System.Windows.Forms.ToolStripMenuItem add_gaussian_noise;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.ToolStripMenuItem wavelet;
        private System.Windows.Forms.ToolStripMenuItem feature_detect;
        private System.Windows.Forms.ToolStripMenuItem object_recognize;
        private System.Windows.Forms.ToolStripMenuItem color_fortify;
        private System.Windows.Forms.ToolStripMenuItem add_uni_noise;
        private System.Windows.Forms.ToolStripMenuItem median_blur;
        private System.Windows.Forms.ToolStripMenuItem average_blur;
        private System.Windows.Forms.ToolStripMenuItem gaussian_blur;
        private System.Windows.Forms.Button leftButton;
        private System.Windows.Forms.Button rightButton;
    }
}

