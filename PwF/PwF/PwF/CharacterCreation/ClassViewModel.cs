using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pwf.Navigation;
using PwF.Cells;
using PwF.Cells.PwF.Cells;

using Xamarin.Forms;

namespace PwF.CharacterCreation
{
    public class ClassViewModel
    {
        private PageNavigationManager navManager;

        public CustomCell SelectedClass { get; set; }
        public List<CustomCell> CustomCells { get; }

        public ClassViewModel()
        {
            navManager = PageNavigationManager.Instance;
            CustomCells = getClasses();
        }

        private List<CustomCell> getClasses()
        {
            string[] classes = new string[] {
                "Bard", "Rogue", "Warrior", "Wizard"};

            List<CustomCell> CustomCells = new List<CustomCell>();

            foreach (string cClass in classes) {
                CustomCells.Add(new CustomCell(cClass));
            }

            return CustomCells;
        }

        public void NextPage()
        {
            if (SelectedClass != null && SelectedClass.Title != "")
            {
                Objects.Class CharacterRace = new Objects.Class() {
                    Name = SelectedClass.Title,
                    SkillPoints = 4,
                    Skills = new List<Objects.Skill>() { new Objects.Skill("Acrobatics", Enums.AbilityScoreName.Dexterity, "Perform Acrobatics"),
                    new Objects.Skill("Use Magic Device", Enums.AbilityScoreName.Intelligence, "Skills in using Magical Items"),
                    new Objects.Skill("Bluff", Enums.AbilityScoreName.Charisma, "Skills in attempting to bluff in speach"),
                    new Objects.Skill("Linguistics", Enums.AbilityScoreName.Intelligence, "Ability to Speak more Languages"),
                    new Objects.Skill("Climb", Enums.AbilityScoreName.Strength, "Climbing SKill")},
                    Spells = new List<Objects.Spell> { new Objects.Spell(2, "Adhesive Blood", "1 standard action", "1 minute/level", "personal", 
                    "1 minute/level", "Reflex negates (see text); Spell Resistance no", "Your blood thickens to becomes a glue-like substance upon contact with air. A piercing or slashing weapon that deals hit point damage to you is stuck fast unless the wielder succeeds at a Reflex save. A creature can pry off a stuck weapon on its turn as a standard action with a successful Strength check against the spell's DC. Strong alcohol or universal solvent dissolves the adhesive. The glue breaks down 5 rounds after you die, or when the duration ends. This glue has no effect while underwater or in environments that lack air", 0),
                    new Objects.Spell(1, "Adhesive Spittle", "1 standard action", "15 ft", "one creature", "1 round/level or until discharged",
                    "Reflex partial; Spell Resistance no", "Once during this spell's duration, you can spit a viscous liquid as a standard action. This liquid functions as a tanglefoot bag, except you do not have to make a successful attack roll to hit your target. The DCs to counteract this adhesive (to avoid being stuck to the floor, to fly, to break the adhesive, or to cast a spell) use the spell's DC rather than a tanglefoot bag's normal DCs. The adhesive persists for 2d4 rounds after you spit it.", 0)},
                    Feats = new List<Objects.Feat>() { new Objects.Feat("Adaptive Fortune", "Increase the number of times per day you can use the adaptable luck racial trait by 1", "Fortunate One, adaptable luck racial trait, character level 10th, halfling"),
                    new Objects.Feat("Blundering Defense","Whenever you fight defensively or use the total defense action, allies gain a luck bonus to AC and CMD equal to 1/2 the dodge bonus you gain from the action you are taking","Cautious Fighter, halfling"),
                    new Objects.Feat("Cautious Fighter", "When fighting defensively or using total defense, your dodge bonus to AC increases by 2", "Halfling"),
                    new Objects.Feat("Lucky Strike", "Spend a use of your adaptive luck racial trait to reroll the damage from a single weapon attack. You deal damage equal to the new damage roll, or the original roll, whichever is greater", "Base attack bonus +5, adaptive luck racial trait, halfling")},
                    SpecialAbilities = new List<Objects.SpecialAbility>() { new Objects.SpecialAbility("Adaptable Luck", " Some halflings have greater control over their innate luck. This ability gives them more options for how they can apply their good fortune from day to day, but also narrows its scope. Three times per day, a halfling can gain a +2 luck bonus on an ability check, attack roll, saving throw, or skill check. If halflings choose to use the ability before they make the roll or check, they gain the full +2 bonus; if they choose to do so afterward, they only gain a +1 bonus. Using adaptive luck in this way is not an action. This racial trait replaces halfling luck"),
                    new Objects.SpecialAbility("Craven", "While most halflings are fearless, some are skittish, making them particularly alert. Halflings with this racial trait gain a +1 bonus on initiative checks and a +1 bonus on attack rolls when flanking. They take a –2 penalty on saves against fear effects and gain no benefit from morale bonuses on such saves. When affected by a fear effect, their base speed increases by 10 feet and they gain a +1 dodge bonus to Armor Class. This racial trait replaces fearless and halfling luck"),
                    new Objects.SpecialAbility("Fleet of Foot", "Some halflings are quicker than their kin but less cautious. Halflings with this racial trait move at normal speed and have a base speed of 30 feet. This racial trait replaces slow speed and sure-footed"),
                    new Objects.SpecialAbility("Ingratiating", "Halflings often survive at the whims of larger, more aggressive races. Because of this, they go out of their way to make themselves more useful, or at least entertaining, to larger folk. Halflings with this racial trait gain a +2 bonus on skill checks for a single Perform skill of their choice, and Perform is always a class skill for them. They also gain a +2 bonus on Craft and Profession checks. This racial trait replaces keen senses and sure-footed")}
                };
                Statics.CharacterCreating.CreatingCharacter.CharClass = CharacterRace;
                navManager.ShowAbilityScoresPage();
            }
        }

        public void PrevPage()
        {
            navManager.ShowRacePage(false);
        }

        public void ViewInfo()
        {
            // open the informative page
        }

        public String GetCompendiumEntry()
        {
            String compendiumEntry;

            if (SelectedClass != null && SelectedClass.Title != "")
            {
                compendiumEntry = "You've selected " + SelectedClass.Title + "\n\n" +
                "Information on " + SelectedClass.Title + " will go here.";
            }
            else
            {
                compendiumEntry = "Select the class for your character";
            }

            return compendiumEntry;
        }
    }
}