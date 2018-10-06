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

        public string SelectedClass { get; set; }
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
            if (SelectedClass != "" && SelectedClass != null)
            {
                // save the Selected Class
                // Navigate to the next page
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