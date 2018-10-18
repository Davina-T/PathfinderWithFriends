using PwF.Cells.PwF.Cells;
using PwF.Statics;
using System;
using System.Collections.Generic;
using System.Text;

namespace PwF.CharacterCreation
{
    public static class LanguagesCode
    {
        public static string[] getLanguages()
        {

            //if ((race == dwarf) && (returnModifier(intelligenceScore) >= 20))
            //{
            //    string[] value = new string[] {
            //        "Elemental", "Giant", "Gnome", "Goblin", "Orc", "Undercommon"
            //    };
            //    return value;
            //}
            //else if ((race == elf) && (returnModifier(intelligenceScore) >= 20))
            //{
            //    string[] value = new string[] {
            //        "Draconic", "Gnoll", "Gnome", "Goblin", "Orc", "Sylvan"
            //    };
            //    return value;
            //}
            //else if ((race == gnome) && (returnModifier(intelligenceScore) >= 20))
            //{
            //    string[] value = new string[] {
            //        "Draconic", "Dwarven", "Elven", "Giant", "Goblin", "Orc"
            //    };
            //    return value;
            //}
            //else if ((race == half-elf) && (returnModifier(intelligenceScore) >= 20))
            //{
            //    string[] value = new string[] {
            //        "Abyssal", "Aklo", "Aquan", "Auran", "Celestial",
            //        "Draconic", "Dwarven",
            //        "Giant", "Gnome", "Goblin", "Gnoll", "Halfling",
            //        "Ignan", "Infernal", "Orc", "Sylvan", "Terran", "Undercommon"
            //    };
            //    return value;
            //}
            //else if ((race == half-orc) && (returnModifier(intelligenceScore) >= 20))
            //{
            //    string[] value = new string[] {
            //        "Draconic", "Giant", "Gnoll", "Goblin", "Abyssal"
            //    };
            //    return value;
            //}
            //else if ((race == halfling) && (returnModifier(intelligenceScore) >= 20))
            //{
            //    string[] value = new string[] {
            //        "Abyssal", "Dwarven", "Elven", "Gnome", "Goblin"
            //    };
            //    return value;
            //}
            //else if ((race == human) && (returnModifier(intelligenceScore) >= 20))
            //{
            //    string[] value = new string[] {
            //        "Abyssal", "Aklo", "Aquan", "Auran", "Celestial",
            //        "Draconic", "Dwarven",
            //        "Giant", "Gnome", "Goblin", "Gnoll", "Halfling",
            //        "Ignan", "Infernal", "Orc", "Sylvan", "Terran", "Undercommon"
            //    };
            //    return value;
            //}

            string[] value = new string[] {
                "Abyssal", "Aklo", "Aquan", "Auran", "Celestial",
                "Common", "Draconic", "Druidic", "Dwarven", "Elven",
                "Giant", "Gnome", "Goblin", "Gnoll", "Halfling",
                "Ignan", "Infernal", "Orc", "Sylvan", "Terran", "Undercommon"};
            return value;
        }

        public static List<CustomCell> getLanguageObjects()
        {
            List<CustomCell> CustomCells = new List<CustomCell>();
            string[] languages = getLanguages();

            foreach (string language in languages)
            {
                CustomCells.Add(new CustomCell(language));
            }

            return CustomCells;
        }
    }
}
