using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PwF.Cells;
using PwF.Cells.PwF.Cells;
using Xamarin.Forms;

namespace PwF.CharacterCreation
{
    public static class ClassCode
    {
        public static string[] getClasses()
        {

            string[] value = new string[] {
                "Bard", "Rogue", "Warrior", "Wizard"};
            return value;
        }

        public static List<CustomCell> getClassObjects()
        {
            List<CustomCell> CustomCells = new List<CustomCell>();
            string[] classes = getClasses();

            foreach (string cClass in classes)
            {
                CustomCells.Add(new CustomCell(cClass));
            }

            return CustomCells;
        }

    }
}