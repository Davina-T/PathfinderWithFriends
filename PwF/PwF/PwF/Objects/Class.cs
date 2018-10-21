using System;
using System.Collections.Generic;
using System.Text;

namespace PwF.Objects
{
    
    public class Class
    {
        public string Name { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Spell> Spells { get; set; }
        public List<Feat> Feats { get; set; }
        public List<Feat> SpecialAbilities { get; set; }

        public Class() {

        }
    }
}
