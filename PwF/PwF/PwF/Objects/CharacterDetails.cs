﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PwF.Objects
{
    public class CharacterDetails
    {
        public Enums.Alignment Alignment { get; set; }
        public string Diety { get; set; }
        public string Homeland { get; set; }
        public Enums.Size Size { get; set; }
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

/*"Player":"", "Name":"", "Race":"", "Class":"", "Level":"", 
			"Details":{ "Alignment":{}, "Diety":"", "Homeland":"", "Size":"", "Gender":"", 
			"Age":"", "Height":"", "Weight":"", "Hair":"", "Eyes":"", "Backstory":""},
			"AbilityScores":[], "Skills":[], "Feats":[], "Languages":[], "Spells":[], 
			"Gold":{"CP":"", "SP":"", "GP":"", "PP":""},
			"Equipment":{"Weapons":[], "Armour":[], "Gear":[]},
			"TotoalHP":"", "CurrentHP":""*/
