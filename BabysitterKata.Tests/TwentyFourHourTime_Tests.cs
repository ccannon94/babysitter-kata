using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BabysitterKata.Tests
{
    public class TwentyFourHourTime_Tests
    {
        [TestCase(18, 13)]
        public void TwentyFourHourTime_HoursInitializeProperly(int hours, int minutes)
        {
            TwentyFourHourTime testTime = new TwentyFourHourTime(hours, minutes);
            Assert.That(testTime.Hours, Is.EqualTo(hours));
        }
    }
}
