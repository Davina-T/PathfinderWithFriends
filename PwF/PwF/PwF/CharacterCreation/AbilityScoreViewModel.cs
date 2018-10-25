using Newtonsoft.Json;
using Pwf.Navigation;
using Pwf.Template;
using PwF.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PwF.CharacterCreation
{
    public class AbilityScoreViewModel : ViewModelBase
    {
        private PageNavigationManager navManager;
        private readonly Dice D6;
        public List<int> Numbers { get; set; }
        public AbilityScores Scores;

        private List<int> numbersUsed;
        public List<int> NumbersUsed {
            get { return numbersUsed; }
            set {
                numbersUsed = value;
                OnPropertyChanged();
            }
        }

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
