using System;
using System.Collections.Generic;
using System.Text;

namespace PwF.Objects
{
    public class CharacterDetails
    {
        public Enums.Alignment Alignment { get; set; }
        public string Diety { get; set; }
        public string Homeland { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public string Hair { get; set; }
        public string Eyes { get; set; }
        public string Backstory { get; set; }


        public CharacterDetails() {
                
        }
    }
}
