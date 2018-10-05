using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pwf.Navigation
{
    public class HomeViewModel {
        public ICommand OpenCombatPage { protected set; get; }
        public ICommand OpenCharacterSheet { protected set; get; }
        public ICommand OpenCharacterList { protected set; get; }
        private PageNavigationManager navManager;

        public HomeViewModel() {
            navManager = PageNavigationManager.Instance;

            OpenCharacterList = new Command(() => {
                // change the navManager to call the method in PageNavigationManager
                navManager.ShowCharacterList();
            });

            OpenCharacterSheet = new Command(() => {
                navManager.ShowCharacterSheet();
            });

            OpenCombatPage = new Command(() => {
                navManager.ShowCombatPage();
            });
        }

    }
}
