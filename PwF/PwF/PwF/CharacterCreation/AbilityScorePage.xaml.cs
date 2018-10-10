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
                //DisplayAlert("alert", "info page", "ok");
                viewModel.ViewInfo();
            };
            InfoButton.GestureRecognizers.Add(tapGestureRecognizer3);

            // add the binding for the dice button and a tap recognizer
            td20.BindingContext = viewModel;
            var td20Tap = new TapGestureRecognizer();
            td20Tap.Tapped += (s, e) => {
                CreateDicePopup();
            };
            td20.GestureRecognizers.Add(td20Tap);
            

            ResultsLayout.BindingContext = viewModel;

            Numbers = new List<Label> { Number1, Number2, Number3, Number4, Number5, Number6 };
            NumberContainers = new List<AbsoluteLayout> { Number1Container, Number2Container, Number3Container,
                Number4Container, Number5Container, Number6Container };

            NumbersUsed = new List<int> { -1, -1, -1, -1, -1, -1 };


            foreach (Label label in Numbers) {
                label.GestureRecognizers.Add(GetTapGestureRecognizerForNumber(label));
            }

            Entries = new List<Image> { Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma};
            List<string> tempStats = new List<string> { "STR", "DEX", "CON", "INT", "WIS", "CHA" };

            for (int i = 0; i < Entries.Count(); i++) {
                Entries[i].GestureRecognizers.Add(GetTapGestureRecognizerForEntry(Entries[i], tempStats[i]));
            }

            //viewModel.Numbers = new List<int> { 2, 4, 6, 8, 10, 12 };
            //UpdateNumbers();

            //InfoButton.GestureRecognizers.Add(tapGestureRecognizer3);
        }

        public void CreateDicePopup() {
            // Initialises the layout that will contain the popup layer
            //DisplayAlert("Alert", "Creating overlay", "OK");

            Command exitCommand = new Command(() => {
                RemovePopup();
            });

            AbsoluteLayout popUp = Statics.GlobalFunctions.getPopupBase("Dice Roll", exitCommand);

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
                }
            }
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
                if (SelectedNumber != -1) {
                    if (SelectedNumber != tempNumber) {
                        ResetSelectedNumber();
                        SelectedNumber = tempNumber;
                        Numbers[tempNumber].TextColor = Color.FromHex("#FFFFFF");
                        NumberContainers[tempNumber].BackgroundColor = Color.FromHex("#000000");
                    } else {
                        ResetSelectedNumber();
                    }
                } else {
                    ResetSelectedNumber();
                    SelectedNumber = tempNumber;
                    Numbers[tempNumber].TextColor = Color.FromHex("#FFFFFF");
                    NumberContainers[tempNumber].BackgroundColor = Color.FromHex("#000000");
                }
            };

            return TapNumber;
        }
    }
}