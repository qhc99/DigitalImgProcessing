using System;
using System.Windows.Forms;

namespace opencv
{
    public partial class MedianBlurPopUp : Form
    {
        public int WindowSize ;
        public MedianBlurPopUp()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out WindowSize))
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
    }
}
