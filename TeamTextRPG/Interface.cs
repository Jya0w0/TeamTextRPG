using System;
using System.Numerics;
using Microsoft.VisualBasic.FileIO;
using System.Xml.Linq;

namespace TeamTextRPG
{
	public class Interface
	{
		public Interface()
		{

		}

        public static int CheckValidInput(int min, int max)
        {
            while (true)
            {
                string input = Console.ReadLine();

                bool parseSuccess = int.TryParse(input, out var ret);
                if (parseSuccess)
                {
                    if (ret >= min && ret <= max)
                        return ret;
                }
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("잘못된 입력입니다.");
                Console.ResetColor();
            }
        }

        public static void OutputTxt(string txt) // string = Char(문자) 배열
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            // 아무 키나 눌렀을 때 스킵
            int speed = 50;
            int txtCount = 0; // 글자수
            while (txtCount != txt.Length) // txt 글자수가 끝까지 나올 때까지
            {
                if (Console.KeyAvailable) // 아무 키나 눌렸을 때 true
                {
                    speed = 0; // 아무 키나 눌렀을 때 빠르게 즉, 전체 문장이 나오도록 skip하는 기능
                    Console.ReadKey(true);
                }
                Console.Write(txt[txtCount]); // 글자를 하나하나 가져올 인덱스
                Thread.Sleep(speed); // 속도 지정 메서드
                txtCount++;
            }
        }

        // 설명글씨색
        public static void LineTextColor(string line)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(line);
            Console.ResetColor();
        }

        // 선택지글씨색
        public static void ChooseTextColor(string line)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(line);
            Console.ResetColor();
        }

        // 스텟글씨색
        public static void StatTextColor(string s1, string s2, string s3 = "")
        {
            Console.Write(s1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s2);
            Console.ResetColor();
            Console.WriteLine(s3);
        }


            // 0 = 무기 1 = 대가리 2 = 갑옷 3 = 신발
            // 아이템 정보 세팅

        

        //item

        public static int GetPrintableLength(string str)
        {
            int length = 0;
            foreach (char c in str)
            {
                if (char.GetUnicodeCategory(c) == System.Globalization.UnicodeCategory.OtherLetter)
                {
                    length += 2; // 한글과 같은 넓은 문자에 대해 길이를 2로 취급
                }
                else
                {
                    length += 1; // 나머지 문자에 대해 길이를 1로 취급
                }
            }

            return length;
        }

        public static string PadRightForMixedText(string str, int totalLength)
        {
            int currentLength = GetPrintableLength(str); // 텍스트의 길이를 구한다
            int padding = totalLength - currentLength; // 원하는 크기과 실제 텍스트의 길이를 계산한다
            return str.PadRight(str.Length + padding); // 필요한 길이만큼의 공간을 더해준다
        }
    }
}

