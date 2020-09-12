using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using OpenCvSharp;
using Size = OpenCvSharp.Size;

namespace opencv
{
    public partial class MainForm : Form
    {
        private readonly List<List<Mat>> _workingProcess = new List<List<Mat>>();
        private readonly List<PairIndices> _indicesProcess = new List<PairIndices>();
        private int _currentProcessIndex = -1;

        internal sealed class PairIndices
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
        }

        #region Methods

        /// <summary>
        /// 显示空图片
        /// </summary>
        /// <param name="pb"></param>
        private void LoadNoneImg(PictureBox pb)
        {
            pb.Image = _noneImage;
            if (leftPictureBox == pb)
            {
                right_picture_label.Text = $@"第 {_currentProcessIndex + 1} 行 第 {BoxIndices.LeftIndex + 1} 列";
            }
            else
            {
                left_pircture_label.Text = $@"第 {_currentProcessIndex + 1} 行 第 {BoxIndices.RightIndex + 1} 列";
            }
        }

        private readonly Image _noneImage =
            Image.FromFile(Directory.GetCurrentDirectory() + "..\\..\\..\\..\\Resources\\none.jpg");

        /// <summary>
        /// 当前图片序列
        /// </summary>
        private List<Mat> WorkingImages => _workingProcess[_currentProcessIndex];

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
        private Mat WorkingLeftImg
        {
            get
            {
                if (BoxIndices.LeftIndex >= WorkingImages.Count || BoxIndices.LeftIndex < 0)
                {
                    return OpenCvSharp.Extensions.BitmapConverter.ToMat((Bitmap)_noneImage);
                }
                else
                {
                    return WorkingImages[BoxIndices.LeftIndex];
                }
            }
            set
            {
                if (BoxIndices.LeftIndex >= WorkingImages.Count || BoxIndices.LeftIndex < 0)
                {
                    throw new InvalidOperationException();
                }
                else
                {
                    WorkingImages[BoxIndices.LeftIndex] = value;
                }
            }
        }

        /// <summary>
        /// 当前处理右图片
        /// </summary>
        private Mat WorkingRightImg
        {
            get
            {
                if (BoxIndices.RightIndex >= WorkingImages.Count || BoxIndices.RightIndex < 0)
                {
                    return OpenCvSharp.Extensions.BitmapConverter.ToMat((Bitmap)_noneImage);
                }
                else
                {
                    return WorkingImages[BoxIndices.RightIndex];
                }
            }
            set
            {
                if (BoxIndices.RightIndex >= WorkingImages.Count || BoxIndices.RightIndex < 0)
                {
                    throw new InvalidOperationException();
                }
                else
                {
                    WorkingImages[BoxIndices.RightIndex] = value;
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
            pb.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(GetBoxFittedMat(m));
            if (leftPictureBox == pb)
            {
                right_picture_label.Text = $@"第 {_currentProcessIndex+1} 行 第 {BoxIndices.LeftIndex + 1} 列";
            }
            else
            {
                left_pircture_label.Text = $@"第 {_currentProcessIndex + 1} 行 第 {BoxIndices.RightIndex + 1} 列";
            }

            //Methods:
            Mat GetBoxFittedMat(Mat image)
            {
                var (row, col) = ComputeSize(image.Rows, image.Cols,
                    leftPictureBox.Size.Height, leftPictureBox.Size.Width);
                return image.Resize(new Size(row, col), 0, 0, InterpolationFlags.Cubic);

            }
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
            pre_process.Enabled = true;
            upButton.Enabled = true;
            downButton.Enabled = true;
            add_noise.Enabled = true;
            de_noise.Enabled = true;
            fortify.Enabled = true;
            edge.Enabled = true;
            seg.Enabled = true;
            DFT.Enabled = true;
            file_save_second.Enabled = true;
            file_save_first.Enabled = true;
            wavelet.Enabled = true;
            feature_detect.Enabled = true;
            object_recognize.Enabled = true;
            color_fortify.Enabled = true;
            leftButton.Enabled = true;
            rightButton.Enabled = true;
            clearButton.Enabled = true;
            reverseButton.Enabled = true;
        }

        /// <summary>
        /// 禁用所有按钮(除加载图片)
        /// </summary>
        private void DisableAllButtons()
        {
            pre_process.Enabled = false;
            upButton.Enabled = false;
            downButton.Enabled = false;
            add_noise.Enabled = false;
            de_noise.Enabled = false;
            fortify.Enabled = false;
            edge.Enabled = false;
            seg.Enabled = false;
            DFT.Enabled = false;
            file_save_second.Enabled = false;
            file_save_first.Enabled = false;
            wavelet.Enabled = false;
            feature_detect.Enabled = false;
            object_recognize.Enabled = false;
            color_fortify.Enabled = false;
            leftButton.Enabled = false;
            rightButton.Enabled = false;
            clearButton.Enabled = false;
            reverseButton.Enabled = false;
        }

        /// <summary>
        /// 垂直移动检查按钮禁用情况
        /// </summary>
        private Tuple<bool,bool> VerticalCheck()
        {
            if (_currentProcessIndex <= 0) upButton.Enabled = false;
            else upButton.Enabled = true;
            if (_currentProcessIndex + 1 == _workingProcess.Count) downButton.Enabled = false;
            else downButton.Enabled = true;
            return new Tuple<bool, bool>(upButton.Enabled,downButton.Enabled);
        }

        /// <summary>
        /// 水平移动检查按钮禁用情况
        /// </summary>
        private Tuple<bool,bool> HorizontalCheck()
        {

            return new Tuple<bool, bool>(leftButton.Enabled,rightButton.Enabled);
        }

        /// <summary>
        /// 获取待处理的图片
        /// </summary>
        /// <returns></returns>
        private Mat GetImageToProcess()
        {
            Mat originImg;
            if (WorkingImages.Count <= BoxIndices.RightIndex)
            {
                originImg = WorkingLeftImg;
            }
            else
            {
                originImg = WorkingRightImg;
            }
            return originImg;
        }

        /// <summary>
        /// 处理结果保存并显示
        /// </summary>
        /// <param name="img"></param>
        /// <param name="resImg"></param>
        private void AddImageToListAndShow(Mat img)
        {
            WorkingImages.Add(img);

            if (BoxIndices.RightIndex + 1 < WorkingImages.Count)
            {
                BoxIndices.LeftIndex++;
                BoxIndices.RightIndex++;
            }

            ShowMat(leftPictureBox, WorkingLeftImg);
            ShowMat(rightPictureBox, WorkingRightImg);
            HorizontalCheck();
        }

        #endregion

        #region Buttons
        
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

                var originImg = new Mat(openFileDialog1.FileName);
                //Mat resizedImg = GetBoxFittedImg(originImg);
                WorkingImages.Add(originImg);

                ShowMat(leftPictureBox, originImg);
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


                ShowMat(leftPictureBox, WorkingLeftImg);
                ShowMat(rightPictureBox, WorkingRightImg);
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
            Mat grayImg, resGrayImg;
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
            ShowMat(leftPictureBox,WorkingLeftImg);
            ShowMat(rightPictureBox,WorkingRightImg);
            VerticalCheck();
            HorizontalCheck();
        }

        /// <summary>
        /// 下移一行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownButton_Click(object sender, EventArgs e)
        {
            _currentProcessIndex++;
            ShowMat(leftPictureBox, WorkingLeftImg);
            ShowMat(rightPictureBox, WorkingRightImg);
            VerticalCheck();
            HorizontalCheck();
        }

        /// <summary>
        /// 两张图片左移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Left_Click(object sender, EventArgs e)
        {

            HorizontalCheck();
        }

        /// <summary>
        /// 两张图片右移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Right_Click(object sender, EventArgs e)
        {

            HorizontalCheck();
        }

        /// <summary>
        /// 保存第二张图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveSecondButton_Click(object sender, EventArgs e)
        {
            var res = saveFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                OpenCvSharp.Extensions.BitmapConverter.ToBitmap(WorkingRightImg).Save(saveFileDialog1.FileName);
            }
        }

