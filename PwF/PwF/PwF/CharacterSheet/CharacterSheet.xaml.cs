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
            HealthLabel.Text = viewModel.character.HealthBar.TotalHealth.ToString() + "/" + viewModel.character.HealthBar.CurrentHealth.ToString();

            HealthBarLayout.BindingContext = viewModel;
            AbsoluteLayout.SetLayoutBounds(HealthBarLayout, new Rectangle(0, 0, viewModel.character.HealthBar.TotalHealth/ viewModel.character.HealthBar.CurrentHealth, 1));

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

        public void RemovePopup() {

            PageContent.Children.Remove(popUpOverlay);

        }
    }
}