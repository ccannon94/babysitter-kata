using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabysitterKata
{
    /// <summary>
    /// Stores a babysitter's start and end time based on the 24-hour clock.
    /// </summary>
    public class BabysitterTimeCard
    {
        private enum START_TIME_PERIOD
        {
            EVENING = 0x00,
            MORNING = 0x01
        };

        private TwentyFourHourTime EARLIEST_START_TIME = new TwentyFourHourTime(17, 0);
        private TwentyFourHourTime LATEST_END_TIME = new TwentyFourHourTime(4, 0);
        private TwentyFourHourTime ONE_MINUTE_TO_MIDNIGHT = new TwentyFourHourTime(23, 59);
        private TwentyFourHourTime MIDNIGHT = new TwentyFourHourTime(0, 0);
        private START_TIME_PERIOD _startTimePeriod;
        private TwentyFourHourTime _startTime;
        private TwentyFourHourTime _endTime;
        private TwentyFourHourTime _bedTime;

        /// <summary>
        /// The time the babysitting shift began.
        /// Valid Range: 17:00 - 04:00
        /// </summary>
        public TwentyFourHourTime StartTime { get { return _startTime; } }

        /// <summary>
        /// The time the babysitting shift ended.
        /// Valid Range: 17:00 - 04:00
        /// Must come after StartTime
        /// </summary>
        public TwentyFourHourTime EndTime { get { return _endTime; } }

        /// <summary>
        /// The only constructor for a TimeCard must include a start and an end time.
        /// </summary>
        /// <param name="startTime">Time shift began, valid range: 17:00 - 04:00</param>
        /// <param name="endTime">Time shift ended, valid range: 17:00 - 04:00, must come after startTime</param>
        public BabysitterTimeCard(TwentyFourHourTime startTime, TwentyFourHourTime endTime)
        {
            if (StartTimeIsValid(startTime))
                _startTime = startTime;

            _startTimePeriod = EnumerateStartTimePeriod();

            if (EndTimeIsValid(endTime))
                _endTime = endTime;
        }

        public BabysitterTimeCard(TwentyFourHourTime startTime, TwentyFourHourTime endTime, TwentyFourHourTime bedTime)
        {
            if (StartTimeIsValid(startTime))
                _startTime = startTime;

            _startTimePeriod = EnumerateStartTimePeriod();

            if (EndTimeIsValid(endTime))
                _endTime = endTime;

            _bedTime = bedTime;
        }

        /// <summary>
        /// Calculate total time of a shift.
        /// </summary>
        /// <returns>Double representing the total time of a shift in hours</returns>
        public double CalculateTotalTime()
        {
            double hours = _endTime.Hours - _startTime.Hours;
            double minutes = _endTime.Minutes - _startTime.Minutes;
            return hours + minutes / 60;
        }

        public int CalculateHoursBeforeBedtime()
        {
            switch (_startTimePeriod)
            {
                case (START_TIME_PERIOD)0x1:
                    return CalculateHoursBeforeBedtime_MorningStart();
                    break;
                default:
                    return CalculateHoursBeforeBedtime_EveningStart();
                    break;
            }
        }

		private int CalculateHoursBetweenBedtimeAndMidnight()
		{
			return 0;
		}	

        private int CalculateHoursBeforeBedtime_MorningStart()
        {
            return (int) Math.Round(_bedTime.Minus(_startTime));
        }

        private int CalculateHoursBeforeBedtime_EveningStart()
        {
            if (_bedTime.CompareTo(EARLIEST_START_TIME) < 0)
                return (int) Math.Round(ONE_MINUTE_TO_MIDNIGHT.Minus(_startTime) + _bedTime.Minus(MIDNIGHT));
            return (int) Math.Round(_bedTime.Minus(_startTime));
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
