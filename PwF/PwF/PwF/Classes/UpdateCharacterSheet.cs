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

            //Character Creattion
            var character = new Character("Rctor")
            {

                //List all the character information:
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
                charClass = classes.ArchaneArcher,
                MoneyCP = 4,
                MoneySP = 12,
                MoneyGP = 9652,
                MoneyPP = 103,
                Health = 110,
                Strength = 32,
                Dexterity = 48,
                Constitution = 29,
                Intelligence = 50,
                Wisdom = 55,
                Charisma = 21,
                StatusEffects = "Sick", //?
                Languages = "Common", //?
            };
        }

    }
}
