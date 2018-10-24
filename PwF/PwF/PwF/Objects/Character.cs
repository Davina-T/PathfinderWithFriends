using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PwF.Objects
{
    public class Character
    {
        //[JsonProperty("player")]

        public string Player { get; set; }
        public string Name { get; set; }
        public Race CharRace { get; set; }
        public Class CharClass { get; set; }
        public int Level { get; set; }
        public CharacterDetails Details { get; set; }
        public AbilityScores Scores { get; set; }
        public List<Skill> Skills;
        public List<Feat> Feats;
        public List<SpecialAbility> SpecialAbilities;
        public List<string> Languages { get; set; }
        public List<string> Statuses { get; set; }
        //public string Languages { get; set; }
        public List<Spell> Spells;
        public Money Gold { get; set; }
        public Equipment Equipments { get; set; }
        public Health HealthBar { get; set; }


        public Character() {
            Scores = new AbilityScores();
        }

        // The handlers of the Skills
        // Adding a Skill to the character
        public bool AddSkill(string name, Enums.AbilityScoreName modifierType, string description, int value = 0) {
                // check to see if Skill already exists
                foreach (Skill skill in Skills) {
                    if (skill.Name == name) {
                        // if Skill exists return false
                        return false;
                    }
                }
                // if it Skill doesn't exists add Skill and return true
                Skills.Add(new Skill(name, modifierType, description, value));
                return true;
            }

        // getting the Skill information for the character
        public Skill GetSkill(string name) {
            // try to find Skill
            foreach (Skill skill in Skills) {
                if(skill.Name == name) {
                    // if Skill exists return Skill
                    return skill;
                }
            }
            // if it Skill doesn't exists return undefined Skill
            return new Skill("undefinded", Enums.AbilityScoreName.Strength, "undefined");
        }

        // removing the Skill from the character
        public bool RemoveSkill(string name) {
            // check to see if Skill exists
            foreach (Skill skill in Skills) {
                if (skill.Name == name) {
                    // if Skill exists remove Skill and return true
                    Skills.Remove(skill);
                    return true;
                }
            }
            // if it Skill doesn't exists return false
            return false;
        }

        // setting the value of a Skill for the character
        public bool SetSkillValue(string name, int value) {
            // check to see if Skill exists
            foreach (Skill skill in Skills) {
                if (skill.Name == name) {
                    // if Skill exists reasign value and return true
                    skill.Value = value;
                    return true;
                }
            }
            // if it Skill doesn't exists add Skill and return false
            return false;
        }


        // The handlers of the Feats
        // Adding a Feat to the character
        public bool AddFeat(string name, string effect, string prerequisite) {
            // check to see if Feat already exists
            foreach (Feat feat in Feats) {
                if (feat.Name == name) {
                    // if Feat exists return false
                    return false;
                }
            }
            // if it Feat doesn't exists add Feat and return true
            Feats.Add(new Feat(name, effect, prerequisite));
            return true;
        }

        // getting the Feat information for the character
        public Feat GetFeat(string name) {
            // try to find Feat
            foreach (Feat feat in Feats) {
                if (feat.Name == name) {
                    // if Feat exists return Feat
                    return feat;
                }
            }
            // if it Feat doesn't exists return undefined Feat
            return new Feat("undefinded", "undefined", "undefined");
        }

        // removing the Feat from the character
        public bool RemoveFeat(string name) {
            // check to see if Feat exists
            foreach (Feat feat in Feats) {
                if (feat.Name == name) {
                    // if Feat exists remove Feat and return true
                    Feats.Remove(feat);
                    return true;
                }
            }
            // if it Feat doesn't exists return false
            return false;
        }


        // The handlers of the Spells
        // Adding a Feat to the character
        public bool AddSpell(int level, string name, string castingTime, string range, string target, string duration, string reflexThow, string effect, int damage) {
            // check to see if Spell already exists
            foreach (Spell spell in Spells) {
                if (spell.Name == name) {
                    // if Spell exists return false
                    return false;
                }
            }
            // if it Spell doesn't exists add Spell and return true
            Spells.Add(new Spell(level, name, castingTime, range, target, duration, reflexThow, effect, damage));
            return true;
        }

        // getting the Spell information for the character
        public Spell GetSpell(string name) {
            // try to find Spell
            foreach (Spell spell in Spells) {
                if (spell.Name == name) {
                    // if Feat exists return Spell
                    return spell;
                }
            }
            // if it SPell doesn't exists return undefined Spell
            return new Spell(0, "undefinded", "undefined", "undefinded", "undefinded", "undefinded", "undefinded", "undefinded", 0);
        }

        // removing the Spell from the character
        public bool RemoveSpell(string name) {
            // check to see if Spell exists
            foreach (Spell spell in Spells) {
                if (spell.Name == name) {
                    // if Feat exists remove Spell and return true
                    Spells.Remove(spell);
                    return true;
                }
            }
            // if it Spell doesn't exists return false
            return false;
        }


        //// The handlers of Languages
        //// Add a Language to the character
        //public bool AddLanguage(string name)
        //{
        //    // check to see if Language already exists
        //    foreach (string language in Languages)
        //    {
        //        if (language == name)
        //        {
        //            // if Language exists return false
        //            return false;
        //        }
        //    }
        //    // if Language doesn't exists add Language and return true
        //    Languages.Add(name);
        //    return true;
        //}

        //// removing the Language from the character
        //public bool RemoveLanguage(string name)
        //{
        //    // check to see if Language exists
        //    foreach (string language in Languages)
        //    {
        //        if (language == name)
        //        {
        //            // if Language exists remove Language and return true
        //            Languages.Remove(language);
        //            return true;
        //        }
        //    }
        //    // if it Language doesn't exists return false
        //    return false;
        //}
    }
}

/*"Player":"", "Name":"", "Race":"", "Class":"", "Level":"", 
			"Details":{ "Alignment":{}, "Diety":"", "Homeland":"", "Size":"", "Gender":"", 
			"Age":"", "Height":"", "Weight":"", "Hair":"", "Eyes":"", "Backstory":""},
			"AbilityScores":[], "Skills":[], "Feats":[], "Languages":[], "Spells":[], 
			"Gold":{"CP":"", "SP":"", "GP":"", "PP":""},
			"Equipment":{"Weapons":[], "Armour":[], "Gear":[]},
			"TotoalHP":"", "CurrentHP":""*/