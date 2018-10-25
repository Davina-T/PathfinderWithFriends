﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PwF.Objects
{
    public class Feat
    {
        public string Name { get; set; }
        public string Effect { get; set; }
        public string Prerequistite { get; set; }

        public Feat(string name, string effect, string prerequistite) {
            Name = name;
            Effect = effect;
            Prerequistite = prerequistite;
        }
    }
}
