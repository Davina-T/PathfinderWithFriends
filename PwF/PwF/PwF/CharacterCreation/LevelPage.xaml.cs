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
	public partial class LevelPage : ContentPage
    {
        LevelViewModel viewModel = new LevelViewModel();
        Compendium temp = new Compendium();

        public LevelPage()
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
                String levelCompendium = "Select the starting level for your character.\n\nUnless your DM specificies otherwise you should start on level 1.";
                AbsoluteLayout overlay = temp.CreateOverlay(levelCompendium);
                pageContainer.Children.Add(overlay);

                // add the binding for the compendium overlay and a tap recognizer
                overlay.BindingContext = viewModel;
                var tapGestureRecognizer4 = new TapGestureRecognizer();
                tapGestureRecognizer4.Tapped += (s2, e2) => {
                    //DisplayAlert("Alert", "Remove Overlay", "OK");
                    pageContainer.Children.Remove(overlay);
                };
                overlay.GestureRecognizers.Add(tapGestureRecognizer4);
            };
            InfoButton.GestureRecognizers.Add(tapGestureRecognizer3);

            ContainingLayout.BindingContext = viewModel;
        }
	}
}