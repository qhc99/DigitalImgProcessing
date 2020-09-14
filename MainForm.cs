﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using Size = OpenCvSharp.Size;

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
            Mat none = ((Bitmap) _noneImage).ToMat();
            none.Resize(new Size(leftPictureBox.Height, leftPictureBox.Width));
            ShowMat(pb, none);
        }

        private readonly Image _noneImage =
            Image.FromFile(Directory.GetCurrentDirectory() + "..\\..\\..\\..\\Resources\\none.jpg");

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
                    0 => ((Bitmap) _noneImage).ToMat(),
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
                    return ((Bitmap) _noneImage).ToMat();
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
            return m.Resize(new Size(row, col), 0, 0, InterpolationFlags.Cubic);

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
            transformButton.Enabled = true;
            saveSecondFileButton.Enabled = true;
            saveFirstFileButton.Enabled = true;
            transformButton.Enabled = true;
            featureDetectButton.Enabled = true;
            videoProcessButton.Enabled = true;
            pseudoColorFortifyButton.Enabled = true;
            clearButton.Enabled = true;
            reverseButton.Enabled = true;
            imagesListButton.Enabled = true;
            overwriteButton.Enabled = true;
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
            transformButton.Enabled = false;
            saveSecondFileButton.Enabled = false;
            saveFirstFileButton.Enabled = false;
            transformButton.Enabled = false;
            featureDetectButton.Enabled = false;
            videoProcessButton.Enabled = false;
            pseudoColorFortifyButton.Enabled = false;
            clearButton.Enabled = false;
            reverseButton.Enabled = false;
            imagesListButton.Enabled = false;
            overwriteButton.Enabled = false;
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
        /// 灰度化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrayButton_Click(object sender, EventArgs e)
        {
            var originImg = GetImageToProcess();
            Mat grayImg;
            try
            {
                grayImg = originImg.CvtColor(ColorConversionCodes.BGR2GRAY, 1);
            }
            catch (OpenCVException)
            {
                //ignore
                return;
            }

            AddMatToListAndShow(grayImg);
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
        /// 加高斯噪声
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddGaussianNoise_Click(object sender, EventArgs e)
        {
            var inputWindow = new MeanVariancePopUp();
            var dialogResult = inputWindow.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                var originImg = GetImageToProcess();

                Mat gNoise = new Mat(originImg.Size(), originImg.Type());
                gNoise.Randn(inputWindow.Mean, inputWindow.Variance);

                Mat workRes = originImg + gNoise;

                AddMatToListAndShow(workRes);
            }
        }

        /// <summary>
        /// 加均值噪声
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddUniformNoise_Click(object sender, EventArgs e)
        {
            var inputWindow = new UpperLowerLimitPopUp();
            var dRest = inputWindow.ShowDialog();
            if (dRest == DialogResult.OK)
            {
                var originImg = GetImageToProcess();

                Mat uNoise = new Mat(originImg.Size(), originImg.Type());
                uNoise.Randu(inputWindow.Low, inputWindow.High);
                Mat workRes = originImg + uNoise;

                AddMatToListAndShow(workRes);
            }
        }

        /// <summary>
        /// 加椒盐噪声
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddImpulseNoise_Click(object sender, EventArgs e)
        {
            var inputWindow = new UpperLowerLimitPopUp();
            var dialogRes = inputWindow.ShowDialog();
            if (dialogRes == DialogResult.OK)
            {
                var originImg = GetImageToProcess();
                var addNoiseImg = originImg.Clone();

                Mat rand = Mat.Zeros(new Size(addNoiseImg.Height, addNoiseImg.Width), addNoiseImg.Type());
                rand.Randu(0, 255);
                Mat white = rand.LessThanOrEqual(inputWindow.Low);
                Mat black = rand.GreaterThanOrEqual(inputWindow.High);

                addNoiseImg -= black;
                addNoiseImg += white;

                AddMatToListAndShow(addNoiseImg);
            }
        }

        /// <summary>
        /// 中值滤波
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MedianBlur_Click(object sender, EventArgs e)
        {
            var inputWindow = new RectangleBoxSizePopUp();
            var dRes = inputWindow.ShowDialog();
            if (dRes == DialogResult.OK)
            {
                if (inputWindow.WindowSize % 2 == 0 || inputWindow.WindowSize < 3)
                {
                    MessageBox.Show(@"输入应为奇数并且>=3");
                    return;
                }

                var originImg = GetImageToProcess();
                var blurImg = originImg.MedianBlur(inputWindow.WindowSize);
                AddMatToListAndShow(blurImg);
            }
        }

        /// <summary>
        /// 均值滤波
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AverageBlur_Click(object sender, EventArgs e)
        {
            var inputWindow = new BoxHeightWidthPopUp();
            var dRes = inputWindow.ShowDialog();
            if (dRes == DialogResult.OK)
            {
                var originImg = GetImageToProcess();
                var blurImg = originImg.Blur(new Size(inputWindow.H, inputWindow.W));
                AddMatToListAndShow(blurImg);
            }
        }

        /// <summary>
        /// 高斯滤波
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GaussianBlur_Click(object sender, EventArgs e)
        {
            var inputWindow = new BoxHeightWidthPopUp();
            var dRes = inputWindow.ShowDialog();
            if (dRes == DialogResult.OK)
            {
                var originImg = GetImageToProcess();
                var blurImg = originImg.GaussianBlur(new Size(inputWindow.H, inputWindow.W), 0);
                AddMatToListAndShow(blurImg);
            }
        }

        /// <summary>
        /// 图片上右击保存
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
                            "alt + v: 查看图片序列\n" +
                            "alt + o: 打开图片\n" +
                            "ctrl + ←: 图片序列向左翻页\n" +
                            "ctrl + →: 图片序列向右翻页\n" +
                            "ESC: 关闭窗口");
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
            var inputWindow = new CoefficientAlphaPopUp();
            var dialogRes = inputWindow.ShowDialog();
            if (dialogRes == DialogResult.OK)
            {
                var originImg = GetImageToProcess();
                Mat newOriginImg = new Mat(originImg.Size(), MatType.CV_16S);
                originImg.ConvertTo(newOriginImg, MatType.CV_16S);
                // why minus works?
                Mat sharpenImg = newOriginImg - originImg.Laplacian(MatType.CV_16S) * inputWindow.Alpha;
                Mat resSharpenImg = new Mat(sharpenImg.Size(), MatType.CV_8U);
                sharpenImg.ConvertTo(resSharpenImg, MatType.CV_8U);
                AddMatToListAndShow(resSharpenImg);
            }
        }

        /// <summary>
        /// Sobel锐化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SobelSharpenButton_Click(object sender, EventArgs e)
        {
            var w = new SobelCoefficientPopUp();
            var dialogRes = w.ShowDialog();
            if (dialogRes == DialogResult.OK)
            {
                var img = GetImageToProcess();
                Mat newImg = new Mat(img.Size(), MatType.CV_16S);
                img.ConvertTo(newImg, MatType.CV_16S);
                // there plus works ?!
                Mat sharpenImg = newImg + img.Sobel(MatType.CV_16S, w.XOrder, w.YOrder, w.WindowSize) * w.Alpha;
                Mat resSharpenImg = new Mat(sharpenImg.Size(), MatType.CV_8U);
                sharpenImg.ConvertTo(resSharpenImg, MatType.CV_8U);
                AddMatToListAndShow(resSharpenImg);
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
            var w = new ColorMapComboPopUp();
            var dialogRes = w.ShowDialog();
            if (dialogRes == DialogResult.OK)
            {
                var img = GetImageToProcess();
                Mat cImg = new Mat(img.Size(), img.Type());
                Cv2.ApplyColorMap(img, cImg, w.SelectedTypes);
                AddMatToListAndShow(cImg);
            }
        }

        /// <summary>
        /// Laplacian边缘检测
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LaplacianEdgeDetection_Click(object sender, EventArgs e)
        {
            var originImg = GetImageToProcess();
            Mat newOriginImg = new Mat(originImg.Size(), MatType.CV_16S);
            originImg.ConvertTo(newOriginImg, MatType.CV_16S);
            Mat edgeImg = originImg.Laplacian(MatType.CV_16S);
            Mat resEdgeImg = new Mat(edgeImg.Size(), MatType.CV_8U);
            edgeImg.ConvertTo(resEdgeImg, MatType.CV_8U);
            AddMatToListAndShow(resEdgeImg);
        }

        /// <summary>
        /// Canny边缘检测
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CannyEdgeDetection_Click(object sender, EventArgs e)
        {
            var w = new UpperLowerLimitPopUp(true);
            var dialogRes = w.ShowDialog();
            if (dialogRes == DialogResult.OK)
            {
                var img = GetImageToProcess();
                Mat edgeImg = img.Canny(w.Low, w.High, w.ApertureSize);
                AddMatToListAndShow(edgeImg);
            }
        }

        /// <summary>
        /// Sobel边缘检测
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SobelEdgeDetection_Click(object sender, EventArgs e)
        {
            var w = new SobelCoefficientPopUp(true);
            var dialogRes = w.ShowDialog();
            if (dialogRes == DialogResult.OK)
            {
                var img = GetImageToProcess();
                Mat newImg = new Mat(img.Size(), MatType.CV_16S);
                img.ConvertTo(newImg, MatType.CV_16S);
                Mat edgeImg = img.Sobel(MatType.CV_16S, w.XOrder, w.YOrder, w.WindowSize);
                Mat resEdgeImg = new Mat(edgeImg.Size(), MatType.CV_8U);
                edgeImg.ConvertTo(resEdgeImg, MatType.CV_8U);
                AddMatToListAndShow(resEdgeImg);
            }
        }

        /// <summary>
        /// Mean 均值门限分割
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void meanThresholdSegButton_Click(object sender, EventArgs e)
        {
            var w = new AdaptiveSegmentationComboPopUp();
            var dialogRes = w.ShowDialog();
            if (dialogRes == DialogResult.OK)
            {
                var img = GetImageToProcess();
                Mat seg;
                try
                {
                    seg = img.AdaptiveThreshold(255, AdaptiveThresholdTypes.MeanC, w.SelectedTypes, w.WindowSize,
                        w.Constant);
                }
                catch (OpenCVException)
                {
                    MessageBox.Show(@"非灰度图像");
                    return;
                }

                AddMatToListAndShow(seg.GreaterThan(0));
            }
        }

        /// <summary>
        /// Gaussian 高斯门限分割
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GaussianThresholdSegButton_Click(object sender, EventArgs e)
        {
            var w = new AdaptiveSegmentationComboPopUp();
            var dialogRes = w.ShowDialog();
            if (dialogRes == DialogResult.OK)
            {
                var img = GetImageToProcess();
                Mat seg;
                try
                {
                    seg = img.AdaptiveThreshold(255, AdaptiveThresholdTypes.GaussianC, w.SelectedTypes, w.WindowSize,
                        w.Constant);
                }
                catch (OpenCVException)
                {
                    MessageBox.Show(@"非灰度图像");
                    return;
                }

                AddMatToListAndShow(seg.GreaterThan(0));
            }
        }

        /// <summary>
        /// Otsu门限分割
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OtsuSegButton_Click(object sender, EventArgs e)
        {
            var img = GetImageToProcess();
            Mat otsuImg;
            try
            {
                otsuImg = img.Threshold(0, 255, ThresholdTypes.Binary | ThresholdTypes.Otsu);
            }
            catch (OpenCVException)
            {
                MessageBox.Show(@"非灰度化图像");
                return;
            }

            AddMatToListAndShow(otsuImg);
        }

        /// <summary>
        /// 傅里叶变换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DFTTransformButton_Click(object sender, EventArgs e)
        {
            var I = GetImageToProcess();
            Mat padded = new Mat(); //expand input image to optimal size
            int m = Cv2.GetOptimalDFTSize(I.Rows), n = Cv2.GetOptimalDFTSize(I.Cols); // on the border add zero values
            Cv2.CopyMakeBorder(I, padded, 0, m - I.Rows, 0, n - I.Cols, BorderTypes.Constant, Scalar.All(0));
            
            padded.ConvertTo(padded,MatType.CV_32F);
            Mat[] planes = {padded, Mat.Zeros(padded.Size(), MatType.CV_32F)};
            Mat complexI = new Mat();
            Cv2.Merge(planes,complexI);// Add to the expanded another plane with zeros
            
            try
            {
                Cv2.Dft(complexI, complexI);
            }
            catch (OpenCVException)
            {
                MessageBox.Show(@"非灰度化图像");
                return;
            }
            // this way the result may fit in the source matrix
            // compute the magnitude and switch to logarithmic scale
            // => log(1 + sqrt(Re(DFT(I))^2 + Im(DFT(I))^2))
            Cv2.Split(complexI, out planes); // planes.get(0) = Re(DFT(I)// planes.get(1) = Im(DFT(I))
            Cv2.Magnitude(planes[0],planes[1],planes[0]); // planes.get(0) = magnitude
            Mat magI = planes[0];
            
            Mat matOfOnes = Mat.Ones(magI.Size(), magI.Type());
            Cv2.Add(matOfOnes, magI, magI); // switch to logarithmic scale
            Cv2.Log(magI, magI);
            
            // crop the spectrum, if it has an odd number of rows or columns
            magI = new Mat(magI,new Rect(0, 0, magI.Cols & -2, magI.Rows & -2));
            int cx = magI.Cols / 2, cy = magI.Rows / 2;
            Mat q0 = new Mat(magI, new Rect(0, 0, cx, cy));   // Top-Left - Create a ROI per quadrant
            Mat q1 = new Mat(magI, new Rect(cx, 0, cx, cy));  // Top-Right
            Mat q2 = new Mat(magI, new Rect(0, cy, cx, cy));  // Bottom-Left
            Mat q3 = new Mat(magI, new Rect(cx, cy, cx, cy)); // Bottom-Right
            
            Mat tmp = new Mat();               // swap quadrants (Top-Left with Bottom-Right)
            q0.CopyTo(tmp);
            q3.CopyTo(q0);
            tmp.CopyTo(q3);
            
            q1.CopyTo(tmp);                    // swap quadrant (Top-Right with Bottom-Left)
            q2.CopyTo(q1);
            tmp.CopyTo(q2);
            
            magI.ConvertTo(magI, MatType.CV_8UC1);
            Cv2.Normalize(magI, magI, 0, 255, NormTypes.MinMax, MatType.CV_8UC1); 
            // Transform the matrix with float values
            // into a viewable image form (float between
            // values 0 and 255).
            
            AddMatToListAndShow(magI);
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
    }
}