using System;
using static opencv.ImageProcessing;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace opencv
{
    public partial class VideoForm : Form
    {
        private bool _opening;

        public VideoForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            button1.Select();
        }

        /// <summary>
        /// 开启
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button1.Enabled = false;
            using VideoCapture capture = new VideoCapture(0);
            using Mat image = new Mat();
            // When the movie playback reaches end, Mat.data becomes NULL.
            _opening = true;
            while (_opening) //q键
            {
                capture.Read(image); // same as cvQueryFrame
                if (image.Empty()) break; // 摄像头大小:480*640
                pictureBox1.Image = FaceLocate(image, CopyTypes.ShallowCopy).ToBitmap();
                Cv2.WaitKey(10);
            }

            pictureBox1.Image = null;
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button1.Enabled = true;
            _opening = false;
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
                    button2_Click(this, EventArgs.Empty);
                    break;
            }

            if (e.Modifiers == Keys.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        button1_Click(this, EventArgs.Empty);
                        break;
                }
            }
        }
    }
}