namespace MMBCA
{
    internal class colors
    {
        /// <summary>
        /// Instantiates colors inside of a WriteLine block, using standard Control Code format
        /// (0 = White, 1 = Black, ... 15 = Gray)
        /// </summary>
        /// <param name="colorId"></param>
        /// <param name="text"></param>
        public static void echo(int f = 15, string text = "", int b = 1)
        {
            ConsoleColor colorName;
            int colorCount = 1;
            int colorId = 0;
            while (colorCount <= 2)
            {
                if (colorCount == 1) colorId = f;
                else colorId = b;
                switch (colorId)
                {
                    case 0: colorName = ConsoleColor.White; break;
                    case 1: colorName = ConsoleColor.Black; break;
                    case 2: colorName = ConsoleColor.DarkBlue; break;
                    case 3: colorName = ConsoleColor.DarkGreen; break;
                    case 4: colorName = ConsoleColor.Red; break;
                    case 5: colorName = ConsoleColor.DarkRed; break;
                    case 6: colorName = ConsoleColor.DarkMagenta; break;
                    case 7: colorName = ConsoleColor.DarkYellow; break;
                    case 8: colorName = ConsoleColor.Yellow; break;
                    case 9: colorName = ConsoleColor.Green; break;
                    case 10: colorName = ConsoleColor.DarkCyan; break;
                    case 11: colorName = ConsoleColor.Cyan; break;
                    case 12: colorName = ConsoleColor.Blue; break;
                    case 13: colorName = ConsoleColor.Magenta; break;
                    case 14: colorName = ConsoleColor.DarkGray; break;
                    case 15: colorName = ConsoleColor.Gray; break;
                    default: if (colorCount == 2) colorName = ConsoleColor.Black; else colorName = ConsoleColor.Gray; break;
                }
                if (colorCount == 2) Console.BackgroundColor = colorName;
                else Console.ForegroundColor = colorName;
                colorCount++;
            }
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
