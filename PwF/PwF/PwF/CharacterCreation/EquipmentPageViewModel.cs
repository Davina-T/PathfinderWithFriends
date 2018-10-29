using Pwf.Navigation;
using PwF.Cells.PwF.Cells;
using PwF.Objects;
using System;
using System.Collections.Generic;
using System.Text;

//Workspace for the page:
namespace PwF.CharacterCreation
{
    //The EquipmentPage viewmodel:
    public class EquipmentPageViewModel
    {
        //Globals:
        private PageNavigationManager navManager;
        public List<Weapon> Weapons;
        public List<Armour> Armour;
        public List<Gear> Gear;
        public Money Coin { get; set; }
        public string SelectedTab = "Weapons";

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
            Weapons = new List<Weapon>();
            Armour = new List<Armour>();
            Gear = new List<Gear>();
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
                    //Stubbed Price: --GET PRICE FROM SERVER--
                    Coin.Subtract(5);
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
                    //Stubbed Price: --GET PRICE FROM SERVER--
                    Coin.Subtract(10);
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
                    //Stubbed Price: --GET PRICE FROM SERVER--
                    Coin.Subtract(2);
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
                    //Stubbed Refund: --GET PRICE FROM SERVER--
                    Coin.Add(5);
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
                    //Stubbed Refund: --GET PRICE FROM SERVER--
                    Coin.Add(10);
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
                    //Stubbed Refund: --GET PRICE FROM SERVER--
                    Coin.Add(2);
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
                "Hook hand", "Kunai", "Heavy mace", "Morningstar", "Lantern Staff", "Heavy crossbow"};

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
                "Silken ceremonial", "Scale mail", "Agile breastplate", "Full plate", "Hellknight plate", "Light steel", "War-shield, dwarven"};

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
                "Area map", "Bedroll", "Blanket", "Cane (elegant)", "City map", "Compass", "Dusk lantern"};

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

        //Go to the next page:
        public void NextPage()
        {

            //Stub Data GET FROM SERVER:
            string[] weapons = new string[] { "Hook hand", "Kunai", "Heavy mace", "Morningstar", "Lantern Staff", "Heavy crossbow"};
            string[] armour = new string[] {"Silken ceremonial", "Scale mail", "Agile breastplate", "Full plate", "Hellknight plate", "Light steel", "War-shield, dwarven"};
            string[] gear = new string[] {"Area map", "Bedroll", "Blanket", "Cane (elegant)", "City map", "Compass", "Dusk lantern"};
            string[] type = new string[] { "STUB" };
            int[] critical = new int[] { 1 };
            int[][] damage = new int[][]
            {
                new int[]{1}
            };

            //Make sure that none of the item lists are null:
            if (SelectedArmour != null && SelectedGear != null && SelectedWeapons != null)
            {

                //Add all selected weapons to the list:
                for(int i=0; i<SelectedWeapons.Count; i++)
                {
                    //Add a stubbed weapon:
                    Weapons.Add(new Weapon(weapons[i], type, 0.25, 4, critical, damage, 4, 0.35, "STUB"));
                }

                //Add all selected armour to the list:
                for (int i = 0; i < SelectedArmour.Count; i++)
                {
                    //Add a stubbed armour:
                    Armour.Add(new Armour(armour[i], 4, "H", 4, 2, 0.35, "STUB"));
                }

                //Add all selected gear to the list:
                for (int i = 0; i < SelectedGear.Count; i++)
                {
                    //Add a stubbed gear:
                    Gear.Add(new Gear(gear[i], 0.35));
                }


                //Send user to the next page:
                Statics.CharacterCreating.CreatingCharacter.Equipments.Weapons = Weapons;
                Statics.CharacterCreating.CreatingCharacter.Equipments.Armours = Armour;
                Statics.CharacterCreating.CreatingCharacter.Equipments.Gears = Gear;
                navManager.ShowCharacterDetailsPage();
            }
        }

        //Go to the previous page:
        public void PrevPage()
        {
            //Statics.CharacterCreating.CreatingCharacter.Race = null;
            navManager.ShowMoneyPage(false);
        }

        //View the compendium:
        public void ViewInfo()
        {
            // open info page
        }

        //Show the weapons page:
        public void chageToWeaponsPage()
        {
            //Set the selected tab:
            SelectedTab = "Weapons";
        }

        //Show the gear page:
        public void chageToGearPage()
        {
            //Set the selected tab:
            SelectedTab = "Gear";
        }

        //Show the armour page:
        public void chageToArmourPage()
        {
            //Set the selected tab:
            SelectedTab = "Armour";
        }
    }
}

