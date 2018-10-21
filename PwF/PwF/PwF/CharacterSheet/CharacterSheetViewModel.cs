using Pwf.Navigation;
using Pwf.Template;
using PwF.Cells.PwF.Cells;
using System;
using System.Collections.Generic;
using System.Text;

namespace PwF.CharacterSheet {
    class CharacterSheetViewModel : ViewModelBase {

        private PageNavigationManager navManager;
        private List<Objects.Character> Characters;
        public Objects.Character character;
        public int position;

        private List<CustomCell> statuses;
        public List<CustomCell> Statuses {
            get { return statuses; }
            set {
                statuses = value;
                OnPropertyChanged();
            }
        }

        private string languageCells;
        public string LanguageCells {
            get { return languageCells; }
            set {
                languageCells = value;
                OnPropertyChanged();
            }
        }


        public CharacterSheetViewModel(int i) {
            navManager = PageNavigationManager.Instance;

            Characters = Statics.JsonStuff.DeserializeCharacters();
            position = i;
            character = Characters[i];

            LanguageCells = CreateLanguageCells(character.Languages);
            Statuses = GetStatusCells(character.Statuses);
        }

        public List<CustomCell> GetStatusCells(List<string> statuses) {
            List<CustomCell> statusCells = new List<CustomCell>();

            for(int i = 0; i < statuses.Count; i++) {
                statusCells.Add(new CustomCell(statuses[i]));
            }

            return statusCells;
        }

        public bool AddStatusAffect(string status) {
            bool exists = false;
            for (int i = 0; i < character.Statuses.Count; i++) {
                if (character.Statuses[i] == status) {
                    exists = true;
                }
            }
            if (!exists) {
                character.Statuses.Add(status);
            }

            Statuses = GetStatusCells(character.Statuses);
            SaveCharacter();
            return !exists;
        }

        public bool RemoveStatusAffect(string status) {
            bool exists = false;
            for (int i = 0; i < character.Statuses.Count; i++) {
                if (character.Statuses[i] == status) {
                    exists = true;
                }
            }
            if (exists) {
                character.Statuses.Remove(status);
            }

            Statuses = GetStatusCells(character.Statuses);
            SaveCharacter();
            return exists;
        }

        private string CreateLanguageCells(List<string> languages) {
            string languageCells = "";
            for (int i = 0; i < languages.Count; i++) {
                if(i != 0) {
                    languageCells += ", " + languages[i];
                } else {
                    languageCells += languages[i];
                }

            }
            return languageCells;
        }

        public List<string> GetRaceLanguages() {
            List<string> languages = new List<string>();

            for(int i = 0; i < character.CharRace.Languages.Count; i++) {
                bool exists = false;
                for(int j = 0; j < character.Languages.Count; j++) {
                    if(character.Languages[j] == character.CharRace.Languages[i]) {
                        exists = true;
                    }
                }
                if (!exists) {
                    languages.Add(character.CharRace.Languages[i]);
                }
            }

            return languages;
        }

        public bool AddLanguage(string language) {
            bool exists = false;
            for(int i = 0; i < character.Languages.Count; i++) {
                if(character.Languages[i] == language) {
                    exists = true;
                }
            }
            if (!exists) {
                character.Languages.Add(language);
            }

            LanguageCells = CreateLanguageCells(character.Languages);
            SaveCharacter();
            return !exists;
        }

        public bool RemoveLanguage(string language) {
            bool exists = false;
            for (int i = 0; i < character.Languages.Count; i++) {
                if (character.Languages[i] == language) {
                    exists = true;
                }
            }
            if (exists) {
                character.Languages.Remove(language);
            }
            LanguageCells = CreateLanguageCells(character.Languages);
            SaveCharacter();
            return exists;
        }

        public void OpenCombatPage() {
            navManager.ShowCombatPage(position);
        }

        public void OpenSkillsPage() {

        }

        public void OpenSpellsPage() {

        }

        public void OpenItemsPage() {

        }

        public void OpenCharacterList() {

            //List<string> languages = new List<string>() { "Common", "Dragconic", "Elfish", "Orcish", "Celestial" };
            //character.CharRace.Languages = languages;

            SaveCharacter();
            navManager.ShowCharacterList();
        }

        public void SaveCharacter() {
            Characters[position] = character;
            Statics.JsonStuff.SerializeCharacters(Characters);
        }

    }
}
