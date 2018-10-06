using System;
using System.Collections.Generic;
using System.Text;

namespace PwF.Objects
{
   
    public class AbilityScore
    {
        public Enums.AbilityScoreName Name { get; }
        public int Value { get; set; }

        public AbilityScore(Enums.AbilityScoreName name) {
            Name = name;
        }
    }
}
