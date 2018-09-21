using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PwF.CharacterList
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CharacterList : ContentPage
	{
        StackLayout layout;

        public CharacterList ()
		{
			InitializeComponent ();

            SetupStackLayout();
            CreateCharacterButtons();
            CreateNewCharacterButton();

        }

        public void SetupStackLayout()
        {
            Label label = new Label
            {
                Text = "CHOOSE CHARACTER",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                TextColor = Color.FromHex("#C4DCC4"),
                BackgroundColor = Color.FromHex("#1B2C34")
            };

            layout = new StackLayout
            {
                BackgroundColor = Color.FromHex("#607F6F"),

                Children =
                {
                    label
                }
            };
        }

        public void CreateCharacterButtons()
        {
            // Will be a call to the DB
            int numberOfCharacters = 2;
            for (int i = 0; i < numberOfCharacters; i++)
            {
                Button button = new Button
                {
                    Text = "Example Character",
                    VerticalOptions = LayoutOptions.End,
                    HorizontalOptions = LayoutOptions.Center,
                    TextColor = Color.FromHex("#000000"),
                    BackgroundColor = Color.FromHex("#C4DCC4"),
                    //Command = Binding.Create<>
                };
                //button.SetBinding(Button.NavigationProperty, OpenCharacterSheet);
                layout.Children.Add(button);
            }
            Content = layout;
        }

        public void CreateNewCharacterButton()
        {
            Button button = new Button
            {
                Text = "Create New Character",
                VerticalOptions = LayoutOptions.End,
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.FromHex("#000000"),
                BackgroundColor = Color.FromHex("#C4DCC4")
            };
            
            layout.Children.Add(button);
            Content = layout;
        }
    }
}