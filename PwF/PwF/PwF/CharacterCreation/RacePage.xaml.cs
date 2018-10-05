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
    public partial class RacePage : ContentPage {

        string Race = "";
        RaceViewModel viewModel = new RaceViewModel();


        public RacePage() {
            InitializeComponent();

            // add binding and apply cells to list view
            SelectionGroup.BindingContext = viewModel;
            SelectionGroup.ItemsSource = viewModel.CustomCells;

            // add the binding for the right arrow and a tap recognizer
            RightArrow.BindingContext = viewModel;
            var tapGestureRecognizer1 = new TapGestureRecognizer();
            tapGestureRecognizer1.Tapped += (s, e) => {
                viewModel.NextPage();
            };
            RightArrow.GestureRecognizers.Add(tapGestureRecognizer1);

            // add the binding for the left arrow and a tap recognizer
            LeftArrow.BindingContext = viewModel;
            var tapGestureRecognizer2 = new TapGestureRecognizer();
            tapGestureRecognizer2.Tapped += (s, e) => {
                viewModel.PrevPage();
            };
            LeftArrow.GestureRecognizers.Add(tapGestureRecognizer2);

            // add the binding for the InfoButton and a tap recognizer
            InfoButton.BindingContext = viewModel;
            var tapGestureRecognizer3 = new TapGestureRecognizer();
            tapGestureRecognizer3.Tapped += (s, e) => {
                viewModel.ViewInfo();
            };
            LeftArrow.GestureRecognizers.Add(tapGestureRecognizer3);

        }

        void OnItemSelected(object sender, System.EventArgs e) {
            if (SelectionGroup.SelectedItem != null) {
                CustomCell temp = (CustomCell)SelectionGroup.SelectedItem;
                DisplayAlert("OnItemSelected", temp.Title, "OK");
                viewModel.SelectedRace = temp.Title;
                // save the Race option
            }
        }

    }
}