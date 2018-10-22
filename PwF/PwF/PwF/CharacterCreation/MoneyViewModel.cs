using System;
using System.Collections.Generic;
using System.Text;
using Pwf.Navigation;
using PwF.Objects;

namespace PwF.CharacterCreation
{

    public class MoneyViewModel 
    {
        private PageNavigationManager navManager;
        private readonly Dice D6;
        public List<int> Numbers { get; set; }
        public Money Coin { get; set; }

        public MoneyViewModel()
        {
            navManager = PageNavigationManager.Instance;
            D6 = new Dice(6);
            Coin = Statics.CharacterCreating.CreatingCharacter.Coin;

        }

        //Change to the next page:
        public void NextPage()
        {
            //Check if the money values have been set:
            if (Coin.PP != 0 ||
                Coin.GP != 0 ||
                Coin.SP != 0 ||
                Coin.CP != 0) {

                Statics.CharacterCreating.CreatingCharacter.Coin = Coin;
                //Statics.CharacterCreating.ScoreRolls = Numbers;
                //Statics.CharacterCreating.ScoreRollsUsed = NumbersUsed;
                navManager.ShowEquipmentPage();
            }
        }

        //View the previous page:
        public void PrevPage()
        {
            //Go back but don't show the familiar:
            navManager.ShowSpellssPage(false);
        }

        //View the information page:
        public void ViewInfo()
        {
            // open the informative page
        }

        //Roll the Dice more than once:
        public int[] RollMany(int number)
        {
            //Create an array of ints:
            int[] results = new int[number];

            //Roll the dice for the selected amount of times:
            for (int i = 0; i < number; i++)
            {
                //Add the result to the array:
                results[i] = D6.Roll();
            }

            //Return the array:
            return results;

        }

        //Convert amount to copper:
        public int ConvertToCopper(int Gold)
        {
            //Return the copper amount:
            return Gold * 10000;
        }

    }
}
