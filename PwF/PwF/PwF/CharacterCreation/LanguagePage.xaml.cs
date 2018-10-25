using PwF.Cells.PwF.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PwF.CharacterCreation
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LanguagePage : ContentPage
    {
        LanguageViewModel viewModel = new LanguageViewModel();
        AbsoluteLayout popUpOverlay;
        Compendium temp = new Compendium();

        public LanguagePage()
		{
			InitializeComponent ();

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
                //DisplayAlert("Alert", "Information View", "OK");
                //viewModel.ViewInfo();

                // use web interfeace to get the description of feats
                string data = "Languages" + "\n\n" + "the amount of languages you have is determined by your intelligence and your" + 
                " selection is based on your Race's selection of lanuages";

                string content = data;

                Compendium(content);

            };
            InfoButton.GestureRecognizers.Add(tapGestureRecognizer3);

            PossibleLanguages.BindingContext = viewModel;
            PossibleLanguages.ItemsSource = viewModel.PossibleLanguages;
            SelectedLanguages.BindingContext = viewModel;

            SelectedLanguages.ItemsSource = viewModel.SelectedLanguages;

            LanguageLeftIdentifier.BindingContext = viewModel;
            LanguageLeftIdentifier.Text = "Languages Left: " + viewModel.LanguagesLeft;

            // add the binding for the DownArrow and a tap recognizer
            DownArrow.BindingContext = viewModel;
            var AddToList = new TapGestureRecognizer();
            AddToList.Tapped += (s, e) => {
                MoveSelectedItemDown();
            };
            DownArrow.GestureRecognizers.Add(AddToList);

            // add the binding for the UpArrow and a tap recognizer
            UpArrow.BindingContext = viewModel;
            var TakeFromList = new TapGestureRecognizer();

            TakeFromList.Tapped += (s, e) => {
                MoveSelectedItemUp();
            };
            UpArrow.GestureRecognizers.Add(TakeFromList);

        }

        void Compendium(string content) {
            Command exitCommand = new Command(() => {
                RemovePopup();
            });

            popUpOverlay = Statics.GlobalFunctions.getCompendium("Compendium", content, exitCommand);

            // Add this layout to the Content layout
            PageContent.Children.Add(popUpOverlay);
        }

        void RemovePopup() {
            PageContent.Children.Remove(popUpOverlay);
        }

        void MoveSelectedItemDown() {
            CustomCell temp = (CustomCell)PossibleLanguages.SelectedItem;
            if (temp != null) {

                viewModel.MoveToSelected(temp);

                PossibleLanguages.SelectedItem = null;
                SelectedLanguages.SelectedItem = null;
                PossibleLanguages.ItemsSource = null;
                SelectedLanguages.ItemsSource = null;
                PossibleLanguages.ItemsSource = viewModel.PossibleLanguages;

                SelectedLanguages.ItemsSource = viewModel.SelectedLanguages;

                LanguageLeftIdentifier.Text = "Languages Left: " + viewModel.LanguagesLeft;
            }
        }

        void MoveSelectedItemUp() {
            CustomCell temp = (CustomCell)SelectedLanguages.SelectedItem;
            //DisplayAlert("Alert", "Check: " + viewModel.CheckInStarting(temp) + 
            //    "\nSelected Cell: " + temp.Title +
            //    "\nSelected Language Length: " + viewModel.SelectedLanguages[0].Title, "OK");

            if (temp != null && viewModel.CheckInStarting(temp)) {

                viewModel.MoveToPossible(temp);

                PossibleLanguages.SelectedItem = null;
                SelectedLanguages.SelectedItem = null;
                PossibleLanguages.ItemsSource = null;
                SelectedLanguages.ItemsSource = null;
                PossibleLanguages.ItemsSource = viewModel.PossibleLanguages;

                SelectedLanguages.ItemsSource = viewModel.SelectedLanguages;

                LanguageLeftIdentifier.Text = "Languages Left: " + viewModel.LanguagesLeft;
            }
        }

        void OnItemPossibleSelected(object sender, System.EventArgs e) {
            if (PossibleLanguages.SelectedItem != null) {
                SelectedLanguages.SelectedItem = null;
                CustomCell temp = (CustomCell)PossibleLanguages.SelectedItem;
                //DisplayAlert("OnItemSelected", temp.Title, "OK");
                viewModel.PossibleLanguage = temp;
                // save the Class option
            }
        }

        void OnItemSelectSelected(object sender, System.EventArgs e) {
            if (SelectedLanguages.SelectedItem != null) {
                PossibleLanguages.SelectedItem = null;
                CustomCell temp = (CustomCell)SelectedLanguages.SelectedItem;
                //DisplayAlert("OnItemSelected", temp.Title, "OK");
                viewModel.SelectedLanguage = temp;
                // save the Class option
            }
        }
    }
}