using System;
using System.Windows.Forms;

namespace opencv
{
    public partial class GaussianNoiseSelectForm : Form
    {
        public double Mean;
        public double Variance;

        public GaussianNoiseSelectForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(textBox1.Text, out Mean) || !double.TryParse(textBox2.Text, out Variance))
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
