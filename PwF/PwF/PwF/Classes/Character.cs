using Pwf.ViewModels;
using PwF.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PwF.Classes
{
    //Barebones Charactersheet:
    public class Character : ViewModelBase
    {
        //Set the character's name:
        public Character(string name)
        {
            Name = name;
        }

        //Character's name:
        private string name;

        //Handle character's name:
        public string Name {

            //Get the character's name:
            get { return name; }
            //Set the character's name: (Unchangable)
            private set { name = value;
                OnPropertyChanged();
            }

        }

        //Character's alignment:
        private Enum alignment;

        //Handle character's alignment:
        public Enum Alignment {

            //Get the character's alignment:
            get { return alignment; }
            //Set the character's alignment:
            set { alignment = value;
                OnPropertyChanged();
            }

        }

        //Character's level:
        private int level;

        //Handle character's level:
        public int CharacterLevel {

            //Get the character's level:
            get { return level; }
            //Set the character's level:
            set { level = value;
                OnPropertyChanged();
            }

        }

        //Character's deity:
        private string deity;

        //Handle character's deity:
        public string Deity {

            //Get the character's deity:
            get { return deity; }
            //Set the character's deity:
            set { deity = value;
                OnPropertyChanged();
            }

        }

        //Character's homeland:
        private string homeland;

        //Handle character's homeland:
        public string Homeland {

            //Get the character's homeland:
            get { return homeland; }
            //Set the character's homeland:
            set { homeland = value;
                OnPropertyChanged();
            }

        }

        //Character's race:
        private Races race;

        //Handle character's race:
        public Races Race {

            //Get the character's race:
            get { return race; }
            //Set the character's race:
            set { race = value;
                OnPropertyChanged();
            }
        }

        //Character's size:
        private string size;

        //Handle character's size:
        public string Size {

            //Get the character's size:
            get { return size; }
            //Set the character's size:
            set { size = value;
                OnPropertyChanged();
            }

        }

        //Character's gender:
        private string gender;

        //Handle character's gender:
        public string Gender {

            //Get the character's gender:
            get { return gender; }
            //Get the character's gender:
            set { gender = value;
                OnPropertyChanged();
            }

        }

        //Character's age:
        private int age;

        //Handle character's age:
        public int Age {

            //Get the character's age:
            get { return age; }
            //Set the character's age:
            set { age = value;
                OnPropertyChanged();
            }

        }

        //Character's height:
        private double height;

        //Handle character's height:
        public double Height {

            //Get the character's height:
            get { return height; }
            //Set the character's height:
            set { height = value;
                OnPropertyChanged();
            }

        }

        //Character's weight:
        private double weight;

        //Handle character's weight:
        public double Weight {

            //Get the character's weight:
            get { return weight; }
            //Set the character's weight:
            set { weight = value;
                OnPropertyChanged();
            }

        }

        //Character's hairType:
        private string hairType;

        //Handle character's hairType:
        public string HairType {

            //Get the character's hairType:
            get { return hairType; }
            //Set the character's hairType:
            set { hairType = value;
                OnPropertyChanged();
            }

        }

        //Character's hairColour:
        private HairColour hairColour;

        //Handle character's hairColour:
        public HairColour HairColour {

            //Get the character's hairColour:
            get { return hairColour; }
            //Set the character's hairColour:
            set { hairColour = value;
                OnPropertyChanged();
            }

        }

        //Character's eyeColour:
        private EyeColour eyeColour;

        //Handle character's eyeColour:
        public EyeColour EyeColour {

            //Get the character's eyeColour:
            get { return eyeColour; }
            //Get the character's eyeColour:
            set { eyeColour = value;
                OnPropertyChanged();
            }

        }

        //Character's Class:
        private classes Class;

        //Handle character's Class:
        public classes charClass {

            //Get the character's Class:
            get { return Class; }
            //Set the character's Class:
            set { Class = value;
                OnPropertyChanged();
            }

        }

        //Character's cp:
        private int cp;

        //Handle character's cp:
        public int MoneyCP {

            //Get the character's cp:
            get { return cp; }
            //Set the character's cp:
            set { cp = value;
                OnPropertyChanged();
            }

        }

        //Character's sp:
        private int sp;

        //Handle character's sp:
        public int MoneySP {

            //Get the character's sp:
            get { return sp; }
            //Set the character's sp:
            set { sp = value;
                OnPropertyChanged();
            }

        }

        //Character's gp:
        private int gp;

        //Handle character's gp:
        public int MoneyGP {

            //Get the character's gp:
            get { return gp; }
            //Set the character's gp:
            set { gp = value;
                OnPropertyChanged();
            }

        }

        //Character's pp:
        private int pp;

        //Handle character's pp:
        public int MoneyPP {

            //Get the character's pp:
            get { return pp; }
            //Set the character's pp:
            set { pp = value;
                OnPropertyChanged();
            }

        }

        //Character's health:
        private int health;

        //Handle character's health:
        public int Health {

            //Get the character's health:
            get { return health; }
            //Set the character's health:
            set { health = value;
                OnPropertyChanged();
            }

        }

        //Character's strength:
        private int strength;

        //Handle character's strength:
        public int Strength {

            //Get the character's strength:
            get { return strength; }
            //Set the character's strength:
            set { strength = value;
                OnPropertyChanged();
            }

        }

        //Character's dexterity:
        private int dexterity;

        //Handle character's dexterity:
        public int Dexterity {

            //Get the character's dexterity:
            get { return dexterity; }
            //Set the character's dexterity:
            set { dexterity = value;
                OnPropertyChanged();
            }

        }

        //Character's constitution:
        private int constitution;

        //Handle character's constitution:
        public int Constitution {

            //Get the character's constitution:
            get { return constitution; }
            //Set the character's constitution:
            set { constitution = value;
                OnPropertyChanged();
            }

        }

        //Character's intelligence:
        private int intelligence;

        //Handle character's intelligence:
        public int Intelligence {

            //Get the character's intelligence:
            get { return intelligence; }
            //Set the character's intelligence:
            set { intelligence = value;
                OnPropertyChanged();
            }

        }

        //Character's wisdom:
        private int wisdom;

        //Handle character's wisdom:
        public int Wisdom {

            //Get the character's wisdom:
            get { return wisdom; }
            //Set the character's wisdom:
            set { wisdom = value;
                OnPropertyChanged();
            }

        }

        //Character's charisma:
        private int charisma;

        //Handle character's charisma:
        public int Charisma {

            //Get the character's charisma:
            get { return charisma; }
            //Set the character's charisma:
            set { charisma = value;
                OnPropertyChanged();
            }

        }

        //Character's statusEffects:
        private List<string> statusEffects = new List<string>();

        //Handle character's statusEffects:
        public List<string> StatusEffects {

            //Get the character's statusEffects:
            get => statusEffects;
            //Set the character's statusEffects:
            set => statusEffects = value; //?

        }

        //Character's languages:
        private List<string> languages = new List<string>();

        //Handle character's languages:
        public List<string> Languages {

            //Get the character's languages:
            get => languages;
            //Set the character's languages:
            set => languages = value; //?

        }

    }
}
