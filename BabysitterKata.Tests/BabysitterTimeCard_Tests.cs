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
        [TestCase(19, 15, 22, 32)]
        public void BabysitterTimeCard_GivenTwoValidTime_CalculatesTotalTime(int startTimeHours, int startTimeMinutes, int endTimeHours, int endTimeMinutes)
        {
            TwentyFourHourTime startTime = new TwentyFourHourTime(startTimeHours, startTimeMinutes);
            TwentyFourHourTime endTime = new TwentyFourHourTime(endTimeHours, endTimeMinutes);

            BabysitterTimeCard timeCard = new BabysitterTimeCard(startTime, endTime);

            Assert.AreEqual((endTime.Hours - startTime.Hours) + ((endTime.Hours - startTime.Hours)/60), timeCard.CalculateTotalTime());
        }
    }
}
