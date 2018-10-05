using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PwF.Enums;

namespace PwF.Classes{

    //Update Character Sheet:
    class UpdateCharacterSheet{

        public void CreateCharacter()
        {
            var character = new Character("Rctor")
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
