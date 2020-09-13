using System;
using System.Windows.Forms;

namespace opencv
{
    public partial class UpperLowerLimitPopUp : Form
    {
        public double Low;
        public double High;
        public int ApertureSize;
        public UpperLowerLimitPopUp()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        public UpperLowerLimitPopUp(bool isCannyEdgeDetection)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            if (isCannyEdgeDetection)
            {
                label3.Visible = true;
                textBox3.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(textBox1.Text, out High) ||
                !double.TryParse(textBox2.Text, out Low) ||
                !int.TryParse(textBox3.Text, out ApertureSize))
            {
                MessageBox.Show(@"输入错误");
                DialogResult = DialogResult.Cancel;
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void UpperLowerLimitPopUp_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    button1_Click(this, EventArgs.Empty);
                    break;
                case Keys.Escape:
                    Close();
                    break;
            }
        }
    }
}
