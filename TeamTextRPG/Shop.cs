using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTextRPG
{
    public class Item
    {
        // 장비 타입
        //이름
        public enum ItemType
        {
            Weapon,
            Head,
            Body,
            Shoes,
            Acc
        }

        public string Name { get; }
        public string Description { get; }
        public ItemType Type { get; }
        public int AtkOption { get; }
        public int DefOption { get; }
        public int HpOption { get; }
        public bool IsEquipped { get; set; }

        public static int ItemCount = 0; // static을 붙임으로 Item이라는 클래스에 귀속된다

        public Item(string name, string description, ItemType type, int atkOption, int defOption, int hpOption, bool isEquipped = false)
        {
            Name = name;
            Description = description;
            Type = type;
            AtkOption = atkOption;
            DefOption = defOption;
            HpOption = hpOption;
            IsEquipped = isEquipped;
        }

        // 장비 착용 표시
        public void ItemStat(bool equippedItem = false, int index = 0) // 기본값이 false
        {
            Console.Write("- ");
            if (equippedItem)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("{0} ", index); // 몇 번째 아이템인가
                Console.ResetColor();
            }
            if (IsEquipped)
            {
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("E");
                Console.ResetColor();
                Console.Write("]");
                Console.WriteLine(PadRightForMixedText(Name, 9)); // 방어력, 공격력 옵션들 간격맞춤
            }
            else
                Console.WriteLine(PadRightForMixedText(Name, 12));
            Console.Write(" | ");

            if (AtkOption != 0) Console.Write($"공격력 {(AtkOption >= 0 ? "+" : "")}{AtkOption} "); // 삼항연산자
            if (DefOption != 0) Console.Write($"방어력 {(DefOption >= 0 ? "+" : "")}{DefOption} "); // 옵션이 0이 아니라면 옵션수치를 내보내라
            if (HpOption != 0) Console.Write($"체 력 {(HpOption >= 0 ? "+" : "")}{HpOption} "); // [조건 ? 참 : 거짓]

            Console.Write(" | ");

            Console.WriteLine(Description);
        }

        // 정렬
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
