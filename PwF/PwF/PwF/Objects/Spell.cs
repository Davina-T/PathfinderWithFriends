using System;
using System.Collections.Generic;
using System.Text;

namespace PwF.Objects
{
    public class Spell {
        public string Name { get; set; }
        public string Effect { get; set; }
        public int Damage { get; set; }

        public Spell(string name, string effect, int damage) {
            Name = name;
            Effect = effect;
            Damage = damage;
        }
    }
}
