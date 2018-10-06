using System;
using System.Collections.Generic;
using System.Text;

namespace PwF.Objects
{
    public class Weapon
    {
        public string Name { get; set; }
        public string[] Type { get; set; }
        public double Range { get; set; }
        public double Ammunition { get; set; }
        public int AttackBonus { get; set; }
        public int[] Critical { get; set; }
        public int[][] Damage { get; set; }
        public int ExtraDamage { get; set; }
        public double Weight { get; set; }
        public string Special { get; set; }

        public Weapon(string name, string[] type, double range, int attackBonus, int[] critical, int[][] damage, int extraDamage, double weight, string special) {
            Name = name;
            Type = type;
            Range = range;
            AttackBonus = attackBonus;
            Critical = critical;
            Damage = damage;
            ExtraDamage = extraDamage;
            Weight = weight;
            Special = special;
        }

        public int SwingWeapon() {
            return Statics.DiceRoll.Roll(Damage) + ExtraDamage;
        }
    }
}
