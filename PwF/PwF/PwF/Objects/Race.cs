using System;
using System.Collections.Generic;
using System.Text;

namespace PwF.Objects
{

    public class Race
    {
        public string Name { get; set; }
        public List<string> Languages { get; set; }
        public List<string> StartingLanguages { get; set; }
        public List<Feat> Feats { get; set; }
        public List<SpecialAbility> SpecialAbilities { get; set; }
        public Enums.Size Size { get; set; }

        public Race() {

        }
    }
}
