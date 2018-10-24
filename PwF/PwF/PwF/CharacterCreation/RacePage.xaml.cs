using PwF.Cells.PwF.Cells;
using PwF.Template;
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
    public partial class RacePage : ContentPage {
        
        RaceViewModel viewModel = new RaceViewModel();
        AbsoluteLayout popUpOverlay;
        Compendium temp = new Compendium();


        public RacePage() {
            InitializeComponent();
            
            // add binding and apply cells to list view
            SelectionGroup.BindingContext = viewModel;
            SelectionGroup.ItemsSource = viewModel.CustomCells;

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
                //DisplayAlert("Alert", Statics.JsonStuff.GetFile("Characters.json"), "OK");
                // get data from the server
                if (viewModel.SelectedRace != null) {
                    // use web interfeace to get the description of feat selected
                    string data = "This would be the data sent back from the server";

                    string content = viewModel.SelectedRace.Title + "\n\n" + data;

                    Compendium(content);

                } else {
                    // use web interfeace to get the description of feat selected
                    string data = "Races determine how you play the game, each race has a set of skills unique to them";

                    string content = "Race" + "\n\n" + data;

                    Compendium(content);
                }
            };
            InfoButton.GestureRecognizers.Add(tapGestureRecognizer3);

        }

        void OnItemSelected(object sender, System.EventArgs e) {
            if (SelectionGroup.SelectedItem != null) {
                CustomCell temp = (CustomCell)SelectionGroup.SelectedItem;
                //DisplayAlert("OnItemSelected", temp.Title, "OK");
                viewModel.SelectedRace = temp;
                // save the Race option
            }
        }

        void Compendium(string content) {
            Command exitCommand = new Command(() => {
                RemovePopup();
            });

            popUpOverlay = Statics.GlobalFunctions.getCompendium("Compendium", content, exitCommand);

            // Add this layout to the Content layout
            PageContent.Children.Add(popUpOverlay);
        }

        public void RemovePopup() {

            PageContent.Children.Remove(popUpOverlay);

        }

    }
}