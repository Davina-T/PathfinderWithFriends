using System;
using System.Collections.Generic;
using System.Text;

namespace PwF.Statics
{
    public static class GlobalFunctions
    {

        // returning the modifier of selected Score
        public static int ReturnModifier(int scoreValue) {
            double temp;

            // if found Score then apply equation, round down number and return result
            temp = (Math.Floor(((double)scoreValue - 10) / 2));
            return (int)temp;

        }
    }
}
