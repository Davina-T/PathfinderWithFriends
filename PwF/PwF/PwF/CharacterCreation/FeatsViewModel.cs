using Pwf.Navigation;
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

        public FeatsViewModel() {
            navManager = PageNavigationManager.Instance;
            Feats = new List<Feat>();
        }

        public void NextPage() {
            if (Feats.Count != 0) {
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
