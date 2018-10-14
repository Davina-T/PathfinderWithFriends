using System;
using System.Collections.Generic;
using System.Text;
using Pwf.Navigation;
using PwF.Cells.PwF.Cells;

namespace PwF.CharacterCreation
{
    class SkillsViewModel
    {
        private PageNavigationManager navManager;
        public List<CustomCell> CustomCells { get; }

        public SkillsViewModel()
        {
            navManager = PageNavigationManager.Instance;
            //CustomCells = getSkills();
        }

        //private List<CustomCell> getSkills()
        //{
        //    return SkillsCode.GetSkillObjects();
        //}

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
