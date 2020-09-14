using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using OpenCvSharp.Extensions;
using System.Windows.Forms;
using OpenCvSharp;

namespace opencv
{
    public partial class CameraPopUp : Form
    {
        private bool _opening = false;
        public CameraPopUp()
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
            if (button1.Text == "开启")
            {
                using VideoCapture capture = new VideoCapture(0);
                Mat image = new Mat();
                // When the movie playback reaches end, Mat.data becomes NULL.
                _opening = true;
                while (_opening) //q键
                {
                    capture.Read(image); // same as cvQueryFrame
                    if (image.Empty()) break; // 摄像头大小:480*640
                    pictureBox1.Image = image.ToBitmap();
                    Cv2.WaitKey(30);
                }
            }
        }

        private void CameraPopUp_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Close();
                    break;
                case Keys.Enter:
                    button1_Click(this, EventArgs.Empty);
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _opening = false;
        }
    }
}
