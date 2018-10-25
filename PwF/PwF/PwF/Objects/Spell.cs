using System;
using System.Collections.Generic;
using System.Text;

namespace PwF.Objects
{
    public class Spell {
        public int Level { get; set; }
        public string Name { get; set; }
        public string CastingTime { get; set; }
        public string Range { get; set; }
        public string Target { get; set; }
        public string Duration { get; set; }
        public string ReflexThrows { get; set; }
        public string Effect { get; set; }
        public int Damage { get; set; }

        public Spell(int level, string name, string castingTime, string range, string target, string duration, string reflexThow, string effect, int damage) {
            Level = level;
            Name = name;
            Range = range;
            Target = target;
            Duration = duration;
            ReflexThrows = reflexThow;
            Effect = effect;
            Damage = damage;
        }
    }
}
