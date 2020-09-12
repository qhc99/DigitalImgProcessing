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
        private readonly List<Mat> _workingMats;
        private readonly MainForm.PairIndices _boxIndices;

        public ImagesListForm(List<Mat> workingMats, MainForm.PairIndices boxIndices)
        {
            InitializeComponent();
            _boxIndices = boxIndices;
            _workingMats = workingMats;
            StartPosition = FormStartPosition.CenterScreen;
            LoadNoneImg(leftPictureBox);
            LoadNoneImg(rightPictureBox);
            ShowMat(leftPictureBox, WorkingLeftMat);
            ShowMat(rightPictureBox, WorkingRightMat);
            SwitchCheck();
        }

        private void LoadNoneImg(PictureBox pb)
        {
            Mat none = ((Bitmap) _noneImage).ToMat();
            none.Resize(new Size(leftPictureBox.Height, leftPictureBox.Width));
            ShowMat(pb, none);
        }

        private readonly Image _noneImage =
            Image.FromFile(Directory.GetCurrentDirectory() + "..\\..\\..\\..\\Resources\\none.jpg");

        private void SwitchCheck()
        {
            if (_boxIndices.LeftIndex <= 0) leftButton.Enabled = false;
            else leftButton.Enabled = true;
            if (_boxIndices.RightIndex >= _workingMats.Count - 1) rightButton.Enabled = false;
            else rightButton.Enabled = true;
        }

        private Mat WorkingRightMat
        {
            get
            {
                if (_boxIndices.RightIndex < 0 || _boxIndices.RightIndex >= _workingMats.Count)
                {
                    Mat none = ((Bitmap) _noneImage).ToMat();
                    none.Resize(new Size(leftPictureBox.Height, leftPictureBox.Width));
                    return none;
                }
                else
                {
                    return _workingMats[_boxIndices.RightIndex];
                }
            }
        }

        private Mat WorkingLeftMat
        {
            get
            {
                if (_boxIndices.LeftIndex < 0 || _boxIndices.LeftIndex >= _workingMats.Count)
                {
                    Mat none = ((Bitmap) _noneImage).ToMat();
                    none.Resize(new Size(leftPictureBox.Height, leftPictureBox.Width));
                    return none;
                }
                else
                {
                    return _workingMats[_boxIndices.LeftIndex];
                }
            }
        }

        private void ShowMat(PictureBox pb, Mat m)
        {
            pb.Image = GetBoxFittedMat(m).ToBitmap();
            if (leftPictureBox == pb)
            {
                left_picture_label.Text = $@"第 {_boxIndices.LeftIndex + 1} 列";
                leftPictureSize.Text = $@"H:{m.Height} W:{m.Width}";
            }
            else
            {
                right_picture_label.Text = $@"第 {_boxIndices.RightIndex + 1} 列";
                rightPictureSize.Text = $@"H:{m.Height} W:{m.Width}";
            }
        }

        private Mat GetBoxFittedMat(Mat m)
        {
            var (row, col) = ComputeSize(m.Rows, m.Cols,
                leftPictureBox.Size.Height, leftPictureBox.Size.Width);
            return m.Resize(new Size(row, col), 0, 0, InterpolationFlags.Cubic);

            static Tuple<int, int> ComputeSize(int imgRow, int imgCol, int boxRow, int boxCol)
            {
                if (imgRow <= boxRow && imgCol <= boxCol)
                {
                    return new Tuple<int, int>(imgRow, imgCol);
                }
                else
                {
                    double ratio = ((double) imgRow) / imgCol;
                    //newRow/newCol = imgRow/imgCol
                    if (imgRow > boxRow)
                    {
                        return new Tuple<int, int>(boxRow, (int) (boxRow / ratio));
                    }
                    else
                    {
                        return new Tuple<int, int>((int) (ratio * boxCol), boxCol);
                    }
                }
            }
        }

        private void leftButton_Click(object sender, EventArgs e)
        {
            _boxIndices.LeftIndex--;
            _boxIndices.RightIndex--;
            ShowMat(leftPictureBox, WorkingLeftMat);
            ShowMat(rightPictureBox, WorkingRightMat);
            SwitchCheck();
        }

        private void rightButton_Click(object sender, EventArgs e)
        {
            _boxIndices.LeftIndex++;
            _boxIndices.RightIndex++;
            ShowMat(leftPictureBox, WorkingLeftMat);
            ShowMat(rightPictureBox, WorkingRightMat);
            SwitchCheck();
        }

        private void ImagesListForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        if (leftButton.Enabled)
                        {
                            leftButton_Click(this, EventArgs.Empty);
                        }

                        break;
                    case Keys.Right:
                        if (rightButton.Enabled)
                        {
                            rightButton_Click(this, EventArgs.Empty);
                        }

                        break;
                }
            }
        }

        private void SaveMat(Mat m)
        {
            var res = saveFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                m.ToBitmap().Save(saveFileDialog1.FileName);
            }
        }

        private void PictureRightClickSave_Click(object sender, EventArgs e)
        {
            if (sender is ContextMenuStrip owner)
            {
                Control sourceControl = owner.SourceControl;
                if (sourceControl == leftPictureBox && _workingMats.Count >= 1)
                {
                    SaveMat(WorkingLeftMat);
                }
                else if (sourceControl == rightPictureBox && _workingMats.Count >= 2)
                {
                    SaveMat(WorkingRightMat);
                }
            }
        }
    }
}