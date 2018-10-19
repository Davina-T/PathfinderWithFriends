using System;
using System.Collections.Generic;
using System.Text;
using Pwf.Navigation;
//using PwF.Classes;
using PwF.Objects;

namespace PwF.CharacterCreation
{
    class SkillsViewModel
    {
        private PageNavigationManager navManager;
        private int remainingPoints { get; set; }

        public SkillsViewModel()
        {
            navManager = PageNavigationManager.Instance;
        }

        public void NextPage()
        {
            if (remainingPoints == 0)
            {
                navManager.ShowFeatsPage();
            }
        }

        public void PrevPage()
        {
            navManager.ShowAbilityScoresPage(false);
        }

        public void ViewInfo()
        {
            // open the informative page
        }
        /*
        public void IncreaseAcrobatics()
        {
            if (remainingPoints != 0)
            {

            }
        }

        public void DecreaseAcrobatics()
        {

        }
        */
    }
}
