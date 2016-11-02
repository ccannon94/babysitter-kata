using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabysitterKata
{
    public class TwentyFourHourTime
    {
        private const int MIN_HOURS_VALUE = 0;
        private const int MIN_MINUTES_VALUE = 0;
        private const int MAX_HOURS_VALUE = 23;
        private const int MAX_MINUTES_VALUE = 59;
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
            if (minutes <= MAX_MINUTES_VALUE && minutes >= MIN_MINUTES_VALUE)
                return true;
            return false;
        }

        private bool ValidateHourValue(int hours)
        {
            if (hours <= MAX_HOURS_VALUE && hours >= MIN_HOURS_VALUE)
                return true;
            return false;
        }
    }
}
