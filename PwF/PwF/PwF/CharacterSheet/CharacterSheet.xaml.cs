using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PwF.CharacterSheet
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CharacterSheet : ContentPage
	{
        CharacterSheetViewModel viewModel;
        AbsoluteLayout popUpOverlay;

        public CharacterSheet (int character)
		{
			InitializeComponent ();
            viewModel = new CharacterSheetViewModel(character);

            CharacterName.BindingContext = viewModel;
            CharacterName.Text = viewModel.character.Name;

            RaceLabel.BindingContext = viewModel;
            RaceLabel.Text = viewModel.character.CharRace.Name;

            ClassLabel.BindingContext = viewModel;
            ClassLabel.Text = viewModel.character.CharClass.Name;

            CPLabel.BindingContext = viewModel;
            CPLabel.Text = "CP: " + viewModel.character.Gold.CP;
            SPLabel.BindingContext = viewModel;
            SPLabel.Text = "SP: " + viewModel.character.Gold.SP;
            GPLabel.BindingContext = viewModel;
            GPLabel.Text = "GP: " + viewModel.character.Gold.GP;
            PPLabel.BindingContext = viewModel;
            PPLabel.Text = "PP: " + viewModel.character.Gold.PP;

            LevelLabel.BindingContext = viewModel;
            LevelLabel.Text = "Level: " + viewModel.character.Level.ToString();

            HealthLabel.BindingContext = viewModel;
            HealthLabel.Text = viewModel.character.HealthBar.CurrentHealth.ToString() + "/" + viewModel.character.HealthBar.TotalHealth.ToString();

            HealthBarLayout.BindingContext = viewModel;
            AbsoluteLayout.SetLayoutBounds(HealthBarLayout, new Rectangle(0, 0, ((double)viewModel.character.HealthBar.CurrentHealth / (double)viewModel.character.HealthBar.TotalHealth), 1));

            CombatButton.BindingContext = viewModel;
            CombatButton.Command = new Command(() => {
                viewModel.OpenCombatPage();
            });

            SkillsButton.BindingContext = viewModel;
            SkillsButton.Command = new Command(() => {
                viewModel.OpenSkillsPage();
            });

            SpellsButton.BindingContext = viewModel;
            SpellsButton.Command = new Command(() => {
                viewModel.OpenSpellsPage();
            });

            ItemsButton.BindingContext = viewModel;
            ItemsButton.Command = new Command(() => {
                viewModel.OpenItemsPage();
            });

            STRLabel.BindingContext = viewModel;
            DEXLabel.BindingContext = viewModel;
            CONLabel.BindingContext = viewModel;
            INTLabel.BindingContext = viewModel;
            WISLabel.BindingContext = viewModel;
            CHALabel.BindingContext = viewModel;
            STRLabel.Text = viewModel.character.Scores.Strength.Value.ToString();
            DEXLabel.Text = viewModel.character.Scores.Strength.Value.ToString();
            CONLabel.Text = viewModel.character.Scores.Strength.Value.ToString();
            INTLabel.Text = viewModel.character.Scores.Strength.Value.ToString();
            WISLabel.Text = viewModel.character.Scores.Strength.Value.ToString();
            CHALabel.Text = viewModel.character.Scores.Strength.Value.ToString();

            ChangeCharacterButton.BindingContext = viewModel;
            ChangeCharacterButton.Command = new Command(() => {
                viewModel.OpenCharacterList();
            });

            LanguagesLabel.BindingContext = viewModel;
            LanguagesLabel.Text = viewModel.LanguageCells;

            LagnuageAddButton.BindingContext = viewModel;
            LagnuageAddButton.Command = new Command(() => {
                AddLanguage();
            });

            LagnuageRemoveButton.BindingContext = viewModel;
            LagnuageRemoveButton.Command = new Command(() => {
                RemoveLanguage();
            });

            StatusListView.BindingContext = viewModel;
            StatusListView.ItemsSource = viewModel.Statuses;

            StatusAddButton.BindingContext = viewModel;
            StatusAddButton.Command = new Command(() => {
                AddStatus();
            });

            StatusRemoveButton.BindingContext = viewModel;
            StatusRemoveButton.Command = new Command(() => {
                RemoveStatus();
            });

            HealthBar.BindingContext = viewModel;
            var ChangeHealthTap = new TapGestureRecognizer();
            ChangeHealthTap.Tapped += (s, e) => {
                //DisplayAlert("Alert", "Previous Page", "OK");
                ChangeHealth();
            };
            HealthBar.GestureRecognizers.Add(ChangeHealthTap);

            MoneyField.BindingContext = viewModel;
            var ChangeMoneyTap = new TapGestureRecognizer();
            ChangeMoneyTap.Tapped += (s, e) => {
                //DisplayAlert("Alert", "Previous Page", "OK");
                ChangeMoney();
            };
            MoneyField.GestureRecognizers.Add(ChangeMoneyTap);
        }

        public void AddLanguage() {
            // Initialises the layout that will contain the popup layer
            //DisplayAlert("Alert", "Creating overlay", "OK");

            Command exitCommand = new Command(() => {
                RemovePopup();
            });

            Picker LanguageSelect = new Picker() {
                FontSize = 24,
                BackgroundColor = Color.FromHex("#BBBBBB"),
                ItemsSource = viewModel.GetRaceLanguages()
            };
            AbsoluteLayout.SetLayoutBounds(LanguageSelect, new Rectangle(.5, .5, .8, .3));
            AbsoluteLayout.SetLayoutFlags(LanguageSelect, AbsoluteLayoutFlags.All);

            Command acceptCommand = new Command(() => {
                if (LanguageSelect.SelectedItem != null &&
                    viewModel.AddLanguage(LanguageSelect.SelectedItem.ToString())) {
                    LanguagesLabel.Text = viewModel.LanguageCells;
                    RemovePopup();
                }
                //DisplayAlert("Alert", "Entry: " + LanguageSelect.SelectedItem.ToString(), "OK");

            });

            AbsoluteLayout popUp = Statics.GlobalFunctions.getPopupBase("Add Language", exitCommand, acceptCommand);

            AbsoluteLayout popUpFill = Statics.GlobalFunctions.getPopUpFill();

            popUp.Children.Add(popUpFill);

            popUpFill.Children.Add(LanguageSelect);

            popUpOverlay = popUp;

            // Add this layout to the Content layout
            PageContent.Children.Add(popUpOverlay);
        }

        public void RemoveLanguage() {
            // Initialises the layout that will contain the popup layer
            //DisplayAlert("Alert", "Creating overlay", "OK");

            Command exitCommand = new Command(() => {
                RemovePopup();
            });

            Picker LanguageSelect = new Picker() {
                FontSize = 24,
                BackgroundColor = Color.FromHex("#BBBBBB"),
                ItemsSource = viewModel.character.Languages
            };
            AbsoluteLayout.SetLayoutBounds(LanguageSelect, new Rectangle(.5, .5, .8, .3));
            AbsoluteLayout.SetLayoutFlags(LanguageSelect, AbsoluteLayoutFlags.All);

            Command acceptCommand = new Command(() => {
                if (LanguageSelect.SelectedItem != null &&
                    viewModel.RemoveLanguage(LanguageSelect.SelectedItem.ToString())) {
                    LanguagesLabel.Text = viewModel.LanguageCells;
                    RemovePopup();
                }
                //DisplayAlert("Alert", "Entry: " + LanguageSelect.SelectedItem.ToString(), "OK");

            });

            AbsoluteLayout popUp = Statics.GlobalFunctions.getPopupBase("Remove Language", exitCommand, acceptCommand);

            AbsoluteLayout popUpFill = Statics.GlobalFunctions.getPopUpFill();

            popUp.Children.Add(popUpFill);

            popUpFill.Children.Add(LanguageSelect);

            popUpOverlay = popUp;

            // Add this layout to the Content layout
            PageContent.Children.Add(popUpOverlay);
        }

        public void AddStatus() {
            // Initialises the layout that will contain the popup layer
            //DisplayAlert("Alert", "Creating overlay", "OK");

            Command exitCommand = new Command(() => {
                RemovePopup();
            });

            Entry StatusSelect = new Entry() {
                FontSize = 24,
                BackgroundColor = Color.FromHex("#BBBBBB")
            };
            AbsoluteLayout.SetLayoutBounds(StatusSelect, new Rectangle(.5, .5, .8, .3));
            AbsoluteLayout.SetLayoutFlags(StatusSelect, AbsoluteLayoutFlags.All);

            Command acceptCommand = new Command(() => {
                if (StatusSelect.Text != "" &&
                    viewModel.AddStatusAffect(StatusSelect.Text)) {
                    StatusListView.ItemsSource = viewModel.Statuses;
                    RemovePopup();
                }
                //DisplayAlert("Alert", "Entry: " + LanguageSelect.SelectedItem.ToString(), "OK");

            });

            AbsoluteLayout popUp = Statics.GlobalFunctions.getPopupBase("Add Status", exitCommand, acceptCommand);

            AbsoluteLayout popUpFill = Statics.GlobalFunctions.getPopUpFill();

            popUp.Children.Add(popUpFill);

            popUpFill.Children.Add(StatusSelect);

            popUpOverlay = popUp;

            // Add this layout to the Content layout
            PageContent.Children.Add(popUpOverlay);
        }

        public void RemoveStatus() {
            // Initialises the layout that will contain the popup layer
            //DisplayAlert("Alert", "Creating overlay", "OK");

            Command exitCommand = new Command(() => {
                RemovePopup();
            });

            Picker StatusSelect = new Picker() {
                FontSize = 24,
                BackgroundColor = Color.FromHex("#BBBBBB"),
                ItemsSource = viewModel.character.Statuses
            };
            AbsoluteLayout.SetLayoutBounds(StatusSelect, new Rectangle(.5, .5, .8, .3));
            AbsoluteLayout.SetLayoutFlags(StatusSelect, AbsoluteLayoutFlags.All);

            Command acceptCommand = new Command(() => {
                if (StatusSelect.SelectedItem != null &&
                    viewModel.RemoveStatusAffect(StatusSelect.SelectedItem.ToString())) {
                    StatusListView.ItemsSource = viewModel.Statuses;
                    RemovePopup();
                }
                //DisplayAlert("Alert", "Entry: " + LanguageSelect.SelectedItem.ToString(), "OK");

            });

            AbsoluteLayout popUp = Statics.GlobalFunctions.getPopupBase("Remove Status", exitCommand, acceptCommand);

            AbsoluteLayout popUpFill = Statics.GlobalFunctions.getPopUpFill();

            popUp.Children.Add(popUpFill);

            popUpFill.Children.Add(StatusSelect);

            popUpOverlay = popUp;

            // Add this layout to the Content layout
            PageContent.Children.Add(popUpOverlay);
        }

        public void ChangeHealth() {
            // Initialises the layout that will contain the popup layer
            //DisplayAlert("Alert", "Creating overlay", "OK");

            Command exitCommand = new Command(() => {
                RemovePopup();
            });

            Entry HealthSelect = new Entry() {
                FontSize = 24,
                Text="0",
                Keyboard = Keyboard.Numeric,
                BackgroundColor = Color.FromHex("#BBBBBB"),
                HorizontalTextAlignment = TextAlignment.Center
            };
            AbsoluteLayout.SetLayoutBounds(HealthSelect, new Rectangle(.5, .5, .2, .3));
            AbsoluteLayout.SetLayoutFlags(HealthSelect, AbsoluteLayoutFlags.All);

            Image HealthPlus = new Image() {
                Source = "PlusButton.PNG"
            };
            AbsoluteLayout.SetLayoutBounds(HealthPlus, new Rectangle(.9, .5, .3, .3));
            AbsoluteLayout.SetLayoutFlags(HealthPlus, AbsoluteLayoutFlags.All);

            var HealthUp = new TapGestureRecognizer();
            HealthUp.Tapped += (s, e) => {
                int HealthValue = Int32.Parse(HealthSelect.Text);

                HealthSelect.Text = (HealthValue + 1).ToString();
            };
            HealthPlus.GestureRecognizers.Add(HealthUp);

            Image HealthMinus = new Image() {
                Source = "MinusButton.PNG"
            };
            AbsoluteLayout.SetLayoutBounds(HealthMinus, new Rectangle(.1, .5, .3, .3));
            AbsoluteLayout.SetLayoutFlags(HealthMinus, AbsoluteLayoutFlags.All);

            var HealthDown = new TapGestureRecognizer();
            HealthDown.Tapped += (s, e) => {
                int HealthValue = Int32.Parse(HealthSelect.Text);

                HealthSelect.Text = (HealthValue - 1).ToString();
            };
            HealthMinus.GestureRecognizers.Add(HealthDown);

            Command acceptCommand = new Command(() => {
                int Health = Int32.Parse(HealthSelect.Text);
                if (Health < 0) {
                    viewModel.character.HealthBar.RemoveHealth(Health);
                    HealthLabel.Text = viewModel.character.HealthBar.CurrentHealth.ToString() + "/" + viewModel.character.HealthBar.TotalHealth.ToString();
                    AbsoluteLayout.SetLayoutBounds(HealthBarLayout, new Rectangle(0, 0, ((double)viewModel.character.HealthBar.CurrentHealth / (double)viewModel.character.HealthBar.TotalHealth), 1));
                } else if(Health > 0) {
                    viewModel.character.HealthBar.AddHealth(Health);
                    HealthLabel.Text = viewModel.character.HealthBar.CurrentHealth.ToString() + "/" + viewModel.character.HealthBar.TotalHealth.ToString();
                    AbsoluteLayout.SetLayoutBounds(HealthBarLayout, new Rectangle(0, 0, ((double)viewModel.character.HealthBar.CurrentHealth / (double)viewModel.character.HealthBar.TotalHealth), 1));
                }
                RemovePopup();
                //DisplayAlert("Alert", "Entry: " + LanguageSelect.SelectedItem.ToString(), "OK");

            });

            Label CurrentHealth = new Label() {
                Text = viewModel.character.HealthBar.TotalHealth.ToString() + "/" + viewModel.character.HealthBar.CurrentHealth.ToString(),
                FontSize=24,
                HorizontalTextAlignment=TextAlignment.Center
            };
            AbsoluteLayout.SetLayoutBounds(CurrentHealth, new Rectangle(.5, .2, .5, .3));
            AbsoluteLayout.SetLayoutFlags(CurrentHealth, AbsoluteLayoutFlags.All);

            AbsoluteLayout popUp = Statics.GlobalFunctions.getPopupBase("Change Health", exitCommand, acceptCommand);

            AbsoluteLayout popUpFill = Statics.GlobalFunctions.getPopUpFill();

            popUp.Children.Add(popUpFill);

            popUpFill.Children.Add(HealthSelect);
            popUpFill.Children.Add(HealthPlus);
            popUpFill.Children.Add(HealthMinus);
            popUpFill.Children.Add(CurrentHealth);

            popUpOverlay = popUp;

            // Add this layout to the Content layout
            PageContent.Children.Add(popUpOverlay);
        }

        public void ChangeMoney() {
            // Initialises the layout that will contain the popup layer
            //DisplayAlert("Alert", "Creating overlay", "OK");

            Command exitCommand = new Command(() => {
                RemovePopup();
            });

            Entry MoneySelect = new Entry() {
                FontSize = 24,
                Text = "0",
                Keyboard = Keyboard.Numeric,
                BackgroundColor = Color.FromHex("#BBBBBB"),
                HorizontalTextAlignment = TextAlignment.Center
            };
            AbsoluteLayout.SetLayoutBounds(MoneySelect, new Rectangle(.5, .55, .6, .3));
            AbsoluteLayout.SetLayoutFlags(MoneySelect, AbsoluteLayoutFlags.All);

            Label MoneyGP = new Label() {
                FontSize = 24,
                Text = "GP",
                BackgroundColor = Color.FromHex("#BBBBBB"),
                HorizontalTextAlignment = TextAlignment.Center
            };
            AbsoluteLayout.SetLayoutBounds(MoneyGP, new Rectangle(.5, 1, .1, .3));
            AbsoluteLayout.SetLayoutFlags(MoneyGP, AbsoluteLayoutFlags.All);


            Command acceptCommand = new Command(() => {
                double Money = double.Parse(MoneySelect.Text);
                DisplayAlert("Alert", "Money: " + (int)(Money * 10000), "OK");
                if (Money > 0) {
                    viewModel.character.Gold.Add((int)(Money*10000));
                    CPLabel.Text = "CP: " + viewModel.character.Gold.CP;
                    SPLabel.Text = "SP: " + viewModel.character.Gold.SP;
                    GPLabel.Text = "GP: " + viewModel.character.Gold.GP;
                    PPLabel.Text = "PP: " + viewModel.character.Gold.PP;
                    RemovePopup();
                } else if(Money < 0) {
                    viewModel.character.Gold.Subtract((int)(Money *10000));
                    CPLabel.Text = "CP: " + viewModel.character.Gold.CP;
                    SPLabel.Text = "SP: " + viewModel.character.Gold.SP;
                    GPLabel.Text = "GP: " + viewModel.character.Gold.GP;
                    PPLabel.Text = "PP: " + viewModel.character.Gold.PP;
                    RemovePopup();
                }
                //DisplayAlert("Alert", "Entry: " + LanguageSelect.SelectedItem.ToString(), "OK");

            });

            Label CurrentMoney = new Label() {
                Text = viewModel.character.Gold.GetTotal() + " GP",
                FontSize = 24,
                HorizontalTextAlignment = TextAlignment.Center
            };
            AbsoluteLayout.SetLayoutBounds(CurrentMoney, new Rectangle(.5, .15, .8, .3));
            AbsoluteLayout.SetLayoutFlags(CurrentMoney, AbsoluteLayoutFlags.All);

            AbsoluteLayout popUp = Statics.GlobalFunctions.getPopupBase("Change Money", exitCommand, acceptCommand);

            AbsoluteLayout popUpFill = Statics.GlobalFunctions.getPopUpFill();

            popUp.Children.Add(popUpFill);

            popUpFill.Children.Add(MoneySelect);
            popUpFill.Children.Add(CurrentMoney);

            popUpOverlay = popUp;

            // Add this layout to the Content layout
            PageContent.Children.Add(popUpOverlay);
        }

        public void RemovePopup() {

            PageContent.Children.Remove(popUpOverlay);

        }
    }
}