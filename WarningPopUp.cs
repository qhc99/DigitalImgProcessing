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

        private void WarningPopUp_KeyDown(object sender, KeyEventArgs e)
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
