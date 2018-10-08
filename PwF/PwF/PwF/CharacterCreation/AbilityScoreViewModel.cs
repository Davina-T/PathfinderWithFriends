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


        public AbilityScoreViewModel() {
            navManager = PageNavigationManager.Instance;
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
    }
}
