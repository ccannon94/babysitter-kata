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
        public void BabysitterTimeCard_GivenTwoValidTime_CalculatesTotalTime(TwentyFourHourTime startTime, TwentyFourHourTime endTime)
        {
            BabysitterTimeCard timeCard = new BabysitterTimeCard(startTime, endTime);
            Assert.AreEqual((endTime.Hours - startTime.Hours) + ((endTime.Hours - startTime.Hours)/60), timeCard.CalculateTotalTime());
        }
    }
}
