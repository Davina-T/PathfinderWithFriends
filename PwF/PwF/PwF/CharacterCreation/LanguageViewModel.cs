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

        public CustomCell SelectedLanguages { get; set; }
        public List<CustomCell> CustomCells { get; }
        //public List<String> CustomCells = new List<String>();

        public LanguageViewModel()
        {
            navManager = PageNavigationManager.Instance;
            CustomCells = getLanguages();
        }

        private List<CustomCell> getLanguages()
        {
            return LanguagesCode.getLanguageObjects();
        }

        public void NextPage()
        {
            //if (SelectedLanguages != null && SelectedLanguages.Title != "")
            //{
            //    return;
            //}

            //Statics.CharacterCreating.CreatingCharacter.Languages = SelectedLanguages.Title;
            navManager.ShowRacePage();
        }

        public void PrevPage()
        {
            Statics.CharacterCreating.CreatingCharacter.Languages = null;
            navManager.ShowCharacterList(false);
        }

        public void ViewInfo()
        {
            // open the informative page
        }
    }
}
