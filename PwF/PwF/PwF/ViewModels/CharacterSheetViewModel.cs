using Pwf.ViewModels;
using PwF.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace PwF.ViewModels
{
    public class CharacterSheetViewModel : ViewModelBase
    {
        private Character character;

        public Character Character {
            get { return character; }
            set { character = value; }
        }

        public CharacterSheetViewModel()
        {
            Character = UpdateCharacterSheet.CreateCharacter();
        }
    }
}
