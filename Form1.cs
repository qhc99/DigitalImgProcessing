using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using OpenCvSharp;
using Size = OpenCvSharp.Size;

namespace opencv
{
    public partial class Form1 : Form
    {
        private readonly List<List<Mat>> _workingProcess = new List<List<Mat>>();
        private readonly List<List<Mat>> _resultProcess = new List<List<Mat>>();
        private readonly List<PictureBoxIndices> _processesPictureIndices = new List<PictureBoxIndices>();
        private int _currentProcessIndex = 0;

        internal sealed class PictureBoxIndices
        {
            public int LeftIndex;
            public int RightIndex;

            public PictureBoxIndices(int l, int r)
            {
                LeftIndex = l;
                RightIndex = r;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 显示空图片
        /// </summary>
        /// <param name="pb"></param>
        private void LoadNoneImg(PictureBox pb)
        {
            pb.Image = Image.FromFile(Directory.GetCurrentDirectory() + "..\\..\\..\\..\\Resources\\timg.jpg");
        }

        private List<Mat> WorkingImages => _workingProcess[_currentProcessIndex];

        private List<Mat> ResultImages => _resultProcess[_currentProcessIndex];

        private PictureBoxIndices CurrentPictureBoxIndices =>
            _processesPictureIndices[_currentProcessIndex];

        private Mat WorkingLeftImg =>
            WorkingImages[CurrentPictureBoxIndices.LeftIndex];

        private Mat WorkingRightImg =>
            WorkingImages[CurrentPictureBoxIndices.RightIndex];

        private Mat ResultLeftImg =>
            ResultImages[CurrentPictureBoxIndices.LeftIndex];

        private Mat ResultRightImg =>
            ResultImages[CurrentPictureBoxIndices.RightIndex];

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
                label1.Text = $@"第 {_currentProcessIndex+1} 行 第 {CurrentPictureBoxIndices.LeftIndex + 1} 列";
            }
            else
            {
                label2.Text = $@"第 {_currentProcessIndex + 1} 行 第 {CurrentPictureBoxIndices.RightIndex + 1} 列";
            }
        }
        
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
        /// 计算放缩后的尺寸
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        private Size GetBoxFittedSizeFromImg(Mat image)
        {
            var (row, col) = ComputeSize(image.Rows, image.Cols,
                pictureBox1.Size.Height, pictureBox2.Size.Width);
            return new Size(row, col);
        }

        /// <summary>
        /// 加载图片后恢复所有按钮
        /// </summary>
        private void EnableAllButtons()
        {
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
        }

        /// <summary>
        /// 加载图片到两个工作序列,变换显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                _resultProcess.Add(new List<Mat>());
                _workingProcess.Add(new List<Mat>());
                _processesPictureIndices.Add(new PictureBoxIndices(0,0));
                if (_currentProcessIndex != 0) _currentProcessIndex++;
                var originImg = new Mat(openFileDialog1.FileName);
                
                ResultImages.Add(originImg);
                
                Mat resizedImg = originImg.Resize(GetBoxFittedSizeFromImg(originImg), 0, 0, InterpolationFlags.Cubic);
                
                _workingProcess[_currentProcessIndex].Add(resizedImg);
                ShowMat(pictureBox1, resizedImg);

                EnableAllButtons();

            }
        }

        /// <summary>
        /// 清除此行图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            LoadNoneImg(pictureBox1);
            LoadNoneImg(pictureBox2);
            _workingProcess.RemoveAt(_currentProcessIndex);
            _resultProcess.RemoveAt(_currentProcessIndex);
            _processesPictureIndices.RemoveAt(_currentProcessIndex);
        }

        /// <summary>
        /// 灰度化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            var indices = CurrentPictureBoxIndices;
            Mat originImg, resOriginImg, grayImg, resGrayImg;
            if (indices.LeftIndex == indices.RightIndex)
            {
                originImg = WorkingLeftImg;
                resOriginImg = ResultLeftImg;
            }
            else
            {
                originImg = WorkingRightImg;
                resOriginImg = WorkingRightImg;
            }

            try
            {
                grayImg = originImg.CvtColor(ColorConversionCodes.BGR2GRAY, 1);
                resGrayImg = resOriginImg.CvtColor(ColorConversionCodes.BGR2GRAY, 1);
            }
            catch (OpenCVException)
            {
                MessageBox.Show(@"不能重复灰度化图像");
                return;
            }

            WorkingImages.Add(grayImg);
            ResultImages.Add(resGrayImg);
            if (indices.RightIndex != 0) indices.LeftIndex++;
            indices.RightIndex++;

            ShowMat(pictureBox1, WorkingLeftImg);
            ShowMat(pictureBox2, WorkingRightImg);
        }

        /// <summary>
        /// 上移一行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 下移一行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
