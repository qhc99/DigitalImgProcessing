using System;
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
        private readonly List<List<Mat>> _workingProcess = new List<List<Mat>>();
        private readonly List<PairIndices> _indicesProcess = new List<PairIndices>();
        private int _currentProcessIndex = -1;

        public sealed class PairIndices
        {
            public int LeftIndex;
            public int RightIndex;

            public PairIndices(int l, int r)
            {
                LeftIndex = l;
                RightIndex = r;
            }
        }

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
            ShowMat(pb,none);
            if (leftPictureBox == pb)
            {
                right_picture_label.Text = $@"第 {_currentProcessIndex + 1} 行 第 {BoxIndices.LeftIndex + 1} 列";
            }
            else
            {
                left_picture_label.Text = $@"第 {_currentProcessIndex + 1} 行 第 {BoxIndices.RightIndex + 1} 列";
            }
        }

        private readonly Image _noneImage =
            Image.FromFile(Directory.GetCurrentDirectory() + "..\\..\\..\\..\\Resources\\none.jpg");

        private void NotImplemented()
        {
            MessageBox.Show(@"为实现此功能");
        }

        /// <summary>
        /// 当前图片序列
        /// </summary>
        private List<Mat> WorkingMats => _workingProcess[_currentProcessIndex];

        /// <summary>
        /// 当前序列索引
        /// </summary>
        private PairIndices BoxIndices
        {
            get
            {
                if (_currentProcessIndex == -1)
                {
                    return new PairIndices(-1,-1);
                }
                else
                {
                    return _indicesProcess[_currentProcessIndex];
                }
            }
            set
            {
                if (_currentProcessIndex == -1)
                {
                    throw new InvalidOperationException();
                }
                else
                {
                    _indicesProcess[_currentProcessIndex] = value;
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
                if (BoxIndices.LeftIndex >= WorkingMats.Count || BoxIndices.LeftIndex < 0)
                {
                    return ((Bitmap)_noneImage).ToMat();
                }
                else
                {
                    return WorkingMats[BoxIndices.LeftIndex];
                }
            }
            set
            {
                if (BoxIndices.LeftIndex >= WorkingMats.Count || BoxIndices.LeftIndex < 0)
                {
                    throw new InvalidOperationException();
                }
                else
                {
                    WorkingMats[BoxIndices.LeftIndex] = value;
                }
            }
        }

        /// <summary>
        /// 当前处理右图片
        /// </summary>
        private Mat WorkingRightMat
        {
            get
            {
                if (BoxIndices.RightIndex >= WorkingMats.Count || BoxIndices.RightIndex < 0)
                {
                    return ((Bitmap)_noneImage).ToMat();
                }
                else
                {
                    return WorkingMats[BoxIndices.RightIndex];
                }
            }
            set
            {
                if (BoxIndices.RightIndex >= WorkingMats.Count || BoxIndices.RightIndex < 0)
                {
                    throw new InvalidOperationException();
                }
                else
                {
                    WorkingMats[BoxIndices.RightIndex] = value;
                }
            }
        }

        /// <summary>
        /// 显示到PictureBox
        /// </summary>
        /// <param name="pb"></param>
        /// <param name="m"></param>
        private void ShowMat(PictureBox pb, Mat m)
        {
            pb.Image = GetBoxFittedMat(m).ToBitmap();
            if (leftPictureBox == pb)
            {
                left_picture_label.Text = $@"第 {_currentProcessIndex + 1} 行 第 {BoxIndices.LeftIndex + 1} 列";
                leftPictureSize.Text = $@"H:{m.Height} W:{m.Width}";
            }
            else
            {
                right_picture_label.Text = $@"第 {_currentProcessIndex + 1} 行 第 {BoxIndices.RightIndex + 1} 列";
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
                    double ratio = ((double)imgRow) / imgCol;
                    //newRow/newCol = imgRow/imgCol
                    if (imgRow > boxRow)
                    {
                        return new Tuple<int, int>(boxRow, (int)(boxRow / ratio));
                    }
                    else
                    {
                        return new Tuple<int, int>((int)(ratio * boxCol), boxCol);
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
            deNoiseButton.Enabled = true;
            fortifyButton.Enabled = true;
            edgeButton.Enabled = true;
            segButton.Enabled = true;
            DFTButton.Enabled = true;
            saveSecondFileButton.Enabled = true;
            saveFirstFileButton.Enabled = true;
            waveletButton.Enabled = true;
            featureDetectButton.Enabled = true;
            objectRecognizeButton.Enabled = true;
            colorFortifyButton.Enabled = true;
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
            deNoiseButton.Enabled = false;
            fortifyButton.Enabled = false;
            edgeButton.Enabled = false;
            segButton.Enabled = false;
            DFTButton.Enabled = false;
            saveSecondFileButton.Enabled = false;
            saveFirstFileButton.Enabled = false;
            waveletButton.Enabled = false;
            featureDetectButton.Enabled = false;
            objectRecognizeButton.Enabled = false;
            colorFortifyButton.Enabled = false;
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
            if (_currentProcessIndex + 1 == _workingProcess.Count) downButton.Enabled = false;
            else downButton.Enabled = true;
        }

        /// <summary>
        /// 获取待处理的图片
        /// </summary>
        /// <returns></returns>
        private Mat GetImageToProcess()
        {
            Mat originImg;
            if (WorkingMats.Count <= BoxIndices.RightIndex)
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
        private void AddImageToListAndShow(Mat img)
        {
            WorkingMats.Add(img);

            if (BoxIndices.RightIndex + 1 < WorkingMats.Count)
            {
                BoxIndices.LeftIndex++;
                BoxIndices.RightIndex++;
            }

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
                _workingProcess.Add(new List<Mat>());
                _indicesProcess.Add(new PairIndices(0,1));

                LoadNoneImg(leftPictureBox);
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
                _workingProcess.RemoveAt(_currentProcessIndex);
                _indicesProcess.RemoveAt(_currentProcessIndex);
                _currentProcessIndex--;
                if (_currentProcessIndex == -1)
                {
                    if (_workingProcess.Count == 0)
                    {
                        LoadNoneImg(leftPictureBox);
                        LoadNoneImg(rightPictureBox);
                        if (_workingProcess.Count == 0)
                        {
                            DisableAllButtons();
                        }
                        return;
                    }
                    else
                    {
                        _currentProcessIndex++;
                    }
                }


                ShowMat(leftPictureBox, WorkingLeftMat);
                ShowMat(rightPictureBox, WorkingRightMat);
                VerticalCheck();
                if (_workingProcess.Count == 0)
                {
                    DisableAllButtons();
                }
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

            AddImageToListAndShow(grayImg);
        }

        /// <summary>
        /// 上移一行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpButton_Click(object sender, EventArgs e)
        {
            _currentProcessIndex--;
            ShowMat(leftPictureBox,WorkingLeftMat);
            ShowMat(rightPictureBox,WorkingRightMat);
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
        /// 撤销
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
                    if (WorkingMats.Count > 2)
                    {
                        WorkingMats.RemoveAt(BoxIndices.RightIndex);
                        BoxIndices.LeftIndex--;
                        BoxIndices.RightIndex--;
                        ShowMat(leftPictureBox, WorkingLeftMat);
                        ShowMat(rightPictureBox, WorkingRightMat);
                    }

                    if (WorkingMats.Count == 2)
                    {
                        WorkingMats.RemoveAt(BoxIndices.RightIndex);
                        ShowMat(leftPictureBox, WorkingLeftMat);
                        ShowMat(rightPictureBox, WorkingRightMat);
                    }
                }
            }
        }

        /// <summary>
        /// 查看图片序列
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imagesListButton_Click(object sender, EventArgs e)
        {
            var imagesForm = new ImagesListForm(WorkingMats,_indicesProcess[_currentProcessIndex]);
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
                        if (BoxIndices.RightIndex < WorkingMats.Count)
                        {
                            SaveSecondButton_Click(this, EventArgs.Empty);
                        }
                        else
                        {
                            MessageBox.Show(@"不能保存空图片");
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
                            overwrite_Click(this,EventArgs.Empty);
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
                            imagesListButton_Click(this,EventArgs.Empty);
                        }
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
            var inputWindow = new GaussianNoisePopUp();
            var dialogResult = inputWindow.ShowDialog();
            
            if (dialogResult == DialogResult.OK)
            {
                var originImg = GetImageToProcess();

                Mat gNoise = new Mat(originImg.Size(), originImg.Type());
                gNoise.Randn(inputWindow.Mean, inputWindow.Variance);

                Mat workRes = originImg + gNoise;

                AddImageToListAndShow(workRes);
            }
        }

        /// <summary>
        /// 加均值噪声
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddUniformNoise_Click(object sender, EventArgs e)
        {
            var inputWindow = new UniNoisePopUp();
            var dRest = inputWindow.ShowDialog();
            if (dRest == DialogResult.OK)
            {
                var originImg= GetImageToProcess();

                Mat uNoise = new Mat(originImg.Size(), originImg.Type());
                uNoise.Randu(inputWindow.Low,inputWindow.High);
                Mat workRes = originImg + uNoise;

                AddImageToListAndShow(workRes);
            }
        }

        /// <summary>
        /// 加脉冲噪声
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void add_impulse_noise_Click(object sender, EventArgs e)
        {
            NotImplemented();
        }

        /// <summary>
        /// 中值滤波
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MedianBlur_Click(object sender, EventArgs e)
        {
            var inputWindow = new MedianBlurPopUp();
            var dRes = inputWindow.ShowDialog();
            if (dRes == DialogResult.OK)
            {
                var originImg = GetImageToProcess();
                var blurImg = originImg.MedianBlur(inputWindow.WindowSize);
                AddImageToListAndShow(blurImg);
            }
        }

        /// <summary>
        /// 均值滤波
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AverageBlur_Click(object sender, EventArgs e)
        {
            var inputWindow = new AverageBlurPopUp();
            var dRes = inputWindow.ShowDialog();
            if (dRes == DialogResult.OK)
            {
                var originImg = GetImageToProcess();
                var blurImg = originImg.Blur(new Size(inputWindow.H, inputWindow.W));
                AddImageToListAndShow(blurImg);
            }
        }

        /// <summary>
        /// 高斯滤波
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gaussian_blur_Click(object sender, EventArgs e)
        {
            NotImplemented();
        }

        /// <summary>
        /// 图片上右击保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rightClickSave_Click(object sender, EventArgs e)
        {
            if (sender is ContextMenuStrip owner)
            {
                Control sourceControl = owner.SourceControl;
                if (sourceControl == leftPictureBox && WorkingMats.Count >= 1)
                {
                    SaveMat(WorkingLeftMat);
                }
                else if (sourceControl == rightPictureBox && WorkingMats.Count >= 2)
                {
                    SaveMat(WorkingRightMat);
                }
            }
        }

        /// <summary>
        /// 显示快捷键提示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void shortCutHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ctrl + ↑: 上一个工作序列\n" +
                            "ctrl + ↓: 下一个工作序列\n" + 
                            "ctrl + s: 保存第二张图片\n" + 
                            "ctrl + z: 撤销一次处理操作\n" +
                            "ctrl + o: 覆盖上一张图片\n" +
                            "alt + v: 查看处理历史\n" + 
                            "ctrl + ←: 处理历史向左翻页\n" + 
                            "ctrl + →: 处理历史向右翻页");
        }

        /// <summary>
        /// 覆盖上一张图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void overwrite_Click(object sender, EventArgs e)
        {
            if (WorkingMats.Count == 2)
            {
                WorkingMats.RemoveAt(0);
                ShowMat(leftPictureBox,WorkingLeftMat);
                ShowMat(rightPictureBox,WorkingRightMat);
            }

            if (WorkingMats.Count >= 2)
            {
                WorkingMats.RemoveAt(BoxIndices.LeftIndex);
                BoxIndices.LeftIndex--;
                BoxIndices.RightIndex--;
                ShowMat(leftPictureBox, WorkingLeftMat);
                ShowMat(rightPictureBox, WorkingRightMat);
            }
        }
    }
}
