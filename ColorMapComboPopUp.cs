using System;

using System.Windows.Forms;
using OpenCvSharp;

namespace opencv
{
    public partial class ColorMapComboPopUp : Form
    {

        public ColormapTypes SelectedTypes;

        public ColorMapComboPopUp()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            foreach (var map in (ColormapTypes[])Enum.GetValues(typeof(ColormapTypes)))
            {
                comboBox1.Items.Add(map);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectedTypes = (ColormapTypes)comboBox1.SelectedItem;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ColorMapComboPopUp_KeyDown(object sender, KeyEventArgs e)
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
