using System;
using System.Collections.Generic;
using System.Text;

namespace PwF.Objects
{
    public class AbilityScores
    {
        // the public value to hold the Ability Scores
        public List<AbilityScore> Scores { get; set; }

        //public Objects.AbilityScore Strength { get; set; }
        //public Objects.AbilityScore Dexterity { get; set; }
        //public Objects.AbilityScore Constitution { get; set; }
        //public Objects.AbilityScore Intelligence { get; set; }
        //public Objects.AbilityScore Wisdom { get; set; }
        //public Objects.AbilityScore Charisma { get; set; }

        // a list containing the names of each Ability Score
        private readonly List<Enums.AbilityScoreName> ScoreNames = new List<Enums.AbilityScoreName>() {Enums.AbilityScoreName.Strength,
            Enums.AbilityScoreName.Dexterity, Enums.AbilityScoreName.Constitution, Enums.AbilityScoreName.Intelligence,
            Enums.AbilityScoreName.Wisdom, Enums.AbilityScoreName.Charisma };

        public AbilityScores() {

            // Add each Ability Score to the list on creation
            foreach (Enums.AbilityScoreName Name in ScoreNames) {
                Scores.Add(new AbilityScore(Name));
            }

        }

        // getting the score of choice
        public int GetScore(Enums.AbilityScoreName name) {
            // try to find Score in list
            foreach (AbilityScore Score in Scores) {
                if (Score.Name == name) {
                    // if found Score then return the value
                    return Score.Value;
                }
            }
            // if Score was not in list return 0
            return 0;
        }

        // changing the selected Score
        public int ChangeScore(Enums.AbilityScoreName name, int value) {
            // try to find Score in list
            foreach (AbilityScore Score in Scores) {
                if (Score.Name == name) {
                    // if found Score then reasign the value
                    Score.Value = value;
                }
            }
            // if Score was not in list return 0
            return 0;
        }

        // returning the modifier of selected Score
        public int ReturnModifier(Enums.AbilityScoreName name) {
            double temp;
            // try to find Score in list
            foreach (AbilityScore Score in Scores) {
                if (Score.Name == name) {
                    // if found Score then apply equation, round down number and return result
                    temp = (Math.Floor(((double)Score.Value - 10) / 2));
                    return (int)temp;
                }
            }
            // if Score was not in list return 0
            return 0;
        }

    }
}
