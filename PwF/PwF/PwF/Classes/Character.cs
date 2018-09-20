using PwF.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PwF.Classes
{
    public class Character
    {
        public Character(string name)
        {
            Name = name;
        }
        private string name;

        public string Name {
            get { return name; }
            private set { name = value; }
        }

        private string alignment;

        public string Alignment {
            get { return alignment; }
            set { alignment = value; }
        }

        private int level;

        public int CharacterLevel {
            get { return level; }
            set { level = value; }
        }

        private string deity;

        public string Deity {
            get { return deity; }
            set { deity = value; }
        }

        private string homeland;

        public string Homeland {
            get { return homeland; }
            set { homeland = value; }
        }

        private Races race;

        public Races Race {
            get { return race; }
            set { race = value; }
        }

        private string size;

        public string Size {
            get { return size; }
            set { size = value; }
        }

        private string gender;

        public string Gender {
            get { return gender; }
            set { gender = value; }
        }

        private int age;

        public int Age {
            get { return age; }
            set { age = value; }
        }

        private double height;

        public double Height {
            get { return height; }
            set { height = value; }
        }

        private double weight;

        public double Weight {
            get { return weight; }
            set { weight = value; }
        }

        private string hairType;

        public string HairType {
            get { return hairType; }
            set { hairType = value; }
        }

        private HairColour hairColour;

        public HairColour HairColour {
            get { return hairColour; }
            set { hairColour = value; }
        }

        private EyeColour eyeColour;

        public EyeColour EyeColour {
            get { return eyeColour; }
            set { eyeColour = value; }
        }



    }
}
