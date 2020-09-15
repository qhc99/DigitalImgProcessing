using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using OpenCvSharp.XFeatures2D;
using Size = OpenCvSharp.Size;
using static opencv.ImageProcessing;
using Point = OpenCvSharp.Point;

namespace opencv
{
    public partial class MainForm : Form
    {
        private readonly List<List<Mat>> _workingMatsProcesses = new List<List<Mat>>();
        private int _currentProcessIndex = -1;

        public MainForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            LoadNoneImg(leftPictureBox);
            LoadNoneImg(rightPictureBox);
        }

        #region Methods

        /// <summary>
        /// 显示空图片
        /// </summary>
        /// <param name="pb"></param>
        private void LoadNoneImg(PictureBox pb)
        {
            ShowMat(pb, _noneMat);
        }

        private readonly Mat _noneMat =
            ((Bitmap) Image.FromFile(Directory.GetCurrentDirectory() + "..\\..\\..\\..\\Resources\\none.jpg")).ToMat();

        // ReSharper disable once UnusedMember.Local
        private void NotImplemented()
        {
            MessageBox.Show(@"未实现此功能");
        }

        /// <summary>
        /// 当前图片序列
        /// </summary>
        private List<Mat> WorkingMats
        {
            get
            {
                if (_currentProcessIndex == -1)
                {
                    return new List<Mat>();
                }
                else
                {
                    return _workingMatsProcesses[_currentProcessIndex];
                }
            }
        }

        /// <summary>
        /// 当前处理左图片
        /// </summary>
        private Mat WorkingLeftMat
        {
            get
            {
                return WorkingMats.Count switch
                {
                    0 => _noneMat,
                    1 => WorkingMats[0],
                    _ => WorkingMats[^2]
                };
            }
        }

        /// <summary>
        /// 当前处理右图片
        /// </summary>
        private Mat WorkingRightMat
        {
            get
            {
                if (WorkingMats.Count <= 1)
                {
                    return _noneMat;
                }
                else
                {
                    return WorkingMats[^1];
                }
            }
        }

        /// <summary>
        /// Resize Mat 并显示到PictureBox
        /// </summary>
        /// <param name="pb"></param>
        /// <param name="m"></param>
        private void ShowMat(PictureBox pb, Mat m)
        {
            pb.Image = GetBoxFittedMat(m).ToBitmap();
            if (leftPictureBox == pb)
            {
                leftPictureLabel.Text = $@"第 {_currentProcessIndex + 1} 行 第 {WorkingMats.Count - 1} 列";
                leftPictureSize.Text = $@"H:{m.Height} W:{m.Width}";
            }
            else if (rightPictureBox == pb)
            {
                rightPictureLabel.Text = $@"第 {_currentProcessIndex + 1} 行 第 {WorkingMats.Count} 列";
                rightPictureSize.Text = $@"H:{m.Height} W:{m.Width}";
            }
        }

        /// <summary>
        /// 符合窗口大小的Mat
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        private Mat GetBoxFittedMat(Mat m)
        {
            var (row, col) = ComputeSize(m.Rows, m.Cols,
                leftPictureBox.Size.Height, leftPictureBox.Size.Width);
            try
            {
                return m.Resize(new Size(row, col), 0, 0, InterpolationFlags.Cubic);
            }
            catch (OpenCVException)
            {
                MessageBox.Show(@"只能打开图片文件");
                return _noneMat;
            }

            static Tuple<int, int> ComputeSize(int imgRow, int imgCol, int boxRow, int boxCol)
            {
                if (imgRow <= boxRow && imgCol <= boxCol)
                {
                    return new Tuple<int, int>(imgRow, imgCol);
                }
                else
                {
                    double ratio = ((double) imgRow) / imgCol;
                    //newRow/newCol = imgRow/imgCol
                    if (imgRow > boxRow)
                    {
                        return new Tuple<int, int>(boxRow, (int) (boxRow / ratio));
                    }
                    else
                    {
                        return new Tuple<int, int>((int) (ratio * boxCol), boxCol);
                    }
                }
            }
        }

