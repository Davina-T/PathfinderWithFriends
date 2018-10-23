using Pwf.Navigation;
using PwF.Cells.PwF.Cells;
using PwF.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PwF.CharacterCreation
{
    //The EquipmentPage viewmodel:
    public class EquipmentPageViewModel
    {
        //Globals:
        private PageNavigationManager navManager;
        public List<Equipment> Equipment;
        public List<Weapon> Weapons;
        public List<Gear> Gear;
        public List<Armour> Armour;
        public Money Coin { get; set; }
        public string SelectedTab = "Weapons";
        public string[] PossibleTabs = { "Weapons", "Armour", "Gear" };

        //Custom Cells:
        public List<CustomCell> PossibleWeapons { get; }
        public List<CustomCell> SelectedWeapons { get; }
        public List<CustomCell> PossibleArmour { get; }
        public List<CustomCell> SelectedArmour { get; }
        public List<CustomCell> PossibleGear { get; }
        public List<CustomCell> SelectedGear { get; }

        public CustomCell PossibleItemsSelected { get; set; }
        public CustomCell SelectedItemSelected { get; set; }

        //Creeate the EquipmentPageViewModel:
        public EquipmentPageViewModel()
        {
            //Setup the navigation manager:
            navManager = PageNavigationManager.Instance;

            //Setup the Object Lists:
            Equipment = new List<Equipment>();
            PossibleWeapons = getWeapons();
            SelectedWeapons = new List<CustomCell>();
            PossibleArmour = getArmour();
            SelectedArmour = new List<CustomCell>();
            PossibleGear = getGear();
            SelectedGear = new List<CustomCell>();

            //Check the player's Coin:
            if (Statics.CharacterCreating.CreatingCharacter.Coin == null)
            {
                //Create a money Object:
                Coin = new Money();
            }
            else{

                //Set coin to be the characer's money:
                Coin = Statics.CharacterCreating.CreatingCharacter.Coin;

            }

        }

        //Move selected weapon to selected:
        public void MoveToSelectedWeapon(CustomCell cell)
        {
            //Check for a selected weapon:
            for (int i = 0; i < PossibleWeapons.Count; i++)
            {
                //If the selected weapon is found:
                if (cell.Equals(PossibleWeapons[i]))
                 {
                    //Remove it from the possible lsit:
                    PossibleWeapons.Remove(cell);
                    //Add it to the selected list:
                    SelectedWeapons.Add(cell);

                }
            }

        }

        //Move selected armour to selected:
        public void MoveToSelectedArmour(CustomCell cell)
        {
            //Check for selected armour:
            for (int i = 0; i < PossibleArmour.Count; i++)
            {
                //If the selected armour is found:
                if (cell.Equals(PossibleArmour[i]))
                {
                    //Remove it from the possible lsit:
                    PossibleArmour.Remove(cell);
                    //Add it to the selected list:
                    SelectedArmour.Add(cell);

                }
            }
        }

        //Move selected gear to selected:
        public void MoveToSelectedGear(CustomCell cell)
        {
            //Check for selected gear:
            for (int i = 0; i < PossibleGear.Count; i++)
            {
                //If the selected gear is found:
                if (cell.Equals(PossibleGear[i]))
                {
                    //Remove it from the possible lsit:
                    PossibleGear.Remove(cell);
                    //Add it to the selected list:
                    SelectedGear.Add(cell);

                }
            }
        }

        //Move the weapon back to the possible list:
        public void MoveToPossibleWeapon(CustomCell cell)
        {
            //Check for a cell match:
            for (int i = 0; i < SelectedWeapons.Count; i++)
            {
                //If the two cells match:
                if (cell.Equals(SelectedWeapons[i]))
                {
                    //Add the weapon back to the possible list:
                    PossibleWeapons.Add(cell);
                    //Remove the weapon from the selected list:
                    SelectedWeapons.Remove(cell);

                }
            }
        }

        //Move the selected armour back to the possible list:
        public void MoveToPossibleArmour(CustomCell cell)
        {
            //Check for a cell match:
            for (int i = 0; i < SelectedArmour.Count; i++)
            {
                //If the two cells match:
                if (cell.Equals(SelectedArmour[i]))
                {
                    //Add the armour back to the possible list:
                    PossibleArmour.Add(cell);
                    //Remove the armour from the selected list:
                    SelectedArmour.Remove(cell);

                }
            }
        }

        //Move the selected gear back to the possible list:
        public void MoveToPossibleGear(CustomCell cell)
        {
            //Check for a cell match:
            for (int i = 0; i < SelectedGear.Count; i++)
            {
                //If the two cells match:
                if (cell.Equals(SelectedGear[i]))
                {
                    //Add the gear back to the possible list:
                    PossibleGear.Add(cell);
                    //Remove the gear from the selected list:
                    SelectedGear.Remove(cell);

                }
            }
        }

        //Get Weapon Data:
        private List<CustomCell> getWeapons()
        {
            //Get data from database here:
            //STUB DATA:
            string[] weapons = new string[] {
                "Long Sword", "Short Sword", "Simple Staff", "Recurve Bow", "Spear", "Mace"};

            //Create the list of cells:
            List<CustomCell> CustomCells = new List<CustomCell>();
            //Add the weapons to the custom cells:
            foreach (string weapon in weapons)
            {
                //Add the weapon:
                CustomCells.Add(new CustomCell(weapon));
            }

            //Return the list of cells:
            return CustomCells;
        }

        //Get Armour Data:
        private List<CustomCell> getArmour()
        {
            //Get data from database here:
            //STUB DATA:
            string[] armour = new string[] {
                "Heavy Curas", "Heavy Legs", "Heavy Gauntlets", "Heavy Gloves", "Heavy Healm", "Heavy Shield", "Wizard's Robes"};

            //Create the list of cells:
            List<CustomCell> CustomCells = new List<CustomCell>();
            //Add the armour to the custom cells:
            foreach (string piece in armour)
            {
                //Add the piece of armour:
                CustomCells.Add(new CustomCell(piece));
            }

            //Return the list of cells:
            return CustomCells;
        }

        //Get Gear Data:
        private List<CustomCell> getGear()
        {
            //Get data from database here:
            //STUB DATA:
            string[] gear = new string[] {
                "Bedroll", "Rassions", "Waterskin", "Torch", "Tanked", "Mirror", "Empty Vile"};

            //Create the list of cells:
            List<CustomCell> CustomCells = new List<CustomCell>();
            //Add the armour to the custom cells:
            foreach (string item in gear)
            {
                //Add the piece of armour:
                CustomCells.Add(new CustomCell(item));
            }

            //Return the list of cells:
            return CustomCells;
        }

        public void NextPage()
        {
            if(SelectedArmour == null && SelectedGear == null && SelectedWeapons == null)
            {
                //Get Weapon Names:
                string[] weaponNames = new string[SelectedWeapons.Count];
                //Go through the entire selected list of items:
                for (int i = 0; i < weaponNames.Length; i++)
                {
                    //Add each item name to the lsit:
                    weaponNames[i] = SelectedWeapons[i].Title;
                }

                //Get Armour Names:
                string[] armourNames = new string[SelectedArmour.Count];
                //Go through the entire selected list of items:
                for (int i = 0; i < armourNames.Length; i++)
                {
                    //Add each item name to the lsit:
                    armourNames[i] = SelectedArmour[i].Title;
                }

                //Get Armour Names:
                string[] gearNames = new string[SelectedGear.Count];
                //Go through the entire selected list of items:
                for (int i = 0; i < gearNames.Length; i++)
                {
                    //Add each item name to the lsit:
                    gearNames[i] = SelectedGear[i].Title;
                }

                //Add Weapons to character:
                for (int i = 0; i < weaponNames.Length; i++)
                {
                    //Equipment.AddWeapon(weaponNames[i], )
                }

                //Add Gear to character:
                for (int i = 0; i < gearNames.Length; i++)
                {
                    //Equipment.AddGear(gearNames[i], )
                }

                //Add Gear to character:
                for (int i = 0; i < armourNames.Length; i++)
                {
                    //Equipment.AddGear(armourNames[i], )
                }

                //Send user to the next page:
                navManager.ShowCharacterDetailsPage();
            }

            //STUB:::::
            navManager.ShowCharacterDetailsPage();


        }

        public void PrevPage()
        {
            //Statics.CharacterCreating.CreatingCharacter.Race = null;
            navManager.ShowMoneyPage(false);
        }

        public void ViewInfo()
        {
            // open the informative page
        }
    }
}

