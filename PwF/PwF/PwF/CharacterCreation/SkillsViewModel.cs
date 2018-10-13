using System;
using System.Collections.Generic;
using System.Text;
using Pwf.Navigation;

namespace PwF.CharacterCreation
{
    class SkillsViewModel
    {
        private PageNavigationManager navManager;

        public SkillsViewModel()
        {
            navManager = PageNavigationManager.Instance;
        }

        public void NextPage()
        {
            navManager.ShowFeatsPage();
        }

        public void PrevPage()
        {
            navManager.ShowAbilityScoresPage(false);
        }

        public void ViewInfo()
        {
            // open the informative page
        }
    }
}
