using PwF.Cells.PwF.Cells;
using PwF.Statics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//The namespace of the page:
namespace PwF.CharacterCreation
{
    //Creae the class:
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EquipmentPage : ContentPage
    {

        //Link to the viewModel:
        EquipmentPageViewModel viewModel = new EquipmentPageViewModel();
        string TAB = "Weapons";

        //Create the equipment page:
        public EquipmentPage()
        {
            InitializeComponent();

            //Add the binding for the right arrow and a tap recognizer:
            RightArrow.BindingContext = viewModel;
            var tapGestureRecognizer1 = new TapGestureRecognizer();

            tapGestureRecognizer1.Tapped += (s, e) => {
                viewModel.NextPage();
            };
            RightArrow.GestureRecognizers.Add(tapGestureRecognizer1);

            //Add the binding for the left arrow and a tap recognizer:
            LeftArrow.BindingContext = viewModel;
            var tapGestureRecognizer2 = new TapGestureRecognizer();

            tapGestureRecognizer2.Tapped += (s, e) => {
                viewModel.PrevPage();
            };
            LeftArrow.GestureRecognizers.Add(tapGestureRecognizer2);

            //Add the binding for the InfoButton and a tap recognizer:
            InfoButton.BindingContext = viewModel;
            var tapGestureRecognizer3 = new TapGestureRecognizer();

            tapGestureRecognizer3.Tapped += (s, e) => {
                DisplayAlert("Alert", "Selected Weapon: " + viewModel.SelectedWeapons.Count + "\nSelected Gear: " + viewModel.SelectedGear.Count + "\nSelected Armour: " + viewModel.SelectedArmour.Count, "OK");
                viewModel.ViewInfo();
            };
            InfoButton.GestureRecognizers.Add(tapGestureRecognizer3);

            //Add the binding for the Weapons tab and a tap recognizer:
            WeaponButton.BindingContext = viewModel;
            var tapGestureRecognizer4 = new TapGestureRecognizer();

            tapGestureRecognizer4.Tapped += (s, e) => {
                changeToWeaponsPage();
            };
            WeaponButton.GestureRecognizers.Add(tapGestureRecognizer4);

            //Add the binding for the gear tab and a tap recognizer:
            GearButton.BindingContext = viewModel;
            var tapGestureRecognizer5 = new TapGestureRecognizer();

            tapGestureRecognizer5.Tapped += (s, e) => {
                changeToGearPage();
            };
            GearButton.GestureRecognizers.Add(tapGestureRecognizer5);

            //Add the binding for the armour tab and a tap recognizer:
            ArmourButton.BindingContext = viewModel;
            var tapGestureRecognizer6 = new TapGestureRecognizer();

            tapGestureRecognizer6.Tapped += (s, e) => {
                changeToArmourPage();
            };
            ArmourButton.GestureRecognizers.Add(tapGestureRecognizer6);

            //Bind the items in the page:
            PP.BindingContext = viewModel;
            GP.BindingContext = viewModel;
            SP.BindingContext = viewModel;
            CP.BindingContext = viewModel;
            loadContent();

            //PossibleItems.BindingContext = viewModel;
            //PossibleItems.ItemsSource = DeterminePossibleItemSource(TAB);
            //SelectedItems.BindingContext = viewModel;
            //SelectedItems.ItemsSource = DetermineSelectedItemSource(TAB); 


            //Add the binding for the DownArrow and a tap recognizer
            DownArrow.BindingContext = viewModel;
            var AddToList = new TapGestureRecognizer();

            AddToList.Tapped += (s, e) => {
                MoveSelectedItemDown(TAB);
            };
            DownArrow.GestureRecognizers.Add(AddToList);

            //Add the binding for the UpArrow and a tap recognizer:
            UpArrow.BindingContext = viewModel;
            var TakeFromList = new TapGestureRecognizer();

            TakeFromList.Tapped += (s, e) => {
                MoveSelectedItemUp(TAB);
            };
            UpArrow.GestureRecognizers.Add(TakeFromList);


        }

        //Determine which lsit to show for possible items:
        public List<CustomCell> DeterminePossibleItemSource(string tab)
        {
            //Check what the tab selected is:
            if (tab.Equals("Weapons"))
            {
                //Set the item source:
                return viewModel.PossibleWeapons;


            }else if(tab.Equals("Gear")){

                //Set the item source:
                return viewModel.PossibleGear;

            }else if (tab.Equals("Armour")) {

                //Set the item source:
                return viewModel.PossibleArmour;

            }

            //Set the item source:
            return viewModel.PossibleWeapons;
        }

        //Determine which lsit to show for selected items:
        public List<CustomCell> DetermineSelectedItemSource(string tab)
        {
            //Check what the tab selected is:
            if (tab == "Weapons")
            {
                //Set the item source:
                return viewModel.SelectedWeapons;

            }else if (tab == "Gear"){

                //Set the item source:
                return viewModel.SelectedGear;

            }else if (tab == "Armour"){

                //Set the item source:
                return viewModel.SelectedArmour;

            }

            //Set the item source:
            return viewModel.SelectedWeapons;
        }

        //Change to the weapons page:
        void changeToWeaponsPage()
        {

            //Set the colours for the buttons:
            WeaponButton.BackgroundColor = Color.FromHex("#607F6F");
            WeaponButtonText.TextColor = Color.FromHex("#1B2C34");
            GearButton.BackgroundColor = Color.FromHex("#1B2C34");
            GearButtonText.TextColor = Color.FromHex("#607F6F");
            ArmourButton.BackgroundColor = Color.FromHex("#1B2C34");
            ArmourButtonText.TextColor = Color.FromHex("#607F6F");

            //Change the page:
            viewModel.chageToWeaponsPage();
            setTab("Weapons");
            loadContent();
            //TAB = "Weapons";

        }

        //Change to the gear page:
        void changeToGearPage()
        {

            //Set the colours for the buttons:
            WeaponButton.BackgroundColor = Color.FromHex("#1B2C34");
            WeaponButtonText.TextColor = Color.FromHex("#607F6F");
            GearButton.BackgroundColor = Color.FromHex("#607F6F");
            GearButtonText.TextColor = Color.FromHex("#1B2C34");
            ArmourButton.BackgroundColor = Color.FromHex("#1B2C34");
            ArmourButtonText.TextColor = Color.FromHex("#607F6F");

            //Change the page:
            viewModel.chageToGearPage();
            setTab("Gear");
            loadContent();
            //TAB = "Gear";

        }

        //Change to the armour page:
        void changeToArmourPage()
        {

            //Set the colours for the buttons:
            WeaponButton.BackgroundColor = Color.FromHex("#1B2C34");
            WeaponButtonText.TextColor = Color.FromHex("#607F6F");
            GearButton.BackgroundColor = Color.FromHex("#1B2C34");
            GearButtonText.TextColor = Color.FromHex("#607F6F");
            ArmourButton.BackgroundColor = Color.FromHex("#607F6F");
            ArmourButtonText.TextColor = Color.FromHex("#1B2C34");

            //Change the page:
            viewModel.chageToArmourPage();
            setTab("Armour");
            loadContent();
           // TAB = "Armour";

        }

        void setTab(string tab)
        {
            TAB = tab;
        }

        void loadContent()
        {
            PossibleItems.BindingContext = viewModel;
            PossibleItems.ItemsSource = DeterminePossibleItemSource(TAB);
            SelectedItems.BindingContext = viewModel;
            SelectedItems.ItemsSource = DetermineSelectedItemSource(TAB);
        }

        //When the user selects a possible item:
        void OnItemPossibleSelected(object sender, System.EventArgs e)
        {
            //If the item is not empty:
            if (PossibleItems.SelectedItem != null)
            {
                //Set the selected item to null:
                SelectedItems.SelectedItem = null;
                //Create a temperary cell:
                CustomCell temp = (CustomCell)PossibleItems.SelectedItem;
                //Add the item to the selected list:
                viewModel.PossibleItemsSelected = temp;

            }
        }

        //If the user selects a selected item:
        void OnItemSelectSelected(object sender, System.EventArgs e)
        {
            //Make sure the item is not null:
            if (SelectedItems.SelectedItem != null)
            {
                //Set the item to null:
                PossibleItems.SelectedItem = null;
                //Create a temperary cell:
                CustomCell temp = (CustomCell)SelectedItems.SelectedItem;
                //Add it to the list:
                viewModel.SelectedItemSelected = temp;

            }
        }

        //Move the selected item down:
        void MoveSelectedItemDown(String tab)
        {
            //Create a temperary custom cell:
            CustomCell temp = (CustomCell)PossibleItems.SelectedItem;
            //Check if temp is null:
            if (temp != null)
            {
                //Check which tab to use:
                if(tab == "Weapons")
                {
                    //Move the item to the selected list:
                    viewModel.MoveToSelectedWeapon(temp);

                    //Reset the values:
                    PossibleItems.SelectedItem = null;
                    SelectedItems.SelectedItem = null;
                    PossibleItems.ItemsSource = null;
                    SelectedItems.ItemsSource = null;
                    PossibleItems.ItemsSource = viewModel.PossibleWeapons;
                    SelectedItems.ItemsSource = viewModel.SelectedWeapons;

                }else if(tab == "Gear"){

                    //Move the item to the selected list:
                    viewModel.MoveToSelectedGear(temp);

                    //Reset the values:
                    PossibleItems.SelectedItem = null;
                    SelectedItems.SelectedItem = null;
                    PossibleItems.ItemsSource = null;
                    SelectedItems.ItemsSource = null;
                    PossibleItems.ItemsSource = viewModel.PossibleGear;
                    SelectedItems.ItemsSource = viewModel.SelectedGear;

                }else if(tab == "Armour"){

                    //Move the item to the selected list:
                    viewModel.MoveToSelectedArmour(temp);

                    //Reset the values:
                    PossibleItems.SelectedItem = null;
                    SelectedItems.SelectedItem = null;
                    PossibleItems.ItemsSource = null;
                    SelectedItems.ItemsSource = null;
                    PossibleItems.ItemsSource = viewModel.PossibleArmour;
                    SelectedItems.ItemsSource = viewModel.SelectedArmour;

                }
            }
        }

        //Move the selected item up:
        void MoveSelectedItemUp(string tab)
        {
            //Create a temperary custom cell:
            CustomCell temp = (CustomCell)SelectedItems.SelectedItem;
            //Check if temp is null:
            if (temp != null)
            {
                //Check which tab to use:
                if (tab == "Weapons")
                {

                    viewModel.MoveToPossibleWeapon(temp);

                    PossibleItems.SelectedItem = null;
                    SelectedItems.SelectedItem = null;
                    PossibleItems.ItemsSource = null;
                    SelectedItems.ItemsSource = null;
                    PossibleItems.ItemsSource = viewModel.PossibleWeapons;
                    SelectedItems.ItemsSource = viewModel.SelectedWeapons;

                }
                else if (tab == "Gear"){

                    //Move the item to the selected list:
                    viewModel.MoveToPossibleGear(temp);

                    //Reset the values:
                    PossibleItems.SelectedItem = null;
                    SelectedItems.SelectedItem = null;
                    PossibleItems.ItemsSource = null;
                    SelectedItems.ItemsSource = null;
                    PossibleItems.ItemsSource = viewModel.PossibleGear;
                    SelectedItems.ItemsSource = viewModel.SelectedGear;

                }
                else if (tab == "Armour")
                {

                    //Move the item to the selected list:
                    viewModel.MoveToPossibleArmour(temp);

                    //Reset the values:
                    PossibleItems.SelectedItem = null;
                    SelectedItems.SelectedItem = null;
                    PossibleItems.ItemsSource = null;
                    SelectedItems.ItemsSource = null;
                    PossibleItems.ItemsSource = viewModel.PossibleArmour;
                    SelectedItems.ItemsSource = viewModel.SelectedArmour;

                }
            }
        }


    }
}