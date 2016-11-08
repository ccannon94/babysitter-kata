using System;
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
        [TestCase(0, 12, 15, 42)]
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
        public void BabySitterTimeCard_GivenStartTimeBefore5PM_ThrowsArgumentOutOfRangeException(int startTimeHours, int startTimeMinutes, int endTimeHours, int endTimeMinutes)
        {
            TwentyFourHourTime startTime = new TwentyFourHourTime(startTimeHours, startTimeMinutes);
            TwentyFourHourTime endTime = new TwentyFourHourTime(endTimeHours, endTimeMinutes);

            Assert.Throws<ArgumentOutOfRangeException>(delegate { new BabysitterTimeCard(startTime, endTime); });
        }
    }
}
