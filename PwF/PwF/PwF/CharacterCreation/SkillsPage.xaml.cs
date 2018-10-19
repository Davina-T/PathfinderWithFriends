using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PwF.Cells.PwF.Cells;
using PwF.Cells;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PwF.CharacterCreation
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SkillsPage : ContentPage
	{
        SkillsViewModel viewModel = new SkillsViewModel();
        Compendium temp = new Compendium();

        public SkillsPage ()
		{
			InitializeComponent ();
            CreateSkillListItem();
            CreateHeader();
            CreateRemainingPointsDisplay();
            NavigationPage.SetHasNavigationBar(this, false);

            // add binding and apply cells to list view
            //SelectionGroup.BindingContext = viewModel;
            //SelectionGroup.ItemsSource = viewModel.CustomCells;

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
            /*
            // add the binding for the InfoButton and a tap recognizer
            InfoButton.BindingContext = viewModel;
            var tapGestureRecognizer3 = new TapGestureRecognizer();
            tapGestureRecognizer3.Tapped += (s, e) => {
                //DisplayAlert("Alert", "Information View", "OK");
                //viewModel.ViewInfo();
                AbsoluteLayout overlay = temp.CreateOverlay(viewModel.GetCompendiumEntry());
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
            */
        }
        
        public void CreateHeader()
        {
            Label label = new Label
            {
                Text = "Your race: " + Statics.CharacterCreating.CreatingCharacter.Race + "\nAvailable skills:",
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 24,
                //TextColor = Color.FromHex("#70060B"),
            };
            AbsoluteLayout.SetLayoutBounds(label, new Rectangle(0, 0, 1, 1));
            AbsoluteLayout.SetLayoutFlags(label, AbsoluteLayoutFlags.All);

            Container.Children.Add(label);
        }

        public void CreateSkillListItem()
        {
            AbsoluteLayout allListItems = new AbsoluteLayout
            {
                HorizontalOptions = LayoutOptions.Center,
            };
            AbsoluteLayout.SetLayoutBounds(allListItems, new Rectangle(0, 0, 1, 1));
            AbsoluteLayout.SetLayoutFlags(allListItems, AbsoluteLayoutFlags.All);

            for (int i = 0; i < SkillsCode.GetSkills().Count; i++) {
                Label skill = new Label
                {
                    Text = SkillsCode.GetSkills()[i].ToString(),
                    FontSize = 24,
                    TextColor = Color.FromHex("#70060B"),
                };
                AbsoluteLayout.SetLayoutBounds(skill, new Rectangle(0, 0, 0.5, 1));
                AbsoluteLayout.SetLayoutFlags(skill, AbsoluteLayoutFlags.All);

                Label minus = new Label
                {
                    Text = "-",
                    FontSize = 24,
                    TextColor = Color.FromHex("#70060B"),
                };
                AbsoluteLayout.SetLayoutBounds(minus, new Rectangle(0.7, 0, 0.16, 1));
                AbsoluteLayout.SetLayoutFlags(minus, AbsoluteLayoutFlags.All);

                Label count = new Label
                {
                    Text = "4",
                    FontSize = 24,
                    TextColor = Color.FromHex("#70060B"),
                };
                AbsoluteLayout.SetLayoutBounds(count, new Rectangle(0.85, 0, 0.16, 1));
                AbsoluteLayout.SetLayoutFlags(count, AbsoluteLayoutFlags.All);

                Label plus = new Label
                {
                    Text = "+",
                    FontSize = 24,
                    TextColor = Color.FromHex("#70060B"),
                };
                AbsoluteLayout.SetLayoutBounds(plus, new Rectangle(1, 0, 0.16, 1));
                AbsoluteLayout.SetLayoutFlags(plus, AbsoluteLayoutFlags.All);

                AbsoluteLayout listItem = new AbsoluteLayout
                {
                    Children =
                    {
                        skill,
                        minus,
                        count,
                        plus,
                    }
                };
                AbsoluteLayout.SetLayoutBounds(listItem, new Rectangle(0, (40 * i) + 10, 1, 40));
                AbsoluteLayout.SetLayoutFlags(listItem, AbsoluteLayoutFlags.XProportional | AbsoluteLayoutFlags.WidthProportional);

                allListItems.Children.Add(listItem);
            }

            SkillList.Content = allListItems;
        }

        public void CreateRemainingPointsDisplay()
        {
            Label label = new Label
            {
                // Text value will also contain the skill point variable
                Text = "Unspent skill points: ",
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 24,
                //TextColor = Color.FromHex("#70060B"),
            };
            AbsoluteLayout.SetLayoutBounds(label, new Rectangle(0, 0.8, 1, 0.2));
            AbsoluteLayout.SetLayoutFlags(label, AbsoluteLayoutFlags.All);

            Container.Children.Add(label);
        }
    }
}