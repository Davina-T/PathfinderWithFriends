using System;
using System.Collections.Generic;
using System.Text;

namespace PwF.Statics
{
    public static class CharacterCreating
    {

        public static Objects.Character CreatingCharacter = new Objects.Character();

        public static List<int> ScoreRolls = new List<int>() { 0, 0, 0, 0, 0, 0 };
        public static List<int> ScoreRollsUsed = new List<int> { -1, -1, -1, -1, -1, -1 };
    }
}
