using System;
using System.Collections.Generic;
using System.Text;
using Pwf.Navigation;
using PwF.Cells.PwF.Cells;

namespace PwF.CharacterCreation
{
    class LanguageViewModel
    {
        private PageNavigationManager navManager;

        public List<string> Languages { get; set; }

        public List<CustomCell> StartingLanguages { get; set; }
        public List<CustomCell> PossibleLanguages { get; set; }
        public CustomCell PossibleLanguage { get; set; }
        public List<CustomCell> SelectedLanguages { get; }
        public CustomCell SelectedLanguage { get; set; }

        public int LanguagesAmount { get; set; }
        public int LanguagesLeft { get; set; }
        //public List<String> CustomCells = new List<String>();

        public LanguageViewModel()
        {
            navManager = PageNavigationManager.Instance;
            Languages = new List<string>();
            StartingLanguages = getStartingLanguages();
            PossibleLanguages = getLanguages();
            SelectedLanguages = new List<CustomCell>();
            SelectedLanguages = GetStartingAndSelected();
            LanguagesAmount = GetAmountOfLanguages();
            LanguagesLeft = LanguagesAmount;
        }

        private int GetAmountOfLanguages() {
            int temp = Statics.GlobalFunctions.ReturnModifier(Statics.CharacterCreating.CreatingCharacter.Scores.Intelligence.Value);
            if(temp < 0) {
                temp = 0;
            }
            temp += GetLinguisticsSkill();

            return temp;
        }

        private int GetLinguisticsSkill() {
            for(int i = 0; i < Statics.CharacterCreating.CreatingCharacter.Skills.Count; i++) {
                if(Statics.CharacterCreating.CreatingCharacter.Skills[i].Name == "Linguistics") {
                    return Statics.CharacterCreating.CreatingCharacter.Skills[i].Value;
                }
            }
            return 0;
        }

        private List<CustomCell> getLanguages()
        {
            List<string> languages = Statics.CharacterCreating.CreatingCharacter.CharRace.Languages;

            List<CustomCell> CustomCells = new List<CustomCell>();

            foreach (string language in languages) {
                CustomCells.Add(new CustomCell(language));
            }

            return CustomCells;

        }

        private List<CustomCell> getStartingLanguages() {
            List<string> languages = Statics.CharacterCreating.CreatingCharacter.CharRace.StartingLanguages;

            List<CustomCell> CustomCells = new List<CustomCell>();

            foreach (string language in languages) {
                CustomCells.Add(new CustomCell(language + "*"));
            }

            return CustomCells;
        }

        public void MoveToSelected(CustomCell cell) {
            if (LanguagesLeft > 0) {
                for (int i = 0; i < PossibleLanguages.Count; i++) {
                    if (cell.Equals(PossibleLanguages[i])) {
                        PossibleLanguages.Remove(cell);
                        SelectedLanguages.Add(cell);
                    }
                }
                LanguagesLeft -= 1;
            }
        }

        public void MoveToPossible(CustomCell cell) {
            for (int i = 0; i < SelectedLanguages.Count; i++) {
                if (cell.Equals(SelectedLanguages[i])) {
                    if (CheckInStarting(cell)) {
                        PossibleLanguages.Add(cell);
                        SelectedLanguages.Remove(cell);
                        LanguagesLeft += 1;
                    }
                }
            }
        }

        public bool CheckInStarting(CustomCell cell) {
            bool check = true;
            for (int j = 0; j < StartingLanguages.Count; j++) {
                if (cell.Title == StartingLanguages[j].Title) {
                    check = false;
                }
            }
            return check;
        }

        public void NextPage()
        {
            if (LanguagesLeft == 0 || PossibleLanguages.Count == 0) {

                List<string> languages = new List<string>();
                for (int i = 0; i < SelectedLanguages.Count; i++) {
                    languages.Add(SelectedLanguages[i].Title);
                }

                // send to next page
                Statics.CharacterCreating.CreatingCharacter.Languages = languages;
                navManager.ShowSpellsPage();
            }
        }

        public void PrevPage()
        {
            navManager.ShowFeatsPage(false);
        }

        public void ViewInfo()
        {
            // open the informative page
        }

        public List<CustomCell> GetStartingAndSelected() {
            List<string> temp = new List<string>();
            List<CustomCell> tempCells = new List<CustomCell>();

            for (int i = 0; i < StartingLanguages.Count; i++) {
                temp.Add(StartingLanguages[i].Title);
            }

            for (int i = 0; i < SelectedLanguages.Count; i++) {
                temp.Add(SelectedLanguages[i].Title);
            }

            for(int i = 0; i < temp.Count; i++) {
                tempCells.Add(new CustomCell(temp[i]));
            }


            return tempCells;
        }
    }
}
