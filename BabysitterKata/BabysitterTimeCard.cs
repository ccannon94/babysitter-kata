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
            _startTime = startTime;
            _endTime = endTime;
        }

        public double CalculateTotalTime()
        {
            double hours = _endTime.Hours - _startTime.Hours;
            double minutes = _endTime.Minutes - _startTime.Minutes;
            return hours + minutes / 60;
        }
    }
}
