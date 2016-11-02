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
            if (hours >= 0 && hours < 24)
            {
                _hours = hours;
            }else
            {
                throw new ArgumentOutOfRangeException("Hours entered must be 0-23. Please try again.");
            }

            if (minutes >= 0 && minutes < 60)
            {
                _minutes = minutes;
            }else
            {
                throw new ArgumentOutOfRangeException("Minutes entered must be 0-59. Please try again.");
            }
        }
    }
}
