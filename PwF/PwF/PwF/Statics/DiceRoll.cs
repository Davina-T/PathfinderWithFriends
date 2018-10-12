using System;
using System.Collections.Generic;
using System.Text;

namespace PwF.Statics
{
    public static class DiceRoll
    {
        public static int Roll(int[][] dice) {
            int total = 0;
            foreach (int[] die in dice) {
                int rolls = die[0];
                int faces = die[1];
                Objects.Dice tmpDice = new Objects.Dice(faces);
                int value = 0;
                for(int i = 0; i < rolls; i++) {
                    value = tmpDice.Roll();
                }
                total += value;
            }

            return total;
        }

        public static int RollSet(int[] dice) {
            int total = 0;
            foreach (int faces in dice) {
                Objects.Dice tmpDice = new Objects.Dice(faces);
                total += tmpDice.Roll();
            }

            return total;
        }

        public static int SingleRoll(int faces) {
            Objects.Dice tmpDice = new Objects.Dice(faces);
            int value = tmpDice.Roll();

            return value;
        }

        public static int[] RollSetWithDetail(int[] dice) {
            int[] total = { };

            for (int i = 0; i < dice.Length; i++) {
                Objects.Dice tmpDice = new Objects.Dice(dice[i]);
                total[i] = tmpDice.Roll();
            }

            return total;
        }
    }
}
