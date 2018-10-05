using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using PwF.CharacterCreation;
using PwF.CreateCharacter;
using PwF.CharacterSheet;

using Xamarin.Forms;

namespace PwF.CharacterList
{
	public class CharacterListViewModel
	{
        public ICommand OpenCharacterSheet { protected set; get; }
        public ICommand OpenLevelPage { protected set; get; }

        private INavigation navigation;

        public INavigation Navigation
        {
            set { navigation = value; }
        }

        public CharacterListViewModel ()
		{
            //navManager = PageNavigationManager.Instance;

            OpenCharacterSheet = new Command(() => {
                //navManager.ShowCharacterSheet();
                navigation.PushAsync(new CharacterSheet.CharacterSheet());
            });

            OpenLevelPage = new Command(() => {
                //navManager.ShowCombatPage();
                navigation.PushAsync(new LevelPage());
            });
        }
	}
}