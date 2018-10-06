using System;
using System.Collections.Generic;
using System.Text;
using Pwf.Navigation;

namespace PwF.CharacterCreation
{
    class LevelViewModel
    {
        private PageNavigationManager navManager;
        public int Level { get; set; }

        public LevelViewModel()
        {
            navManager = PageNavigationManager.Instance;
            Level = Statics.CharacterCreating.CreatingCharacter.Level;
        }
        public void NextPage()
        {
            if(Level > 0) {
                Statics.CharacterCreating.CreatingCharacter.Level = Level;
                navManager.ShowRacePage();
            }
        }

        public void PrevPage()
        {
            Statics.CharacterCreating.CreatingCharacter.Level = 0;
            navManager.ShowCharacterList();
        }

        public void ViewInfo()
        {
            // open the informative page
        }
    }
}
