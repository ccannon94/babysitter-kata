using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabysitterKata
{
    /// <summary>
    /// A representation of time in 24 hour clock format
    /// Valid times range from 0000 to 2359.
    /// </summary>
    public class TwentyFourHourTime : IComparable, IComparable<TwentyFourHourTime>
    {
        private const int MIN_HOURS_VALUE = 0;
        private const int MIN_MINUTES_VALUE = 0;
        private const int MAX_HOURS_VALUE = 23;
        private const int MAX_MINUTES_VALUE = 59;
        private int _hours;
        private int _minutes;

        /// <summary>
        /// The number of hours since midnight.
        /// </summary>
        public int Hours { get{ return _hours; } }
        /// <summary>
        /// The number of minutes since the last hour.
        /// </summary>
        public int Minutes { get { return _minutes; } }

        /// <summary>
        /// Creates a TwentyFourHourTime.
        /// </summary>
        /// <param name="hours">
        /// The number of hours since midnight.
        /// Valid Range: 0-23
        /// </param>
        /// <param name="minutes">
        /// The number of minutes since the last turn of the hour.
        /// Valid Range: 0-59
        /// </param>
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

        public int CompareTo(object obj)
        {
            obj = (TwentyFourHourTime)obj;
            if (obj != null)
                return this.CompareTo(obj);
            //Objects of TwentyFourHourTime should always be greater than other objects
            return 1;
        }

        public int CompareTo(TwentyFourHourTime other)
        {
            if (this.Hours == other.Hours)
                return this.Minutes.CompareTo(other.Minutes);
            return this.Hours.CompareTo(other.Hours);
        }
    }
}
