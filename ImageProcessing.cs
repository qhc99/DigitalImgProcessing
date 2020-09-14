using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using OpenCvSharp;
using Range = OpenCvSharp.Range;

namespace opencv
{
    public static class ImageProcessing
    {
        //private static readonly CascadeClassifier FaceClassifier = new CascadeClassifier(@"..\\..\\..\\Resources\\haarcascade_frontalface_default.xml");
        private static readonly CascadeClassifier FaceClassifier = new CascadeClassifier(@"..\\..\\..\\Resources\\lbpcascade_frontalface.xml");

        public static Mat FaceLocate(Mat img)
        {
            Mat grayImg = ConvertToGrayMat(img);

            Rect[] faces = FaceClassifier.DetectMultiScale(grayImg, 
                1.08, 2, HaarDetectionType.ScaleImage, new Size(30, 30));
            foreach (var rect in faces)
            {
                Cv2.Rectangle(img, new Point(rect.X,rect.Y), new Point(rect.X + rect.Width, 
                    rect.Y + rect.Height), new Scalar(255, 0, 0),3);
                // var roiGray = grayImg.SubMat(new Range(rect.Y, rect.Y + rect.Height),
                //     new Range(rect.X, rect.X + rect.Width));
                // var roiImg = img.SubMat(new Range(rect.Y, rect.Y + rect.Height),
                //     new Range(rect.X, rect.X + rect.Width));
                
            }

            return img;
        }

        /// <summary>
        /// 灰度化
        /// </summary>
        /// <param name="img"></param>
        /// <returns>gray img or null </returns>
        public static Mat ConvertToGrayMat(Mat img)
        {
            Mat grayImg;
            try
            {
                grayImg = img.CvtColor(ColorConversionCodes.BGR2GRAY, 1);
            }
            catch (OpenCVException)
            {
                return img;
            }

            return grayImg;
        }

        public static void ShowHistogram(Mat src)
        {
            // Histogram view
            const int width = 260, height = 200;
            Mat render = new Mat(new Size(width, height), MatType.CV_8UC3, Scalar.All(255));

            // Calculate histogram
            Mat hist = new Mat();
            int[] hDims = { 256 }; // Histogram size for each dimension
            Rangef[] ranges = { new Rangef(0, 256), }; // min/max 
            Cv2.CalcHist(
                new[] { src },
                new[] { 0 },
                null,
                hist,
                1,
                hDims,
                ranges);

            // Get the max value of histogram
            Cv2.MinMaxLoc(hist, out _, out double maxVal);

            Scalar color = Scalar.All(100);
            // Scales and draws histogram
            hist = hist * (maxVal != 0 ? height / maxVal : 0.0);
            for (int j = 0; j < hDims[0]; ++j)
            {
                int binW = (int)((double)width / hDims[0]);
                render.Rectangle(
                    new Point(j * binW, render.Rows - (int)(hist.Get<float>(j))),
                    new Point((j + 1) * binW, render.Rows),
                    color,
                    -1);
            }

            using (new Window("Image", WindowMode.AutoSize | WindowMode.FreeRatio, src))
            using (new Window("Histogram", WindowMode.AutoSize | WindowMode.FreeRatio, render))
            {
                Cv2.WaitKey();
            }
        }

        /// <summary>
        /// 加高斯噪声
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static Mat AddGaussianNoise(Mat img)
        {
            var inputWindow = new MeanVariancePopUp();
            var dialogResult = inputWindow.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {


                Mat gNoise = new Mat(img.Size(), img.Type());
                gNoise.Randn(inputWindow.Mean, inputWindow.Variance);

                return img + gNoise;
            }
            else
            {
                throw new ProcessCanceledException();
            }
        }

        /// <summary>
        /// 加均匀噪声
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static Mat AddUniformNoise(Mat img)
        {
            var inputWindow = new UpperLowerLimitPopUp();
            var dRest = inputWindow.ShowDialog();
            if (dRest == DialogResult.OK)
            {


                Mat uNoise = new Mat(img.Size(), img.Type());
                uNoise.Randu(inputWindow.Low, inputWindow.High);
                return img + uNoise;
            }
            else
            {
                throw new ProcessCanceledException();
            }
        }

        /// <summary>
        /// 加椒盐噪声
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static Mat AddSaltAndPepperNoise(Mat img)
        {
            var inputWindow = new UpperLowerLimitPopUp();
            var dialogRes = inputWindow.ShowDialog();
            if (dialogRes == DialogResult.OK)
            {

                var noiseImg = img.Clone();

                Mat rand = Mat.Zeros(new Size(noiseImg.Height, noiseImg.Width), noiseImg.Type());
                rand.Randu(0, 255);
                Mat white = rand.LessThanOrEqual(inputWindow.Low);
                Mat black = rand.GreaterThanOrEqual(inputWindow.High);

                noiseImg -= black;
                noiseImg += white;
                return noiseImg;
            }
            else
            {
                throw new ProcessCanceledException();
            }
        }

        /// <summary>
        /// 中值滤波
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static Mat MedianBlur(Mat img)
        {
            var inputWindow = new RectangleBoxSizePopUp();
            var dRes = inputWindow.ShowDialog();
            if (dRes == DialogResult.OK)
            {
                if (inputWindow.WindowSize % 2 == 0 || inputWindow.WindowSize < 3)
                {
                    MessageBox.Show(@"输入应为奇数并且>=3");
                    throw new ProcessCanceledException();
                }

                return img.MedianBlur(inputWindow.WindowSize);
            }
            else
            {
                throw new ProcessCanceledException();
            }
        }

        /// <summary>
        /// 均值滤波
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static Mat AverageBlur(Mat img)
        {
            var inputWindow = new BoxHeightWidthPopUp();
            var dRes = inputWindow.ShowDialog();
            if (dRes == DialogResult.OK)
            {
                return img.Blur(new Size(inputWindow.H, inputWindow.W));
            }
            else
            {
                throw new ProcessCanceledException();
            }
        }

        /// <summary>
        /// 高斯滤波
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static Mat GaussianBlur(Mat img)
        {
            var inputWindow = new BoxHeightWidthPopUp();
            var dRes = inputWindow.ShowDialog();
            if (dRes == DialogResult.OK)
            {
                return img.GaussianBlur(new Size(inputWindow.H, inputWindow.W), 0);
            }
            else
            {
                throw new ProcessCanceledException();
            }
        }


        public static Mat LaplacianSharpen(Mat img)
        {
            var inputWindow = new CoefficientAlphaPopUp();
            var dialogRes = inputWindow.ShowDialog();
            if (dialogRes == DialogResult.OK)
            {

                Mat newImg = new Mat(img.Size(), MatType.CV_16S);
                img.ConvertTo(newImg, MatType.CV_16S);
                // why minus works?
                Mat sharpenImg = newImg - img.Laplacian(MatType.CV_16S) * inputWindow.Alpha;
                Mat resSharpenImg = new Mat(sharpenImg.Size(), MatType.CV_8U);
                sharpenImg.ConvertTo(resSharpenImg, MatType.CV_8U);
                return resSharpenImg;
            }
            else
            {
                throw new ProcessCanceledException();
            }
        }
    }
}
