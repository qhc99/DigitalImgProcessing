using System;
using System.Windows.Forms;
using OpenCvSharp;

namespace opencv
{
    public partial class AdaptiveSegmentationComboPopUp : Form
    {
        public ThresholdTypes SelectedTypes;
        public int WindowSize, Constant;
        public AdaptiveSegmentationComboPopUp()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            foreach (var type in (ThresholdTypes[])Enum.GetValues(typeof(ThresholdTypes)))
            {
                if (type == ThresholdTypes.Binary || type == ThresholdTypes.BinaryInv)
                {
                    comboBox1.Items.Add(type);
                }
            }
            comboBox1.SelectedIndex = 0;
            button1.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out WindowSize) ||
                !int.TryParse(textBox2.Text, out Constant))
            {
                SelectedTypes = (ThresholdTypes)comboBox1.SelectedItem;
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

        private void AdaptiveThresholdTypesComboPopUp_KeyDown(object sender, KeyEventArgs e)
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
    }
}
