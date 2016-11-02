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
            _hours = hours;
            _minutes = minutes;
        }
    }
}