        /// <summary>
        /// 保存第一张图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveFirstButton_Click(object sender, EventArgs e)
        {
            var res = saveFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {

                OpenCvSharp.Extensions.BitmapConverter.ToBitmap(WorkingLeftImg).Save(saveFileDialog1.FileName);
            }
        }

        /// <summary>
        /// 撤销
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReverseButton_Click(object sender, EventArgs e)
        {
            if (WorkingImages.Count >= 2)
            {
                var checkWindow = new WarningPopUp(@"确认撤销?");
                var res = checkWindow.ShowDialog();
                if (res == DialogResult.OK)
                {
                    if (WorkingImages.Count > 2)
                    {
                        WorkingImages.RemoveAt(BoxIndices.RightIndex);
                        BoxIndices.LeftIndex--;
                        BoxIndices.RightIndex--;
                        ShowMat(leftPictureBox, WorkingLeftImg);
                        ShowMat(rightPictureBox, WorkingRightImg);
                    }

                    if (WorkingImages.Count == 2)
                    {
                        WorkingImages.RemoveAt(BoxIndices.RightIndex);
                        ShowMat(leftPictureBox, WorkingLeftImg);
                        ShowMat(rightPictureBox, WorkingRightImg);
                    }
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
                var blurImg = originImg.Clone();
                blurImg.MedianBlur(inputWindow.Size);

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
                var blurImg = originImg.Clone();
                Size s = new Size(inputWindow.H, inputWindow.W);
                blurImg.Blur(s);

                AddImageToListAndShow(blurImg);
            }
        }

        /// <summary>
        /// 快捷键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers != Keys.Control)
            {
                return;
            }
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (VerticalCheck().Item1)
                    {
                        UpButton_Click(this, EventArgs.Empty);
                    }
                    break;
                case Keys.Down:
                    if (VerticalCheck().Item2)
                    {
                        DownButton_Click(this, EventArgs.Empty);
                    }
                    break;
                case Keys.Left:
                    if (HorizontalCheck().Item1)
                    {
                        Left_Click(this, EventArgs.Empty);
                    }
                    break;
                case Keys.Right:
                    if (HorizontalCheck().Item2)
                    {
                        Right_Click(this, EventArgs.Empty);
                    }
                    break;
                case Keys.S:
                    if (BoxIndices.RightIndex < WorkingImages.Count)
                    {
                        SaveSecondButton_Click(this, EventArgs.Empty);
                    }
                    else
                    {
                        MessageBox.Show(@"不能保存空图片");
                    }
                    break;
                case Keys.Z:
                    ReverseButton_Click(this,EventArgs.Empty);
                    break;
            }
        }

        #endregion
    }
}
