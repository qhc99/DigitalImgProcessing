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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.leftPictureBox = new System.Windows.Forms.PictureBox();
            this.pictureRightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rightClickSave = new System.Windows.Forms.ToolStripMenuItem();
            this.showHitogramButton = new System.Windows.Forms.ToolStripMenuItem();
            this.DFTTransformButton = new System.Windows.Forms.ToolStripMenuItem();
            this.waveletTransformButton = new System.Windows.Forms.ToolStripMenuItem();
            this.rightPictureBox = new System.Windows.Forms.PictureBox();
            this.rightPictureLabel = new System.Windows.Forms.Label();
            this.leftPictureLabel = new System.Windows.Forms.Label();
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
            this.addSaltAndPepperNoise = new System.Windows.Forms.ToolStripMenuItem();
            this.fortifyButton = new System.Windows.Forms.ToolStripMenuItem();
            this.blurButton = new System.Windows.Forms.ToolStripMenuItem();
            this.averageFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.medianFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.gaussianFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.sharpenButton = new System.Windows.Forms.ToolStripMenuItem();
            this.LaplacianSharpenButton = new System.Windows.Forms.ToolStripMenuItem();
            this.SobelSharpenButton = new System.Windows.Forms.ToolStripMenuItem();
            this.homoFilterButton = new System.Windows.Forms.ToolStripMenuItem();
            this.barUniformButton = new System.Windows.Forms.ToolStripMenuItem();
            this.pseudoColorFortifyButton = new System.Windows.Forms.ToolStripMenuItem();
            this.edgeButton = new System.Windows.Forms.ToolStripMenuItem();
            this.LaplacianEdgeDetection = new System.Windows.Forms.ToolStripMenuItem();
            this.SobelEdgeDetection = new System.Windows.Forms.ToolStripMenuItem();
            this.CannyEdgeDetection = new System.Windows.Forms.ToolStripMenuItem();
            this.thresholdSegButton = new System.Windows.Forms.ToolStripMenuItem();
            this.meanThresholdSegButton = new System.Windows.Forms.ToolStripMenuItem();
            this.GaussianThresholdSegButton = new System.Windows.Forms.ToolStripMenuItem();
            this.OtsuSegButton = new System.Windows.Forms.ToolStripMenuItem();
            this.featureDetectButton = new System.Windows.Forms.ToolStripMenuItem();
            this.BRISKButton = new System.Windows.Forms.ToolStripMenuItem();
            this.ORBandFREAK = new System.Windows.Forms.ToolStripMenuItem();
            this.starDetectorButton = new System.Windows.Forms.ToolStripMenuItem();
            this.MSERFeatureDetectButton = new System.Windows.Forms.ToolStripMenuItem();
            this.faceLocateButton = new System.Windows.Forms.ToolStripMenuItem();
            this.phtoFilterButton = new System.Windows.Forms.ToolStripMenuItem();
            this.cartoonButton = new System.Windows.Forms.ToolStripMenuItem();
            this.detailEnhanceButton = new System.Windows.Forms.ToolStripMenuItem();
            this.pencilSketchButton = new System.Windows.Forms.ToolStripMenuItem();
            this.stylizationButton = new System.Windows.Forms.ToolStripMenuItem();
            this.videoProcessButton = new System.Windows.Forms.ToolStripMenuItem();
            this.openCameraButton = new System.Windows.Forms.ToolStripMenuItem();
            this.openVideoFile = new System.Windows.Forms.ToolStripMenuItem();
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
            this.rightClickSave,
            this.showHitogramButton,
            this.DFTTransformButton,
            this.waveletTransformButton});
            this.pictureRightClickMenu.Name = "pictureRightClickMenu";
            this.pictureRightClickMenu.Size = new System.Drawing.Size(137, 92);
            // 
            // rightClickSave
            // 
            this.rightClickSave.Enabled = false;
            this.rightClickSave.Name = "rightClickSave";
            this.rightClickSave.Size = new System.Drawing.Size(136, 22);
            this.rightClickSave.Text = "保存";
            this.rightClickSave.Click += new System.EventHandler(this.RightClickSave_Click);
            // 
            // showHitogramButton
            // 
            this.showHitogramButton.Enabled = false;
            this.showHitogramButton.Name = "showHitogramButton";
            this.showHitogramButton.Size = new System.Drawing.Size(136, 22);
            this.showHitogramButton.Text = "灰度直方图";
            this.showHitogramButton.Click += new System.EventHandler(this.showHistogramButton_Click);
            // 
            // DFTTransformButton
            // 
            this.DFTTransformButton.Enabled = false;
            this.DFTTransformButton.Name = "DFTTransformButton";
            this.DFTTransformButton.Size = new System.Drawing.Size(136, 22);
            this.DFTTransformButton.Text = "傅里叶变换";
            this.DFTTransformButton.Click += new System.EventHandler(this.DFTTransformButton_Click);
            // 
            // waveletTransformButton
            // 
            this.waveletTransformButton.Enabled = false;
            this.waveletTransformButton.Name = "waveletTransformButton";
            this.waveletTransformButton.Size = new System.Drawing.Size(136, 22);
            this.waveletTransformButton.Text = "小波变换";
            this.waveletTransformButton.Click += new System.EventHandler(this.waveletTransformButton_Click);
            // 
            // rightPictureBox
            // 
            this.rightPictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.rightPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rightPictureBox.ContextMenuStrip = this.pictureRightClickMenu;
            this.rightPictureBox.Location = new System.Drawing.Point(378, 56);
            this.rightPictureBox.Name = "rightPictureBox";
            this.rightPictureBox.Size = new System.Drawing.Size(370, 370);
            this.rightPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.rightPictureBox.TabIndex = 2;
            this.rightPictureBox.TabStop = false;
            // 
            // rightPictureLabel
            // 
            this.rightPictureLabel.AutoSize = true;
            this.rightPictureLabel.Location = new System.Drawing.Point(518, 36);
            this.rightPictureLabel.Name = "rightPictureLabel";
            this.rightPictureLabel.Size = new System.Drawing.Size(90, 17);
            this.rightPictureLabel.TabIndex = 5;
            this.rightPictureLabel.Text = "第 0 行 第 0 列";
            // 
            // leftPictureLabel
            // 
            this.leftPictureLabel.AutoSize = true;
            this.leftPictureLabel.Location = new System.Drawing.Point(147, 36);
            this.leftPictureLabel.Name = "leftPictureLabel";
            this.leftPictureLabel.Size = new System.Drawing.Size(90, 17);
            this.leftPictureLabel.TabIndex = 6;
            this.leftPictureLabel.Text = "第 0 行 第 0 列";
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
            this.thresholdSegButton,
            this.featureDetectButton,
            this.phtoFilterButton,
            this.videoProcessButton,
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
            this.addSaltAndPepperNoise});
            this.addNoiseButton.Enabled = false;
            this.addNoiseButton.Name = "addNoiseButton";
            this.addNoiseButton.Size = new System.Drawing.Size(68, 21);
            this.addNoiseButton.Text = "添加噪声";
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
            // addSaltAndPepperNoise
            // 
            this.addSaltAndPepperNoise.Name = "addSaltAndPepperNoise";
            this.addSaltAndPepperNoise.Size = new System.Drawing.Size(124, 22);
            this.addSaltAndPepperNoise.Text = "椒盐噪声";
            this.addSaltAndPepperNoise.Click += new System.EventHandler(this.AddSaltAndPepperNoise_Click);
            // 
            // fortifyButton
            // 
            this.fortifyButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blurButton,
            this.sharpenButton,
            this.homoFilterButton,
            this.barUniformButton,
            this.pseudoColorFortifyButton});
            this.fortifyButton.Enabled = false;
            this.fortifyButton.Name = "fortifyButton";
            this.fortifyButton.Size = new System.Drawing.Size(68, 21);
            this.fortifyButton.Text = "图片增强";
            // 
            // blurButton
            // 
            this.blurButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.averageFilter,
            this.medianFilter,
            this.gaussianFilter});
            this.blurButton.Name = "blurButton";
            this.blurButton.Size = new System.Drawing.Size(158, 22);
            this.blurButton.Text = "平滑/模糊/去噪";
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
            // sharpenButton
            // 
            this.sharpenButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LaplacianSharpenButton,
            this.SobelSharpenButton});
            this.sharpenButton.Name = "sharpenButton";
            this.sharpenButton.Size = new System.Drawing.Size(158, 22);
            this.sharpenButton.Text = "锐化";
            // 
            // LaplacianSharpenButton
            // 
            this.LaplacianSharpenButton.Name = "LaplacianSharpenButton";
            this.LaplacianSharpenButton.Size = new System.Drawing.Size(130, 22);
            this.LaplacianSharpenButton.Text = "Laplacian";
            this.LaplacianSharpenButton.Click += new System.EventHandler(this.LaplacianSharpenButton_Click);
            // 
            // SobelSharpenButton
            // 
            this.SobelSharpenButton.Name = "SobelSharpenButton";
            this.SobelSharpenButton.Size = new System.Drawing.Size(130, 22);
            this.SobelSharpenButton.Text = "Sobel";
            this.SobelSharpenButton.Click += new System.EventHandler(this.SobelSharpenButton_Click);
            // 
            // homoFilterButton
            // 
            this.homoFilterButton.Name = "homoFilterButton";
            this.homoFilterButton.Size = new System.Drawing.Size(158, 22);
            this.homoFilterButton.Text = "同态滤波";
            this.homoFilterButton.Click += new System.EventHandler(this.HomoFilterButton_Click);
            // 
            // barUniformButton
            // 
            this.barUniformButton.Name = "barUniformButton";
            this.barUniformButton.Size = new System.Drawing.Size(158, 22);
            this.barUniformButton.Text = "直方图均匀化";
            this.barUniformButton.Click += new System.EventHandler(this.BarUniformButton_Click);
            // 
            // pseudoColorFortifyButton
            // 
            this.pseudoColorFortifyButton.Name = "pseudoColorFortifyButton";
            this.pseudoColorFortifyButton.Size = new System.Drawing.Size(158, 22);
            this.pseudoColorFortifyButton.Text = "伪彩色增强";
            this.pseudoColorFortifyButton.Click += new System.EventHandler(this.PseudoColorFortifyButton_Click);
            // 
            // edgeButton
            // 
            this.edgeButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LaplacianEdgeDetection,
            this.SobelEdgeDetection,
            this.CannyEdgeDetection});
            this.edgeButton.Enabled = false;
            this.edgeButton.Name = "edgeButton";
            this.edgeButton.Size = new System.Drawing.Size(68, 21);
            this.edgeButton.Text = "边缘检测";
            // 
            // LaplacianEdgeDetection
            // 
            this.LaplacianEdgeDetection.Name = "LaplacianEdgeDetection";
            this.LaplacianEdgeDetection.Size = new System.Drawing.Size(130, 22);
            this.LaplacianEdgeDetection.Text = "Laplacian";
            this.LaplacianEdgeDetection.Click += new System.EventHandler(this.LaplacianEdgeDetection_Click);
            // 
            // SobelEdgeDetection
            // 
            this.SobelEdgeDetection.Name = "SobelEdgeDetection";
            this.SobelEdgeDetection.Size = new System.Drawing.Size(130, 22);
            this.SobelEdgeDetection.Text = "Sobel";
            this.SobelEdgeDetection.Click += new System.EventHandler(this.SobelEdgeDetection_Click);
            // 
            // CannyEdgeDetection
            // 
            this.CannyEdgeDetection.Name = "CannyEdgeDetection";
            this.CannyEdgeDetection.Size = new System.Drawing.Size(130, 22);
            this.CannyEdgeDetection.Text = "Canny";
            this.CannyEdgeDetection.Click += new System.EventHandler(this.CannyEdgeDetection_Click);
            // 
            // thresholdSegButton
            // 
            this.thresholdSegButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.meanThresholdSegButton,
            this.GaussianThresholdSegButton,
            this.OtsuSegButton});
            this.thresholdSegButton.Enabled = false;
            this.thresholdSegButton.Name = "thresholdSegButton";
            this.thresholdSegButton.Size = new System.Drawing.Size(68, 21);
            this.thresholdSegButton.Text = "门限分割";
            // 
            // meanThresholdSegButton
            // 
            this.meanThresholdSegButton.Name = "meanThresholdSegButton";
            this.meanThresholdSegButton.Size = new System.Drawing.Size(184, 22);
            this.meanThresholdSegButton.Text = "自适应均值门限分割";
            this.meanThresholdSegButton.Click += new System.EventHandler(this.meanThresholdSegButton_Click);
            // 
            // GaussianThresholdSegButton
            // 
            this.GaussianThresholdSegButton.Name = "GaussianThresholdSegButton";
            this.GaussianThresholdSegButton.Size = new System.Drawing.Size(184, 22);
            this.GaussianThresholdSegButton.Text = "自适应高斯门限分割";
            this.GaussianThresholdSegButton.Click += new System.EventHandler(this.GaussianThresholdSegButton_Click);
            // 
            // OtsuSegButton
            // 
            this.OtsuSegButton.Name = "OtsuSegButton";
            this.OtsuSegButton.Size = new System.Drawing.Size(184, 22);
            this.OtsuSegButton.Text = "Otsu门限分割";
            this.OtsuSegButton.Click += new System.EventHandler(this.OtsuSegButton_Click);
            // 
            // featureDetectButton
            // 
            this.featureDetectButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BRISKButton,
            this.ORBandFREAK,
            this.starDetectorButton,
            this.MSERFeatureDetectButton,
            this.faceLocateButton});
            this.featureDetectButton.Enabled = false;
            this.featureDetectButton.Name = "featureDetectButton";
            this.featureDetectButton.Size = new System.Drawing.Size(68, 21);
            this.featureDetectButton.Text = "特征识别";
            // 
            // BRISKButton
            // 
            this.BRISKButton.Name = "BRISKButton";
            this.BRISKButton.Size = new System.Drawing.Size(199, 22);
            this.BRISKButton.Text = "BRISK特征提取";
            this.BRISKButton.Click += new System.EventHandler(this.BRISKButton_Click);
            // 
            // ORBandFREAK
            // 
            this.ORBandFREAK.Name = "ORBandFREAK";
            this.ORBandFREAK.Size = new System.Drawing.Size(199, 22);
            this.ORBandFREAK.Text = "ORB和FREAK特征提取";
            this.ORBandFREAK.Click += new System.EventHandler(this.ORBandFREAK_Click);
            // 
            // starDetectorButton
            // 
            this.starDetectorButton.Name = "starDetectorButton";
            this.starDetectorButton.Size = new System.Drawing.Size(199, 22);
            this.starDetectorButton.Text = "Star特征检测";
            this.starDetectorButton.Click += new System.EventHandler(this.starDetectorButton_Click);
            // 
            // MSERFeatureDetectButton
            // 
            this.MSERFeatureDetectButton.Name = "MSERFeatureDetectButton";
            this.MSERFeatureDetectButton.Size = new System.Drawing.Size(199, 22);
            this.MSERFeatureDetectButton.Text = "MSER特征检测";
            this.MSERFeatureDetectButton.Click += new System.EventHandler(this.MSERFeatureDetectButton_Click);
            // 
            // faceLocateButton
            // 
            this.faceLocateButton.Name = "faceLocateButton";
            this.faceLocateButton.Size = new System.Drawing.Size(199, 22);
            this.faceLocateButton.Text = "人脸定位";
            this.faceLocateButton.Click += new System.EventHandler(this.faceLocateButton_Click);
            // 
            // phtoFilterButton
            // 
            this.phtoFilterButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cartoonButton,
            this.detailEnhanceButton,
            this.pencilSketchButton,
            this.stylizationButton});
            this.phtoFilterButton.Enabled = false;
            this.phtoFilterButton.Name = "phtoFilterButton";
            this.phtoFilterButton.Size = new System.Drawing.Size(68, 21);
            this.phtoFilterButton.Text = "添加滤镜";
            // 
            // cartoonButton
            // 
            this.cartoonButton.Name = "cartoonButton";
            this.cartoonButton.Size = new System.Drawing.Size(124, 22);
            this.cartoonButton.Text = "动漫";
            this.cartoonButton.Click += new System.EventHandler(this.cartoonButton_Click);
            // 
            // detailEnhanceButton
            // 
            this.detailEnhanceButton.Name = "detailEnhanceButton";
            this.detailEnhanceButton.Size = new System.Drawing.Size(124, 22);
            this.detailEnhanceButton.Text = "细节增强";
            this.detailEnhanceButton.Click += new System.EventHandler(this.detailEnhanceButton_Click);
            // 
            // pencilSketchButton
            // 
            this.pencilSketchButton.Name = "pencilSketchButton";
            this.pencilSketchButton.Size = new System.Drawing.Size(124, 22);
            this.pencilSketchButton.Text = "素描";
            this.pencilSketchButton.Click += new System.EventHandler(this.pencilSketchButton_Click);
            // 
            // stylizationButton
            // 
            this.stylizationButton.Name = "stylizationButton";
            this.stylizationButton.Size = new System.Drawing.Size(124, 22);
            this.stylizationButton.Text = "油画";
            this.stylizationButton.Click += new System.EventHandler(this.stylizationButton_Click);
            // 
            // videoProcessButton
            // 
            this.videoProcessButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openCameraButton,
            this.openVideoFile});
            this.videoProcessButton.Name = "videoProcessButton";
            this.videoProcessButton.Size = new System.Drawing.Size(68, 21);
            this.videoProcessButton.Text = "视频处理";
            // 
            // openCameraButton
            // 
            this.openCameraButton.Name = "openCameraButton";
            this.openCameraButton.Size = new System.Drawing.Size(136, 22);
            this.openCameraButton.Text = "开启摄像头";
            this.openCameraButton.Click += new System.EventHandler(this.openCameraButton_Click);
            // 
            // openVideoFile
            // 
            this.openVideoFile.Name = "openVideoFile";
            this.openVideoFile.Size = new System.Drawing.Size(136, 22);
            this.openVideoFile.Text = "打开文件";
            this.openVideoFile.Click += new System.EventHandler(this.openVideoFile_Click);
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
            this.Controls.Add(this.leftPictureLabel);
            this.Controls.Add(this.rightPictureLabel);
            this.Controls.Add(this.rightPictureBox);
            this.Controls.Add(this.leftPictureBox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private System.Windows.Forms.Label rightPictureLabel;
        private System.Windows.Forms.Label leftPictureLabel;
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
        private System.Windows.Forms.ToolStripMenuItem thresholdSegButton;
        private System.Windows.Forms.ToolStripMenuItem preProcessButton;
        private System.Windows.Forms.ToolStripMenuItem addGaussianNoise;
        private System.Windows.Forms.ToolStripMenuItem featureDetectButton;
        private System.Windows.Forms.ToolStripMenuItem clearButton;
        private System.Windows.Forms.ToolStripMenuItem reverseButton;
        private System.Windows.Forms.ToolStripMenuItem imagesListButton;
        private System.Windows.Forms.Label leftPictureSize;
        private System.Windows.Forms.Label rightPictureSize;
        private System.Windows.Forms.ContextMenuStrip pictureRightClickMenu;
        private System.Windows.Forms.ToolStripMenuItem rightClickSave;
        private System.Windows.Forms.ToolStripMenuItem shortCutHelp;
        private System.Windows.Forms.ToolStripMenuItem overwriteButton;
        private System.Windows.Forms.ToolStripMenuItem grayButton;
        private System.Windows.Forms.ToolStripMenuItem addUniNoise;
        private System.Windows.Forms.ToolStripMenuItem addSaltAndPepperNoise;
        private System.Windows.Forms.ToolStripMenuItem barUniformButton;
        private System.Windows.Forms.ToolStripMenuItem blurButton;
        private System.Windows.Forms.ToolStripMenuItem averageFilter;
        private System.Windows.Forms.ToolStripMenuItem medianFilter;
        private System.Windows.Forms.ToolStripMenuItem gaussianFilter;
        private System.Windows.Forms.ToolStripMenuItem sharpenButton;
        private System.Windows.Forms.ToolStripMenuItem LaplacianSharpenButton;
        private System.Windows.Forms.ToolStripMenuItem SobelSharpenButton;
        private System.Windows.Forms.ToolStripMenuItem homoFilterButton;
        private System.Windows.Forms.ToolStripMenuItem pseudoColorFortifyButton;
        private System.Windows.Forms.ToolStripMenuItem LaplacianEdgeDetection;
        private System.Windows.Forms.ToolStripMenuItem SobelEdgeDetection;
        private System.Windows.Forms.ToolStripMenuItem CannyEdgeDetection;
        private System.Windows.Forms.ToolStripMenuItem meanThresholdSegButton;
        private System.Windows.Forms.ToolStripMenuItem GaussianThresholdSegButton;
        private System.Windows.Forms.ToolStripMenuItem OtsuSegButton;
        private System.Windows.Forms.ToolStripMenuItem faceLocateButton;
        private System.Windows.Forms.ToolStripMenuItem videoProcessButton;
        private System.Windows.Forms.ToolStripMenuItem openCameraButton;
        private System.Windows.Forms.ToolStripMenuItem openVideoFile;
        private System.Windows.Forms.ToolStripMenuItem DFTTransformButton;
        private System.Windows.Forms.ToolStripMenuItem waveletTransformButton;
        private System.Windows.Forms.ToolStripMenuItem showHitogramButton;
        private System.Windows.Forms.ToolStripMenuItem starDetectorButton;
        private System.Windows.Forms.ToolStripMenuItem ORBandFREAK;
        private System.Windows.Forms.ToolStripMenuItem BRISKButton;
        private System.Windows.Forms.ToolStripMenuItem MSERFeatureDetectButton;
        private System.Windows.Forms.ToolStripMenuItem phtoFilterButton;
        private System.Windows.Forms.ToolStripMenuItem cartoonButton;
        private System.Windows.Forms.ToolStripMenuItem detailEnhanceButton;
        private System.Windows.Forms.ToolStripMenuItem pencilSketchButton;
        private System.Windows.Forms.ToolStripMenuItem stylizationButton;
    }
}

