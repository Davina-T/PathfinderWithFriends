using System;
using System.Collections.Generic;
using System.Text;
using Pwf.Navigation;
using PwF.Objects;

namespace PwF.CharacterCreation
{

    public class MoneyViewModel 
    {

        //Create Global variables:
        private PageNavigationManager navManager;
        private readonly Dice D6;
        public List<int> Numbers { get; set; }
        public Money Coin { get; set; }
        public string Class { get; set; }

        //Create the money viewmodel:
        public MoneyViewModel()
        {
            //Setup navigation:
            navManager = PageNavigationManager.Instance;
            //Create Dice:
            D6 = new Dice(6);

            //Check if the charater has money already:
            if(Statics.CharacterCreating.CreatingCharacter.Coin == null)
            {
                //Create a money Object:
                Coin = new Money();
            }else{
                //Set the characters money to the current object:
                Coin = Statics.CharacterCreating.CreatingCharacter.Coin;
            }

            //Check if there is a class selected for the character:
            if (Statics.CharacterCreating.CreatingCharacter.Class == null)
            {
                //Assign a stubbed class:
                Class = "Wizard";
            }else{
                //Assign the character's class to this object:
                Class = Statics.CharacterCreating.CreatingCharacter.Class;
            }
            
        }

        //Change to the next page:
        public void NextPage()
        {
            //Check if the money values have been set:
            if (Coin.GP != 0) {
                //Go to the next page:
                Statics.CharacterCreating.CreatingCharacter.Coin = Coin;
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

        //Determine how many times the dice needs to be rolled:
        public void CalculateMoney()
        {
            //Get value from class selected here:
            int WealthRolls = 4; //STUB
            //Money variables:
            int Gold = 0;
            int Copper = 0;
            //Roll the dice:
            int[] Rolls = RollMany(WealthRolls);

            //Get the numbers and add them together:
            for(int i=0; i<WealthRolls; i++)
            {
                //Get the number:
                int tempNum = Rolls[i];
                Gold += tempNum;
            }

            //Show the user how mmuch gold they have:
            Gold = Gold * 10;
            Coin.GP = Gold;

        }

    }
}
