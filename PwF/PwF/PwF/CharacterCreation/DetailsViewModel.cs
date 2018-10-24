using System;
using System.Collections.Generic;
using System.Text;
using Pwf.Navigation;
using Pwf.Template;

namespace PwF.CharacterCreation
{
    public class DetailsViewModel : ViewModelBase {
        private PageNavigationManager navManager;

        //public String SelectedName { get; set; }
        //public String SelectedAlignment { get; set; }
        //public String SelectedDeity { get; set; }
        //public String SelectedHomeland { get; set; }
        //public String SelectedSize { get; set; }
        //public String SelectedGender { get; set; }
        //public String SelectedAge { get; set; }
        //public String SelectedHeight { get; set; }
        //public String SelectedWeight { get; set; }
        //public String SelectedHair { get; set; }
        //public String SelectedEyes { get; set; }

        private Objects.CharacterDetails details;
        public Objects.CharacterDetails Details {
            get { return details; }
            set {
                details = value;
                OnPropertyChanged();
            }
        }

        private string alignmentString;
        public string AlignmentString {
            get { return alignmentString; }
            set {
                alignmentString = value;
                OnPropertyChanged();
            }
        }

        private string name;
        public string Name {
            get { return name; }
            set {
                name = value;
                OnPropertyChanged();
            }
        }

        public DetailsViewModel() {
            navManager = PageNavigationManager.Instance;

            details = new Objects.CharacterDetails();
        }

        public Enums.Alignment GetAlignment(string alignment) {
            string[] alignments = {"Lawful Good", "Lawful Neutral", "Lawful Evil", "Neutral Good",
                "Neutral", "Neutral Evil", "Chaotic Good", "Chaotic Neutral", "Chaotic Evil" };

            Enums.Alignment[] alignemntEnums = { Enums.Alignment.LawfulGood, Enums.Alignment.LawfulNeutral,
                Enums.Alignment.LawfulEvil, Enums.Alignment.NeutralGood, Enums.Alignment.NeutralNeutral, Enums.Alignment.NeutralEvil,
                Enums.Alignment.ChaoticGood, Enums.Alignment.ChaoticNeutral, Enums.Alignment.ChaoticEvil};

            for (int i = 0; i < alignments.Length; i++) {
                if (alignments[i] == alignment) {
                    return alignemntEnums[i];
                }
            }

            return Enums.Alignment.NeutralNeutral;
        }

        public void NextPage()
        {

            if (Name != "" &&
                AlignmentString != "" &&
                Details.Diety != "" &&
                Details.Homeland != "" &&
                Details.Gender != "" &&
                Details.Age != 0 &&
                Details.Height != 0 &&
                Details.Weight != 0 &&
                Details.Hair != "" &&
                Details.Eyes != "") {

                Details.Alignment = GetAlignment(AlignmentString);
                Statics.CharacterCreating.CreatingCharacter.Name = Name;
                Statics.CharacterCreating.CreatingCharacter.Details = Details;
                navManager.ShowBackstoryPage();

            }            
            
        }

        public void PrevPage()
        {
            navManager.ShowEquipmentPage(false);
        }

        public void ViewInfo()
        {
            // open the informative page
        }
    }
}
