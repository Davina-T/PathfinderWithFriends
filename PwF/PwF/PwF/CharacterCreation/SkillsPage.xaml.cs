using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PwF.Cells.PwF.Cells;
using PwF.Cells;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PwF.Objects;

namespace PwF.CharacterCreation
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SkillsPage : ContentPage
	{
        SkillsViewModel viewModel = new SkillsViewModel();
        AbsoluteLayout popUpOverlay;
        Compendium temp = new Compendium();

        Label unspentSkillPoints;

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
            // add the binding for the InfoButton and a tap recognizer
            InfoButton.BindingContext = viewModel;
            var tapGestureRecognizer3 = new TapGestureRecognizer();
            tapGestureRecognizer3.Tapped += (s, e) => {
                //DisplayAlert("Alert", Statics.JsonStuff.GetFile("Characters.json"), "OK");
                // get data from the server
                string content = "Skills" + "\n\n" + "skills are used by the character to perform actions in the world";

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

        public void CreateHeader()
        {
            Label label = new Label
            {
                Text = "Your race: " + Statics.CharacterCreating.CreatingCharacter.CharRace.Name + "\nAvailable Skills:",
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

            
            

            for (int i = 0; i < viewModel.skills.Count; i++) {
                Label skill = new Label {
                    Text = viewModel.skills[i].Name,
                    FontSize = 18,
                    TextColor = Color.FromHex("#70060B"),
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center
                };
                AbsoluteLayout.SetLayoutBounds(skill, new Rectangle(0, 0, 0.4, 1));
                AbsoluteLayout.SetLayoutFlags(skill, AbsoluteLayoutFlags.All);

                Label count = new Label
                {
                    Text = viewModel.skills[i].Value.ToString(),
                    FontSize = 18,
                    TextColor = Color.FromHex("#70060B"),
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center
                };
                AbsoluteLayout.SetLayoutBounds(count, new Rectangle(0.8, 0, 0.2, 1));
                AbsoluteLayout.SetLayoutFlags(count, AbsoluteLayoutFlags.All);

                Label minus = new Label {
                    Text = "-",
                    FontSize = 18,
                    TextColor = Color.FromHex("#70060B"),
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center
                };
                AbsoluteLayout.SetLayoutBounds(minus, new Rectangle(.5, .5, 1, 1));
                AbsoluteLayout.SetLayoutFlags(minus, AbsoluteLayoutFlags.All);

                AbsoluteLayout minusLayout = new AbsoluteLayout {
                    BackgroundColor = Color.FromHex("#30FF0000"),
                    Children = {
                        minus
                    }
                };
                AbsoluteLayout.SetLayoutBounds(minusLayout, new Rectangle(0.6, 0, 0.2, 1));
                AbsoluteLayout.SetLayoutFlags(minusLayout, AbsoluteLayoutFlags.All);

                Label plus = new Label
                {
                    Text = "+",
                    FontSize = 18,
                    TextColor = Color.FromHex("#70060B"),
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center
                };
                AbsoluteLayout.SetLayoutBounds(plus, new Rectangle(.5, .5, 1, 1));
                AbsoluteLayout.SetLayoutFlags(plus, AbsoluteLayoutFlags.All);

                AbsoluteLayout plusLayout = new AbsoluteLayout {
                    BackgroundColor = Color.FromHex("#3000FF00"),
                    Children = {
                        plus
                    }
                };
                AbsoluteLayout.SetLayoutBounds(plusLayout, new Rectangle(1, 0, 0.2, 1));
                AbsoluteLayout.SetLayoutFlags(plusLayout, AbsoluteLayoutFlags.All);

                minusLayout.GestureRecognizers.Add(GetMinusPress(count, i));
                plusLayout.GestureRecognizers.Add(GetPlusPress(count, i));

                AbsoluteLayout listItem = new AbsoluteLayout
                {
                    Children =
                    {
                        skill,
                        count,
                        minusLayout,
                        plusLayout,
                    }
                };
                AbsoluteLayout.SetLayoutBounds(listItem, new Rectangle(0, (40 * i) + 10, 1, 40));
                AbsoluteLayout.SetLayoutFlags(listItem, AbsoluteLayoutFlags.XProportional | AbsoluteLayoutFlags.WidthProportional);

                allListItems.Children.Add(listItem);
            }

            SkillList.Content = allListItems;
        }

        TapGestureRecognizer GetPlusPress(Label label, int position) {
            var PlusSkill = new TapGestureRecognizer();
            PlusSkill.Tapped += (s, e) => {
                //DisplayAlert("Alert", "Minusing skill number: " + position + "\nSkills length: " + viewModel.skills.Count, "OK");

                if (viewModel.remainingPoints > 0) {
                    viewModel.skills[position].Value += 1;
                    label.Text = viewModel.skills[position].Value.ToString();
                    viewModel.remainingPoints -= 1;
                    unspentSkillPoints.Text = "Unspent skill points: " + viewModel.remainingPoints;
                }
            };

            return PlusSkill;
        }

        TapGestureRecognizer GetMinusPress(Label label, int position) {
            var MinusSkill = new TapGestureRecognizer();
            MinusSkill.Tapped += (s, e) => {
                DisplayAlert("Alert", "Minusing skill number: " + position + "\nSkills length: " + viewModel.skills.Count, "OK");

                if (viewModel.skills[position].Value > 0) {
                    viewModel.skills[position].Value -= 1;
                    label.Text = viewModel.skills[position].Value.ToString();
                    viewModel.remainingPoints += 1;
                    unspentSkillPoints.Text = "Unspent skill points: " + viewModel.remainingPoints;
                }
            };

            return MinusSkill;
        }

        public void CreateRemainingPointsDisplay()
        {
            unspentSkillPoints = new Label
            {
                // Text value will also contain the skill point variable
                Text = "Unspent skill points: " + viewModel.remainingPoints,
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 24,
                //TextColor = Color.FromHex("#70060B"),
            };
            AbsoluteLayout.SetLayoutBounds(unspentSkillPoints, new Rectangle(0, 0.8, 1, 0.2));
            AbsoluteLayout.SetLayoutFlags(unspentSkillPoints, AbsoluteLayoutFlags.All);

            Container.Children.Add(unspentSkillPoints);
        }
    }
}