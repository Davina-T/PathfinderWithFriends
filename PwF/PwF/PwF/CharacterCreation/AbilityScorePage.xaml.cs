using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PwF.CharacterCreation
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AbilityScorePage : ContentPage
	{
        AbilityScoreViewModel viewModel = new AbilityScoreViewModel();
        AbsoluteLayout popUpOverlay;
        public int SelectedNumber = -1;
        List<Label> Numbers;
        List<int> NumbersUsed;
        List<AbsoluteLayout> NumberContainers;
        List<Image> Entries;


        public AbilityScorePage ()
		{
            InitializeComponent();

            // add the binding for the right arrow and a tap recognizer
            RightArrow.BindingContext = viewModel;
            var tapGestureRecognizer1 = new TapGestureRecognizer();
            tapGestureRecognizer1.Tapped += (s, e) => {
                //DisplayAlert("Alert", "Next Page", "OK");
                viewModel.NextPage();
            };
            RightArrow.GestureRecognizers.Add(tapGestureRecognizer1);

            // add the binding for the left arrow and a tap recognizer
            LeftArrow.BindingContext = viewModel;
            var tapGestureRecognizer2 = new TapGestureRecognizer();
            tapGestureRecognizer2.Tapped += (s, e) => {
                //DisplayAlert("Alert", "Previous Page", "OK");
                viewModel.PrevPage();
            };
            LeftArrow.GestureRecognizers.Add(tapGestureRecognizer2);

            // add the binding for the InfoButton and a tap recognizer
            InfoButton.BindingContext = viewModel;
            var tapGestureRecognizer3 = new TapGestureRecognizer();
            tapGestureRecognizer3.Tapped += (s, e) => {
                //DisplayAlert("alert", "str: " + viewModel.Scores.Strength.Value + "\ndex: " + viewModel.Scores.Dexterity.Value + 
                //    "con: " + viewModel.Scores.Constitution.Value + "\nint: " + viewModel.Scores.Intelligence.Value + 
                //    "\nwis: " + viewModel.Scores.Wisdom.Value + "\ncha: " + viewModel.Scores.Charisma.Value, "ok");
                viewModel.ViewInfo();
            };
            InfoButton.GestureRecognizers.Add(tapGestureRecognizer3);
          

            ResultsLayout.BindingContext = viewModel;

            Numbers = new List<Label> { Number1, Number2, Number3, Number4, Number5, Number6 };
            NumberContainers = new List<AbsoluteLayout> { Number1Container, Number2Container, Number3Container,
                Number4Container, Number5Container, Number6Container };

            //NumbersUsed = new List<int> { -1, -1, -1, -1, -1, -1 };
            NumbersUsed = viewModel.NumbersUsed;


            for (int i = 0; i < Numbers.Count(); i++) {
                NumberContainers[i].GestureRecognizers.Add(GetTapGestureRecognizerForNumber(Numbers[i]));
            }

            Entries = new List<Image> { Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma};
            List<string> tempStats = new List<string> { "STR", "DEX", "CON", "INT", "WIS", "CHA" };

            for (int i = 0; i < Entries.Count(); i++) {
                Entries[i].GestureRecognizers.Add(GetTapGestureRecognizerForEntry(Entries[i], tempStats[i]));
            }

            ResetSelectedNumber();
        }

        public void CreateDicePopup(int position) {
            // Initialises the layout that will contain the popup layer
            //DisplayAlert("Alert", "Creating overlay", "OK");

            Command exitCommand = new Command(() => {
                RemovePopup();
            });

            AbsoluteLayout popUp = Statics.GlobalFunctions.getPopupBase("Dice Roll", exitCommand);

            AbsoluteLayout popUpFill = Statics.GlobalFunctions.getPopUpFill();

            Button StandardButton = new Button {
                Text = "Standard",
                BackgroundColor = Color.FromHex("#00AA00"),
                Command = new Command(() => {
                    CreateStandardPopup(position);
                })

            };
            AbsoluteLayout.SetLayoutBounds(StandardButton, new Rectangle(.5, .05, .8, .25));
            AbsoluteLayout.SetLayoutFlags(StandardButton, AbsoluteLayoutFlags.All);

            Button ClassicButton = new Button {
                Text = "Classic",
                BackgroundColor = Color.FromHex("#99AA00"),
                Command = new Command(() => {
                    CreateClassicPopup(position);
                })

            };
            AbsoluteLayout.SetLayoutBounds(ClassicButton, new Rectangle(.5, .5, .8, .25));
            AbsoluteLayout.SetLayoutFlags(ClassicButton, AbsoluteLayoutFlags.All);

            Button HeroicButton = new Button {
                Text = "Heroic",
                BackgroundColor = Color.FromHex("#FF2200"),
                Command = new Command(() => {
                    CreateHeroicPopup(position);
                })

            };
            AbsoluteLayout.SetLayoutBounds(HeroicButton, new Rectangle(.5, .95, .8, .25));
            AbsoluteLayout.SetLayoutFlags(HeroicButton, AbsoluteLayoutFlags.All);

            popUp.Children.Add(popUpFill);

            popUpFill.Children.Add(StandardButton);
            popUpFill.Children.Add(ClassicButton);
            popUpFill.Children.Add(HeroicButton);

            // Add this layout to the Content layout
            PageContent.Children.Add(popUpOverlay);
        }

        public void CreateStandardPopup(int position) {
            RemovePopup();

            Command exitCommand = new Command(() => {
                RemovePopup();
            });

            AbsoluteLayout popUp = Statics.GlobalFunctions.getPopupBase("Standard Roll", exitCommand);

            // Dice 1
            Label Dice1Text = new Label {
                Text = "Dice",
                FontSize=24,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions= LayoutOptions.Center
            };
            AbsoluteLayout.SetLayoutBounds(Dice1Text, new Rectangle(.5, .5, 1, 1));
            AbsoluteLayout.SetLayoutFlags(Dice1Text, AbsoluteLayoutFlags.All);

            AbsoluteLayout Dice1 = new AbsoluteLayout {
                BackgroundColor = Color.FromHex("#00000000"),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Children =
                {
                    Dice1Text
                }
            };
            AbsoluteLayout.SetLayoutBounds(Dice1, new Rectangle(0, .5, .25, 1));
            AbsoluteLayout.SetLayoutFlags(Dice1, AbsoluteLayoutFlags.All);

            // Dice 2
            Label Dice2Text = new Label {
                Text = "Dice",
                FontSize = 24,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };
            AbsoluteLayout.SetLayoutBounds(Dice2Text, new Rectangle(.5, .5, 1, 1));
            AbsoluteLayout.SetLayoutFlags(Dice2Text, AbsoluteLayoutFlags.All);

            AbsoluteLayout Dice2 = new AbsoluteLayout {
                BackgroundColor = Color.FromHex("#00000000"),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Children =
                {
                    Dice2Text
                }
            };
            AbsoluteLayout.SetLayoutBounds(Dice2, new Rectangle(.325, .5, .25, 1));
            AbsoluteLayout.SetLayoutFlags(Dice2, AbsoluteLayoutFlags.All);

            // Dice 3
            Label Dice3Text = new Label {
                Text = "Dice",
                FontSize = 24,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            AbsoluteLayout.SetLayoutBounds(Dice3Text, new Rectangle(.5, .5, 1, 1));
            AbsoluteLayout.SetLayoutFlags(Dice3Text, AbsoluteLayoutFlags.All);

            AbsoluteLayout Dice3 = new AbsoluteLayout {
                BackgroundColor = Color.FromHex("#00000000"),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Children =
                {
                    Dice3Text
                }
            };
            AbsoluteLayout.SetLayoutBounds(Dice3, new Rectangle(.675, .5, .25, 1));
            AbsoluteLayout.SetLayoutFlags(Dice3, AbsoluteLayoutFlags.All);

            // Dice 3
            Label Dice4Text = new Label {
                Text = "Dice",
                FontSize = 24,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            AbsoluteLayout.SetLayoutBounds(Dice4Text, new Rectangle(.5, .5, 1, 1));
            AbsoluteLayout.SetLayoutFlags(Dice4Text, AbsoluteLayoutFlags.All);

            AbsoluteLayout Dice4 = new AbsoluteLayout {
                BackgroundColor = Color.FromHex("#00000000"),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Children =
                {
                    Dice4Text
                }
            };
            AbsoluteLayout.SetLayoutBounds(Dice4, new Rectangle(1, .5, .25, 1));
            AbsoluteLayout.SetLayoutFlags(Dice4, AbsoluteLayoutFlags.All);

            popUp.Children.Add(Dice1);
            popUp.Children.Add(Dice2);
            popUp.Children.Add(Dice3);
            popUp.Children.Add(Dice4);

            // add the binding for the InfoButton and a tap recognizer
            popUp.BindingContext = viewModel;
            var RollDice = new TapGestureRecognizer();
            RollDice.Tapped += (s, e) => {
                if(viewModel.Numbers[position] == 0) {
                    int[] numbers = viewModel.RollMany(4);
                    Dice1Text.Text = numbers[0].ToString();
                    Dice2Text.Text = numbers[1].ToString();
                    Dice3Text.Text = numbers[2].ToString();
                    Dice4Text.Text = numbers[3].ToString();

                    int lowest = viewModel.FindLowestValue(numbers);
                    int total = 0;
                    for(int i = 0; i < numbers.Length; i++) {
                        if(i != lowest) {
                            total += numbers[i];
                        }
                    }
                    viewModel.Numbers[position] = total;

                    UpdateNumbers();
                } else {
                    RemovePopup();
                }
            };
            popUp.GestureRecognizers.Add(RollDice);

            popUpOverlay = new AbsoluteLayout {
                BackgroundColor = Color.FromHex("#60000000"),
                Children =
                {
                    popUp
                }
            };
            AbsoluteLayout.SetLayoutBounds(popUpOverlay, new Rectangle(.5, .5, 1, 1));
            AbsoluteLayout.SetLayoutFlags(popUpOverlay, AbsoluteLayoutFlags.All);

            // Add this layout to the Content layout
            PageContent.Children.Add(popUpOverlay);

        }

        public void CreateClassicPopup(int position) {
            RemovePopup();

            Command exitCommand = new Command(() => {
                RemovePopup();
            });

            AbsoluteLayout popUp = Statics.GlobalFunctions.getPopupBase("Classic Roll", exitCommand);

            // Dice 1
            Label Dice1Text = new Label {
                Text = "Dice",
                FontSize = 24,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            AbsoluteLayout.SetLayoutBounds(Dice1Text, new Rectangle(.5, .5, 1, 1));
            AbsoluteLayout.SetLayoutFlags(Dice1Text, AbsoluteLayoutFlags.All);

            AbsoluteLayout Dice1 = new AbsoluteLayout {
                BackgroundColor = Color.FromHex("#00000000"),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Children =
                {
                    Dice1Text
                }
            };
            AbsoluteLayout.SetLayoutBounds(Dice1, new Rectangle(.1, .5, .25, 1));
            AbsoluteLayout.SetLayoutFlags(Dice1, AbsoluteLayoutFlags.All);

            // Dice 2
            Label Dice2Text = new Label {
                Text = "Dice",
                FontSize = 24,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };
            AbsoluteLayout.SetLayoutBounds(Dice2Text, new Rectangle(.5, .5, 1, 1));
            AbsoluteLayout.SetLayoutFlags(Dice2Text, AbsoluteLayoutFlags.All);

            AbsoluteLayout Dice2 = new AbsoluteLayout {
                BackgroundColor = Color.FromHex("#00000000"),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Children =
                {
                    Dice2Text
                }
            };
            AbsoluteLayout.SetLayoutBounds(Dice2, new Rectangle(.5, .5, .25, 1));
            AbsoluteLayout.SetLayoutFlags(Dice2, AbsoluteLayoutFlags.All);

            // Dice 3
            Label Dice3Text = new Label {
                Text = "Dice",
                FontSize = 24,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            AbsoluteLayout.SetLayoutBounds(Dice3Text, new Rectangle(.5, .5, 1, 1));
            AbsoluteLayout.SetLayoutFlags(Dice3Text, AbsoluteLayoutFlags.All);

            AbsoluteLayout Dice3 = new AbsoluteLayout {
                BackgroundColor = Color.FromHex("#00000000"),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Children =
                {
                    Dice3Text
                }
            };
            AbsoluteLayout.SetLayoutBounds(Dice3, new Rectangle(.9, .5, .25, 1));
            AbsoluteLayout.SetLayoutFlags(Dice3, AbsoluteLayoutFlags.All);

            // Dice 3
            Label Dice4Text = new Label {
                Text = "Dice",
                FontSize = 24,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            AbsoluteLayout.SetLayoutBounds(Dice4Text, new Rectangle(.5, .5, 1, 1));
            AbsoluteLayout.SetLayoutFlags(Dice4Text, AbsoluteLayoutFlags.All);

            popUp.Children.Add(Dice1);
            popUp.Children.Add(Dice2);
            popUp.Children.Add(Dice3);

            // add the binding for the InfoButton and a tap recognizer
            popUp.BindingContext = viewModel;
            var RollDice = new TapGestureRecognizer();
            RollDice.Tapped += (s, e) => {
                if (viewModel.Numbers[position] == 0) {
                    int[] numbers = viewModel.RollMany(3);
                    Dice1Text.Text = numbers[0].ToString();
                    Dice2Text.Text = numbers[1].ToString();
                    Dice3Text.Text = numbers[2].ToString();
                    
                    viewModel.Numbers[position] = numbers[0] + numbers[1] + numbers[2];

                    UpdateNumbers();
                } else {
                    RemovePopup();
                }
            };
            popUp.GestureRecognizers.Add(RollDice);

            popUpOverlay = new AbsoluteLayout {
                BackgroundColor = Color.FromHex("#60000000"),
                Children =
                {
                    popUp
                }
            };
            AbsoluteLayout.SetLayoutBounds(popUpOverlay, new Rectangle(.5, .5, 1, 1));
            AbsoluteLayout.SetLayoutFlags(popUpOverlay, AbsoluteLayoutFlags.All);

            // Add this layout to the Content layout
            PageContent.Children.Add(popUpOverlay);

        }

        public void CreateHeroicPopup(int position) {
            RemovePopup();

            Command exitCommand = new Command(() => {
                RemovePopup();
            });

            AbsoluteLayout popUp = Statics.GlobalFunctions.getPopupBase("Heroic Roll", exitCommand);

            // Dice 1
            Label Dice1Text = new Label {
                Text = "Dice",
                FontSize = 24,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            AbsoluteLayout.SetLayoutBounds(Dice1Text, new Rectangle(.5, .5, 1, 1));
            AbsoluteLayout.SetLayoutFlags(Dice1Text, AbsoluteLayoutFlags.All);

            AbsoluteLayout Dice1 = new AbsoluteLayout {
                BackgroundColor = Color.FromHex("#00000000"),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Children =
                {
                    Dice1Text
                }
            };
            AbsoluteLayout.SetLayoutBounds(Dice1, new Rectangle(.1, .5, .25, 1));
            AbsoluteLayout.SetLayoutFlags(Dice1, AbsoluteLayoutFlags.All);

            // Dice 2
            Label Dice2Text = new Label {
                Text = "Dice",
                FontSize = 24,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };
            AbsoluteLayout.SetLayoutBounds(Dice2Text, new Rectangle(.5, .5, 1, 1));
            AbsoluteLayout.SetLayoutFlags(Dice2Text, AbsoluteLayoutFlags.All);

            AbsoluteLayout Dice2 = new AbsoluteLayout {
                BackgroundColor = Color.FromHex("#00000000"),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Children =
                {
                    Dice2Text
                }
            };
            AbsoluteLayout.SetLayoutBounds(Dice2, new Rectangle(.5, .5, .25, 1));
            AbsoluteLayout.SetLayoutFlags(Dice2, AbsoluteLayoutFlags.All);

            // Dice 3
            Label Dice3Text = new Label {
                Text = "+ 6",
                FontSize = 24,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            AbsoluteLayout.SetLayoutBounds(Dice3Text, new Rectangle(.5, .5, 1, 1));
            AbsoluteLayout.SetLayoutFlags(Dice3Text, AbsoluteLayoutFlags.All);

            AbsoluteLayout Dice3 = new AbsoluteLayout {
                BackgroundColor = Color.FromHex("#00000000"),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Children =
                {
                    Dice3Text
                }
            };
            AbsoluteLayout.SetLayoutBounds(Dice3, new Rectangle(.9, .5, .25, 1));
            AbsoluteLayout.SetLayoutFlags(Dice3, AbsoluteLayoutFlags.All);

            // Dice 3
            Label Dice4Text = new Label {
                Text = "Dice",
                FontSize = 24,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            AbsoluteLayout.SetLayoutBounds(Dice4Text, new Rectangle(.5, .5, 1, 1));
            AbsoluteLayout.SetLayoutFlags(Dice4Text, AbsoluteLayoutFlags.All);

            popUp.Children.Add(Dice1);
            popUp.Children.Add(Dice2);
            popUp.Children.Add(Dice3);

            // add the binding for the InfoButton and a tap recognizer
            popUp.BindingContext = viewModel;
            var RollDice = new TapGestureRecognizer();
            RollDice.Tapped += (s, e) => {
                if (viewModel.Numbers[position] == 0) {
                    int[] numbers = viewModel.RollMany(3);
                    Dice1Text.Text = numbers[0].ToString();
                    Dice2Text.Text = numbers[1].ToString();

                    viewModel.Numbers[position] = numbers[0] + numbers[1] + 6;

                    UpdateNumbers();
                } else {
                    RemovePopup();
                }
            };
            popUp.GestureRecognizers.Add(RollDice);

            popUpOverlay = new AbsoluteLayout {
                BackgroundColor = Color.FromHex("#60000000"),
                Children =
                {
                    popUp
                }
            };
            AbsoluteLayout.SetLayoutBounds(popUpOverlay, new Rectangle(.5, .5, 1, 1));
            AbsoluteLayout.SetLayoutFlags(popUpOverlay, AbsoluteLayoutFlags.All);

            // Add this layout to the Content layout
            PageContent.Children.Add(popUpOverlay);

        }

        public void RemovePopup() {

            PageContent.Children.Remove(popUpOverlay);

        }

        public void ResetScores() {
            NumbersUsed = new List<int> { -1, -1, -1, -1, -1, -1 };
            viewModel.Scores.Strength.Value = 0;
            viewModel.Scores.Dexterity.Value = 0;
            viewModel.Scores.Constitution.Value = 0;
            viewModel.Scores.Intelligence.Value = 0;
            viewModel.Scores.Wisdom.Value = 0;
            viewModel.Scores.Charisma.Value = 0;
            HighLightStats(false);
            ResetSelectedNumber();
            UpdateScores();
        }

        public void UpdateScores() {
            strengthEntry.Text = viewModel.Scores.Strength.Value.ToString();
            dexterityEntry.Text = viewModel.Scores.Dexterity.Value.ToString();
            constitutionEntry.Text = viewModel.Scores.Constitution.Value.ToString();
            intelligenceEntry.Text = viewModel.Scores.Intelligence.Value.ToString();
            wisdomEntry.Text = viewModel.Scores.Wisdom.Value.ToString();
            charismaEntry.Text = viewModel.Scores.Charisma.Value.ToString();
        }

        public void UpdateNumbers() {

            for (int i = 0; i < Numbers.Count(); i++) {
                Numbers[i].Text = viewModel.Numbers[i].ToString();
            }
            viewModel.NumbersUsed = NumbersUsed;
        }

        public void HighLightStats(bool highlight) {
            if (highlight) {
                Strength.Source = "StrengthHighlight.png";
                Dexterity.Source = "DexterityHighlight.png";
                Constitution.Source = "ConstitutionHighlight.png";
                Intelligence.Source = "IntelligenceHighlight.png";
                Wisdom.Source = "WisdomHighlight.png";
                Charisma.Source = "CharismaHighlight.png";
            } else {
                Strength.Source = "Strength.png";
                Dexterity.Source = "Dexterity.png";
                Constitution.Source = "Constitution.png";
                Intelligence.Source = "Intelligence.png";
                Wisdom.Source = "Wisdom.png";
                Charisma.Source = "Charisma.png";
            }
        }

        public TapGestureRecognizer GetTapGestureRecognizerForEntry(Image entry, string stat) {
            var TapEntry = new TapGestureRecognizer();
            TapEntry.Tapped += (s, e) => {
                //DisplayAlert("Alert", "Entry: " + entry.ToString(), "OK");

                if (SelectedNumber != -1) {
                    int temp;
                    Int32.TryParse(Numbers[SelectedNumber].Text, out temp);
                    AssignSelectedNumber(temp, stat, SelectedNumber);
                    ResetSelectedNumber();
                }
            };

            return TapEntry;
        }

        public void AssignSelectedNumber(int number, string score, int position) {
            if (NumbersUsed[position] != -1) {
                if (NumbersUsed[position] == 0) {
                    viewModel.Scores.Strength.Value = 0;
                } else if (NumbersUsed[position] == 1) {
                    viewModel.Scores.Dexterity.Value = 0;
                } else if (NumbersUsed[position] == 2) {
                    viewModel.Scores.Constitution.Value = 0;
                } else if (NumbersUsed[position] == 3) {
                    viewModel.Scores.Intelligence.Value = 0;
                } else if (NumbersUsed[position] == 4) {
                    viewModel.Scores.Wisdom.Value = 0;
                } else if (NumbersUsed[position] == 5) {
                    viewModel.Scores.Charisma.Value = 0;
                }
            }

            if (score == "STR") {
                CheckStat(0);
                viewModel.Scores.Strength.Value = number;
                NumbersUsed[position] = 0;
            } else if (score == "DEX") {
                CheckStat(1);
                viewModel.Scores.Dexterity.Value = number;
                NumbersUsed[position] = 1;
            } else if (score == "CON") {
                CheckStat(2);
                viewModel.Scores.Constitution.Value = number;
                NumbersUsed[position] = 2;
            } else if (score == "INT") {
                CheckStat(3);
                viewModel.Scores.Intelligence.Value = number;
                NumbersUsed[position] = 3;
            } else if (score == "WIS") {
                CheckStat(4);
                viewModel.Scores.Wisdom.Value = number;
                NumbersUsed[position] = 4;
            } else if (score == "CHA") {
                CheckStat(5);
                viewModel.Scores.Charisma.Value = number;
                NumbersUsed[position] = 5;
            }


            Numbers[position].TextColor = Color.FromHex("#FF0000");
            NumberContainers[position].BackgroundColor = Color.FromHex("#FFFFFF");
            HighLightStats(false);
            UpdateNumbers();
            UpdateScores();

            void CheckStat(int statPosition) {
                for(int i = 0; i < NumbersUsed.Count(); i++) {
                    if(NumbersUsed[i] == statPosition) {
                        NumbersUsed[i] = -1;
                    }
                }
            }
        }

        public void ResetSelectedNumber() {
            for (int i = 0; i < Numbers.Count(); i++) {
                if (NumbersUsed[i] == -1) {
                    Numbers[i].TextColor = Color.FromHex("#000000");
                    NumberContainers[i].BackgroundColor = Color.FromHex("#00000000");
                } else {
                    Numbers[i].TextColor = Color.FromHex("#FF0000");
                    NumberContainers[i].BackgroundColor = Color.FromHex("#FFFFFF");
                }
            }
            HighLightStats(false);
            SelectedNumber = -1;
        }

        public TapGestureRecognizer GetTapGestureRecognizerForNumber(Label label) {
            var TapNumber = new TapGestureRecognizer();
            TapNumber.Tapped += (s, e) => {
                //DisplayAlert("Alert", "Selected Item: " + label.ToString(), "OK");
                int tempNumber = -1;
                for (int i = 0; i < Numbers.Count(); i++) {
                    if (label == Numbers[i]) {
                        tempNumber = i;
                    }
                }
                if (viewModel.Numbers[tempNumber] == 0) {
                    CreateDicePopup(tempNumber);
                } else {
                    if (SelectedNumber != -1) {
                        if (SelectedNumber != tempNumber) {
                            ResetSelectedNumber();
                            SelectedNumber = tempNumber;
                            Numbers[tempNumber].TextColor = Color.FromHex("#FFFFFF");
                            NumberContainers[tempNumber].BackgroundColor = Color.FromHex("#000000");
                            HighLightStats(true);
                        } else {
                            ResetSelectedNumber();
                        }
                    } else {
                        ResetSelectedNumber();
                        SelectedNumber = tempNumber;
                        Numbers[tempNumber].TextColor = Color.FromHex("#FFFFFF");
                        NumberContainers[tempNumber].BackgroundColor = Color.FromHex("#000000");
                        HighLightStats(true);
                    }
                }
            };

            return TapNumber;
        }
    }
}