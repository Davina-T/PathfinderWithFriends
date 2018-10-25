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
	public partial class MoneyPage : ContentPage
	{

        public MoneyViewModel viewModel = new MoneyViewModel();

		public MoneyPage ()
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
                //DisplayAlert("Alert", "Info Page", "OK");
                viewModel.ViewInfo();
            };
            InfoButton.GestureRecognizers.Add(tapGestureRecognizer3);

            CharClass.BindingContext = viewModel;
            coinEntry.BindingContext = viewModel;

            //Add the binding for the dice roll tap gesture:
            td20.BindingContext = viewModel;
            var tapGestureRecognizer4 = new TapGestureRecognizer();
            tapGestureRecognizer4.Tapped += (s, e) =>
            {
                viewModel.CalculateMoney();
                coinEntry.Text = viewModel.Coin.GP.ToString();
            };
            td20.GestureRecognizers.Add(tapGestureRecognizer4);
        }


	}
}