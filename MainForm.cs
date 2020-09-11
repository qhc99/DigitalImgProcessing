using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using OpenCvSharp;
using Size = OpenCvSharp.Size;

namespace opencv
{
    public partial class MainForm : Form
    {
        private readonly List<List<Mat>> _workingProcess = new List<List<Mat>>();
        private readonly List<List<Mat>> _resultProcess = new List<List<Mat>>();
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
        }

        /// <summary>
        /// 显示空图片
        /// </summary>
        /// <param name="pb"></param>
        private void LoadNoneImg(PictureBox pb)
        {
            pb.Image = _noneImage;
            if (pictureBox1 == pb)
            {
                figure1_label.Text = $@"第 {_currentProcessIndex + 1} 行 第 {BoxIndices.LeftIndex + 1} 列";
            }
            else
            {
                label2.Text = $@"第 {_currentProcessIndex + 1} 行 第 {BoxIndices.RightIndex + 1} 列";
            }
        }

        private readonly Image _noneImage =
            Image.FromFile(Directory.GetCurrentDirectory() + "..\\..\\..\\..\\Resources\\none.jpg");

        /// <summary>
        /// 当前处理图片序列
        /// </summary>
        private List<Mat> WorkingImages => _workingProcess[_currentProcessIndex];

        /// <summary>
        /// 结果图片序列
        /// </summary>
        private List<Mat> ResultImages => _resultProcess[_currentProcessIndex];

        /// <summary>
        /// 当前处理序列索引
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
        /// 结果左图片
        /// </summary>
        private Mat ResultLeftImg
        {
            get
            {
                if (BoxIndices.LeftIndex >= ResultImages.Count || BoxIndices.LeftIndex < 0)
                {
                    return OpenCvSharp.Extensions.BitmapConverter.ToMat((Bitmap)_noneImage);
                }
                else
                {
                    return ResultImages[BoxIndices.LeftIndex];
                }
            }
            set
            {
                if (BoxIndices.LeftIndex >= ResultImages.Count || BoxIndices.LeftIndex < 0)
                {
                    throw new InvalidOperationException();
                }
                else
                {
                    ResultImages[BoxIndices.LeftIndex] = value;
                }
            }
        }

        /// <summary>
        /// 结果右图片
        /// </summary>
        private Mat ResultRightImg
        {
            get
            {
                if (BoxIndices.RightIndex >= ResultImages.Count || BoxIndices.RightIndex < 0)
                {
                    return OpenCvSharp.Extensions.BitmapConverter.ToMat((Bitmap)_noneImage);
                }
                else
                {
                    return ResultImages[BoxIndices.RightIndex];
                }
            }
            set
            {
                if (BoxIndices.RightIndex >= ResultImages.Count || BoxIndices.RightIndex < 0)
                {
                    throw new InvalidOperationException();
                }
                else
                {
                    ResultImages[BoxIndices.RightIndex] = value;
                }
            }
        }

        /// <summary>
        /// 显示Mat图片
        /// </summary>
        /// <param name="pb"></param>
        /// <param name="m"></param>
        private void ShowMat(PictureBox pb, Mat m)
        {
            pb.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(m);
            if (pictureBox1 == pb)
            {
                figure1_label.Text = $@"第 {_currentProcessIndex+1} 行 第 {BoxIndices.LeftIndex + 1} 列";
            }
            else
            {
                label2.Text = $@"第 {_currentProcessIndex + 1} 行 第 {BoxIndices.RightIndex + 1} 列";
            }
        }
        
        /// <summary>
        /// Helper Function
        /// </summary>
        /// <param name="imgRow"></param>
        /// <param name="imgCol"></param>
        /// <param name="boxRow"></param>
        /// <param name="boxCol"></param>
        /// <returns></returns>
        private static Tuple<int, int> ComputeSize(int imgRow, int imgCol, int boxRow, int boxCol)
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

        /// <summary>
        /// 得到适合PictureBox尺寸的新图像
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        private Mat GetBoxFittedImg(Mat image)
        {
            var (row, col) = ComputeSize(image.Rows, image.Cols,
                pictureBox1.Size.Height, pictureBox2.Size.Width);
            return image.Resize(new Size(row, col), 0, 0, InterpolationFlags.Cubic);
        }

