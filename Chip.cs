using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMBCA
{
    public class Chip
    {
        public string Name;
        public Elements Element;
        public int Damage = -1;
        public ValidChipDmg ChipDmg = 0;
        public int Health;
        public int Cost;
        public int Accuracy = -1;
        public int Speed;
        public int Tier;

        public Chip(string name)
        {
            Name = name;
        }
        public static string Grade(int power)
        {
            switch (power)
            {
                case 1: return "E";
                case 2: return "D";
                case 3: return "C";
                case 4: return "B";
                case 5: return "A";
                case 6: return "S";
                default: return "?";
            }
        }
        public string DmgType()
        {
            switch (ChipDmg)
            {
                case ValidChipDmg.Last: return "Add";
                case ValidChipDmg.Rand: return "Rand";
                case ValidChipDmg.All: return "AllAdd";
                case ValidChipDmg.Delete: return "Delete";
                case ValidChipDmg.Smash: return "Smash";
                case ValidChipDmg.Disarm: return "Disarm";
                default: return "Normal";
            }
        }
        public override string ToString()
        {
            string output = Name.PadRight(8);
            output += $" [{Element}]".PadRight(8);
            output += "(";
            if (Damage != -1) output += $"{DmgType()}{Damage}, ";
            output += $"{Health} HP, ".PadLeft(8);
            output += $"{Cost} MB, ".PadLeft(7);
            if (Accuracy != -1) output += $"Acc {Grade(Accuracy)}, ";
            output += $"Spd {Grade(Speed)}, ";
            output += $"Tier {Tier}";
            output += ")";

            return output;
        }
    }
}
