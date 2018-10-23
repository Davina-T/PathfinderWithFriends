using Pwf.Navigation;
using PwF.Cells.PwF.Cells;
using System;
using System.Collections.Generic;
using System.Text;

namespace PwF.CharacterCreation
{
    public class EquipmentPageViewModel
    {
        private PageNavigationManager navManager;
        public CustomCell PossibleItemsSelected { get; set; }
        public CustomCell SelectedItemSelected { get; set; }

        public EquipmentPageViewModel()
        {
            navManager = PageNavigationManager.Instance;

        }

        public void NextPage()
        {
            //if (SelectedRace != null && SelectedRace.Title != "") {
            //    Statics.CharacterCreating.CreatingCharacter.Race = SelectedRace.Title;
            //    navManager.ShowClassPage();
            //}
        }

        public void PrevPage()
        {
            //Statics.CharacterCreating.CreatingCharacter.Race = null;
            //navManager.ShowLevelPage(false);
        }

        public void ViewInfo()
        {
            // open the informative page
        }
    }
}

