using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp;
using Range = OpenCvSharp.Range;

namespace opencv
{
    public static class ImageProcessing
    {
        private static readonly CascadeClassifier FaceClassifier = new CascadeClassifier(@"..\\..\\..\\Resources\\haarcascade_frontalface_default.xml");
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
    }
}
