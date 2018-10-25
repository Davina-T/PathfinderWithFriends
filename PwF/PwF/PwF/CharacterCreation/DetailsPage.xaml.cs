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
        AbsoluteLayout popUpOverlay;

        public DetailsPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);

            Name.BindingContext = viewModel;
            //Name.Text = viewModel.Name;

            Alignment.BindingContext = viewModel;
            //Alignment.SelectedItem = viewModel.AlignmentString;

            Deity.BindingContext = viewModel;
            //Deity.Text = viewModel.details.Diety;

            Homeland.BindingContext = viewModel;
            //Homeland.Text = viewModel.details.Homeland;

            Gender.BindingContext = viewModel;
            //Gender.Text = viewModel.details.Gender;

            Age.BindingContext = viewModel;
            //Age.Text = viewModel.details.Age.ToString();

            cHeight.BindingContext = viewModel;
            //cHeight.Text = viewModel.details.Height.ToString();

            Weight.BindingContext = viewModel;
            //Weight.Text = viewModel.details.Weight.ToString();

            Hair.BindingContext = viewModel;
            //Hair.Text = viewModel.details.Hair;

            Eyes.BindingContext = viewModel;
            //Eyes.Text = viewModel.details.Eyes;

            cSize.Text = Statics.CharacterCreating.CreatingCharacter.CharRace.Size.ToString();

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
                string content = "Details" + "\n\n" + "The details of your character does not affect gameplay but is details asociated with the character that makes them unique";

                Compendium(content);
            };
            InfoButton.GestureRecognizers.Add(tapGestureRecognizer3);
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