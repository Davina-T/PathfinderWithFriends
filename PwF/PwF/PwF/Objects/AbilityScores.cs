using PwF.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PwF.Objects
{
    public class AbilityScores
    {
        // the public value to hold the Ability Scores
        //public List<AbilityScore> Scores { get; set; }

        public Objects.AbilityScore Strength { get; set; }
        public Objects.AbilityScore Dexterity { get; set; }
        public Objects.AbilityScore Constitution { get; set; }
        public Objects.AbilityScore Intelligence { get; set; }
        public Objects.AbilityScore Wisdom { get; set; }
        public Objects.AbilityScore Charisma { get; set; }

        // a list containing the names of each Ability Score
        private readonly List<AbilityScoreName> ScoreNames = new List<AbilityScoreName>() {AbilityScoreName.Strength,
            AbilityScoreName.Dexterity, AbilityScoreName.Constitution, AbilityScoreName.Intelligence,
            AbilityScoreName.Wisdom, AbilityScoreName.Charisma };

        public AbilityScores() {

            // Add each Ability Score to the list on creation
            //foreach (Enums.AbilityScoreName Name in ScoreNames) {
            //    Scores.Add(new AbilityScore(Name));
            //}
            Strength = new AbilityScore(ScoreNames[0]);
            Dexterity = new AbilityScore(ScoreNames[1]);
            Constitution = new AbilityScore(ScoreNames[2]);
            Intelligence = new AbilityScore(ScoreNames[3]);
            Wisdom = new AbilityScore(ScoreNames[4]);
            Charisma = new AbilityScore(ScoreNames[5]);

        }

    }
}
