using PwF.CharacterSheet;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using PwF.CharacterList;
using PwF.CharacterCreation;

namespace Pwf.Navigation
{
    public class PageNavigationManager {
        private static PageNavigationManager instance;

        private PageNavigationManager() { }

        public static PageNavigationManager Instance {
            get {
                if (instance == null) {
                    instance = new PageNavigationManager();
                }
                return instance;
            }
        }

        private INavigation navigation;

        public INavigation Navigation {
            set { navigation = value; }
        }

        public void ShowCharacterList(bool forward = true) {
            // change navigation to send to main page (character list page)
            navigation.PushAsync(new CharacterList());
        }

        public void ShowCharacterSheet(bool forward = true) {
            navigation.PushAsync(new CharacterSheet());
        }

        public void ShowCombatPage(bool forward = true) {
            navigation.PushAsync(new CombatPage());
        }

        public void ShowLevelPage(bool forward = true) {
            navigation.PushAsync(new LevelPage());
        }

        public void ShowRacePage(bool forward = true) {
            navigation.PushAsync(new RacePage());
        }

        public void ShowClassPage(bool forward = true) {
            navigation.PushAsync(new ClassPage());
        }

        public void ShowFamiliarPage(bool forward = true) {
            // change navigation to send to Familiars Page
            // navigation.PushAsync(new ClassPage());
            if (forward) {
                ShowAbilityScoresPage();
            } else {
                ShowClassPage(false);
            }
            
        }

        public void ShowAbilityScoresPage(bool forward = true) {
            // change navigation to send to Ability Scores Page
            navigation.PushAsync(new AbilityScorePage());
        }

        public void ShowSkillsPage(bool forward = true) {
            // change navigation to send to Skills Page
            navigation.PushAsync(new SkillsPage());
        }

        public void ShowFeatsPage(bool forward = true) {
            // change navigation to send to Feats Page
            // navigation.PushAsync(new AbilityScorePage());
            navigation.PushAsync(new FeatsPage());
        }

        public void ShowLanguagesPage(bool forward = true) {
            // change navigation to send to Languages Page
            // navigation.PushAsync(new AbilityScorePage());
            if (forward) {
                ShowSpellssPage();
            } else {
                ShowFeatsPage(false);
            }
        }

        public void ShowSpellssPage(bool forward = true) {
            // change navigation to send to Spells Page
            // navigation.PushAsync(new AbilityScorePage());
            if (forward) {
                ShowMoneyPage();
            } else {
                ShowLanguagesPage(false);
            }
        }

        public void ShowMoneyPage(bool forward = true) {
            // change navigation to send to Money Page
            navigation.PushAsync(new MoneyPage());
        }

        public void ShowEquipmentPage(bool forward = true) {
            // change navigation to send to Equipment Page
            // navigation.PushAsync(new AbilityScorePage());
            if (forward) {
                ShowCharacterDetailsPage();
            } else {
                ShowMoneyPage(false);
            }
        }

        public void ShowCharacterDetailsPage(bool forward = true) {
            // change navigation to send to Character Details Page
            navigation.PushAsync(new DetailsPage());
        }

        public void ShowBackstoryPage(bool forward = true)
        {
            // change navigation to send to Character Details Page
            // navigation.PushAsync(new AbilityScorePage());
            if (forward)
            {
                ShowCharacterConfirmPage();
            }
            else
            {
                ShowCharacterDetailsPage(false);
            }
        }

        public void ShowCharacterConfirmPage(bool forward = true) {
            // change navigation to send to Character Confirm Page
            // navigation.PushAsync(new AbilityScorePage());
            ShowTesterPage();
        }

        public void ShowTesterPage() {
            navigation.PushAsync(new TesterPage());
        }

    }
}
