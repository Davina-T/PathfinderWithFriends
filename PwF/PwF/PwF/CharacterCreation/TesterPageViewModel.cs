using Pwf.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PwF.CharacterCreation
{
    public class TesterPageViewModel
    {
        
        private PageNavigationManager navManager;
        List<Objects.Character> Characters;
        Objects.Character Character;

        public TesterPageViewModel() {
            navManager = PageNavigationManager.Instance;
            Characters = Statics.JsonStuff.DeserializeCharacters();
            Character = Statics.CharacterCreating.CreatingCharacter;

            AutoFill();
        }

        public void AutoFill() {
            Character.HealthBar = new Objects.Health(17);
            Character.Statuses = new List<string>();

            Characters.Add(Character);
            Statics.JsonStuff.SerializeCharacters(Characters);
        }

        public void ReturnToList() {
            navManager.ShowCharacterList();
        }
    }
}
