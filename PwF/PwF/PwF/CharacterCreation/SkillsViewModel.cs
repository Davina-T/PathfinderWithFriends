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
        public Skills SkillValues { get; set; }
        private int remainingPoints { get; set; }

        public SkillsViewModel()
        {
            navManager = PageNavigationManager.Instance;
            SkillValues = new Skills();
        }

        public void NextPage()
        {
            if (remainingPoints == 0)
            {
                Statics.CharacterCreating.CreatingCharacter.Skills = SkillValues;
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

        public void IncreaseAcrobatics()
        {
            if (remainingPoints != 0)
            {
                SkillValues.Acrobatics.Value += 1;
                remainingPoints -= 1;
            }
        }

        public void DecreaseAcrobatics()
        {
            SkillValues.Acrobatics.Value -= 1;
            remainingPoints += 1;
        }
    }
}
