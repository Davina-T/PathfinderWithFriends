using System;
using System.Collections.Generic;
using System.Text;

namespace PwF.Objects
{
    public class Equipment
    {
        public List<Weapon> Weapons;
        public List<Armour> Armours;
        public List<Gear> Gears;

        public Equipment() {

        }

        // The handlers of the Weapons
        // Adding a Weapon to the character
        public bool AddWeapon(string name, string[] type, double range, int attackBonus, 
            int[] critical, int[][] damage, int extraDamage, double weight, string special) {
            // check to see if Weapon already exists
            foreach (Weapon weapon in Weapons) {
                if (weapon.Name == name) {
                    // if Weapon exists return false
                    return false;
                }
            }
            // if it Weapon doesn't exists add Weapon and return true
            Weapons.Add(new Weapon(name, type, range, attackBonus, critical, damage, extraDamage, weight, special));
            return true;
        }

        // getting the Weapon information for the character
        public int WeaponAttack(string name) {
            // try to find Weapon
            foreach (Weapon weapon in Weapons) {
                if (weapon.Name == name) {
                    // if Weapon exists return damage from swing
                    return weapon.SwingWeapon();
                }
            }
            // if Weapons doesn't exist return 0;
            return 0;
        }

        // removing the Weapon from the character
        public bool RemoveWeapon(string name) {
            // check to see if Weapon exists
            foreach (Weapon weapon in Weapons) {
                if (weapon.Name == name) {
                    // if Weapon exists remove Weapon and return true
                    Weapons.Remove(weapon);
                    return true;
                }
            }
            // if it Weapon doesn't exists return false
            return false;
        }


        // The handlers of the Armours
        // Adding a Armour to the character
        public bool AddArmour(string name, int bonus, string type, int checkPenalty, int spellFailure, double weight, string properties) {
            // check to see if Armour already exists
            foreach (Armour armour in Armours) {
                if (armour.Name == name) {
                    // if Armour exists return false
                    return false;
                }
            }
            // if it Armour doesn't exists add Armour and return true
            Armours.Add(new Armour(name, bonus, type, checkPenalty, spellFailure, weight, properties));
            return true;
        }

        // get the bonus defence for the armour
        public int UseArmour(string name) {
            // try to find Armour
            foreach (Armour armour in Armours) {
                if (armour.Name == name) {
                    // if Armour exists return Bonus
                    return armour.Bonus;
                }
            }
            // if Armour doesn't exist return 0;
            return 0;
        }

        // removing the Armour from the character
        public bool RemoveArmour(string name) {
            // check to see if Armour exists
            foreach (Armour armour in Armours) {
                if (armour.Name == name) {
                    // if Armour exists remove Armour and return true
                    Armours.Remove(armour);
                    return true;
                }
            }
            // if it Armour doesn't exists return false
            return false;
        }


        // The handlers of the Gears
        // Adding a Gear to the character
        public bool AddGear(string name, int weight) {
            // check to see if Gear already exists
            foreach (Gear gear in Gears) {
                if (gear.Name == name) {
                    // if Gear exists return false
                    return false;
                }
            }
            // if it Gear doesn't exists add Gear and return true
            Gears.Add(new Gear(name, weight));
            return true;
        }

        // removing the Gear from the character
        public bool RemoveGear(string name) {
            // check to see if Gear exists
            foreach (Gear gear in Gears) {
                if (gear.Name == name) {
                    // if Gear exists remove Gear and return true
                    Gears.Remove(gear);
                    return true;
                }
            }
            // if it Gear doesn't exists return false
            return false;
        }
    }
}
