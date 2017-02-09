using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BabysitterKata.Tests
{
    class BabysitterPaySheet_Tests
    {
        [TestCase(3, 2, 3)]
        public void BabysitterPaySheet_GivenThreeValidParameters_CreateBabysitterPaySheet(int hrsBeforeBed, int hrsBedToMidnight, int hrsAfterMidnight)
        {
            BabysitterPaySheet paySheet = new BabysitterPaySheet(hrsBeforeBed, hrsBedToMidnight, hrsAfterMidnight);

            Assert.IsInstanceOf(typeof(BabysitterPaySheet), paySheet);
        }
    }
}
