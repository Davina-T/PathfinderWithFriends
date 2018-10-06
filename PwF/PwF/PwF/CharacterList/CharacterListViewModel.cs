using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using PwF.CharacterCreation;
using PwF.CharacterSheet;
using Pwf.Navigation;

using Xamarin.Forms;

namespace PwF.CharacterList
{
	public class CharacterListViewModel
	{
        private PageNavigationManager navManager;

        public CharacterListViewModel ()
		{
            navManager = PageNavigationManager.Instance;
        }
        public void OpenCharacterSheet()
        {
            navManager.ShowCharacterSheet();
        }

        public void StartNewCharacter()
        {
            navManager.ShowLevelPage();
        }
    }
}