using System;
using System.Collections.Generic;
using System.Text;

namespace PwF.Objects
{
    class Dice {

        public int Faces { get; set; }
        Random rnd;

        public Dice(int faces) {
            Faces = faces;
            rnd = new Random();
        }

        public int Roll() {
            return rnd.Next(1, Faces+1);
        }
    }
}
