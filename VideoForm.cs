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
            ShowNoneImage();
        }

        /// <summary>
        /// show none image
        /// </summary>
        private void ShowNoneImage()
        {
            pictureBox1.Image = MainForm.NoneMat.Resize(new Size(640,480)).ToBitmap();
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
                    case "人脸":
                        img = FaceLocate(img, CopyTypes.ShallowCopy);
                        break;
                    case "人眼":
                        img = EyeLocate(img, CopyTypes.ShallowCopy);
                        break;
                    case "行人":
                        img = PedestrianLocate(img, CopyTypes.ShallowCopy);
                        break;
                    case "拳头":
                        img = FistLocate(img, CopyTypes.ShallowCopy);
                        break;
                    case "手掌":
                        img = RightPalmLocate(img, CopyTypes.ShallowCopy);
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
            openFileButton.Enabled = false;

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
                    int key = -1;
                    while (key != 113 &&_opening) //q键
                    {
                        capture.Read(image); // same as cvQueryFrame
                        if (image.Empty())
                        {
                            break; // 摄像头大小:480*640
                        }
                        pictureBox1.Image = Processing(image).ToBitmap();
                        writer.Write(image);
                        key = Cv2.WaitKey(10);
                    }
                    ShowNoneImage();
                }
            }
            else
            {
                int key = -1;
                while (key != 113 && _opening) //q键
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
                    key =Cv2.WaitKey(10);
                }
                ShowNoneImage();
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
            openFileButton.Enabled = false;
            closeCameraButton.Enabled = true;
            openCameraButton.Enabled = false;
            saveButton.Enabled = false;
            _opening = true;
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
                        while (key != 113 && _opening)
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
                    while (key != 113 && _opening)
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

            ShowNoneImage();
            closeButton_Click(this,EventArgs.Empty);
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
            openFileButton.Enabled = true;
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
            if (saveButton.Text == "保存×")
            {
                saveButton.Text = "保存√";
                _save = true;
            }
            else if(saveButton.Text == "保存√")
            {
                saveButton.Text = "保存×";
                _save = false;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}