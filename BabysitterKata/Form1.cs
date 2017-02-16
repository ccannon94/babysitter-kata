using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BabysitterKata
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void TimeCardSubmit_Button_Click(object sender, EventArgs e)
        {

        }

        private void BedTimeEnabled_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (BedTimeEnabled_CheckBox.Checked)
            {
                BedTimeHour_NumericUpDown.Enabled = true;
                BedTimeMinute_NumericUpDown.Enabled = true;
                BedTime_AMPM_ComboBox.Enabled = true;
            }
            else
            {
                BedTimeHour_NumericUpDown.Enabled = false;
                BedTimeMinute_NumericUpDown.Enabled = false;
                BedTime_AMPM_ComboBox.Enabled = false;
            }
        }
    }
}
