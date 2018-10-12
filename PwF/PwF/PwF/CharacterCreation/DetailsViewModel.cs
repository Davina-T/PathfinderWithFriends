using System;
using System.Collections.Generic;
using System.Text;

namespace PwF.CharacterCreation
{
    class DetailsViewModel
    {
        public String SelectedName { get; set; }
        public String SelectedAlignment { get; set; }
        public String SelectedDeity { get; set; }
        public String SelectedHomeland { get; set; }
        public String SelectedSize { get; set; }
        public String SelectedGender { get; set; }
        public String SelectedAge { get; set; }
        public String SelectedHeight { get; set; }
        public String SelectedWeight { get; set; }
        public String SelectedHair { get; set; }
        public String SelectedEyes { get; set; }

        public void NextPage()
        {
            // If any details isn't filled in, return rather than going to the next page
            if (SelectedName == null || SelectedName == "")
            {
                return;
            }

            if (SelectedDeity == null || SelectedDeity == "")
            {
                return;
            }

            if (SelectedHomeland == null || SelectedHomeland == "")
            {
                return;
            }

            if (SelectedSize == null || SelectedSize == "")
            {
                return;
            }

            if (SelectedGender == null || SelectedGender == "")
            {
                return;
            }

            if (SelectedAge == null || SelectedAge == "")
            {
                return;
            }

            if (SelectedHeight == null || SelectedHeight == "")
            {
                return;
            }

            if (SelectedWeight == null || SelectedWeight == "")
            {
                return;
            }

            if (SelectedHair == null || SelectedHair == "")
            {
                return;
            }

            if (SelectedEyes == null || SelectedEyes == "")
            {
                return;
            }
            Statics.CharacterCreating.CreatingCharacter.Name = SelectedName;
            //Statics.CharacterCreating.CreatingCharacter.Race = SelectedRace.Title;
            // Link to next page
        }

        public void PrevPage()
        {
            //Statics.CharacterCreating.CreatingCharacter.Race = null;
            // Link to previous page
        }

        public void ViewInfo()
        {
            // open the informative page
        }
    }
}
