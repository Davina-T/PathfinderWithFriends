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

        public void ShowCharacterList() {
            // change navigation to send to main page (character list page)
            navigation.PushAsync(new CharacterList());
        }

        public void ShowCharacterSheet() {
            navigation.PushAsync(new CharacterSheet());
        }

        public void ShowCombatPage() {
            navigation.PushAsync(new CombatPage());
        }

        public void ShowLevelPage() {
            // change navigation to send to Level Page
            navigation.PushAsync(new LevelPage());
        }

        public void ShowRacePage() {
            navigation.PushAsync(new RacePage());
        }

        public void ShowClassPage() {
            // change navigation to send to Class Page
            navigation.PushAsync(new ClassPage());
        }

        public void ShowTesterPage() {
            navigation.PushAsync(new TesterPage());
        }

    }
}
