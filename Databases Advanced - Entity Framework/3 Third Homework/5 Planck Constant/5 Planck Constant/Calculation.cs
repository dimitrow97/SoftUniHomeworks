﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_Planck_Constant
{
    class Calculation
    {
        public static double planck = 6.62606896e-34;
        public static double pi = 3.14159;

        public static double reduction()
        {
            double result = (planck / (2 * pi));
            return result;
        }
    }
}
