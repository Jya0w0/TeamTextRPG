using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTextRPG
{
    internal class Design
    {
        // Console.SetWindowSize(200, 100);
        // Console.SetCursorPosition(10,10);
        // Console.CursorVisible = false;
        // 게임로고
        static void GameLogo()
        {
            ConsoleBackground();
            // 아스키 코드로 이루어진 타이틀 화면을 위한 인코딩 설정
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "= Sparta Dungeon =";

            Console.ForegroundColor = ConsoleColor.Cyan;
            LogoColor("                                                                               \r\n ####                  #          ######                                       \r\n##  #                 ##           ##  ##                                      \r\n###   ###   ##   ## # ###  ##      ##  ## ## ## # ##    ####  ###  ###  # ##   \r\n ###  ## # # ##  #### ##  # ##     ##  ## ## #  ## ##  ## #  ## # ## ## ## ##  \r\n  ### ## #  ###  ##   ##   ###     ##  ## ## #  ## ##  ## #  #### ## ## ## ##  \r\n#  ## ## # #  #  ##   ##  #  #     ##  ## ## #  ## ##   ###  ##   ## ## ## ##  \r\n####  ###  ##### ##    ## #####   ######   ###  ## ### ##     ###  ###  ## ### \r\n      ##                                               ####                    \r\n      ###                                              #  #                    \r\n                                                       ####                    ");
            Console.WriteLine();
            Console.WriteLine("          ===== 계속하려면 아무 키나 입력하십시오. =====          ");
            Console.ResetColor();
            Console.ReadKey();
            Console.Beep(); // 삡 소리 나게 하는 것
        }

        static void ConsoleBackground()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public static string LogoColor(string text)
        {
            // 배열에 원하는 색상을 순서대로 나열
            ConsoleColor[] colors = { ConsoleColor.Red, ConsoleColor.Yellow, ConsoleColor.Green, ConsoleColor.Blue, ConsoleColor.Magenta };

            Console.Clear();

            // 무한 루프로 색상을 변경
            while (true)
            {
                foreach (var color in colors)
                {
                    Console.ForegroundColor = color;
                    Console.WriteLine(text);
                    Thread.Sleep(1000); // 1초 대기
                    Console.Clear();
                }
            }
        }
    }
}
