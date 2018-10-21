using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PwF.Cells.PwF.Cells;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Pwf.Navigation;

namespace PwF.CharacterList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterList : ContentPage
    {
        CharacterListViewModel viewModel = new CharacterListViewModel();

        AbsoluteLayout layout;
        ScrollView scroll;
        AbsoluteLayout allButtons;
        AbsoluteLayout titleText;

        // Will be a call to the DB

        //int numberOfCharacters = 4;

        //String name = "Bob";
        //String race = "Halfling";
        //String characterClass = "Bard";
        //int level = 2;
        //int money = 30;

        public CharacterList()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            DisplayAlert("Alert", "Testing", "okay");
            SetupStackLayout();
            CreateCharacterButtons();
            CreateNewCharacterButton();

        }

        // Creates the title label and the absolute layouts used to make the page
        public void SetupStackLayout()
        {
            // Creates the title label
            Label label = new Label
            {
                Text = "CHOOSE CHARACTER",
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.FromHex("#C4DCC4"),
                FontSize = 32,
                FontAttributes = FontAttributes.Bold
            };
            AbsoluteLayout.SetLayoutBounds(label, new Rectangle(0, 0, 1, 1));
            AbsoluteLayout.SetLayoutFlags(label, AbsoluteLayoutFlags.All);

            // Initialises the layout that will contain the title label
            titleText = new AbsoluteLayout
            {
                BackgroundColor = Color.FromHex("#1B2C34"),
                Children =
                {
                    label
                }
            };
            AbsoluteLayout.SetLayoutBounds(titleText, new Rectangle(0, 0, 1, 0.1));
            AbsoluteLayout.SetLayoutFlags(titleText, AbsoluteLayoutFlags.All);

            // Initialises the layout that will contain all the buttons
            allButtons = new AbsoluteLayout
            {

            };
            AbsoluteLayout.SetLayoutBounds(allButtons, new Rectangle(0, 0, 1, 1));
            AbsoluteLayout.SetLayoutFlags(allButtons, AbsoluteLayoutFlags.All);

            // Initialises the scroll that will contain the allButtons layout
            scroll = new ScrollView
            {
                Content = allButtons
            };
            AbsoluteLayout.SetLayoutBounds(scroll, new Rectangle(0, 0, 1, 1));
            AbsoluteLayout.SetLayoutFlags(scroll, AbsoluteLayoutFlags.All);

            // Creates the layout that contains the scroll view
            AbsoluteLayout scrollLayout = new AbsoluteLayout
            {
                Children =
                {
                    scroll
                }
            };
            AbsoluteLayout.SetLayoutBounds(scrollLayout, new Rectangle(0, 0.7, 1, 0.8));
            AbsoluteLayout.SetLayoutFlags(scrollLayout, AbsoluteLayoutFlags.All);

            // Initialises the layout that will contain everything on the page
            layout = new AbsoluteLayout
            {
                BackgroundColor = Color.FromHex("#607F6F"),

                Children =
                {
                    titleText,
                    scrollLayout
                }
            };
            AbsoluteLayout.SetLayoutBounds(layout, new Rectangle(0, 0, 1, 1));
            AbsoluteLayout.SetLayoutFlags(layout, AbsoluteLayoutFlags.All);
        }

        // Creates a button for each character the user has
        public void CreateCharacterButtons()
        {
            BindingContext = viewModel;

            // Loops the button creation process based on the number of characters
            //DisplayAlert("Alert", "Count: " + viewModel.Characters.Count +
            //    "\nName: " + viewModel.Characters[0].Name + 
            //    "\nRace: " + viewModel.Characters[0].CharRace.Name + 
            //    "\nLevel: " + viewModel.Characters[0].Level + 
            //    "\nClass: " + viewModel.Characters[0].CharClass.Name + 
            //    "\nGold: " + viewModel.Characters[0].Gold.ToString(), "OK");


            for (int i = 0; i < viewModel.Characters.Count; i++) {
                if (viewModel.Characters[i].Name != null &&
                    viewModel.Characters[i].CharRace.Name != null &&
                    viewModel.Characters[i].Level > 0 &&
                    viewModel.Characters[i].CharClass.Name != null &&
                    viewModel.Characters[i].Gold != null) {

                    // Create a label that displays the name of the character
                    Label cName = new Label {
                        Text = viewModel.Characters[i].Name,
                        FontSize = 24,
                        HorizontalOptions = LayoutOptions.Center
                    };
                    AbsoluteLayout.SetLayoutBounds(cName, new Rectangle(0.5, 0, 1, 0.33));
                    AbsoluteLayout.SetLayoutFlags(cName, AbsoluteLayoutFlags.All);

                    // Create a label that displays the race of the character, place it inside a layout for positioning
                    Label cRace = new Label {
                        Text = viewModel.Characters[i].CharRace.Name,
                        FontSize = 24,
                    };
                    AbsoluteLayout.SetLayoutBounds(cRace, new Rectangle(0, 0, 1, 1));
                    AbsoluteLayout.SetLayoutFlags(cRace, AbsoluteLayoutFlags.All);

                    AbsoluteLayout raceLayout = new AbsoluteLayout {
                        Children =
                        {
                        cRace,
                    }
                    };
                    AbsoluteLayout.SetLayoutBounds(raceLayout, new Rectangle(0.05, 0.45, 0.5, 0.33));
                    AbsoluteLayout.SetLayoutFlags(raceLayout, AbsoluteLayoutFlags.All);

                    // Create a label that displays the level of the character, place it inside a layout for positioning
                    Label cLevel = new Label {
                        Text = "lvl " + viewModel.Characters[i].Level.ToString(),
                        FontSize = 24,
                    };
                    AbsoluteLayout.SetLayoutBounds(cLevel, new Rectangle(0, 0, 1, 1));
                    AbsoluteLayout.SetLayoutFlags(cLevel, AbsoluteLayoutFlags.All);

                    AbsoluteLayout levelLayout = new AbsoluteLayout {
                        Children =
                        {
                        cLevel,
                    }
                    };
                    AbsoluteLayout.SetLayoutBounds(levelLayout, new Rectangle(0.05, 0.9, 0.5, 0.33));
                    AbsoluteLayout.SetLayoutFlags(levelLayout, AbsoluteLayoutFlags.All);

                    // Create a label that displays the class of the character, place it inside a layout for positioning
                    Label cClass = new Label {
                        Text = viewModel.Characters[i].CharClass.Name,
                        FontSize = 24,
                    };
                    AbsoluteLayout.SetLayoutBounds(cClass, new Rectangle(0, 0, 1, 1));
                    AbsoluteLayout.SetLayoutFlags(cClass, AbsoluteLayoutFlags.All);

                    AbsoluteLayout classLayout = new AbsoluteLayout {
                        HorizontalOptions = LayoutOptions.Center,
                        Children =
                        {
                        cClass,
                    }
                    };
                    AbsoluteLayout.SetLayoutBounds(classLayout, new Rectangle(0.75, 0.45, 0.5, 0.33));
                    AbsoluteLayout.SetLayoutFlags(classLayout, AbsoluteLayoutFlags.All);

                    // Create a label that displays the money of the character, place it inside a layout for positioning
                    Label cMoney = new Label {
                        Text = viewModel.Characters[i].Gold.GetTotal() + "gp",
                        FontSize = 24,
                    };
                    AbsoluteLayout.SetLayoutBounds(cMoney, new Rectangle(0, 0.5, 1, 1));
                    AbsoluteLayout.SetLayoutFlags(cMoney, AbsoluteLayoutFlags.All);

                    AbsoluteLayout moneyLayout = new AbsoluteLayout {
                        HorizontalOptions = LayoutOptions.Center,
                        Children =
                        {
                        cMoney,
                    }
                    };
                    AbsoluteLayout.SetLayoutBounds(moneyLayout, new Rectangle(0.75, 0.9, 0.5, 0.33));
                    AbsoluteLayout.SetLayoutFlags(moneyLayout, AbsoluteLayoutFlags.All);

                    // Create the AbsoluteLayout that will be used as a button
                    AbsoluteLayout fauxButton = new AbsoluteLayout {
                        Opacity = 0,
                    };
                    AbsoluteLayout.SetLayoutBounds(fauxButton, new Rectangle(0, 0, 1, 1));
                    AbsoluteLayout.SetLayoutFlags(fauxButton, AbsoluteLayoutFlags.All);

                    var tapGestureRecognizer = new TapGestureRecognizer();
                    tapGestureRecognizer.Tapped += (s, e) => {
                        //DisplayAlert("Alert", "Howdy", "OK");
                        viewModel.OpenCharacterSheet(i-1);
                    };
                    fauxButton.GestureRecognizers.Add(tapGestureRecognizer);

                    // Place the button and all the labels inside a layout
                    AbsoluteLayout buttonLayout = new AbsoluteLayout {
                        BackgroundColor = Color.FromHex("#C4DCC4"),
                        Children =
                        {
                        cName,
                        raceLayout,
                        levelLayout,
                        classLayout,
                        moneyLayout,
                        fauxButton,
                    }
                    };
                    AbsoluteLayout.SetLayoutBounds(buttonLayout, new Rectangle(0.5, (150 * i), 0.75, 100));
                    AbsoluteLayout.SetLayoutFlags(buttonLayout, AbsoluteLayoutFlags.XProportional | AbsoluteLayoutFlags.WidthProportional);

                    // Add this layout to the allButtons layout
                    allButtons.Children.Add(buttonLayout);
                }
            }
            Content = layout;
        }

        // Create the button that starts the character creation process
        public void CreateNewCharacterButton()
        {
            BindingContext = viewModel;

            // Create the label for the button
            Label label = new Label
            {
                Text = "Create New Character",
                FontSize = 24,
                HorizontalOptions = LayoutOptions.Center,
            };
            AbsoluteLayout.SetLayoutBounds(label, new Rectangle(0, 0.45, 1, 0.33));
            AbsoluteLayout.SetLayoutFlags(label, AbsoluteLayoutFlags.All);

            // Create the AbsoluteLayout that will be used as a button
            AbsoluteLayout fauxButton = new AbsoluteLayout
            {
                Opacity = 0,
            };
            AbsoluteLayout.SetLayoutBounds(fauxButton, new Rectangle(0, 0, 1, 1));
            AbsoluteLayout.SetLayoutFlags(fauxButton, AbsoluteLayoutFlags.All);
            
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                //DisplayAlert("Alert", "Howdy", "OK");
                //viewModel.StartNewCharacter();
                DisplayAlert("Alert", "Count: " + viewModel.Characters.Count +
                    "\nName: " + viewModel.Characters[0].Name +
                    "\nRace: " + viewModel.Characters[0].CharRace.Name +
                    "\nLevel: " + viewModel.Characters[0].Level +
                    "\nClass: " + viewModel.Characters[0].CharClass.Name +
                    "\nGold: " + viewModel.Characters[0].Gold.ToString(), "OK");
            };
            fauxButton.GestureRecognizers.Add(tapGestureRecognizer);

            // Add the button to a layout
            AbsoluteLayout buttonLayout = new AbsoluteLayout
            {
                BackgroundColor = Color.FromHex("#C4DCC4"),
                Children =
                    {
                        label,
                        fauxButton,
                    }
            };
            AbsoluteLayout.SetLayoutBounds(buttonLayout, new Rectangle(0.5, (150 * viewModel.Characters.Count), 0.75, 100));
            AbsoluteLayout.SetLayoutFlags(buttonLayout, AbsoluteLayoutFlags.XProportional | AbsoluteLayoutFlags.WidthProportional);
            
            // Add the layout to the allButtons layout
            allButtons.Children.Add(buttonLayout);
            Content = layout;
        }
    }
}