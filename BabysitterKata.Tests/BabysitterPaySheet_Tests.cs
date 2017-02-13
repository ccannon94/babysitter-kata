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
        [TestCase(0, 0, 0)]
        [TestCase(3, 2, 3)]
        [TestCase(2, 5, 3)]
        [TestCase(1, 2, 5)]
        public void BabysitterPaySheet_GivenThreeValidParameters_CreateBabysitterPaySheet(int hrsBeforeBed, int hrsBedToMidnight, int hrsAfterMidnight)
        {
            BabysitterPaySheet paySheet = new BabysitterPaySheet(hrsBeforeBed, hrsBedToMidnight, hrsAfterMidnight);

            Assert.IsInstanceOf(typeof(BabysitterPaySheet), paySheet);
        }

        [TestCase(1, 2, 3, 76)]
        public void BabysitterPaySheet_GivenThreeValidParameters_ReturnCorrectPay(int hrsBeforeBed, int hrsBedToMidnight, int hrsAfterMidnight, int expectedPay)
        {
            BabysitterPaySheet paySheet = new BabysitterPaySheet(hrsBeforeBed, hrsBedToMidnight, hrsAfterMidnight);

            Assert.AreEqual(expectedPay, paySheet.Pay);
        }
    }
}
