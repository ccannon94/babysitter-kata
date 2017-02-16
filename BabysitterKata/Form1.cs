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
            TwentyFourHourTime startTime;
            TwentyFourHourTime endTime;
            TwentyFourHourTime bedtime;

            switch ((TIME_OF_DAY)StartTime_AMPM_ComboBox.SelectedValue)
            {
                case TIME_OF_DAY.AM:
                    startTime = InitializeAMTime(StartTimeHour_NumericUpDown.Value, StartTimeMinute_NumericUpDown.Value);
                    break;
                case TIME_OF_DAY.PM:
                    startTime = InitializePMTime(StartTimeHour_NumericUpDown.Value, StartTimeMinute_NumericUpDown.Value);
                    break;
            }

        }

        private TwentyFourHourTime InitializeAMTime(decimal hour, decimal minute)
        {
            return new TwentyFourHourTime((int)hour, (int)minute);
        }

        private TwentyFourHourTime InitializePMTime(decimal hour, decimal minute)
        {
            int realHour = (int)hour + 12;

            if (realHour == 24)
                realHour = 0;

            return new TwentyFourHourTime((int)hour, (int)minute);
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
