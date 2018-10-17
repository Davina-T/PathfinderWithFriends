using Pwf.Navigation;
using PwF.Cells.PwF.Cells;
using PwF.Objects;
using PwF.Statics;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PwF.CharacterCreation
{
    public class FeatsViewModel
    {
        private PageNavigationManager navManager;
        public List<Feat> Feats;

        public List<CustomCell> PossibleFeats { get; }
        public CustomCell PossibleFeatSelected { get; set; }
        public List<CustomCell> SelectedFeats { get; }
        public CustomCell SelectedFeatSelected { get; set; }
        public int FeatsAmount { get; set; }
        public int FeatsLeft { get; set; }

        public FeatsViewModel() {
            navManager = PageNavigationManager.Instance;
            Feats = new List<Feat>();
            PossibleFeats = getFeats();
            SelectedFeats = new List<CustomCell>();
            FeatsAmount = GetAmountofFeats();
            FeatsLeft = FeatsAmount;
        }

        int GetAmountofFeats() {
            //int temp = (int)(Math.Floor((double)CharacterCreating.CreatingCharacter.Level+1)/2);

            int temp = (int)(Math.Floor((double)4 + 1) / 2);

            return temp;
        }

        public void MoveToSelected(CustomCell cell) {
            if(FeatsLeft > 0) {
                for (int i = 0; i < PossibleFeats.Count; i++) {
                    if (cell.Equals(PossibleFeats[i])) {
                        PossibleFeats.Remove(cell);
                        SelectedFeats.Add(cell);
                    }
                }
                FeatsLeft -= 1;
            }
        }

        public void MoveToPossible(CustomCell cell) {
            for (int i = 0; i < SelectedFeats.Count; i++) {
                if (cell.Equals(SelectedFeats[i])) {
                    PossibleFeats.Add(cell);
                    SelectedFeats.Remove(cell);
                    FeatsLeft += 1;
                }
            }
        }

        private List<CustomCell> getFeats() {

            string[] feats = new string[] {
                "Weapons Finesse", "Dark Vision", "Glide", "Other One"};

            List<CustomCell> CustomCells = new List<CustomCell>();

            foreach (string feat in feats) {
                CustomCells.Add(new CustomCell(feat));
            }

            return CustomCells;
        }

        private string[] RequestFeatsDescription(string[] feats) {
            string[] descriptions = new string[feats.Length];

            // perform request to get data
            //string[] data = new string[] { "this is stubbed" };

            for(int i = 0; i < feats.Length; i++) {
                descriptions[i] = "This is stub data";
            }

            return descriptions;
        }

        public void NextPage() {
            if (FeatsLeft == 0) {

                // get list and data
                string[] featNames = new string[SelectedFeats.Count];
                for(int i = 0; i < featNames.Length; i++) {
                    featNames[i] = SelectedFeats[i].Title;
                }
                string[] featDescriptions = RequestFeatsDescription(featNames);

                for (int i = 0; i < featNames.Length; i++) {
                    Feats.Add(new Feat(featNames[i], featDescriptions[i]));
                }

                // send to next page
                Statics.CharacterCreating.CreatingCharacter.Feats = Feats;
                navManager.ShowLanguagesPage();
            }
        }

        public void PrevPage() {
            //Statics.CharacterCreating.CreatingCharacter.Race = null;
            navManager.ShowSkillsPage(false);
        }

        public void ViewInfo() {
            // open the informative page
        }
    }
}
