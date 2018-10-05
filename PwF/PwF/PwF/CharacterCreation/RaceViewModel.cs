using Pwf.Navigation;
using PwF.Cells.PwF.Cells;
using System;
using System.Collections.Generic;
using System.Text;

namespace PwF.CharacterCreation
{
    public class RaceViewModel {
        private PageNavigationManager navManager;

        public string SelectedRace { get; set; }
        public List<CustomCell> CustomCells { get; }

        public RaceViewModel() {
            navManager = PageNavigationManager.Instance;
            CustomCells = getRaces();
        }

        private List<CustomCell> getRaces() {
            return RaceCode.getRaceObjects();
        }

        public void NextPage() {
            if (SelectedRace != "" && SelectedRace != null) {
                // save the Selected Race
                navManager.ShowClassPage();
            }
        }

        public void PrevPage() {
            navManager.ShowLevelPage();
        }

        public void ViewInfo() {
            // open the informative page
        }
    }
}
