using System;
using System.Collections.Generic;
using System.Text;

namespace PwF.Statics
{
    public static class DiceRoll
    {
        public static int Roll(int[][] dice) {
            foreach (int[] die in dice) {
                int rolls = die[0];
                int faces = die[1];
                Objects.Dice tmpDice = new Objects.Dice(faces);
                int value = 0;
                for(int i = 0; i < rolls; i++) {
                    value = tmpDice.Roll();
                }
                return value;
            }

            return 0;
        }
    }
}
