using System;
using System.Collections.Generic;
using System.Text;

namespace PwF.Objects
{
    public class Money
    {
        public int CP { get; set; }
        public int SP { get; set; }
        public int GP { get; set; }
        public int PP { get; set; }

        public Money() {
            CP = 0;
            SP = 0;
            GP = 0;
            PP = 0;
        }

        public double GetTotal() {
            double total = 0;
            total = ((double)CP/1000) + ((double)SP /100) + ((double)GP) + ((double)PP * 100);

            return total;
        }

        // Adds currency to amount in CP
        public void Add(int amount) {
            // adds the amount
            CP += amount;
            // corectifies the money
            CorectifyAddedMoney();
        }

        // Subtract currency from amount in CP
        public bool Subtract(int amount) {
            // check if the amount can be subtracted
            int total = CP + (SP * 100) + (GP * 10000) + (PP * 1000000);
            if (total > amount) {
                // subtracts the amount
                CP += amount;
                // corectifies the money
                CorectifySubtractedMoney();
                return true;
            }
            return false;
        }

        // Exchanges the currency to the highest value
        private void CorectifyAddedMoney() {
            int temp;

            // calutes the amount of 100's of CP and removes the number from CP and adds the number/100 to SP
            temp = (int)Math.Floor(((double)CP)/100.00);
            CP -= temp * 100;
            SP += temp;

            // calutes the amount of 100's of SP and removes the number from SP and adds the number/100 to GP
            temp = (int)Math.Floor(((double)SP) / 100.00);
            SP -= temp * 100;
            GP += temp;

            // calutes the amount of 100's of GP and removes the number from GP and adds the number/100 to PP
            temp = (int)Math.Floor(((double)GP) / 100.00);
            GP -= temp * 100;
            PP += temp;

        }

        public void CorectifySubtractedMoney() {
            int temp;

            // calutes the amount of 100's CP is below 0 and adds that number to CP while subtracting the number/100 from SP
            temp = (int)Math.Ceiling(((double)CP) / -100.00);
            CP += temp * 100;
            SP -= temp;

            // calutes the amount of 100's SP is below 0 and adds that number to SP while subtracting the number/100 from GP
            temp = (int)Math.Ceiling(((double)SP) / -100.00);
            SP += temp * 100;
            GP -= temp;

            // calutes the amount of 100's GP is below 0 and adds that number to GP while subtracting the number/100 from PP
            temp = (int)Math.Ceiling(((double)GP) / -100.00);
            GP += temp * 100;
            PP -= temp;
        }
    }
}
