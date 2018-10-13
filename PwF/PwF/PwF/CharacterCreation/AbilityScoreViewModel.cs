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
        public List<int> Numbers { get; set; }
        public List<int> NumbersUsed { get; set; }

        public AbilityScoreViewModel() {
            navManager = PageNavigationManager.Instance;
            D6 = new Dice(6);
            Scores = Statics.CharacterCreating.CreatingCharacter.Scores;
            Numbers = Statics.CharacterCreating.ScoreRolls;
            NumbersUsed = Statics.CharacterCreating.ScoreRollsUsed;

        }

        public void NextPage() {
            if (Scores.Strength.Value != 0 &&
                Scores.Dexterity.Value != 0 &&
                Scores.Constitution.Value != 0 &&
                Scores.Intelligence.Value != 0 &&
                Scores.Wisdom.Value != 0 &&
                Scores.Charisma.Value != 0) {
                Statics.CharacterCreating.CreatingCharacter.Scores = Scores;
                Statics.CharacterCreating.ScoreRolls = Numbers;
                Statics.CharacterCreating.ScoreRollsUsed = NumbersUsed;
                navManager.ShowSkillsPage();
            }
        }

        public void PrevPage() {
            navManager.ShowFamiliarPage(false);
        }

        public void ViewInfo() {
             // open the informative page
        }

        public int[] RollMany(int number) {
            int[] results = new int[number];
            for(int i = 0; i < number; i++) {
                results[i] = D6.Roll();
            }

            return results;
        }

        public int FindLowestValue(int[] numbers) {
            int position = 0;
            int value = numbers[0];
            for(int i = 1; i < numbers.Length; i++) {
                if (value > numbers[i]) {
                    value = numbers[i];
                    position = i;
                }
            }

            return position;

        }

    }
}