        /// <summary>
        /// 加载图片后启用所有按钮
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
        }

        /// <summary>
        /// 没有工作序列时禁用所有按钮(除了加载图片)
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
        }

        /// <summary>
        /// 根据当前状态启用或禁用处理系列切换按钮
        /// </summary>
        private void CheckProcessSwitchButton()
        {
            if (_currentProcessIndex <= 0) upButton.Enabled = false;
            else upButton.Enabled = true;
            if (_currentProcessIndex + 1 == _workingProcess.Count) downButton.Enabled = false;
            else downButton.Enabled = true;
        }

        /// <summary>
        /// 获取待处理的工作图像和原图像
        /// </summary>
        /// <returns></returns>
        private Tuple<Mat, Mat> GetImagesToProcess()
        {
            Mat originImg, resOriginImg;
            if (WorkingImages.Count <= BoxIndices.RightIndex)
            {
                originImg = WorkingLeftImg;
                resOriginImg = ResultLeftImg;
            }
            else
            {
                originImg = WorkingRightImg;
                resOriginImg = ResultRightImg;
            }
            return new Tuple<Mat, Mat>(originImg,resOriginImg);
        }

        /// <summary>
        /// 将处理后的两张图放入List并显示
        /// </summary>
        /// <param name="img"></param>
        /// <param name="resImg"></param>
        private void AddImagesToListAndShow(Mat img, Mat resImg)
        {
            WorkingImages.Add(img);
            ResultImages.Add(resImg);

            if (BoxIndices.RightIndex + 1 < WorkingImages.Count)
            {
                BoxIndices.LeftIndex++;
                BoxIndices.RightIndex++;
            }

            ShowMat(pictureBox1, WorkingLeftImg);
            ShowMat(pictureBox2, WorkingRightImg);
        }

        /// <summary>
        /// 加载图片到两个工作序列,变换显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadButton_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                 _currentProcessIndex++;
                _resultProcess.Add(new List<Mat>());
                _workingProcess.Add(new List<Mat>());
                _indicesProcess.Add(new PairIndices(0,1));

                LoadNoneImg(pictureBox1);
                LoadNoneImg(pictureBox2);

                var originImg = new Mat(openFileDialog1.FileName);
                ResultImages.Add(originImg);
                Mat resizedImg = GetBoxFittedImg(originImg);
                WorkingImages.Add(resizedImg);

                ShowMat(pictureBox1, resizedImg);
                EnableAllButtons();
                CheckProcessSwitchButton();
            }
        }

        /// <summary>
        /// 清除此行图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            var checkWindow = new ClearWarningPopUp();
            var dialogRes = checkWindow.ShowDialog();
            if (dialogRes == DialogResult.OK)
            {
                _workingProcess.RemoveAt(_currentProcessIndex);
                _resultProcess.RemoveAt(_currentProcessIndex);
                _indicesProcess.RemoveAt(_currentProcessIndex);
                _currentProcessIndex--;
                if (_currentProcessIndex == -1)
                {
                    if (_workingProcess.Count == 0)
                    {
                        LoadNoneImg(pictureBox1);
                        LoadNoneImg(pictureBox2);
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


                ShowMat(pictureBox1, WorkingLeftImg);
                ShowMat(pictureBox2, WorkingRightImg);
                CheckProcessSwitchButton();
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
            var (originImg, resOriginImg) = GetImagesToProcess();
            Mat grayImg, resGrayImg;
            try
            {
                grayImg = originImg.CvtColor(ColorConversionCodes.BGR2GRAY, 1);
                resGrayImg = resOriginImg.CvtColor(ColorConversionCodes.BGR2GRAY, 1);
            }
            catch (OpenCVException)
            {
                //ignore
                return;
            }

            AddImagesToListAndShow(grayImg,resGrayImg);
        }

        /// <summary>
        /// 上移一行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpButton_Click(object sender, EventArgs e)
        {
            _currentProcessIndex--;
            ShowMat(pictureBox1,WorkingLeftImg);
            ShowMat(pictureBox2,WorkingRightImg);
            CheckProcessSwitchButton();
        }

        /// <summary>
        /// 下移一行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownButton_Click(object sender, EventArgs e)
        {
            _currentProcessIndex++;
            ShowMat(pictureBox1, WorkingLeftImg);
            ShowMat(pictureBox2, WorkingRightImg);
            CheckProcessSwitchButton();
        }

        /// <summary>
        /// 两张图片左移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Left_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 两张图片右移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Right_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            var res = saveFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                OpenCvSharp.Extensions.BitmapConverter.ToBitmap(ResultRightImg).Save(saveFileDialog1.FileName);
            }
        }

        private void SaveButton_first_Click(object sender, EventArgs e)
        {
            var res = saveFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                OpenCvSharp.Extensions.BitmapConverter.ToBitmap(ResultLeftImg).Save(saveFileDialog1.FileName);
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
                var (originImg, resOriginImg) = GetImagesToProcess();

                Mat gNoise = new Mat(originImg.Size(), originImg.Type());
                gNoise.Randn(inputWindow.Mean, inputWindow.Variance);
                Mat resGNoise = new Mat(resOriginImg.Size(), resOriginImg.Type());
                resGNoise.Randn(inputWindow.Mean, inputWindow.Variance);

                Mat workRes = originImg + gNoise;
                Mat res = resOriginImg + resGNoise;

                AddImagesToListAndShow(workRes, res);
            }
        }

        /// <summary>
        /// 均值滤波
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddUniformNoise_Click(object sender, EventArgs e)
        {
            var inputWindow = new UniNoisePopUp();
            var dRest = inputWindow.ShowDialog();
            if (dRest == DialogResult.OK)
            {
                var (originImg, resOriginImg) = GetImagesToProcess();

                Mat uNoise = new Mat(originImg.Size(), originImg.Type());
                uNoise.Randu(inputWindow.Low,inputWindow.High);
                Mat resUNoise = new Mat(resOriginImg.Size(), resOriginImg.Type());
                resUNoise.Randu(inputWindow.Low, inputWindow.High);

                Mat workRes = originImg + uNoise;
                Mat res = resOriginImg + resUNoise;

                AddImagesToListAndShow(workRes, res);
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
                var (originImg, resOriginImg) = GetImagesToProcess();
                var blurImg = originImg.Clone();
                blurImg.MedianBlur(inputWindow.Size);
                var resBlurImg = resOriginImg.Clone();
                resBlurImg.MedianBlur(inputWindow.Size);

                AddImagesToListAndShow(blurImg,resBlurImg);
            }
        }

        private void AverageBlur_Click(object sender, EventArgs e)
        {
            var inputWindow = new AverageBlurPopUp();
            var dRes = inputWindow.ShowDialog();
            if (dRes == DialogResult.OK)
            {
                var (originImg, resOriginImg) = GetImagesToProcess();
                var blurImg = originImg.Clone();
                Size s = new Size(inputWindow.H, inputWindow.W);
                blurImg.Blur(s);
                var resBlurImg = resOriginImg.Clone();
                resBlurImg.Blur(s);

                AddImagesToListAndShow(blurImg, resBlurImg);
            }
        }
    }
}