        /// <summary>
        /// 启用所有按钮
        /// </summary>
        private void EnableAllButtons()
        {
            preProcessButton.Enabled = true;
            upButton.Enabled = true;
            downButton.Enabled = true;
            addNoiseButton.Enabled = true;
            blurButton.Enabled = true;
            fortifyButton.Enabled = true;
            edgeButton.Enabled = true;
            thresholdSegButton.Enabled = true;
            saveSecondFileButton.Enabled = true;
            saveFirstFileButton.Enabled = true;
            featureDetectButton.Enabled = true;
            // videoProcessButton.Enabled = true;
            pseudoColorFortifyButton.Enabled = true;
            clearButton.Enabled = true;
            reverseButton.Enabled = true;
            imagesListButton.Enabled = true;
            overwriteButton.Enabled = true;
            DFTTransformButton.Enabled = true;
            waveletTransformButton.Enabled = true;
            rightClickSave.Enabled = true;
            showHitogramButton.Enabled = true;
        }

        /// <summary>
        /// 禁用所有按钮(除加载图片)
        /// </summary>
        private void DisableAllButtons()
        {
            preProcessButton.Enabled = false;
            upButton.Enabled = false;
            downButton.Enabled = false;
            addNoiseButton.Enabled = false;
            blurButton.Enabled = false;
            fortifyButton.Enabled = false;
            edgeButton.Enabled = false;
            thresholdSegButton.Enabled = false;
            saveSecondFileButton.Enabled = false;
            saveFirstFileButton.Enabled = false;
            featureDetectButton.Enabled = false;
            // videoProcessButton.Enabled = false;
            pseudoColorFortifyButton.Enabled = false;
            clearButton.Enabled = false;
            reverseButton.Enabled = false;
            imagesListButton.Enabled = false;
            overwriteButton.Enabled = false;
            DFTTransformButton.Enabled = false;
            waveletTransformButton.Enabled = false;
            rightClickSave.Enabled = false;
            showHitogramButton.Enabled = false;
        }

        /// <summary>
        /// 垂直移动检查按钮禁用情况
        /// </summary>
        private void VerticalCheck()
        {
            if (_currentProcessIndex <= 0) upButton.Enabled = false;
            else upButton.Enabled = true;
            if (_currentProcessIndex + 1 == _workingMatsProcesses.Count) downButton.Enabled = false;
            else downButton.Enabled = true;
        }

        /// <summary>
        /// 获取待处理的图片
        /// </summary>
        /// <returns></returns>
        private Mat GetImageToProcess()
        {
            Mat originImg;
            if (WorkingMats.Count <= 1)
            {
                originImg = WorkingLeftMat;
            }
            else
            {
                originImg = WorkingRightMat;
            }

            return originImg;
        }

        /// <summary>
        /// 处理结果存入内存并显示
        /// </summary>
        /// <param name="img"></param>
        private void AddMatToListAndShow(Mat img)
        {
            WorkingMats.Add(img);
            ShowMat(leftPictureBox, WorkingLeftMat);
            ShowMat(rightPictureBox, WorkingRightMat);
        }

