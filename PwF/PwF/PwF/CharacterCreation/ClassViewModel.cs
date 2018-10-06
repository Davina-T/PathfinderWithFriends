using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pwf.Navigation;
using PwF.Cells;
using PwF.Cells.PwF.Cells;

using Xamarin.Forms;

namespace PwF.CharacterCreation
{
    public class ClassViewModel
    {
        private PageNavigationManager navManager;

        public CustomCell SelectedClass { get; set; }
        public List<CustomCell> CustomCells { get; }

        public ClassViewModel()
        {
            navManager = PageNavigationManager.Instance;
            CustomCells = getClasses();
        }

        private List<CustomCell> getClasses()
        {
            return ClassCode.getClassObjects();
        }

        public void NextPage()
        {
            if (SelectedClass != null && SelectedClass.Title != "")
            {
                Statics.CharacterCreating.CreatingCharacter.Class = SelectedClass.Title;
                navManager.ShowTesterPage();
            }
        }

        public void PrevPage()
        {
            navManager.ShowRacePage();
        }

        public void ViewInfo()
        {
            // open the informative page
        }
	}
}