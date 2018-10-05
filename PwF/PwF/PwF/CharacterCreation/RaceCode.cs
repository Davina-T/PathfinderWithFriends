using Newtonsoft.Json;
using PwF.Cells;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace PwF.CharacterCreation
{
    public static class RaceCode {
        public static string[] getRaces() {

            //var assembly = typeof(RacePage).GetTypeInfo().Assembly;
            ////Stream stream = assembly.GetManifestResourceStream("Information.json");
            //Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.Your_File.json");

            //using (var reader = new System.IO.StreamReader(stream)) {

            //    var json = reader.ReadToEnd();
            //    var data = JsonConvert.DeserializeObject(json);
            //}

            //var assembly = IntrospectionExtensions.GetTypeInfo(typeof(LoadResourceText)).Assembly;
            //Stream stream = assembly.GetManifestResourceStream("WorkingWithFiles.PCLTextResource.txt");
            //string text = "";
            //using (var reader = new System.IO.StreamReader(stream)) {
            //    text = reader.ReadToEnd();
            //}

            string[] value = new string[] {
                "Dwarves", "Elves", "Gnomes", "Half-Elves", "Half-Orcs",
                "Halflings", "Humans", "Aasimars", "Catfolk", "Dhampirs",
                "Drow", "Fetchlings", "Goblins", "Hobgoblins", "Ifrits",
                "Kobolds", "Orcs", "Oreads", "Ratfolk", "Sylphs", "Tengus",
                "Tieflings", "Undines"};
            return value;
        }

        public static List<CustomCell> getRaceObjects() {
            List<CustomCell> CustomCells = new List<CustomCell>();
            string[] races = getRaces();

            foreach (string race in races) {
                CustomCells.Add(new CustomCell(race));
            }

            return CustomCells;
        }

    }
}
