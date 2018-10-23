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
    public partial class EquipmentPage : ContentPage
    {

        EquipmentPageViewModel viewModel = new EquipmentPageViewModel();

        public EquipmentPage()
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
                //DisplayAlert("Alert", "Info Page", "OK");
                viewModel.ViewInfo();
            };
            InfoButton.GestureRecognizers.Add(tapGestureRecognizer3);
        }

        void OnItemPossibleSelected(object sender, System.EventArgs e)
        {
            if (PossibleItems.SelectedItem != null)
            {
                SelectedItems.SelectedItem = null;
                CustomCell temp = (CustomCell)PossibleItems.SelectedItem;
                //DisplayAlert("OnItemSelected", temp.Title, "OK");
                viewModel.PossibleItemsSelected = temp;
                // save the Class option
            }
        }

        void OnItemSelectSelected(object sender, System.EventArgs e)
        {
            if (SelectedItems.SelectedItem != null)
            {
                PossibleItems.SelectedItem = null;
                CustomCell temp = (CustomCell)SelectedItems.SelectedItem;
                //DisplayAlert("OnItemSelected", temp.Title, "OK");
                viewModel.SelectedItemSelected = temp;
                // save the Class option
            }
        }
    }
}