using Pwf.Navigation;
using PwF.Cells.PwF.Cells;
using System;
using System.Collections.Generic;
using System.Text;

namespace PwF.CharacterCreation
{
    public class RaceViewModel {
        private PageNavigationManager navManager;

        public CustomCell SelectedRace { get; set; }
        //public string[] Races { get; set; }
        public List<CustomCell> CustomCells { get; }

        public RaceViewModel() {
            navManager = PageNavigationManager.Instance;
            CustomCells = getRaces();
            //foreach(CustomCell cell in CustomCells) {
            //    if (cell.Title == Statics.CharacterCreating.CreatingCharacter.Race) {
            //        SelectedRace = cell;
            //    }
            //}
        }

        private List<CustomCell> getRaces() {
            string[] races = new string[] {
                "Dwarves", "Elves", "Gnomes", "Half-Elves", "Half-Orcs",
                "Halflings", "Humans", "Aasimars", "Catfolk", "Dhampirs",
                "Drow", "Fetchlings", "Goblins", "Hobgoblins", "Ifrits",
                "Kobolds", "Orcs", "Oreads", "Ratfolk", "Sylphs", "Tengus",
                "Tieflings", "Undines"};

            List<CustomCell> CustomCells = new List<CustomCell>();

            foreach (string race in races) {
                CustomCells.Add(new CustomCell(race));
            }

            return CustomCells;
        }

        public void NextPage() {
            if (SelectedRace != null && SelectedRace.Title != "") {
                // use Race to get data for race to create race object
                Objects.Race CharacterRace = new Objects.Race() {
                    Name = SelectedRace.Title,
                    Languages = new List<string>() { "Commoner", "Elfish", "Dwarven", "Draconic", "UnCommon", "Celestial" },
                    Feats = new List<Objects.Feat>() { new Objects.Feat("Adaptive Fortune", "Increase the number of times per day you can use the adaptable luck racial trait by 1", "Fortunate One, adaptable luck racial trait, character level 10th, halfling"),
                    new Objects.Feat("Blundering Defense","Whenever you fight defensively or use the total defense action, allies gain a luck bonus to AC and CMD equal to 1/2 the dodge bonus you gain from the action you are taking","Cautious Fighter, halfling"),
                    new Objects.Feat("Cautious Fighter", "When fighting defensively or using total defense, your dodge bonus to AC increases by 2", "Halfling"),
                    new Objects.Feat("Lucky Strike", "Spend a use of your adaptive luck racial trait to reroll the damage from a single weapon attack. You deal damage equal to the new damage roll, or the original roll, whichever is greater", "Base attack bonus +5, adaptive luck racial trait, halfling")},
                    SpecialAbilities = new List<Objects.SpecialAbility>() { new Objects.SpecialAbility("Adaptable Luck", " Some halflings have greater control over their innate luck. This ability gives them more options for how they can apply their good fortune from day to day, but also narrows its scope. Three times per day, a halfling can gain a +2 luck bonus on an ability check, attack roll, saving throw, or skill check. If halflings choose to use the ability before they make the roll or check, they gain the full +2 bonus; if they choose to do so afterward, they only gain a +1 bonus. Using adaptive luck in this way is not an action. This racial trait replaces halfling luck"),
                    new Objects.SpecialAbility("Craven", "While most halflings are fearless, some are skittish, making them particularly alert. Halflings with this racial trait gain a +1 bonus on initiative checks and a +1 bonus on attack rolls when flanking. They take a –2 penalty on saves against fear effects and gain no benefit from morale bonuses on such saves. When affected by a fear effect, their base speed increases by 10 feet and they gain a +1 dodge bonus to Armor Class. This racial trait replaces fearless and halfling luck"),
                    new Objects.SpecialAbility("Fleet of Foot", "Some halflings are quicker than their kin but less cautious. Halflings with this racial trait move at normal speed and have a base speed of 30 feet. This racial trait replaces slow speed and sure-footed"),
                    new Objects.SpecialAbility("Ingratiating", "Halflings often survive at the whims of larger, more aggressive races. Because of this, they go out of their way to make themselves more useful, or at least entertaining, to larger folk. Halflings with this racial trait gain a +2 bonus on skill checks for a single Perform skill of their choice, and Perform is always a class skill for them. They also gain a +2 bonus on Craft and Profession checks. This racial trait replaces keen senses and sure-footed")}
                };
                Statics.CharacterCreating.CreatingCharacter.CharRace = CharacterRace;
                navManager.ShowClassPage();
            }
        }

        public void PrevPage() {
            Statics.CharacterCreating.CreatingCharacter.CharRace = null;
            navManager.ShowLevelPage(false);
        }

        public void ViewInfo() {
            // open the informative page
        }
    }
}
