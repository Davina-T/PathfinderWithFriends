using System;
using System.Collections.Generic;
using System.Text;

namespace PwF.Objects
{
    public class Health
    {
        public int TotalHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int TempHealth { get; set; }

        public Health(int totalHealth) {
            TotalHealth = totalHealth;
            CurrentHealth = totalHealth;
        }

        // method to add health to healthbar
        public void AddHealth(int amount) {
            CurrentHealth += amount;
            if(CurrentHealth > TotalHealth) {
                CurrentHealth = TotalHealth;
            }
        }

        // method to remove health from healthbar and returns true when health reaches 0 and false if health above 0
        public bool RemoveHealth(int amount) {
            CurrentHealth += amount;
            if (CurrentHealth <= 0) {
                CurrentHealth = 0;
                return true;
            }
            return false;
        }
    }
}
