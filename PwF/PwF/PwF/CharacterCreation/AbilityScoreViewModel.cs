using Pwf.Navigation;
using PwF.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PwF.CharacterCreation
{
    public class AbilityScoreViewModel
    {
        private PageNavigationManager navManager;
        public AbilityScores Scores { get; set; }
        private readonly Dice D6; 


        public AbilityScoreViewModel() {
            navManager = PageNavigationManager.Instance;
            D6 = new Dice(6);
        }

        public void NextPage() {
            //if (SelectedRace != null && SelectedRace.Title != "") {
                navManager.ShowSkillsPage();
            //}
        }

        public void PrevPage() {
            navManager.ShowFamiliarPage(false);
        }

        public void ViewInfo() {
             // open the informative page
        }

        public void ShowPopUp() {

        }

        public int[] RollMany(int number) {
            int[] results = { };
            for(int i = 0; i < number; i++) {
                results[i] = D6.Roll();
            }

            return results;
        }

        public int FindLowestValue(int[] numbers) {
            int position = 0;
            int value = numbers[0];
            for(int i = 1; i < numbers.Length; i++) {
                if (value < numbers[i]) {
                    value = numbers[i];
                    position = i;
                }
            }

            return position;

        }

    }
}
