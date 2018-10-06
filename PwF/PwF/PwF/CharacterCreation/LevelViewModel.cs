using System;
using System.Collections.Generic;
using System.Text;
using Pwf.Navigation;

namespace PwF.CharacterCreation
{
    class LevelViewModel
    {
        private PageNavigationManager navManager;
        public LevelViewModel()
        {
            navManager = PageNavigationManager.Instance;
        }
        public void NextPage()
        {
            navManager.ShowRacePage();
        }

        public void PrevPage()
        {
            navManager.ShowCharacterList();
        }

        public void ViewInfo()
        {
            // open the informative page
        }
    }
}
