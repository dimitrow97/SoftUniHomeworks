using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_Math_Utilities
{
    class MathUtil
    {
        public static double Sum(double one, double two)
        {
            return one + two;
        }

        public static double Sub(double one, double two)
        {
            return one - two;
        }

        public static double Multiply(double one, double two)
        {
            return one * two;
        }

        public static double Div(double one, double two)
        {
            return one / two;
        }

        public static double Percentage(double one, double two)
        {
            return (one*two)/100;
        }     
    }
}
