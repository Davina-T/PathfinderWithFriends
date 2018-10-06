using System;
using System.Collections.Generic;
using System.Text;

namespace PwF.Objects
{
    public class Skill
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public Enums.AbilityScoreName ModifierType { get; set; }
        public string Description { get; set; }

        public Skill(string name, Enums.AbilityScoreName modifierType, string description, int value = 0) {
            Name = name;
            ModifierType = modifierType;
            Description = description;
            Value = value;
        }
    }
}
