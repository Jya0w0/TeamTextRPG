using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace TeamTextRPG
{

    public class Character
    {
        public static Character player;

        public string Name { get; }
        public string Job { get; }
        public int Level { get; }
        public int Atk { get; }
        public int Def { get; }
<<<<<<< Updated upstream
        public int Hp { get; }
        public int Gold { get; }
=======
        public int Hp { get; set; }
        public int Gold { get; set; }
        public int Floor { get; set; }
        public bool ItemEquipWeapon { get; set; }
        public bool ItemEquipTop { get; set; }
        public bool ItemEquipPants { get; set; }
        public bool ItemEquipHead { get; set; }
>>>>>>> Stashed changes
        public bool IsAlive { get; } = true;

        public List<Item> Inventory { get; } = new List<Item>();

        public Character(string name, string job, int level, int atk, int def, int hp, int gold, int floor, bool itemEquipWeapon, bool itemEquipTop, bool itemEquipPants, bool itemEquipHead, bool isAlive)
        {
            Name = name;
            Job = job;
            Level = level;
            Atk = atk;
            Def = def;
            Hp = hp;
            Gold = gold;
            Floor = floor;
            ItemEquipWeapon = itemEquipWeapon;
            ItemEquipTop = itemEquipTop;
            ItemEquipPants = itemEquipPants;
            ItemEquipHead = itemEquipHead;
            IsAlive = isAlive;
        }

        public void AddItemsFromItemList(List<Item> itemList)
        {
            Inventory.Clear();

            foreach (var item in Item.ItemList().Where(item => item.Have == true))
            {
                Inventory.Add(item);
            }
        }

        public void ShowInventory()
        {
            foreach (var item in Inventory)
            {
                Console.WriteLine($"[{item.ItemLevel}, {item.Type}] {item.ItemName}, 공격력: {item.ItemAtk}, 빙어력: {item.ItemDef}, 체력: {item.ItemHp}, 설명:{item.ItemDescription}");
            }
        }

        public void ItemStat(bool equipItem = false, int index = 0)
        {
            Console.Write("- ");
            if (equipItem == false)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("{0} ", index); // 몇 번째 아이템인가
                Console.ResetColor();
            }
            if (player.ItemEquipWeapon || player.ItemEquipTop || player.ItemEquipPants || player.ItemEquipHead)
            {
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("E");
                Console.ResetColor();
                Console.Write("]");
            }
            else
                Console.WriteLine(Interface.PadRightForMixedText(player.Name, 12));
            Console.Write(" | ");

            if (player.Inventory.Count > index)
            {
                var selectedItem = player.Inventory[index];
                Console.Write($"{selectedItem.ItemName} | ");
                Console.Write($"공격력 {(selectedItem.ItemAtk >= 0 ? "+" : "")}{selectedItem.ItemAtk} ");
                Console.Write($"방어력 {(selectedItem.ItemDef >= 0 ? "+" : "")}{selectedItem.ItemDef} ");
                Console.Write($"체 력 {(selectedItem.ItemHp >= 0 ? "+" : "")}{selectedItem.ItemHp} ");
                Console.WriteLine($" | {selectedItem.ItemDescription}");
            }
        }

        public static void ToggleEquipStatus(int index) //item
        {
            player.Inventory[index].Equip = !player.Inventory[index].Equip; // ! : 불형의 변수를 반대로 만들어주는 것
        }

        public static int itemStatSumAtk() //item
        {
            int sum = 0;
            for (int i = 0; i < player.Inventory.Count ; i++)
            {
                if (player.Inventory[i].Equip == true) sum += player.Inventory[i].ItemAtk;
            }
            return sum;
        }
        public static int itemStatSumDef()
        {
            int sum = 0;
            for (int i = 0; i < player.Inventory.Count ; i++)
            {
                if (player.Inventory[i].Equip == true) sum += player.Inventory[i].ItemDef;
            }
            return sum;
        }
        public static int itemStatSumHp()
        {
            int sum = 0;
            for (int i = 0; i < player.Inventory.Count ; i++)
            {
                if (player.Inventory[i].Equip == true) sum += player.Inventory[i].ItemHp;
            }
            return sum;
        }
    }
}
