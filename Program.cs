// See https://aka.ms/new-console-template for more information
using System.IO;
using System.Xml.Linq;
using MMBCA;
string chipXML = File.ReadAllText(@"C:\Users\Linkshot\Documents\MMBCA\Chip XML (Experimental).txt");
XElement xmltree = XElement.Parse(chipXML);
Dictionary<string,Chip> chipLibrary = new Dictionary<string,Chip>();
foreach (XElement element in xmltree.Elements("Chip"))
{
    string chipName = element.Element("Name")?.Value ?? "UNNAMED";
    int chipHP = Convert.ToInt16(element.Element("Health")?.Value ?? "PLEASE FILL HP");
    int chipTier = Convert.ToInt16(element.Element("Rarity")?.Value ?? "0");
    Elements chipElem = (Elements)Enum.Parse(typeof(Elements),element.Element("Element")?.Value ?? "None");
    int chipCost = Convert.ToInt16(element.Element("MBSize")?.Value ?? "PLEASE FILL MB");
    int chipSpeed = Convert.ToInt16(element.Element("Priority")?.Value ?? "WHERE SPEED");
    int chipDamage = Convert.ToInt16(element.Element("Damage")?.Value ?? "-1");
    int chipAccuracy = Convert.ToInt16(element.Element("Accuracy")?.Value ?? "-1");
    ValidChipDmg chipDmgType = (ValidChipDmg)Enum.Parse(typeof(ValidChipDmg), element.Element("ChipDmg")?.Value ?? "0");

    //XElement? chipDamageXML = element.Element("Damage");
    //int chipDamage = -1;
    //if (chipDamageXML != null)
    //{
    //    chipDamage = Convert.ToInt16(chipDamageXML.Value);
    //}

    Chip battlechip = new Chip(chipName);

    battlechip.Element = chipElem;
    battlechip.Damage = chipDamage;
    battlechip.ChipDmg = chipDmgType;
    battlechip.Health = chipHP;
    battlechip.Tier = chipTier;
    battlechip.Cost = chipCost;
    battlechip.Accuracy = chipAccuracy;
    battlechip.Speed = chipSpeed;
    chipLibrary.Add(chipName,battlechip);
    Console.WriteLine(battlechip.ToString());
}