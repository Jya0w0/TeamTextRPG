using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTextRPG
{
    internal class Design
    {
        // Console.SetWindowSize(200, 100); 윈도우 콘솔창 크기 고정
        // Console.SetCursorPosition(10,10); 커서 위치
        // Console.CursorVisible = false; 커서 없애기

        public static void ConsoleBackground()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Green;
        }

        //public static string LogoColor(string text)
        //{
        //    int margin = 10; // 텍스트가 출력될 위치의 왼쪽 여백
        //    int logoLength = 10; // 텍스트 길이
        //    // 배열에 원하는 색상을 순서대로 나열
        //    ConsoleColor[] colors = { ConsoleColor.Red, ConsoleColor.Yellow, ConsoleColor.Green, ConsoleColor.Blue, ConsoleColor.Magenta };

        //    // 무한 루프로 색상을 변경
        //    while (true)
        //    {
        //        foreach (var color in colors)
        //        {
        //            Console.ForegroundColor = color;
        //            Console.WriteLine(text);
        //            Thread.Sleep(1000); // 1초 대기
        //            if (Console.KeyAvailable)
        //            {
        //                break;
        //            }
        //        }
        //    }
        //}

        private static int margin = 10; // 텍스트가 출력될 위치의 왼쪽 여백
        private static int logoLength = 10; // 텍스트 길이
        public static void LogoColor()
        {
            // 배열에 원하는 색상을 순서대로 나열
            ConsoleColor[] colors = { ConsoleColor.Red, ConsoleColor.Yellow, ConsoleColor.Green, ConsoleColor.Blue, ConsoleColor.Magenta };

            // 무한 루프로 색상을 변경
            while (true)
            {
                foreach (var color in colors)
                {
                    DrawTitle(color);
                    //Console.WriteLine(text);
                    Thread.Sleep(1000); // 1초 대기
                    if (Console.KeyAvailable)
                    {
                        return;
                    }
                }
            }
        }
        public static void DrawTitle(ConsoleColor logoColor)
        {
            // 로고 위치 글씨 지우기
            Console.SetCursorPosition(margin, 2);
            Console.WriteLine("".PadLeft(logoLength, ' '));
            Console.SetCursorPosition(margin, 3);
            Console.WriteLine("".PadLeft(logoLength, ' '));
            Console.SetCursorPosition(margin, 4);
            Console.WriteLine("".PadLeft(logoLength, ' '));

            // 로고 생성
            Console.ForegroundColor = logoColor;
            Console.SetCursorPosition(margin, 2);
            Console.WriteLine("                                                                               \r");
            Console.SetCursorPosition(margin, 3);
            Console.WriteLine(" ####                  #          ######                                       \r");
            Console.SetCursorPosition(margin, 4);
            Console.WriteLine("##  #                 ##           ##  ##                                      \r");
            Console.SetCursorPosition(margin, 5);
            Console.WriteLine("###   ###   ##   ## # ###  ##      ##  ## ## ## # ##    ####  ###  ###  # ##   \r");
            Console.SetCursorPosition(margin, 6);
            Console.WriteLine(" ###  ## # # ##  #### ##  # ##     ##  ## ## #  ## ##  ## #  ## # ## ## ## ##  \r");
            Console.SetCursorPosition(margin, 7);
            Console.WriteLine("  ### ## #  ###  ##   ##   ###     ##  ## ## #  ## ##  ## #  #### ## ## ## ##  \r");
            Console.SetCursorPosition(margin, 8);
            Console.WriteLine("#  ## ## # #  #  ##   ##  #  #     ##  ## ## #  ## ##   ###  ##   ## ## ## ##  \r");
            Console.SetCursorPosition(margin, 9);
            Console.WriteLine("####  ###  ##### ##    ## #####   ######   ###  ## ### ##     ###  ###  ## ### \r");
            Console.SetCursorPosition(margin, 10);
            Console.WriteLine("      ##                                               ####                    \r");
            Console.SetCursorPosition(margin, 11);
            Console.WriteLine("      ###                                              #  #                    \r");
            Console.SetCursorPosition(margin, 12);
            Console.WriteLine("                                                       ####                    ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                    ==============================================                    ");
            Console.WriteLine("                    ===== 계속하려면 아무 키나 입력하십시오. =====                    ");
            Console.WriteLine("                    ==============================================                    ");
        }
    }
}
