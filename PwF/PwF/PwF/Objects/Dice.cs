using System;
using System.Collections.Generic;
using System.Text;

namespace PwF.Objects
{
    class Dice {

        public int Faces { get; set; }

        public Dice(int faces) {
            Faces = faces;
        }

        public int Roll() {
            Random rnd = new Random();
            return rnd.Next(1, Faces+1);
        }
    }
}
