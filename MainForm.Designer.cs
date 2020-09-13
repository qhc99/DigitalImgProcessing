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
            this.components = new System.ComponentModel.Container();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.leftPictureBox = new System.Windows.Forms.PictureBox();
            this.pictureRightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rightClickSave = new System.Windows.Forms.ToolStripMenuItem();
            this.rightPictureBox = new System.Windows.Forms.PictureBox();
            this.right_picture_label = new System.Windows.Forms.Label();
            this.left_picture_label = new System.Windows.Forms.Label();
            this.upButton = new System.Windows.Forms.Button();
            this.downButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.file = new System.Windows.Forms.ToolStripMenuItem();
            this.imagesListButton = new System.Windows.Forms.ToolStripMenuItem();
            this.file_open = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSecondFileButton = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFirstFileButton = new System.Windows.Forms.ToolStripMenuItem();
            this.clearButton = new System.Windows.Forms.ToolStripMenuItem();
            this.reverseButton = new System.Windows.Forms.ToolStripMenuItem();
            this.overwriteButton = new System.Windows.Forms.ToolStripMenuItem();
            this.preProcessButton = new System.Windows.Forms.ToolStripMenuItem();
            this.grayButton = new System.Windows.Forms.ToolStripMenuItem();
            this.addNoiseButton = new System.Windows.Forms.ToolStripMenuItem();
            this.addGaussianNoise = new System.Windows.Forms.ToolStripMenuItem();
            this.addUniNoise = new System.Windows.Forms.ToolStripMenuItem();
            this.addImpulseNoise = new System.Windows.Forms.ToolStripMenuItem();
            this.fortifyButton = new System.Windows.Forms.ToolStripMenuItem();
            this.blurButton = new System.Windows.Forms.ToolStripMenuItem();
            this.averageFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.medianFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.gaussianFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.barUniformButton = new System.Windows.Forms.ToolStripMenuItem();
            this.edgeButton = new System.Windows.Forms.ToolStripMenuItem();
            this.segButton = new System.Windows.Forms.ToolStripMenuItem();
            this.DFTButton = new System.Windows.Forms.ToolStripMenuItem();
            this.waveletButton = new System.Windows.Forms.ToolStripMenuItem();
            this.featureDetectButton = new System.Windows.Forms.ToolStripMenuItem();
            this.objectRecognizeButton = new System.Windows.Forms.ToolStripMenuItem();
            this.colorFortifyButton = new System.Windows.Forms.ToolStripMenuItem();
            this.shortCutHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.leftPictureSize = new System.Windows.Forms.Label();
            this.rightPictureSize = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.leftPictureBox)).BeginInit();
            this.pictureRightClickMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rightPictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // leftPictureBox
            // 
            this.leftPictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.leftPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.leftPictureBox.ContextMenuStrip = this.pictureRightClickMenu;
            this.leftPictureBox.Location = new System.Drawing.Point(12, 61);
            this.leftPictureBox.Name = "leftPictureBox";
            this.leftPictureBox.Size = new System.Drawing.Size(360, 360);
            this.leftPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.leftPictureBox.TabIndex = 2;
            this.leftPictureBox.TabStop = false;
            // 
            // pictureRightClickMenu
            // 
            this.pictureRightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rightClickSave});
            this.pictureRightClickMenu.Name = "pictureRightClickMenu";
            this.pictureRightClickMenu.Size = new System.Drawing.Size(101, 26);
            // 
            // rightClickSave
            // 
            this.rightClickSave.Name = "rightClickSave";
            this.rightClickSave.Size = new System.Drawing.Size(100, 22);
            this.rightClickSave.Text = "保存";
            this.rightClickSave.Click += new System.EventHandler(this.RightClickSave_Click);
            // 
            // rightPictureBox
            // 
            this.rightPictureBox.BackColor = System.Drawing.Color.SpringGreen;
            this.rightPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.rightPictureBox.ContextMenuStrip = this.pictureRightClickMenu;
            this.rightPictureBox.Location = new System.Drawing.Point(378, 56);
            this.rightPictureBox.Name = "rightPictureBox";
            this.rightPictureBox.Size = new System.Drawing.Size(370, 370);
            this.rightPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.rightPictureBox.TabIndex = 2;
            this.rightPictureBox.TabStop = false;
            // 
            // right_picture_label
            // 
            this.right_picture_label.AutoSize = true;
            this.right_picture_label.Location = new System.Drawing.Point(518, 36);
            this.right_picture_label.Name = "right_picture_label";
            this.right_picture_label.Size = new System.Drawing.Size(90, 17);
            this.right_picture_label.TabIndex = 5;
            this.right_picture_label.Text = "第 0 行 第 0 列";
            // 
            // left_picture_label
            // 
            this.left_picture_label.AutoSize = true;
            this.left_picture_label.Location = new System.Drawing.Point(147, 36);
            this.left_picture_label.Name = "left_picture_label";
            this.left_picture_label.Size = new System.Drawing.Size(90, 17);
            this.left_picture_label.TabIndex = 6;
            this.left_picture_label.Text = "第 0 行 第 0 列";
            // 
            // upButton
            // 
            this.upButton.Enabled = false;
            this.upButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.upButton.Location = new System.Drawing.Point(754, 148);
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
            this.downButton.Location = new System.Drawing.Point(754, 256);
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
            this.preProcessButton,
            this.addNoiseButton,
            this.fortifyButton,
            this.edgeButton,
            this.segButton,
            this.DFTButton,
            this.waveletButton,
            this.featureDetectButton,
            this.objectRecognizeButton,
            this.colorFortifyButton,
            this.shortCutHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(811, 25);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // file
            // 
            this.file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imagesListButton,
            this.file_open,
            this.saveSecondFileButton,
            this.saveFirstFileButton,
            this.clearButton,
            this.reverseButton,
            this.overwriteButton});
            this.file.Name = "file";
            this.file.Size = new System.Drawing.Size(44, 21);
            this.file.Text = "文件";
            // 
            // imagesListButton
            // 
            this.imagesListButton.Enabled = false;
            this.imagesListButton.Name = "imagesListButton";
            this.imagesListButton.Size = new System.Drawing.Size(172, 22);
            this.imagesListButton.Text = "查看当前图片序列";
            this.imagesListButton.Click += new System.EventHandler(this.ImagesListButton_Click);
            // 
            // file_open
            // 
            this.file_open.Name = "file_open";
            this.file_open.Size = new System.Drawing.Size(172, 22);
            this.file_open.Text = "打开";
            this.file_open.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // saveSecondFileButton
            // 
            this.saveSecondFileButton.Enabled = false;
            this.saveSecondFileButton.Name = "saveSecondFileButton";
            this.saveSecondFileButton.Size = new System.Drawing.Size(172, 22);
            this.saveSecondFileButton.Text = "保存第二张图片";
            this.saveSecondFileButton.Click += new System.EventHandler(this.SaveSecondButton_Click);
            // 
            // saveFirstFileButton
            // 
            this.saveFirstFileButton.Enabled = false;
            this.saveFirstFileButton.Name = "saveFirstFileButton";
            this.saveFirstFileButton.Size = new System.Drawing.Size(172, 22);
            this.saveFirstFileButton.Text = "保存第一张图片";
            this.saveFirstFileButton.Click += new System.EventHandler(this.SaveFirstButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Enabled = false;
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(172, 22);
            this.clearButton.Text = "清除此行图片";
            this.clearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // reverseButton
            // 
            this.reverseButton.Enabled = false;
            this.reverseButton.Name = "reverseButton";
            this.reverseButton.Size = new System.Drawing.Size(172, 22);
            this.reverseButton.Text = "撤销处理";
            this.reverseButton.Click += new System.EventHandler(this.ReverseButton_Click);
            // 
            // overwriteButton
            // 
            this.overwriteButton.Enabled = false;
            this.overwriteButton.Name = "overwriteButton";
            this.overwriteButton.Size = new System.Drawing.Size(172, 22);
            this.overwriteButton.Text = "覆盖上一张图片";
            this.overwriteButton.Click += new System.EventHandler(this.OverwriteButton_Click);
            // 
            // preProcessButton
            // 
            this.preProcessButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.grayButton});
            this.preProcessButton.Enabled = false;
            this.preProcessButton.Name = "preProcessButton";
            this.preProcessButton.Size = new System.Drawing.Size(68, 21);
            this.preProcessButton.Text = "格式转换";
            // 
            // grayButton
            // 
            this.grayButton.Name = "grayButton";
            this.grayButton.Size = new System.Drawing.Size(112, 22);
            this.grayButton.Text = "灰度化";
            this.grayButton.Click += new System.EventHandler(this.GrayButton_Click);
            // 
            // addNoiseButton
            // 
            this.addNoiseButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addGaussianNoise,
            this.addUniNoise,
            this.addImpulseNoise});
            this.addNoiseButton.Enabled = false;
            this.addNoiseButton.Name = "addNoiseButton";
            this.addNoiseButton.Size = new System.Drawing.Size(56, 21);
            this.addNoiseButton.Text = "加噪声";
            // 
            // addGaussianNoise
            // 
            this.addGaussianNoise.Name = "addGaussianNoise";
            this.addGaussianNoise.Size = new System.Drawing.Size(124, 22);
            this.addGaussianNoise.Text = "高斯噪声";
            this.addGaussianNoise.Click += new System.EventHandler(this.AddGaussianNoise_Click);
            // 
            // addUniNoise
            // 
            this.addUniNoise.Name = "addUniNoise";
            this.addUniNoise.Size = new System.Drawing.Size(124, 22);
            this.addUniNoise.Text = "均匀噪声";
            this.addUniNoise.Click += new System.EventHandler(this.AddUniformNoise_Click);
            // 
            // addImpulseNoise
            // 
            this.addImpulseNoise.Name = "addImpulseNoise";
            this.addImpulseNoise.Size = new System.Drawing.Size(124, 22);
            this.addImpulseNoise.Text = "脉冲噪声";
            this.addImpulseNoise.Click += new System.EventHandler(this.AddImpulseNoise_Click);
            // 
            // fortifyButton
            // 
            this.fortifyButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blurButton,
            this.barUniformButton});
            this.fortifyButton.Enabled = false;
            this.fortifyButton.Name = "fortifyButton";
            this.fortifyButton.Size = new System.Drawing.Size(44, 21);
            this.fortifyButton.Text = "增强";
            // 
            // blurButton
            // 
            this.blurButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.averageFilter,
            this.medianFilter,
            this.gaussianFilter});
            this.blurButton.Name = "blurButton";
            this.blurButton.Size = new System.Drawing.Size(148, 22);
            this.blurButton.Text = "平滑";
            // 
            // averageFilter
            // 
            this.averageFilter.Name = "averageFilter";
            this.averageFilter.Size = new System.Drawing.Size(124, 22);
            this.averageFilter.Text = "均值滤波";
            this.averageFilter.Click += new System.EventHandler(this.AverageBlur_Click);
            // 
            // medianFilter
            // 
            this.medianFilter.Name = "medianFilter";
            this.medianFilter.Size = new System.Drawing.Size(124, 22);
            this.medianFilter.Text = "中值滤波";
            this.medianFilter.Click += new System.EventHandler(this.MedianBlur_Click);
            // 
            // gaussianFilter
            // 
            this.gaussianFilter.Name = "gaussianFilter";
            this.gaussianFilter.Size = new System.Drawing.Size(124, 22);
            this.gaussianFilter.Text = "高斯滤波";
            this.gaussianFilter.Click += new System.EventHandler(this.GaussianBlur_Click);
            // 
            // barUniformButton
            // 
            this.barUniformButton.Name = "barUniformButton";
            this.barUniformButton.Size = new System.Drawing.Size(148, 22);
            this.barUniformButton.Text = "直方图均匀化";
            this.barUniformButton.Click += new System.EventHandler(this.BarUniformButton_Click);
            // 
            // edgeButton
            // 
            this.edgeButton.Enabled = false;
            this.edgeButton.Name = "edgeButton";
            this.edgeButton.Size = new System.Drawing.Size(68, 21);
            this.edgeButton.Text = "边缘检测";
            // 
            // segButton
            // 
            this.segButton.Enabled = false;
            this.segButton.Name = "segButton";
            this.segButton.Size = new System.Drawing.Size(44, 21);
            this.segButton.Text = "分割";
            // 
            // DFTButton
            // 
            this.DFTButton.Enabled = false;
            this.DFTButton.Name = "DFTButton";
            this.DFTButton.Size = new System.Drawing.Size(80, 21);
            this.DFTButton.Text = "傅里叶变换";
            // 
            // waveletButton
            // 
            this.waveletButton.Enabled = false;
            this.waveletButton.Name = "waveletButton";
            this.waveletButton.Size = new System.Drawing.Size(68, 21);
            this.waveletButton.Text = "小波变换";
            // 
            // featureDetectButton
            // 
            this.featureDetectButton.Enabled = false;
            this.featureDetectButton.Name = "featureDetectButton";
            this.featureDetectButton.Size = new System.Drawing.Size(68, 21);
            this.featureDetectButton.Text = "特征提取";
            // 
            // objectRecognizeButton
            // 
            this.objectRecognizeButton.Enabled = false;
            this.objectRecognizeButton.Name = "objectRecognizeButton";
            this.objectRecognizeButton.Size = new System.Drawing.Size(68, 21);
            this.objectRecognizeButton.Text = "目标识别";
            // 
            // colorFortifyButton
            // 
            this.colorFortifyButton.Enabled = false;
            this.colorFortifyButton.Name = "colorFortifyButton";
            this.colorFortifyButton.Size = new System.Drawing.Size(68, 21);
            this.colorFortifyButton.Text = "彩色处理";
            // 
            // shortCutHelp
            // 
            this.shortCutHelp.Name = "shortCutHelp";
            this.shortCutHelp.Size = new System.Drawing.Size(56, 21);
            this.shortCutHelp.Text = "快捷键";
            this.shortCutHelp.Click += new System.EventHandler(this.ShortCutHelp_Click);
            // 
            // leftPictureSize
            // 
            this.leftPictureSize.AutoSize = true;
            this.leftPictureSize.Location = new System.Drawing.Point(12, 424);
            this.leftPictureSize.Name = "leftPictureSize";
            this.leftPictureSize.Size = new System.Drawing.Size(43, 17);
            this.leftPictureSize.TabIndex = 13;
            this.leftPictureSize.Text = "H: W: ";
            // 
            // rightPictureSize
            // 
            this.rightPictureSize.AutoSize = true;
            this.rightPictureSize.Location = new System.Drawing.Point(378, 429);
            this.rightPictureSize.Name = "rightPictureSize";
            this.rightPictureSize.Size = new System.Drawing.Size(39, 17);
            this.rightPictureSize.TabIndex = 13;
            this.rightPictureSize.Text = "H: W:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 455);
            this.Controls.Add(this.rightPictureSize);
            this.Controls.Add(this.leftPictureSize);
            this.Controls.Add(this.downButton);
            this.Controls.Add(this.upButton);
            this.Controls.Add(this.left_picture_label);
            this.Controls.Add(this.right_picture_label);
            this.Controls.Add(this.rightPictureBox);
            this.Controls.Add(this.leftPictureBox);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "图像处理工具箱";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.leftPictureBox)).EndInit();
            this.pictureRightClickMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rightPictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PictureBox leftPictureBox;
        private System.Windows.Forms.PictureBox rightPictureBox;
        private System.Windows.Forms.Label right_picture_label;
        private System.Windows.Forms.Label left_picture_label;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem file;
        private System.Windows.Forms.ToolStripMenuItem file_open;
        private System.Windows.Forms.ToolStripMenuItem saveSecondFileButton;
        private System.Windows.Forms.ToolStripMenuItem saveFirstFileButton;
        private System.Windows.Forms.ToolStripMenuItem addNoiseButton;
        private System.Windows.Forms.ToolStripMenuItem fortifyButton;
        private System.Windows.Forms.ToolStripMenuItem edgeButton;
        private System.Windows.Forms.ToolStripMenuItem segButton;
        private System.Windows.Forms.ToolStripMenuItem DFTButton;
        private System.Windows.Forms.ToolStripMenuItem preProcessButton;
        private System.Windows.Forms.ToolStripMenuItem pre_gray;
        private System.Windows.Forms.ToolStripMenuItem addGaussianNoise;
        private System.Windows.Forms.ToolStripMenuItem waveletButton;
        private System.Windows.Forms.ToolStripMenuItem featureDetectButton;
        private System.Windows.Forms.ToolStripMenuItem objectRecognizeButton;
        private System.Windows.Forms.ToolStripMenuItem colorFortifyButton;
        private System.Windows.Forms.ToolStripMenuItem add_uni_noise;
        private System.Windows.Forms.ToolStripMenuItem clearButton;
        private System.Windows.Forms.ToolStripMenuItem reverseButton;
        private System.Windows.Forms.ToolStripMenuItem imagesListButton;
        private System.Windows.Forms.ToolStripMenuItem add_impulse_noise;
        private System.Windows.Forms.Label leftPictureSize;
        private System.Windows.Forms.Label rightPictureSize;
        private System.Windows.Forms.ContextMenuStrip pictureRightClickMenu;
        private System.Windows.Forms.ToolStripMenuItem rightClickSave;
        private System.Windows.Forms.ToolStripMenuItem shortCutHelp;
        private System.Windows.Forms.ToolStripMenuItem overwriteButton;
        private System.Windows.Forms.ToolStripMenuItem grayButton;
        private System.Windows.Forms.ToolStripMenuItem addUniNoise;
        private System.Windows.Forms.ToolStripMenuItem addImpulseNoise;
        private System.Windows.Forms.ToolStripMenuItem barUniformButton;
        private System.Windows.Forms.ToolStripMenuItem blurButton;
        private System.Windows.Forms.ToolStripMenuItem averageFilter;
        private System.Windows.Forms.ToolStripMenuItem medianFilter;
        private System.Windows.Forms.ToolStripMenuItem gaussianFilter;
    }
}

