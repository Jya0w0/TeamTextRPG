using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTextRPG
{
    internal class Design
    {
        public void ConsoleBackground()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public void LogoFontColor()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Thread.Sleep(50);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Thread.Sleep(50);
            Console.ForegroundColor = ConsoleColor.Green;
            Thread.Sleep(50);
            Console.ForegroundColor = ConsoleColor.Blue;
            Thread.Sleep(50);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Thread.Sleep(50);
        }
    }
}
