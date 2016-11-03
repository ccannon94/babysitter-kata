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
        [TestCase(12, 15, 0, 0)]
        [TestCase(16, 47, 13, 4)]
        [TestCase(0, 12, 15, 42)]
        [TestCase(7, 15, 16, 32)]
        [TestCase(19, 15, 22, 32)]
        public void BabysitterTimeCard_GivenTwoValidTime_CalculatesTotalTime(int startTimeHours, int startTimeMinutes, int endTimeHours, int endTimeMinutes)
        {
            TwentyFourHourTime startTime = new TwentyFourHourTime(startTimeHours, startTimeMinutes);
            TwentyFourHourTime endTime = new TwentyFourHourTime(endTimeHours, endTimeMinutes);

            BabysitterTimeCard timeCard = new BabysitterTimeCard(startTime, endTime);

            Assert.AreEqual((endTime.Hours - startTime.Hours) + (((double)endTime.Minutes - (double)startTime.Minutes)/60), timeCard.CalculateTotalTime());
        }
    }
}
