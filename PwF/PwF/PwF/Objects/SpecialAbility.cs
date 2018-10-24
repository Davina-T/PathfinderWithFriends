using System;
using System.Collections.Generic;
using System.Text;

namespace PwF.Objects
{
    public class SpecialAbility
    {
        public string Name { get; set; }
        public string Effect { get; set; }

        public SpecialAbility(string name, string effect) {
            Name = name;
            Effect = effect;
        }
    }
}
