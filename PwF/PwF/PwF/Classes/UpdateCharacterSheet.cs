using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PwF.Enums;

namespace PwF.Classes{

    //Update Character Sheet:
    public class UpdateCharacterSheet{

        public Character character;

        public void CreateCharacter(int index)
        {
            character = new Character("Rictor")
            {
                Alignment = Alignment.ChaoticGood,
                CharacterLevel = 38,
                Deity = "None",
                Homeland = "Earth",
                Size = "medium",
                Gender = "Male",
                Age = 24,
                Height = 175.36,
                Weight = 96.2,
                HairType = "Curly",
                HairColour = HairColour.black,
                EyeColour = EyeColour.green,

            };
        }

    }
}
