using System;
using System.Windows.Forms;

namespace opencv
{
    public partial class WarningPopUp : Form
    {
        public WarningPopUp(string text)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            textBox1.Text = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
