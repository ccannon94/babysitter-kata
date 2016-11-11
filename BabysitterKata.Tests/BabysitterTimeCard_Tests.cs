﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BabysitterKata;

namespace BabysitterKata.Tests
{
    class BabysitterTimeCard_Tests
    {
        [TestCase(0, 12, 0, 42)]
        [TestCase(19, 15, 22, 32)]
        [TestCase(20, 52, 03, 15)]
        [TestCase(17, 00, 04, 00)]
        [TestCase(17,23, 3, 19)]
        [TestCase(23, 42, 2, 4)]
        public void BabysitterTimeCard_GivenTwoValidTime_CalculatesTotalTime(int startTimeHours, int startTimeMinutes, int endTimeHours, int endTimeMinutes)
        {
            TwentyFourHourTime startTime = new TwentyFourHourTime(startTimeHours, startTimeMinutes);
            TwentyFourHourTime endTime = new TwentyFourHourTime(endTimeHours, endTimeMinutes);

            BabysitterTimeCard timeCard = new BabysitterTimeCard(startTime, endTime);

            Assert.AreEqual((endTime.Hours - startTime.Hours) + (((double)endTime.Minutes - (double)startTime.Minutes)/60), timeCard.CalculateTotalTime());
        }

        [TestCase(14, 32, 22, 15)]
        [TestCase(5, 14, 23, 14)]
        [TestCase(12, 0, 4, 0)]
        [TestCase(11, 22, 7, 19)]
        [TestCase(8, 48, 19, 12)]
        public void BabySitterTimeCard_GivenStartTimeBefore5PM_ThrowsArgumentOutOfRangeException(int startTimeHours, int startTimeMinutes, int endTimeHours, int endTimeMinutes)
        {
            TwentyFourHourTime startTime = new TwentyFourHourTime(startTimeHours, startTimeMinutes);
            TwentyFourHourTime endTime = new TwentyFourHourTime(endTimeHours, endTimeMinutes);

            Assert.Throws<ArgumentOutOfRangeException>(delegate { new BabysitterTimeCard(startTime, endTime); });
        }

        [TestCase(17, 22, 06, 15)]
        [TestCase(19, 45, 07, 36)]
        [TestCase(22, 0, 4, 01)]
        [TestCase(0, 0, 6, 55)]
        [TestCase(17, 16, 13, 12)]
        public void BabySitterTimeCard_GivenEndTimeAfter4AM_ThrowsArgumentOutOfRangeException(int startTimeHours, int startTimeMinutes, int endTimeHours, int endTimeMinutes)
        {
            TwentyFourHourTime startTime = new TwentyFourHourTime(startTimeHours, startTimeMinutes);
            TwentyFourHourTime endTime = new TwentyFourHourTime(endTimeHours, endTimeMinutes);

            Assert.Throws<ArgumentOutOfRangeException>(delegate { new BabysitterTimeCard(startTime, endTime); });
        }

        [TestCase(17, 25, 17, 0)]
        [TestCase(0, 43, 23, 42)]
        [TestCase(22, 32, 19, 15)]
        [TestCase(02, 15, 0, 0)]
        [TestCase(03, 59, 0, 15)]
        public void BabySittertimeCard_GivenEndTimeBeforeStartTime_ThrowsArgumentException(int startTimeHours, int startTimeMinutes, int endTimeHours, int endTimeMinutes)
        {
            TwentyFourHourTime startTime = new TwentyFourHourTime(startTimeHours, startTimeMinutes);
            TwentyFourHourTime endTime = new TwentyFourHourTime(endTimeHours, endTimeMinutes);

            Assert.Throws<ArgumentException>(delegate { new BabysitterTimeCard(startTime, endTime); });
        }

        [TestCase(17, 15, 23, 45, 22, 0, 5)]
        public void BabySitterTimeCard_GivenValidStartTimeAndBedTime_ReturnHoursBeforeBedtime(int startTimeHours, int startTimeMinutes, int endTimeHours, int endTimeMinutes, int bedTimeHours, int bedTimeMinutes, int hoursBeforeBedTime)
        {
            TwentyFourHourTime startTime = new TwentyFourHourTime(startTimeHours, startTimeMinutes);
            TwentyFourHourTime endTime = new TwentyFourHourTime(endTimeHours, endTimeMinutes);
            TwentyFourHourTime bedTime = new TwentyFourHourTime(bedTimeHours, bedTimeMinutes);

            BabysitterTimeCard timeCard = new BabysitterTimeCard(startTime, endTime, bedTime);

            Assert.AreEqual(hoursBeforeBedTime, timeCard.CalculateHoursBeforeBedtime());
        }
    }
}
