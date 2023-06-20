// See https://aka.ms/new-console-template for more information
using System.IO;
using System.Security.Cryptography;
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

Console.WriteLine();
colors.echo(12, "Initialized Chip Library.");
colors.echo(12, "Generating a Chip Folder...");
Console.WriteLine();

static IEnumerable<TValue> RandomValues<TKey, TValue>(IDictionary<TKey, TValue> chipLibrary)
    {
        Random rand = new Random();
        List<TValue> values = Enumerable.ToList(chipLibrary.Values);
        int size = chipLibrary.Count;
        while (true)
        {
            yield return values[rand.Next(size)];
        }
    }
List<string> chipFolder = new List<string>();
    foreach (object value in RandomValues(chipLibrary).Take(30))
    {
        Console.WriteLine(value);
    chipFolder.Add(value.ToString()!);
    }

Console.WriteLine();
colors.echo(12, "Folder generated. Please fill the Program Deck.");
Console.WriteLine();
var deckCol1 = new List<string>(capacity: 2) { "<EMPTY>", "<EMPTY>"};
var deckCol2 = new List<string>(capacity: 3) { "<EMPTY>", "<EMPTY>", "<EMPTY>"};
var deckCol3 = new List<string>(capacity: 4) { "<EMPTY>", "<EMPTY>", "<EMPTY>", "<EMPTY>"};

static void DisplayDeck(List<string>? deckCol1, List<string>? deckCol2, List<string>? deckCol3)
{
    Console.Write("".PadRight(22)); Console.Write($"[{deckCol3[0]}".PadRight(9)); Console.WriteLine("]");
    Console.Write("".PadRight(11)); Console.Write($"[{deckCol2[0]}".PadRight(9)); Console.WriteLine("]");
    Console.Write($"[{deckCol1[0]}".PadRight(9)); Console.Write("]".PadRight(13)); Console.Write($"[{deckCol3[1]}".PadRight(9)); Console.WriteLine("]");
    Console.Write("".PadRight(11)); Console.Write($"[{deckCol2[1]}".PadRight(9)); Console.WriteLine("]");
    Console.Write($"[{deckCol1[1]}".PadRight(9)); Console.Write("]".PadRight(13)); Console.Write($"[{deckCol3[2]}".PadRight(9)); Console.WriteLine("]");
    Console.Write("".PadRight(11)); Console.Write($"[{deckCol2[2]}".PadRight(9)); Console.WriteLine("]");
    Console.Write("".PadRight(22)); Console.Write($"[{deckCol3[3]}".PadRight(9)); Console.WriteLine("]");
}

DisplayDeck(deckCol1, deckCol2, deckCol3);
Console.WriteLine();
Console.ForegroundColor = ConsoleColor.Cyan;
Console.Write("Col 1, Slot 1: ");
deckCol1.Insert(0, chipFolder[Convert.ToInt32(Console.ReadLine())].Substring(0, 8));
Console.WriteLine($"{deckCol1[0]}");
Console.Write("Col 1, Slot 2: ");
deckCol1.Insert(1, chipFolder[Convert.ToInt32(Console.ReadLine())].Substring(0, 8));
Console.WriteLine($"{deckCol1[1]}");

Console.ForegroundColor = ConsoleColor.Yellow;
Console.Write("Col 2, Slot 1: ");
deckCol2.Insert(0, chipFolder[Convert.ToInt32(Console.ReadLine())].Substring(0, 8));
Console.WriteLine($"{deckCol2[0]}");
Console.Write("Col 2, Slot 2: ");
deckCol2.Insert(1, chipFolder[Convert.ToInt32(Console.ReadLine())].Substring(0, 8));
Console.WriteLine($"{deckCol2[1]}");
Console.Write("Col 2, Slot 3: ");
deckCol2.Insert(2, chipFolder[Convert.ToInt32(Console.ReadLine())].Substring(0, 8));
Console.WriteLine($"{deckCol2[2]}");

Console.ForegroundColor = ConsoleColor.Green;
Console.Write("Col 3, Slot 1: ");
deckCol3.Insert(0, chipFolder[Convert.ToInt32(Console.ReadLine())].Substring(0, 8));
Console.WriteLine($"{deckCol3[0]}");
Console.Write("Col 3, Slot 2: ");
deckCol3.Insert(1, chipFolder[Convert.ToInt32(Console.ReadLine())].Substring(0, 8));
Console.WriteLine($"{deckCol3[1]}");
Console.Write("Col 3, Slot 3: ");
deckCol3.Insert(2, chipFolder[Convert.ToInt32(Console.ReadLine())].Substring(0, 8));
Console.WriteLine($"{deckCol3[2]}");
Console.Write("Col 3, Slot 4: ");
deckCol3.Insert(3, chipFolder[Convert.ToInt32(Console.ReadLine())].Substring(0, 8));
Console.WriteLine($"{deckCol3[3]}");

Console.ResetColor();
Console.WriteLine();
DisplayDeck(deckCol1, deckCol2, deckCol3);