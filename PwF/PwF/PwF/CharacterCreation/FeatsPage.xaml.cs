using PwF.Cells.PwF.Cells;
using PwF.Statics;
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
	public partial class FeatsPage : ContentPage
	{

        FeatsViewModel viewModel = new FeatsViewModel();

        public double ScreenWidth;
        public double ScreenHeight;

        public FeatsPage() {
            InitializeComponent();

            //PageNameLabel.FontSize = Statics.GlobalFunctions.getFontSize(32);

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
                //DisplayAlert("Alert", "info page", "OK");
                viewModel.ViewInfo();
            };
            InfoButton.GestureRecognizers.Add(tapGestureRecognizer3);

            PossibleFeats.BindingContext = viewModel;
            PossibleFeats.ItemsSource = viewModel.PossibleFeats;
            SelectedFeats.BindingContext = viewModel;
            SelectedFeats.ItemsSource = viewModel.SelectedFeats;
            FeatsLeftIdentifier.BindingContext = viewModel;
            FeatsLeftIdentifier.Text = "Feats Left: " + viewModel.FeatsLeft;

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

        void MoveSelectedItemDown() {
            CustomCell temp = (CustomCell)PossibleFeats.SelectedItem;
            if (temp != null) {

                viewModel.MoveToSelected(temp);

                PossibleFeats.SelectedItem = null;
                SelectedFeats.SelectedItem = null;
                PossibleFeats.ItemsSource = null;
                SelectedFeats.ItemsSource = null;
                PossibleFeats.ItemsSource = viewModel.PossibleFeats;
                SelectedFeats.ItemsSource = viewModel.SelectedFeats;
                FeatsLeftIdentifier.Text = "Feats Left: " + viewModel.FeatsLeft;
            }
        }

        void MoveSelectedItemUp() {
            CustomCell temp = (CustomCell)SelectedFeats.SelectedItem;
            if (temp != null) {

                viewModel.MoveToPossible(temp);

                PossibleFeats.SelectedItem = null;
                SelectedFeats.SelectedItem = null;
                PossibleFeats.ItemsSource = null;
                SelectedFeats.ItemsSource = null;
                PossibleFeats.ItemsSource = viewModel.PossibleFeats;
                SelectedFeats.ItemsSource = viewModel.SelectedFeats;
                FeatsLeftIdentifier.Text = "Feats Left: " + viewModel.FeatsLeft;
            }
        }

        void OnItemPossibleSelected(object sender, System.EventArgs e) {
            if (PossibleFeats.SelectedItem != null) {
                SelectedFeats.SelectedItem = null;
                CustomCell temp = (CustomCell)PossibleFeats.SelectedItem;
                //DisplayAlert("OnItemSelected", temp.Title, "OK");
                viewModel.PossibleFeatSelected = temp;
                // save the Class option
            }
        }

        void OnItemSelectSelected(object sender, System.EventArgs e) {
            if (SelectedFeats.SelectedItem != null) {
                PossibleFeats.SelectedItem = null;
                CustomCell temp = (CustomCell)SelectedFeats.SelectedItem;
                //DisplayAlert("OnItemSelected", temp.Title, "OK");
                viewModel.SelectedFeatSelected = temp;
                // save the Class option
            }
        }

        // performs overide when page loads
        protected override void OnSizeAllocated(double width, double height) {
            // gets the screen size and calls the fontsize changing function
            base.OnSizeAllocated(width, height);
            ScreenHeight = height;
            ScreenWidth = width;
            SetFontSizes(width, height);
        }

        // sets all the font sizes based on screen size
        private void SetFontSizes(double width, double height) {
            // setting certain values to use
            double Font12 = Statics.GlobalFunctions.getFontSize(12, width);
            double Font18 = Statics.GlobalFunctions.getFontSize(18, width);
            double Font24 = Statics.GlobalFunctions.getFontSize(24, width);
            double Font32 = Statics.GlobalFunctions.getFontSize(32, width);

            // setting the labels font sizes
            PageNameLabel.FontSize = Font32;
            FeatsLeftIdentifier.FontSize = Font24;
        }

    }
}