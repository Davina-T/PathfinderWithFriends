using PwF.CharacterSheet;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

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
            //navigation.PushAsync(new CharacterSheet());
        }

        public void ShowCharacterSheet() {
            navigation.PushAsync(new CharacterSheet());
        }

        public void ShowCombatPage() {
            navigation.PushAsync(new CombatPage());
        }

    }
}
