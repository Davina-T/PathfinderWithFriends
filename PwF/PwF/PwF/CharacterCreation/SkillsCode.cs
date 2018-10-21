using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using PwF.Cells.PwF.Cells;

namespace PwF.CharacterCreation
{
    public static class SkillsCode
    {
        public static ArrayList GetSkills()
        {
            ArrayList value = new ArrayList() {
                "Acrobatics (DEX)", "Appraise (INT)", "Bluff (CHA)",
                "Climb (STR)"};

            if (Statics.CharacterCreating.CreatingCharacter.CharRace.Name == "Dwarves")
            {
                value.Remove("Acrobatics (DEX)");
            }

            return value;
        }
        /*
        public static List<CustomCell> GetSkillObjects()
        {
            List<CustomCell> CustomCells = new List<CustomCell>();
            string[] skills = GetSkills();

            foreach (string skill in skills)
            {
                CustomCells.Add(new CustomCell(skill));
            }

            return CustomCells;
        }
        */
    }
}
