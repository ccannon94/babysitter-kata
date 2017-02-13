﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabysitterKata
{
    public class BabysitterPaySheet
    {
        public int Pay { get { return _pay; } }

        private const int BEFORE_BEDTIME_PAY_RATE = 12;
        private const int BEDTIME_TO_MIDNIGHT_PAY_RATE = 8;
        private const int AFTER_MIDNIGHT_PAY_RATE = 16;

        private int _pay;

        public BabysitterPaySheet(int hrsBeforeBed, int hrsBedToMidnight, int hrsAfterMidnight)
        {
            _pay = (hrsBeforeBed * BEFORE_BEDTIME_PAY_RATE) + (hrsBedToMidnight * BEDTIME_TO_MIDNIGHT_PAY_RATE) + (hrsAfterMidnight * AFTER_MIDNIGHT_PAY_RATE);
        }
    }
}