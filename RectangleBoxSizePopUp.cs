using System;
using System.Windows.Forms;

namespace opencv
{
    public partial class RectangleBoxSizePopUp : Form
    {
        public int WindowSize ;
        public RectangleBoxSizePopUp()
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
                if (WindowSize % 2 == 0)
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void RectangleBoxSizePopUp_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Close();
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
