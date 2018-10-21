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

            //Objects.CharacterDetails details = new Objects.CharacterDetails();

            //Characters[0].Player = "Cameron";
            //Characters[0].Name = "Master Person";

            //Objects.Race race = new Objects.Race();
            //race.Name = "Dwarf";

            //Characters[0].CharRace = race;

            //Objects.Class charClass = new Objects.Class();
            //charClass.Name = "Wizard";

            //Characters[0].CharClass = charClass;

            //Characters[0].Level = 2;

            //details.Alignment = Enums.Alignment.ChaoticEvil;
            //details.Diety = "Ibis";
            //details.Homeland = "Ibistown";
            //details.Size = Enums.Size.Medium;
            //details.Gender = "Male";
            //details.Age = 20;
            //details.Height = 4.6f;
            //details.Weight = 30.6f;
            //details.Hair = "brown, long";
            //details.Eyes = "Hazel";
            //details.Backstory = "this is the backstory";

            //Characters[0].Details = details;

            //Objects.AbilityScores scores = new Objects.AbilityScores();
            //scores.Strength.Value = 15;
            //scores.Dexterity.Value = 14;
            //scores.Constitution.Value = 13;
            //scores.Intelligence.Value = 12;
            //scores.Wisdom.Value = 11;
            //scores.Charisma.Value = 10;

            //Characters[0].Scores = scores;
            //Characters[0].Skills = new List<Objects.Skill>() { new Objects.Skill("Acrobatics", Enums.AbilityScoreName.Dexterity, 
            //    "perform acrobatics", 4) };
            //Characters[0].Feats = new List<Objects.Feat>() { new Objects.Feat("Glide", "create a slow decent from a fall") };
            //Characters[0].Languages = new List<string>() { "Common", "Draconic" };
            //Characters[0].Spells = new List<Objects.Spell>() { new Objects.Spell("Magic Missle", "fire a shining projectile", 8) };

            //Objects.Money gold = new Objects.Money();
            //gold.CP = 58;
            //gold.SP = 4;
            //gold.GP = 89;
            //gold.PP = 9;

            //Characters[0].Gold = gold;

            //Characters[0].HealthBar = new Objects.Health(17);

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