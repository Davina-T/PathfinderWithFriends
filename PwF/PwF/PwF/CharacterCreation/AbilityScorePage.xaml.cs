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
                //DisplayAlert("Alert", "Info Page", "OK");
                CreatePopup();
                //viewModel.ViewInfo();
            };
            InfoButton.GestureRecognizers.Add(tapGestureRecognizer3);
        }

        public void CreatePopup() {
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
    }
}