using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//The namespace of the app:
namespace PwF.CharacterCreation
{
    //Create the class:
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MoneyPage : ContentPage
	{
        //Link to the viewModel:
        public MoneyViewModel viewModel = new MoneyViewModel();

        //Create the page:
		public MoneyPage ()
		{
			InitializeComponent ();

            //Add the binding for the right arrow and a tap recognizer:
            RightArrow.BindingContext = viewModel;
            var tapGestureRecognizer1 = new TapGestureRecognizer();

            tapGestureRecognizer1.Tapped += (s, e) => {
                viewModel.NextPage();
            };
            RightArrow.GestureRecognizers.Add(tapGestureRecognizer1);

            //Add the binding for the left arrow and a tap recognizer:
            LeftArrow.BindingContext = viewModel;
            var tapGestureRecognizer2 = new TapGestureRecognizer();

            tapGestureRecognizer2.Tapped += (s, e) => {
                viewModel.PrevPage();
            };
            LeftArrow.GestureRecognizers.Add(tapGestureRecognizer2);

            //Add the binding for the InfoButton and a tap recognizer:
            InfoButton.BindingContext = viewModel;
            var tapGestureRecognizer3 = new TapGestureRecognizer();

            tapGestureRecognizer3.Tapped += (s, e) => {
                viewModel.ViewInfo();
            };
            InfoButton.GestureRecognizers.Add(tapGestureRecognizer3);

            //Add bindings for other items on the page:
            CharClass.BindingContext = viewModel;
            coinEntry.BindingContext = viewModel;

            //Add the binding for the dice roll tap gesture:
            td20.BindingContext = viewModel;
            var tapGestureRecognizer4 = new TapGestureRecognizer();

            tapGestureRecognizer4.Tapped += (s, e) => {
                viewModel.CalculateMoney();
                coinEntry.Text = viewModel.Coin.GP.ToString();
            };
            td20.GestureRecognizers.Add(tapGestureRecognizer4);

        }
	}
}