using Pwf.Navigation;
using PwF.Cells.PwF.Cells;
using System;
using System.Collections.Generic;
using System.Text;

namespace PwF.CharacterCreation
{
    public class RaceViewModel {
        private PageNavigationManager navManager;

        public CustomCell SelectedRace { get; set; }
        //public string[] Races { get; set; }
        public List<CustomCell> CustomCells { get; }

        public RaceViewModel() {
            navManager = PageNavigationManager.Instance;
            CustomCells = getRaces();
            //foreach(CustomCell cell in CustomCells) {
            //    if (cell.Title == Statics.CharacterCreating.CreatingCharacter.Race) {
            //        SelectedRace = cell;
            //    }
            //}
        }

        private List<CustomCell> getRaces() {
            return RaceCode.getRaceObjects();
        }

        public void NextPage() {
            if (SelectedRace != null && SelectedRace.Title != "") {
                Statics.CharacterCreating.CreatingCharacter.Race = SelectedRace.Title;
                navManager.ShowClassPage();
            }
        }

        public void PrevPage() {
            Statics.CharacterCreating.CreatingCharacter.Race = null;
            navManager.ShowLevelPage();
        }

        public void ViewInfo() {
            // open the informative page
        }
    }
}
