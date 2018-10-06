using System;
using System.Collections.Generic;
using System.Text;

namespace PwF.Statics
{
    public static class CharacterCreating
    {

        public static Objects.Character CreatingCharacter = new Objects.Character();

        public static void giveName(string name) {
            CreatingCharacter.Name = name;
        }
    }
}
