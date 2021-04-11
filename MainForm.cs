using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using static opencv.ImageProcessing;

namespace opencv
{
    public partial class MainForm : Form
    {
        private readonly List<List<Mat>> _workingMatsProcesses = new List<List<Mat>>();
        private int _currentProcessIndex = -1;

        public static readonly Mat NoneMat =
            ((Bitmap) Image.FromFile(Directory.GetCurrentDirectory() + "..\\..\\..\\..\\Resources\\none.jpg")).ToMat();

        public MainForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            LoadNoneImg(leftPictureBox);
            LoadNoneImg(rightPictureBox);
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
                    0 => NoneMat,
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
                    return NoneMat;
                }
                else
                {
                    return WorkingMats[^1];
                }
            }
        }

        /// <summary>
        /// 显示空图片
        /// </summary>
        /// <param name="pb"></param>
        private void LoadNoneImg(PictureBox pb)
        {
            ShowMat(pb, NoneMat);
        }

        /// <summary>
        /// Resize Mat 并显示到PictureBox
        /// </summary>
        /// <param name="pb"></param>
        /// <param name="m"></param>
        private void ShowMat(PictureBox pb, Mat m)
        {
            pb.Image = GetBoxFittedMat(m,leftPictureBox).ToBitmap();
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
            else
            {
                throw new InvalidOperationException();
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
            pseudoColorFortifyButton.Enabled = true;
            clearButton.Enabled = true;
            reverseButton.Enabled = true;
            imagesListButton.Enabled = true;
            overwriteButton.Enabled = true;
            DFTTransformButton.Enabled = true;
            waveletTransformButton.Enabled = true;
            rightClickSave.Enabled = true;
            showHitogramButton.Enabled = true;
            phtoFilterButton.Enabled = true;
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
            pseudoColorFortifyButton.Enabled = false;
            clearButton.Enabled = false;
            reverseButton.Enabled = false;
            imagesListButton.Enabled = false;
            overwriteButton.Enabled = false;
            DFTTransformButton.Enabled = false;
            waveletTransformButton.Enabled = false;
            rightClickSave.Enabled = false;
            showHitogramButton.Enabled = false;
            phtoFilterButton.Enabled = false;
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
        private Mat GetMatToProcess()
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
                var removedList = _workingMatsProcesses[_currentProcessIndex];
                foreach (Mat mat in removedList)
                {
                    mat.Dispose();
                }
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
                        WorkingMats[^1].Dispose();
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
                            "ctrl + ENTER: 弹窗确认\n" +
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
                    WorkingMats[^2].Dispose();
                    WorkingMats.RemoveAt(WorkingMats.Count - 2);
                    ShowMat(leftPictureBox, WorkingLeftMat);
                    ShowMat(rightPictureBox, WorkingRightMat);
                }
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
            var originImg = GetMatToProcess();
            var grayImg = NewGrayMat(originImg);
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
                AddMatToListAndShow(AddGaussianNoise(GetMatToProcess()));
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
                AddMatToListAndShow(AddUniformNoise(GetMatToProcess()));
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
                AddMatToListAndShow(AddSaltAndPepperNoise(GetMatToProcess()));
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
                AddMatToListAndShow(MedianBlur(GetMatToProcess()));
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
                AddMatToListAndShow(AverageBlur(GetMatToProcess()));
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
                AddMatToListAndShow(GaussianBlur(GetMatToProcess()));
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
                AddMatToListAndShow(GetMatToProcess().EqualizeHist());
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
                AddMatToListAndShow(LaplacianSharpen(GetMatToProcess()));
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
                AddMatToListAndShow(SobelSharpen(GetMatToProcess()));
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
            try
            {
                AddMatToListAndShow(HomoFilter(GetMatToProcess()));
            }
            catch (NotGrayImageException)
            {
                MessageBox.Show(@"非灰度化图像");
            }
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
                AddMatToListAndShow(PseudoColorFortify(GetMatToProcess()));
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
            AddMatToListAndShow(LaplacianEdgeDetect(GetMatToProcess()));
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
                AddMatToListAndShow(CannyEdgeDetect(GetMatToProcess()));
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
                AddMatToListAndShow(SobelEdgeDetect(GetMatToProcess()));
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
                AddMatToListAndShow(MeanThresholdSeg(GetMatToProcess()));
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
                AddMatToListAndShow(GaussianThresholdSeg(GetMatToProcess()));
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
                AddMatToListAndShow(OtsuSeg(GetMatToProcess()));
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
                        using Window dftWindow = new Window("Spectrum Magnitude",
                            WindowMode.KeepRatio | WindowMode.AutoSize);
                        try
                        {
                            Cv2.ImShow("Spectrum Magnitude", DftTransform(WorkingLeftMat));
                        }
                        catch (NotGrayImageException)
                        {
                            Cv2.DestroyWindow("Spectrum Magnitude");
                            MessageBox.Show(@"非灰度化图像");
                        }
                    }
                    else if (sourceControl == rightPictureBox && WorkingMats.Count >= 2)
                    {
                        using Window dftWindow = new Window("Spectrum Magnitude",
                            WindowMode.KeepRatio | WindowMode.AutoSize);
                        try
                        {
                            Cv2.ImShow("Spectrum Magnitude", DftTransform(WorkingRightMat));
                        }
                        catch (NotGrayImageException)
                        {
                            Cv2.DestroyWindow("Spectrum Magnitude");
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
                        using Window dftWindow = new Window("Wavelet", WindowMode.KeepRatio | WindowMode.AutoSize);
                        Cv2.ImShow("Wavelet", WaveletTransform(WorkingLeftMat));
                    }
                    else if (sourceControl == rightPictureBox && WorkingMats.Count >= 2)
                    {
                        using Window dftWindow = new Window("Wavelet", WindowMode.KeepRatio | WindowMode.AutoSize);
                        Cv2.ImShow("Wavelet", WaveletTransform(WorkingRightMat));
                    }
                }
            }
        }

        /// <summary>
        /// 人脸定位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void faceLocateButton_Click(object sender, EventArgs e)
        {
            AddMatToListAndShow(FaceLocate(GetMatToProcess()));
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
                            using (new Window("Histogram", WindowMode.KeepRatio | WindowMode.AutoSize,
                                Histogram(WorkingLeftMat)))
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
                            using (new Window("Histogram", WindowMode.KeepRatio | WindowMode.AutoSize,
                                Histogram(WorkingRightMat)))
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
            AddMatToListAndShow(StarFeatureDetect(GetMatToProcess()));
        }

        /// <summary>
        /// ORB和FREAK特征提取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ORBandFREAK_Click(object sender, EventArgs e)
        {
            AddMatToListAndShow(ORBandFREAKFeatureDetect(GetMatToProcess()));
        }

        /// <summary>
        /// BRISK特征提取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BRISKButton_Click(object sender, EventArgs e)
        {
            AddMatToListAndShow(BRISKFeatureDetect(GetMatToProcess()));
        }

        /// <summary>
        /// MSER特征检测
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MSERFeatureDetectButton_Click(object sender, EventArgs e)
        {
            AddMatToListAndShow(MSERFeatureDetect(GetMatToProcess()));
        }

        /// <summary>
        /// 动漫化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cartoonButton_Click(object sender, EventArgs e)
        {
            Mat res = new Mat();
            Cv2.EdgePreservingFilter(GetMatToProcess(), res);
            AddMatToListAndShow(res);
        }

        /// <summary>
        /// 细节增强
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void detailEnhanceButton_Click(object sender, EventArgs e)
        {
            Mat res = new Mat();
            try
            {
                Cv2.DetailEnhance(GetMatToProcess(), res);
            }
            catch (OpenCVException)
            {
                MessageBox.Show(@"图片不能是灰度图像");
                return;
            }
            AddMatToListAndShow(res);
        }

        /// <summary>
        /// 素描
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pencilSketchButton_Click(object sender, EventArgs e)
        {
            Mat res = new Mat();
            using Mat _ = new Mat();
            try
            {
                Cv2.PencilSketch(GetMatToProcess(), _, res);
            }
            catch (OpenCVException)
            {
                MessageBox.Show(@"图片不能是灰度图像");
                return;
            }
            AddMatToListAndShow(res);
        }

        /// <summary>
        /// 油画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stylizationButton_Click(object sender, EventArgs e)
        {
            Mat res = new Mat();
            Cv2.Stylization(GetMatToProcess(), res);
            AddMatToListAndShow(res);
        }
    }
}