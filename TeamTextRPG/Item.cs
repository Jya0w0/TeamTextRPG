using System;
namespace TeamTextRPG
{
	public class Item
	{
        public static Item[] items;

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

        public Item()
		{
		}
        static void GameDataSattingItem()
        {
            items = new Item[10];
            AddItem(new Item("무쇠갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", Item.ItemType.Body, 0, 5, 0));
            AddItem(new Item("낡은 검", "쉽게 볼 수 있는 낡은 검입니다.", Item.ItemType.Weapon, 2, 0, 0));
            AddItem(new Item("고양이 수염", "고양이 수염은 행운을 가져다 줍니다. 야옹!", Item.ItemType.Acc, 7, 7, 7));
        }

        public static int itemStatSumAtk() //item 
        {
            int sum = 0;
            for (int i = 0; i < Item.ItemCount; i++)
            {
                if (items[i].IsEquipped) sum += items[i].AtkOption;
            }
            return sum;
        }
        public static int itemStatSumDef()
        {
            int sum = 0;
            for (int i = 0; i < Item.ItemCount; i++)
            {
                if (items[i].IsEquipped) sum += items[i].DefOption;
            }
            return sum;
        }
        public static int itemStatSumHp()
        {
            int sum = 0;
            for (int i = 0; i < Item.ItemCount; i++)
            {
                if (items[i].IsEquipped) sum += items[i].HpOption;
            }
            return sum;
        }



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
                Console.WriteLine(Interface.PadRightForMixedText(Name, 9)); // 방어력, 공격력 옵션들 간격맞춤
            }
            else
                Console.WriteLine(Interface.PadRightForMixedText(Name, 12));
            Console.Write(" | ");

            if (AtkOption != 0) Console.Write($"공격력 {(AtkOption >= 0 ? "+" : "")}{AtkOption} "); // 삼항연산자
            if (DefOption != 0) Console.Write($"방어력 {(DefOption >= 0 ? "+" : "")}{DefOption} "); // 옵션이 0이 아니라면 옵션수치를 내보내라
            if (HpOption != 0) Console.Write($"체 력 {(HpOption >= 0 ? "+" : "")}{HpOption} "); // [조건 ? 참 : 거짓]

            Console.Write(" | ");
            Console.WriteLine(Description);
        }

        public static void ToggleEquipStatus(int index) //item
        {
            items[index].IsEquipped = !items[index].IsEquipped; // ! : 불형의 변수를 반대로 만들어주는 것
        }

        static void AddItem(Item item)
        {
            if (Item.ItemCount == 10) return; // 아이템이 꽉차면 아무일도 일어나지 않는다
            items[Item.ItemCount] = item; // 0개 -> items[0], 1개 -> items[1] ...
            Item.ItemCount++;
        }
    }
}

