using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabysitterKata
{
    public class TwentyFourHourTime
    {
        private int _hours;
        private int _minutes;

        public int Hours { get{ return _hours; } }
        public int Minutes { get { return _minutes; } }

        public TwentyFourHourTime(int hours, int minutes)
        {
            if(ValidateMinuteValue(minutes) && ValidateHourValue(hours))
            {
                _hours = hours;
                _minutes = minutes;
            }else
            {
                throw new ArgumentOutOfRangeException("Arguments are outside acceptable range.");
            }
        }

        private bool ValidateMinuteValue(int minutes)
        {
            if (minutes < 60 && minutes >= 0)
                return true;
            return false;
        }

        private bool ValidateHourValue(int hours)
        {
            if (hours < 24 && hours >= 0)
                return true;
            return false;
        }
    }
}
