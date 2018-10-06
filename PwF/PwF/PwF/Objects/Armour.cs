using System;
using System.Collections.Generic;
using System.Text;

namespace PwF.Objects
{
    public class Armour
    {
        public string Name { get; set; }
        public int Bonus { get; set; }
        public string Type { get; set; }
        public int CheckPenalty { get; set; }
        public int SpellFailure { get; set; }
        public double Weight { get; set; }
        public string Properties { get; set; }

        public Armour(string name, int bonus, string type, int checkPenalty, int spellFailure, double weight, string properties) {
            Name = name;
            Bonus = bonus;
            Type = type;
            CheckPenalty = checkPenalty;
            SpellFailure = spellFailure;
            Weight = weight;
            Properties = properties;
        }
    }
}
