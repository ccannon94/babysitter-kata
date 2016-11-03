using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabysitterKata
{
    public class BabysitterTimeCard
    {
        private TwentyFourHourTime _startTime;
        private TwentyFourHourTime _endTime;

        public TwentyFourHourTime StartTime { get { return _startTime; } }
        public TwentyFourHourTime EndTime { get { return _endTime; } }

        public BabysitterTimeCard(TwentyFourHourTime startTime, TwentyFourHourTime endTime)
        {
            if (StartTimeIsValid(startTime))
                _startTime = startTime;
            if (EndTimeIsValid(endTime))
                _endTime = endTime;
        }

        public double CalculateTotalTime()
        {
            double hours = _endTime.Hours - _startTime.Hours;
            double minutes = _endTime.Minutes - _startTime.Minutes;
            return hours + minutes / 60;
        }

        private bool StartTimeIsValid(TwentyFourHourTime startTime)
        {
            if (startTime.Hours > 16 || startTime.Hours < 4)
                return true;
            throw new ArgumentOutOfRangeException("Babysitter cannot start work before 5:00PM");
            return false;
        }

        private bool EndTimeIsValid(TwentyFourHourTime endTime)
        {
            if ((endTime.Hours == 4 && endTime.Minutes == 0) || (endTime.Hours < 4) || (endTime.Hours > StartTime.Hours && endTime.Hours < 24) || (endTime.Hours == StartTime.Hours && endTime.Minutes > StartTime.Minutes))
                return true;
            throw new ArgumentOutOfRangeException("Babysitters cannot work after 4:00AM");
            return false;
        }
    }
}