        /// <summary>
        /// 保存Mat
        /// </summary>
        /// <param name="m"></param>
        private void SaveMat(Mat m)
        {
            var res = saveFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                m.ToBitmap().Save(saveFileDialog1.FileName);
            }
        }

        #endregion

        /// <summary>
        /// 加载图片并显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadButton_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                _currentProcessIndex++;
                _workingMatsProcesses.Add(new List<Mat>());

                LoadNoneImg(rightPictureBox);

                var readMat = new Mat(openFileDialog1.FileName);
                WorkingMats.Add(readMat);

                ShowMat(leftPictureBox, readMat);
                EnableAllButtons();
                VerticalCheck();
            }
        }

        /// <summary>
        /// 清除此行图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            var checkWindow = new WarningPopUp(@"清除不可撤销,是否确认?");
            var dialogRes = checkWindow.ShowDialog();
            if (dialogRes == DialogResult.OK)
            {
                _workingMatsProcesses.RemoveAt(_currentProcessIndex);
                _currentProcessIndex--;
                if (_currentProcessIndex == -1)
                {
                    if (_workingMatsProcesses.Count == 0)
                    {
                        LoadNoneImg(leftPictureBox);
                        LoadNoneImg(rightPictureBox);
                        DisableAllButtons();
                        return;
                    }
                    else
                    {
                        // delete first row but processes count > 0
                        _currentProcessIndex++;
                    }
                }

                ShowMat(leftPictureBox, WorkingLeftMat);
                ShowMat(rightPictureBox, WorkingRightMat);
                VerticalCheck();
            }
        }

        /// <summary>
        /// 上移一行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpButton_Click(object sender, EventArgs e)
        {
            _currentProcessIndex--;
            ShowMat(leftPictureBox, WorkingLeftMat);
            ShowMat(rightPictureBox, WorkingRightMat);
            VerticalCheck();
        }

        /// <summary>
        /// 下移一行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownButton_Click(object sender, EventArgs e)
        {
            _currentProcessIndex++;
            ShowMat(leftPictureBox, WorkingLeftMat);
            ShowMat(rightPictureBox, WorkingRightMat);
            VerticalCheck();
        }

        /// <summary>
        /// 保存第二张图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveSecondButton_Click(object sender, EventArgs e)
        {
            SaveMat(WorkingRightMat);
        }

        /// <summary>
        /// 保存第一张图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveFirstButton_Click(object sender, EventArgs e)
        {
            SaveMat(WorkingLeftMat);
        }

        /// <summary>
        /// 删除当前图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReverseButton_Click(object sender, EventArgs e)
        {
            if (WorkingMats.Count >= 2)
            {
                var checkWindow = new WarningPopUp(@"确认撤销?");
                var res = checkWindow.ShowDialog();
                if (res == DialogResult.OK)
                {
                    if (WorkingMats.Count >= 1)
                    {
                        WorkingMats.RemoveAt(WorkingMats.Count - 1);
                        ShowMat(leftPictureBox, WorkingLeftMat);
                        ShowMat(rightPictureBox, WorkingRightMat);
                    }
                }
            }
        }

        /// <summary>
        /// 图片序列
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImagesListButton_Click(object sender, EventArgs e)
        {
            var imagesForm = new ImagesListForm(WorkingMats);
            imagesForm.ShowDialog();
        }

        /// <summary>
        /// 快捷键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        if (upButton.Enabled)
                        {
                            UpButton_Click(this, EventArgs.Empty);
                        }

                        break;
                    case Keys.Down:
                        if (downButton.Enabled)
                        {
                            DownButton_Click(this, EventArgs.Empty);
                        }

                        break;
                    case Keys.S:
                        if (saveSecondFileButton.Enabled)
                        {
                            if (WorkingMats.Count >= 2)
                            {
                                SaveSecondButton_Click(this, EventArgs.Empty);
                            }
                            else
                            {
                                MessageBox.Show(@"不能保存空图片");
                            }
                        }

                        break;
                    case Keys.Z:
                        if (reverseButton.Enabled)
                        {
                            ReverseButton_Click(this, EventArgs.Empty);
                        }

                        break;
                    case Keys.O:
                        if (overwriteButton.Enabled)
                        {
                            OverwriteButton_Click(this, EventArgs.Empty);
                        }

                        break;
                }
            }

            if (e.Modifiers == Keys.Alt)
            {
                switch (e.KeyCode)
                {
                    case Keys.V:
                        if (imagesListButton.Enabled)
                        {
                            ImagesListButton_Click(this, EventArgs.Empty);
                        }

                        break;
                    case Keys.O:
                        LoadButton_Click(this, EventArgs.Empty);
                        break;
                }
            }
        }

        /// <summary>
        /// 右击保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RightClickSave_Click(object sender, EventArgs e)
        {
            // Try to cast the sender to a ToolStripItem
            if (sender is ToolStripItem menuItem)
            {
                // Retrieve the ContextMenuStrip that owns this ToolStripItem
                if (menuItem.Owner is ContextMenuStrip owner)
                {
                    // Get the control that is displaying this context menu
                    Control sourceControl = owner.SourceControl;
                    if (sourceControl == leftPictureBox && WorkingMats.Count >= 1)
                    {
                        SaveFirstButton_Click(this, EventArgs.Empty);
                    }
                    else if (sourceControl == rightPictureBox && WorkingMats.Count >= 2)
                    {
                        SaveSecondButton_Click(this, EventArgs.Empty);
                    }
                }
            }
        }

        /// <summary>
        /// 快捷键提示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShortCutHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ctrl + ↑: 上一个工作序列\n" +
                            "ctrl + ↓: 下一个工作序列\n" +
                            "ctrl + s: 保存第二张图片\n" +
                            "ctrl + z: 撤销处理操作\n" +
                            "ctrl + o: 覆盖上一张图片\n" +
                            "ctrl + ENTER: 弹窗确认" +
                            "ctrl + ←: 图片序列向左翻页\n" +
                            "ctrl + →: 图片序列向右翻页\n" +
                            "alt + v: 查看图片序列\n" +
                            "alt + o: 打开图片\n" +
                            "ESC: 关闭弹窗\n" +
                            "q: 停止录像");
        }

        /// <summary>
        /// 覆盖上一张图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OverwriteButton_Click(object sender, EventArgs e)
        {
            var warnWindow = new WarningPopUp(@"覆盖不可撤销!请确认。");
            var dialogRes = warnWindow.ShowDialog();
            if (dialogRes == DialogResult.OK)
            {
                if (WorkingMats.Count >= 2)
                {
                    WorkingMats.RemoveAt(WorkingMats.Count - 2);
                    ShowMat(leftPictureBox, WorkingLeftMat);
                    ShowMat(rightPictureBox, WorkingRightMat);
                }
            }
        }

        /// <summary>
        /// 打开视频文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openVideoFile_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                using VideoCapture capture = new VideoCapture(openFileDialog1.FileName);

                int sleepTime = (int) Math.Round(1000 / capture.Fps);

                using Window window = new Window("file", WindowMode.AutoSize | WindowMode.KeepRatio);
                Mat image = new Mat();
                // When the movie playback reaches end, Mat.data becomes NULL.
                int key = -1;
                while (key != 113)
                {
                    capture.Read(image); // same as cvQueryFrame
                    if (image.Empty())
                        break;

                    window.ShowImage(image);
                    key = Cv2.WaitKey(sleepTime);
                }

                Cv2.DestroyWindow("file");
            }
        }

        /// <summary>
        /// 打开摄像头
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openCameraButton_Click(object sender, EventArgs e)
        {
            var videoWindow = new VideoForm();
            videoWindow.ShowDialog();
        }

        /// <summary>
        /// 灰度化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrayButton_Click(object sender, EventArgs e)
        {
            var originImg = GetImageToProcess();
            var grayImg = ConvertToGrayMat(originImg);
            AddMatToListAndShow(grayImg);
        }

        /// <summary>
        /// 加高斯噪声
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddGaussianNoise_Click(object sender, EventArgs e)
        {
            try
            {
                AddMatToListAndShow(AddGaussianNoise(GetImageToProcess()));
            }
            catch (ProcessCanceledException)
            {
            }
        }

        /// <summary>
        /// 加均值噪声
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddUniformNoise_Click(object sender, EventArgs e)
        {
            try
            {
                AddMatToListAndShow(AddUniformNoise(GetImageToProcess()));
            }
            catch (ProcessCanceledException)
            {

            }
        }

        /// <summary>
        /// 加椒盐噪声
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddSaltAndPepperNoise_Click(object sender, EventArgs e)
        {
            try
            {
                AddMatToListAndShow(AddSaltAndPepperNoise(GetImageToProcess()));
            }
            catch (ProcessCanceledException)
            {

            }
        }

        /// <summary>
        /// 中值滤波
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MedianBlur_Click(object sender, EventArgs e)
        {
            try
            {
                AddMatToListAndShow(MedianBlur(GetImageToProcess()));
            }
            catch (ProcessCanceledException)
            {

            }
            catch (NotGrayImageException)
            {

            }
        }

        /// <summary>
        /// 均值滤波
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AverageBlur_Click(object sender, EventArgs e)
        {
            try
            {
                AddMatToListAndShow(AverageBlur(GetImageToProcess()));
            }
            catch (ProcessCanceledException)
            {

            }
        }

        /// <summary>
        /// 高斯滤波
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GaussianBlur_Click(object sender, EventArgs e)
        {
            try
            {
                AddMatToListAndShow(GaussianBlur(GetImageToProcess()));
            }
            catch (ProcessCanceledException)
            {

            }
        }

        /// <summary>
        /// 直方图均衡化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BarUniformButton_Click(object sender, EventArgs e)
        {
            try
            {
                AddMatToListAndShow(GetImageToProcess().EqualizeHist());
            }
            catch (OpenCVException)
            {
                MessageBox.Show(@"非灰度图像");
            }
        }

        /// <summary>
        /// Laplacian锐化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LaplacianSharpenButton_Click(object sender, EventArgs e)
        {
            try
            {
                AddMatToListAndShow(LaplacianSharpen(GetImageToProcess()));
            }
            catch (ProcessCanceledException)
            {

            }
        }

        /// <summary>
        /// Sobel锐化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SobelSharpenButton_Click(object sender, EventArgs e)
        {
            try
            {
                AddMatToListAndShow(SobelSharpen(GetImageToProcess()));
            }
            catch (ProcessCanceledException)
            {

            }
        }

        /// <summary>
        /// 同态滤波
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HomoFilterButton_Click(object sender, EventArgs e)
        {
            //TODO implement
            NotImplemented();
        }

        /// <summary>
        /// 暗通道先验去雾
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HazeRemovalButton_Click(object sender, EventArgs e)
        {
            //TODO implement
            NotImplemented();
        }

        /// <summary>
        /// 伪彩色增强
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PseudoColorFortifyButton_Click(object sender, EventArgs e)
        {
            try
            {
                AddMatToListAndShow(PseudoColorFortify(GetImageToProcess()));
            }
            catch (ProcessCanceledException)
            {

            }
        }

        /// <summary>
        /// Laplacian边缘检测
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LaplacianEdgeDetection_Click(object sender, EventArgs e)
        {
            AddMatToListAndShow(LaplacianEdgeDetect(GetImageToProcess()));
        }

        /// <summary>
        /// Canny边缘检测
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CannyEdgeDetection_Click(object sender, EventArgs e)
        {
            try
            {
                AddMatToListAndShow(CannyEdgeDetect(GetImageToProcess()));
            }
            catch (ProcessCanceledException)
            {

            }
        }

        /// <summary>
        /// Sobel边缘检测
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SobelEdgeDetection_Click(object sender, EventArgs e)
        {
            try
            {
                AddMatToListAndShow(SobelEdgeDetect(GetImageToProcess()));
            }
            catch (ProcessCanceledException)
            {

            }
        }

        /// <summary>
        /// Mean 均值门限分割
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void meanThresholdSegButton_Click(object sender, EventArgs e)
        {
            try
            {
                AddMatToListAndShow(MeanThresholdSeg(GetImageToProcess()).GreaterThan(0));
            }
            catch (ProcessCanceledException)
            {

            }
            catch (NotGrayImageException)
            {
                MessageBox.Show(@"非灰度化图像");
            }
        }

        /// <summary>
        /// Gaussian 高斯门限分割
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GaussianThresholdSegButton_Click(object sender, EventArgs e)
        {
            try
            {
                AddMatToListAndShow(GaussianThresholdSeg(GetImageToProcess()).GreaterThan(0));
            }
            catch (ProcessCanceledException)
            {

            }
            catch (NotGrayImageException)
            {
                MessageBox.Show(@"非灰度图像");
            }
        }

        /// <summary>
        /// Otsu门限分割
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OtsuSegButton_Click(object sender, EventArgs e)
        {
            try
            {
                AddMatToListAndShow(OtsuSeg(GetImageToProcess()));
            }
            catch (NotGrayImageException)
            {
                MessageBox.Show(@"非灰度化图像");
            }
        }

        /// <summary>
        /// 傅里叶变换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DFTTransformButton_Click(object sender, EventArgs e)
        {
            // Try to cast the sender to a ToolStripItem
            if (sender is ToolStripItem menuItem)
            {
                // Retrieve the ContextMenuStrip that owns this ToolStripItem
                if (menuItem.Owner is ContextMenuStrip owner)
                {
                    // Get the control that is displaying this context menu
                    Control sourceControl = owner.SourceControl;
                    if (sourceControl == leftPictureBox && WorkingMats.Count >= 1)
                    {
                        using Window dftWindow = new Window("Spectrum Magnitude",WindowMode.KeepRatio | WindowMode.AutoSize);
                        try
                        {
                            Cv2.ImShow("Spectrum Magnitude", DftTransform(WorkingLeftMat));
                        }
                        catch (NotGrayImageException)
                        {
                            MessageBox.Show(@"非灰度化图像");
                        }
                    }
                    else if (sourceControl == rightPictureBox && WorkingMats.Count >= 2)
                    {
                        using Window dftWindow = new Window("Spectrum Magnitude", WindowMode.KeepRatio | WindowMode.AutoSize);
                        try
                        {
                            Cv2.ImShow("Spectrum Magnitude", DftTransform(WorkingRightMat));
                        }
                        catch (NotGrayImageException)
                        {
                            MessageBox.Show(@"非灰度化图像");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 小波变换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void waveletTransformButton_Click(object sender, EventArgs e)
        {
            //TODO
            NotImplemented();
        }

        /// <summary>
        /// 特征提取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void featureExtractButton_Click(object sender, EventArgs e)
        {
            //TODO
            NotImplemented();
        }

        /// <summary>
        /// 人脸定位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void faceLocateButton_Click(object sender, EventArgs e)
        {
            //TODO
            NotImplemented();
        }

        /// <summary>
        /// 显示灰度直方图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showHistogramButton_Click(object sender, EventArgs e)
        {
            

            // Try to cast the sender to a ToolStripItem
            if (sender is ToolStripItem menuItem)
            {
                // Retrieve the ContextMenuStrip that owns this ToolStripItem
                if (menuItem.Owner is ContextMenuStrip owner)
                {
                    // Get the control that is displaying this context menu
                    Control sourceControl = owner.SourceControl;
                    if (sourceControl == leftPictureBox && WorkingMats.Count >= 1)
                    {
                        try
                        {
                            using (new Window("Histogram", WindowMode.KeepRatio | WindowMode.AutoSize, Histogram(WorkingLeftMat)))
                            {
                                Cv2.WaitKey();
                            }
                        }
                        catch (NotGrayImageException)
                        {
                            MessageBox.Show(@"非灰度化图像");
                        }
                    }
                    else if (sourceControl == rightPictureBox && WorkingMats.Count >= 2)
                    {
                        try
                        {
                            using (new Window("Histogram", WindowMode.KeepRatio | WindowMode.AutoSize, Histogram(WorkingRightMat)))
                            {
                                Cv2.WaitKey();
                            }
                        }
                        catch (NotGrayImageException)
                        {
                            MessageBox.Show(@"非灰度化图像");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Star特征提取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void starDetectorButton_Click(object sender, EventArgs e)
        {
            var img = GetImageToProcess();
            var newImg = img.Clone();
            var gray = ConvertToGrayMat(img);
            var detector = StarDetector.Create(45);

            KeyPoint[] keyPoints = detector.Detect(gray);

            foreach (KeyPoint kpt in keyPoints)
            {
                var color = new Scalar(0, 255, 0);
                float r = kpt.Size / 2;
                Cv2.Circle(newImg, (Point)kpt.Pt, (int)r, color, 1, LineTypes.Link8, 0);
                Cv2.Line(newImg,
                    (Point)new Point2f(kpt.Pt.X + r, kpt.Pt.Y + r),
                    (Point)new Point2f(kpt.Pt.X - r, kpt.Pt.Y - r),
                    color, 1, LineTypes.Link8, 0);
                Cv2.Line(newImg,
                    (Point)new Point2f(kpt.Pt.X - r, kpt.Pt.Y + r),
                    (Point)new Point2f(kpt.Pt.X + r, kpt.Pt.Y - r),
                    color, 1, LineTypes.Link8, 0);
            }
            AddMatToListAndShow(newImg);
        }

        /// <summary>
        /// ORB和FREAK特征提取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ORBandFREAK_Click(object sender, EventArgs e)
        {
            // ORB
            Mat img = GetImageToProcess();
            Mat newImg = img.Clone();
            Mat gray = ConvertToGrayMat(img);
            ORB orb = ORB.Create(1000);
            KeyPoint[] keyPoints = orb.Detect(gray);

            // FREAK
            FREAK freak = FREAK.Create();
            Mat freakDescriptors = new Mat();
            freak.Compute(gray, ref keyPoints, freakDescriptors);


            var color = new Scalar(0, 255, 0);
            foreach (KeyPoint kpt in keyPoints)
            {
                float r = kpt.Size / 2;
                Cv2.Circle(newImg, (Point)kpt.Pt, (int)r, color, 1, LineTypes.Link8, 0);
                Cv2.Line(newImg,
                    (Point)new Point2f(kpt.Pt.X + r, kpt.Pt.Y + r),
                    (Point)new Point2f(kpt.Pt.X - r, kpt.Pt.Y - r),
                    color, 1, LineTypes.Link8, 0);
                Cv2.Line(newImg,
                    (Point)new Point2f(kpt.Pt.X - r, kpt.Pt.Y + r),
                    (Point)new Point2f(kpt.Pt.X + r, kpt.Pt.Y - r),
                    color, 1, LineTypes.Link8, 0);
            }
            AddMatToListAndShow(newImg);
        }
    }
}