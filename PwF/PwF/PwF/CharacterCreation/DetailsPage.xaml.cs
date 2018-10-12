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
	public partial class DetailsPage : ContentPage
	{
        DetailsViewModel viewModel = new DetailsViewModel();

        public DetailsPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);

            // add the binding for the right arrow and a tap recognizer
            RightArrow.BindingContext = viewModel;
            var tapGestureRecognizer1 = new TapGestureRecognizer();
            tapGestureRecognizer1.Tapped += (s, e) => {
                viewModel.SelectedName = Name.Text;
                viewModel.SelectedAlignment = Alignment.SelectedItem.ToString();
                viewModel.SelectedDeity = Deity.SelectedItem.ToString();
                viewModel.SelectedHomeland = Homeland.Text;
                viewModel.SelectedSize = cSize.Text;
                viewModel.SelectedGender = Gender.SelectedItem.ToString();
                viewModel.SelectedAge = Age.Text;
                viewModel.SelectedHeight = cHeight.Text;
                viewModel.SelectedWeight = Weight.Text;
                viewModel.SelectedHair = Hair.Text;
                viewModel.SelectedEyes = Eyes.Text;
                /*DisplayAlert("Alert", viewModel.SelectedName + ", " +
                                      viewModel.SelectedAlignment + ", " +
                                      viewModel.SelectedDeity + ", " +
                                      viewModel.SelectedHomeland + ", " +
                                      viewModel.SelectedSize + ", " +
                                      viewModel.SelectedGender + ", " +
                                      viewModel.SelectedAge + ", " +
                                      viewModel.SelectedHeight + ", " +
                                      viewModel.SelectedWeight + ", " +
                                      viewModel.SelectedHair + ", " +
                                      viewModel.SelectedEyes, "OK");*/
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
                //DisplayAlert("Alert", viewModel.SelectedName, "OK");
                //viewModel.ViewInfo();
            };
            InfoButton.GestureRecognizers.Add(tapGestureRecognizer3);
        }
	}
}