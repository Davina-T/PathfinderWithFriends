using System;
using System.Collections.Generic;
using System.Text;

namespace PwF.Objects
{
    public class Gear
    {
        public string Name { get; set; }
        public double Weight { get; set; }

        public Gear(string name, double weight) {
            Name = name;
            Weight = weight;
        }
    }
}
