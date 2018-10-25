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
        public int remainingPoints { get; set; }
        public List<Skill> skills;


        public SkillsViewModel()
        {
            navManager = PageNavigationManager.Instance;
            if (Statics.CharacterCreating.CreatingCharacter.CharClass.Skills != null) {
                skills = Statics.CharacterCreating.CreatingCharacter.CharClass.Skills;
            } else {
                skills = new List<Skill>();
            }

            remainingPoints = (Statics.CharacterCreating.CreatingCharacter.CharClass.SkillPoints * 
                Statics.CharacterCreating.CreatingCharacter.Level) + 
                Statics.GlobalFunctions.ReturnModifier(Statics.CharacterCreating.CreatingCharacter.Scores.Intelligence.Value);
        }

        public void NextPage()
        {
            if (remainingPoints == 0)
            {
                Statics.CharacterCreating.CreatingCharacter.Skills = skills;
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
