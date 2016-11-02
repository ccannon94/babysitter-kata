using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BabysitterKata;

namespace BabysitterKata.Tests
{
    public class TwentyFourHourTime_Tests
    {
        [TestCase(18, 13)]
        [TestCase(20, 57)]
        [TestCase(4, 15)]
        [TestCase(15, 0)]
        [TestCase(23, 32)]
        public void TwentyFourHourTime_HoursInitializeProperly(int hours, int minutes)
        {
            TwentyFourHourTime testTime = new TwentyFourHourTime(hours, minutes);
            Assert.That(testTime.Hours, Is.EqualTo(hours));
        }

        [TestCase(14, 32)]
        [TestCase(12, 13)]
        [TestCase(5, 42)]
        [TestCase(17, 0)]
        [TestCase(3, 36)]
        public void TwentyFourHourTime_MinutesInitializeProperly(int hours, int minutes)
        {
            TwentyFourHourTime testTime = new TwentyFourHourTime(hours, minutes);
            Assert.That(testTime.Minutes, Is.EqualTo(minutes));
        }
    }
}
