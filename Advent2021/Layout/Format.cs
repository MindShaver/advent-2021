using System;

namespace Advent2021
{
    public class Format
    {
        public void Header(string title, string subtitle = "", ConsoleColor foreGroundColor = ConsoleColor.White, int windowWidthSize = 90)
        {
            Console.Title = title + (subtitle != "" ? " - " + subtitle : "");
            string titleContent = CenterText(title, "║");
            string subtitleContent = CenterText(subtitle, "║");
            string borderLine = new String('═', windowWidthSize - 2);

            Console.ForegroundColor = foreGroundColor;
            Console.WriteLine($"╔{borderLine}╗");
            Console.WriteLine(titleContent);
            if (!string.IsNullOrEmpty(subtitle))
            {
                Console.WriteLine(subtitleContent);
            }
            Console.WriteLine($"╚{borderLine}╝");
            Console.ResetColor();
        }

        public string CenterText(string content, string decorationString = "", int windowWidthSize = 90)
        {
            int windowWidth = windowWidthSize - (2 * decorationString.Length);
            return String.Format(decorationString + "{0," + ((windowWidth / 2) + (content.Length / 2)) + "}{1," + (windowWidth - (windowWidth / 2) - (content.Length / 2) + decorationString.Length) + "}", content, decorationString);
        }

        public void CreateTable()
        {
            // The first number is the index and the second is alignment
            Console.WriteLine("{0,10}{1,10}{2,10}{3,10}{4,10}",
              1,
              2,
             3,
              111,
              22);
        }

        public void PrintLinesInCenter(params string[] lines)
        {
            int verticalStart = (Console.WindowHeight - lines.Length) / 2; // work out where to start printing the lines
            int verticalPosition = verticalStart;
            foreach (var line in lines)
            {
                // work out where to start printing the line text horizontally
                int horizontalStart = (Console.WindowWidth - line.Length) / 2;
                // set the start position for this line of text
                Console.SetCursorPosition(horizontalStart, verticalPosition);
                // write the text
                Console.WriteLine(line);
                // move to the next line
                ++verticalPosition;
            }
        }
    }
}
