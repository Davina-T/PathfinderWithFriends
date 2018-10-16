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
        //static List<SelectableData<FeatListData>> data;
        FeatsViewModel viewModel = new FeatsViewModel(/*data*/);

        public double ScreenWidth;
        public double ScreenHeight;

        public FeatsPage() {
            InitializeComponent();

            //PageNameLabel.FontSize = Statics.GlobalFunctions.getFontSize(32);
            //BindingContext = new FeatsViewModel(data); OBSOLETE?

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
        }

    }
}