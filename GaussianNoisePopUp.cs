using System;
using System.Windows.Forms;

namespace opencv
{
    public partial class GaussianNoisePopUp : Form
    {
        public double Mean;
        public double Variance;

        public GaussianNoisePopUp()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
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

        private void GaussianNoisePopUp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this,EventArgs.Empty);
            }
        }
    }
}
