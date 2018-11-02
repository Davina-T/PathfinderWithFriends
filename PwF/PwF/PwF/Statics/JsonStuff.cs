using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Xamarin.Forms.PlatformConfiguration;

namespace PwF.Statics
{
    public static class JsonStuff {

        public static void SerializeCharacters(List<Objects.Character> obj) {

            string characters = JsonConvert.SerializeObject(obj);

            EditFile("Characters.json", new string[] { characters });
        }

        public static List<Objects.Character> DeserializeCharacters() {
            string obj = GetFile("Characters.json");

            List<Objects.Character> characters = JsonConvert.DeserializeObject<List<Objects.Character>>(obj);

            if(characters == null) {
                characters = new List<Objects.Character>();
            }

            return characters;
        }

        public static string GetFile(string file) {
            // get file path
            string filepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Pwf\" + file);

            // Create file if it doesn't exists
            if (!File.Exists(filepath)) {
                return "";
            }

            // read lines and print to single varaible
            string[] files = File.ReadAllLines(filepath);
            string fileContent = "";

            for(int i = 0; i < files.Length; i++) {
                fileContent += files[i];
            }

            return fileContent;
        }

        public static void EditFile(string file, string[] content) {
            // get file path
            string filepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Pwf\" + file);

            // Create file if it doesn't exists
            if (!File.Exists(filepath)) {
                var MyFile = File.Create(filepath);
                MyFile.Close();
            }

            File.WriteAllLines(filepath, content);

        }

    }
}
