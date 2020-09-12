using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using OpenCvSharp;
using System.Windows.Forms;
using OpenCvSharp.Extensions;
using Size = OpenCvSharp.Size;

namespace opencv
{
    public partial class ImagesListForm : Form
    {
        private readonly List<Image> _images;
        private readonly MainForm.PairIndices _indices;

        public ImagesListForm(List<Image> images, MainForm.PairIndices indices)
        {
            InitializeComponent();
            _images = images;
            _indices = indices;
            StartPosition = FormStartPosition.CenterScreen;
            LoadNoneImg(leftPictureBox);
            LoadNoneImg(rightPictureBox);
            
        }
        private void LoadNoneImg(PictureBox pb)
        {
            Mat none = ((Bitmap)_noneImage).ToMat();
            none.Resize(new Size(leftPictureBox.Height, leftPictureBox.Width));
            pb.Image = none.ToBitmap();
            if (leftPictureBox == pb)
            {
                right_picture_label.Text = $@"第 {_indices.LeftIndex + 1} 列";
            }
            else
            {
                left_picture_label.Text = $@"第 {_indices.RightIndex + 1} 列";
            }
        }

        private readonly Image _noneImage =
            Image.FromFile(Directory.GetCurrentDirectory() + "..\\..\\..\\..\\Resources\\none.jpg");

        private void SwitchCheck()
        {

        }

        private Image WorkingRightImage
        {
            get
            {
                if (_indices.RightIndex < 0 || _indices.RightIndex >= _images.Count)
                {
                    Mat none = ((Bitmap)_noneImage).ToMat();
                    none.Resize(new Size(leftPictureBox.Height, leftPictureBox.Width));
                    return none.ToBitmap();
                }
                else
                {
                    return _images[_indices.RightIndex];
                }
            }
        }

        private Image WorkingLeftImage
        {
            get
            {
                if (_indices.LeftIndex < 0 || _indices.LeftIndex >= _images.Count)
                {
                    Mat none = ((Bitmap)_noneImage).ToMat();
                    none.Resize(new Size(leftPictureBox.Height, leftPictureBox.Width));
                    return none.ToBitmap();
                }
                else
                {
                    return _images[_indices.LeftIndex];
                }
            }
        }

        private void ShowImage(PictureBox pb, Image img)
        {
            pb.Image = img;
        }

        private void leftButton_Click(object sender, EventArgs e)
        {

        }

        private void rightButton_Click(object sender, EventArgs e)
        {

        }
    }
}
