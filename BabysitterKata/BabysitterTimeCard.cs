using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabysitterKata
{
    public class BabysitterTimeCard
    {
        private enum START_TIME_PERIOD
        {
            EVENING = 0x00,
            MORNING = 0x01
        };

        private TwentyFourHourTime EARLIEST_START_TIME = new TwentyFourHourTime(17, 0);
        private TwentyFourHourTime LATEST_END_TIME = new TwentyFourHourTime(4, 0);
        private START_TIME_PERIOD _startTimePeriod;
        private TwentyFourHourTime _startTime;
        private TwentyFourHourTime _endTime;

        public TwentyFourHourTime StartTime { get { return _startTime; } }
        public TwentyFourHourTime EndTime { get { return _endTime; } }

        public BabysitterTimeCard(TwentyFourHourTime startTime, TwentyFourHourTime endTime)
        {
            if (StartTimeIsValid(startTime))
                _startTime = startTime;

            _startTimePeriod = EnumerateStartTimePeriod();

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
            if (startTime.CompareTo(EARLIEST_START_TIME) >= 0 || startTime.CompareTo(LATEST_END_TIME) < 0)
                return true;
            throw new ArgumentOutOfRangeException("Babysitter cannot start work before 5:00PM");
            return false;
        }

        private bool EndTimeIsValid(TwentyFourHourTime endTime)
        {
            if ((endTime.CompareTo(EARLIEST_START_TIME) >= 0 || endTime.CompareTo(LATEST_END_TIME) <= 0) && StartTimePreceedsEndTime(endTime))
                return true;
            throw new ArgumentOutOfRangeException("Babysitters cannot work after 4:00AM");
            return false;
        }

        private bool StartTimePreceedsEndTime(TwentyFourHourTime endTime)
        {
            switch ((int)_startTimePeriod)
            {
                case 0x01:
                    if (endTime.CompareTo(_startTime) >= 0 && endTime.CompareTo(LATEST_END_TIME) <=0)
                        return true;
                    throw new ArgumentException("End time must come after start time");
                    return false;
                    break;
                default:
                    if (endTime.CompareTo(_startTime) >= 0 || endTime.CompareTo(LATEST_END_TIME) <= 0)
                        return true;
                    throw new ArgumentException("End time must come after start time");
                    return false;
                    break;
            }
        }

        private START_TIME_PERIOD EnumerateStartTimePeriod()
        {
            if (StartTime.CompareTo(EARLIEST_START_TIME) >= 0)
                return START_TIME_PERIOD.EVENING;
            return START_TIME_PERIOD.MORNING;
        }
    }
}
