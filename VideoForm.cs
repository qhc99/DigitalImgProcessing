using System;
using static opencv.ImageProcessing;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace opencv
{
    public partial class VideoForm : Form
    {
        private bool _save;
        private bool _opening;

        public VideoForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            openCameraButton.Select();
        }

        /// <summary>
        /// 处理视频图像
        /// </summary>
        /// <param name="img">原图像</param>
        private Mat Processing(Mat img)
        {
            foreach (string item in checkedListBox1.CheckedItems)
            {
                switch (item)
                {
                    case "人脸检测":
                        img = FaceLocate(img, CopyTypes.ShallowCopy);
                        break;
                    case "人眼检测":
                        img = EyeLocate(img, CopyTypes.ShallowCopy);
                        break;
                    case "证件照检测":
                        img = ProfileFaceLocate(img, CopyTypes.ShallowCopy);
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }

            return img;
        }

        /// <summary>
        /// 打开摄像头
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openCameraButton_Click(object sender, EventArgs e)
        {
            checkedListBox1.Enabled = false;
            saveButton.Enabled = false;
            closeCameraButton.Enabled = true;
            openCameraButton.Enabled = false;

            Size dSize = new Size(640, 480);
            using VideoCapture capture = new VideoCapture(0);
            Mat image = new Mat();
            // When the movie playback reaches end, Mat.data becomes NULL.
            _opening = true;
            if (_save)
            {
                var dialogResult = saveFileDialog1.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    using VideoWriter writer = new VideoWriter(saveFileDialog1.FileName, -1, capture.Fps, dSize);
                    while (_opening) //q键
                    {
                        capture.Read(image); // same as cvQueryFrame
                        if (image.Empty())
                        {
                            break; // 摄像头大小:480*640
                        }
                        pictureBox1.Image = Processing(image).ToBitmap();
                        writer.Write(image);
                        Cv2.WaitKey(10);
                    }
                    pictureBox1.Image = null;
                }
            }
            else
            {
                while (_opening) //q键
                {
                    capture.Read(image); // same as cvQueryFrame
                    if (image.Empty())
                    {
                        break; // 摄像头大小:480*640
                    }
                    pictureBox1.Image = Processing(image).ToBitmap();
                    if (_save)
                    {

                    }
                    Cv2.WaitKey(10);
                }
                pictureBox1.Image = null;
            }
            
        }

        /// <summary>
        /// 打开视频文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openVideoFile_Click(object sender, EventArgs e)
        {
            checkedListBox1.Enabled = false;
            saveButton.Enabled = false;
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                using VideoCapture capture = new VideoCapture(openFileDialog1.FileName);
                int sleepTime = (int) Math.Round(1000 / capture.Fps);
                Mat image = new Mat();

                if (_save)
                {
                    var o = saveFileDialog1.ShowDialog();
                    if (o == DialogResult.OK)
                    {
                        using VideoWriter writer = new VideoWriter(saveFileDialog1.FileName, 
                            -1, 
                            capture.Fps, 
                            new Size(capture.Get(VideoCaptureProperties.FrameWidth), capture.Get(VideoCaptureProperties.FrameHeight)));
                        int key = -1;
                        while (key != 113)
                        {
                            capture.Read(image); 
                            if (image.Empty())
                            {
                                break;
                            }
                            pictureBox1.Image = GetBoxFittedMat(Processing(image), pictureBox1).ToBitmap();
                            writer.Write(image);
                            key = Cv2.WaitKey(sleepTime);
                        }
                    }
                }
                else
                {
                    int key = -1;
                    while (key != 113)
                    {
                        capture.Read(image);
                        if (image.Empty())
                        {
                            break;
                        }
                        pictureBox1.Image = GetBoxFittedMat(Processing(image), pictureBox1).ToBitmap();
                        key = Cv2.WaitKey(sleepTime);
                    }
                }
            }
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeButton_Click(object sender, EventArgs e)
        {
            closeCameraButton.Enabled = false;
            openCameraButton.Enabled = true;
            _opening = false;
            checkedListBox1.Enabled = true;
            saveButton.Enabled = true;
        }

        /// <summary>
        /// 快捷键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CameraPopUp_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Q:
                    closeButton_Click(this, EventArgs.Empty);
                    break;
            }

            if (e.Modifiers == Keys.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        openCameraButton_Click(this, EventArgs.Empty);
                        break;
                }
            }
            
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (saveButton.Text == "保存处理×")
            {
                saveButton.Text = "保存处理√";
                _save = true;
            }
            else
            {
                saveButton.Text = "保存处理×";
                _save = false;
            }
        }
    }
}