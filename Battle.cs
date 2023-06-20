using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMBCA
{
    internal class Battle
    {
        Random rngSeed = new Random();
        int p1HP = 0;
        int p2HP = 0;
        static void BattleInit(string p1Name, string p2Name, int p1MaxHP, int p2MaxHP)
        {
            int p1HP = p1MaxHP;
            int p2HP = p2MaxHP;
        }
        static bool ElemWeakness(string atkElem, string defElem)
        {
            switch (atkElem, defElem)
            {
                case ("Fire", "Wood"): return true;
                case ("Aqua", "Fire"): return true;
                case ("Elec", "Aqua"): return true;
                case ("Wood", "Elec"): return true;
                case ("Sol", "Dark"): return true;
                case ("Dark", "Sol"): return true;
                default: return false;
            }
        }
        static bool PanelWeakness(string atkElem, string floorType)
        {
            switch (atkElem, floorType)
            {
                case ("Fire", "Grass"): return true;
                case ("Elec", "Metal"): return true;
                case ("Elec", "Ice"): return true;
                default: return false;
            }
        }
        static string PanelChange(string atkElem, string floorType)
        {
            switch (atkElem, floorType)
            {
                case ("Fire", "Grass"): DialogueBox("The grass burnt away."); return "Basic";
                case ("Aqua", "Lava"): DialogueBox("The lava cooled off."); return "Basic";
                case ("Wood", "Metal"): DialogueBox("Plants overtake the metal."); return "Grass";
                default: return floorType;
            }
        }
        void DamageCalc(int rawDmg, string chipElem, string userElem, string targElem, string panelElem, string chipDmg, int bonusDmg, int multiHits, bool meteor, bool dice)
        {
            int totalDmg = 0;
            double dmgMult = 1.0;
            bool declareHits = false;
            if (multiHits > 1) { declareHits = true; }
            totalDmg = rawDmg + bonusDmg;
            if (chipElem == userElem) { dmgMult = dmgMult + 0.6; }
            if (ElemWeakness(chipElem, targElem)) { dmgMult = dmgMult + 0.6; }
            if (PanelWeakness(chipElem, panelElem)) { dmgMult = dmgMult + 0.6; }
            totalDmg = (int)Math.Ceiling(totalDmg * dmgMult / 10) * 10;
            if (dice) { multiHits = rngSeed.Next(1, multiHits+1); }
            if (meteor) {
                int totalHits = 0;
                for (int i = 0; i < multiHits; i++)
                {
                    if (rngSeed.Next(0,4) < 3) { totalHits++; }
                }
                multiHits = totalHits;
            }
            if (multiHits != 0)
            {
                for (int i = 0; i < multiHits; i++)
                {
                    if (chipDmg != "Normal") { ApplyChipDmg(totalDmg, chipDmg); }
                    ApplyNaviDmg(totalDmg);
                }
                if (declareHits) { DialogueBox("Hit " + multiHits + " times!"); }
                DialogueBox("Dealt " + (totalDmg * multiHits) + " damage!");
            }
            else DialogueBox("No attacks hit!");
        }
    }
}
