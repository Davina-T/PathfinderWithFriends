using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using PwF.CharacterCreation;
using PwF.CharacterSheet;
using Pwf.Navigation;

using Xamarin.Forms;
using Pwf.Template;

namespace PwF.CharacterList
{
	public class CharacterListViewModel : ViewModelBase
	{
        private PageNavigationManager navManager;
        public List<Objects.Character> Characters;

        public CharacterListViewModel ()
		{
            navManager = PageNavigationManager.Instance;
            Characters = Statics.JsonStuff.DeserializeCharacters();

            //Characters = new List<Objects.Character>();
            //Characters.Add(new Objects.Character());

            //Characters[1].Player = "Cameron";
            //Characters[1].Name = "Night Schwarze";

            //Characters[1].CharRace = new Objects.Race {
            //    Name = "Human"
            //};

            //Characters[1].CharClass = new Objects.Class {
            //    Name = "Rouge"
            //};

            //Characters[1].Level = 2;

            //Characters[1].Details = new Objects.CharacterDetails {
            //    Alignment = Enums.Alignment.ChaoticGood,
            //    Diety = "Moon Lord",
            //    Homeland = "Compendia",
            //    Size = Enums.Size.Medium,
            //    Gender = "Male",
            //    Age = 18,
            //    Height = 5.7f,
            //    Weight = 30.6f,
            //    Hair = "purple, short",
            //    Eyes = "red",
            //    Backstory = "this is the backstory"
            //};

            //Objects.AbilityScores scores = new Objects.AbilityScores();
            //scores.Strength.Value = 15;
            //scores.Dexterity.Value = 18;
            //scores.Constitution.Value = 13;
            //scores.Intelligence.Value = 12;
            //scores.Wisdom.Value = 11;
            //scores.Charisma.Value = 10;

            //Characters[1].Scores = scores;

            //Characters[1].Skills = new List<Objects.Skill>() { new Objects.Skill("Acrobatics", Enums.AbilityScoreName.Dexterity,
            //    "perform acrobatics", 4) };
            //Characters[1].Feats = new List<Objects.Feat>() { new Objects.Feat("Glide", "create a slow decent from a fall") };
            //Characters[1].Languages = new List<string>() { "Common", "Draconic" };
            //Characters[1].Spells = new List<Objects.Spell>() { new Objects.Spell("Magic Missle", "fire a shining projectile", 8) };

            //Characters[0].Coin = new Objects.Money {
            //    CP = 58,
            //    SP = 4,
            //    GP = 89,
            //    PP = 9
            //};

            //Characters[1].Coin = new Objects.Money {
            //    CP = 32,
            //    SP = 14,
            //    GP = 51,
            //    PP = 11
            //};

            //Characters[1].HealthBar = new Objects.Health(17);

            //Characters[1].Statuses = new List<string>();
            //Characters[1].Languages = new List<string>() { "Common", "Dwarven" };

            //Characters[1].CharRace.Languages = new List<string>() { "Common", "Dwarven", "Elfish", "Draconic" };

            //Statics.JsonStuff.SerializeCharacters(Characters);
        }

        public void OpenCharacterSheet(int character){
            navManager.ShowCharacterSheet(character);
        }

        public void StartNewCharacter(){
            navManager.ShowLevelPage();
        }
    }
}