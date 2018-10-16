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

        public FeatsViewModel(/*List<SelectableData<FeatListData>> data*/) {
            navManager = PageNavigationManager.Instance;
            Feats = new List<Feat>();
            //FeatList = data;
        }

        //public List<SelectableData<FeatListData>> FeatList { get; set; }

        /*public List<SelectableData<FeatListData>> GetNewData()
        {
            var list = new List<SelectableData<FeatListData>>();

            foreach (var data in FeatList)
                list.Add(new SelectableData<FeatListData>() { Data = data.Data.Clone(), Selected = data.Selected });

            return list;
        }*/

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
