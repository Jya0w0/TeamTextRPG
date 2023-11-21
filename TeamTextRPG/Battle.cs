using System;
using System.Collections.Generic;
using System.Numerics;

namespace TeamTextRPG
{
    internal class Battle
    {

        private static void StatTextColor(string s1, string s2, string s3 = "")
        {
            Console.Write(s1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s2);
            Console.ResetColor();
            Console.Write(s3);
        }

        private static int CheckValidInput(int min, int max)
        {
            int input;
            while (true)
            {
                Console.WriteLine();
                
                Console.WriteLine();
                Console.WriteLine("대상을 선택해주세요.");
                Console.Write(">> ");
                if (int.TryParse(Console.ReadLine(), out input) && input >= min && input <= max)
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("올바른 입력이 아닙니다. 다시 입력해주세요.");
                }
            }
        }

        public static void PlayerAttack(Character player, Monster monster, ref int playerHpInDungeon, List<Monster> selectedMonster)
        {
            int baseDamage = player.Atk;

            double damageVariation = new Random().NextDouble() * 0.2 - 0.1; // Random value between -0.1 and 0.1
            double totalDamage = baseDamage + baseDamage * damageVariation;

            int actualDamage = Math.Max((int)totalDamage, 0);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Battle!!");
            Console.ResetColor();
            

            if (monster.IsAlive)
            {
                Console.Write($"{player.Name}이(가) Lv{monster.MonsterLv} {monster.MonsterName}에게 공격했습니다!      ");
                Console.Write("[데미지 : ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{actualDamage}");
                Console.ResetColor();
                Console.WriteLine("]");
                Console.WriteLine();

                Console.Write("Lv.");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{monster.MonsterLv}");
                Console.ResetColor();
                Console.WriteLine($" {monster.MonsterName}");
                
                Console.Write("HP ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{monster.MonsterHp}");
                Console.ResetColor();
                Console.Write(" -> ");

                monster.MonsterHp -= actualDamage;

                if (monster.MonsterHp < 0)
                {
                    monster.IsAlive = false;
                    monster.MonsterHp = 0;
                    Console.WriteLine("Dead");
                    int aliveMonsters = selectedMonster.Count(monster => monster.IsAlive == true);
                    if (aliveMonsters == 0)
                    {
                        Console.WriteLine("1. 결과확인");

                        switch (CheckValidInput(1, 1))
                        {
                            case 1:
                                Display.DisplayBattleResurt(player, monster, selectedMonster, ref playerHpInDungeon);
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("1. 다음");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{monster.MonsterHp}");
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.WriteLine("1. 다음");



                }


            }
            else
            {
                Console.WriteLine($"{monster.MonsterName}은(는) 이미 죽었습니다!");
                Console.WriteLine();
                Console.WriteLine("1. 다음");
            }

        }

        public static void EnumyAttack(Character player, Monster monster, ref int playerHpInDungeon, List<Monster> selectedMonster)
        {
            int baseDamage = monster.MonsterAtk;

            double damageVariation = new Random().NextDouble() * 0.2 - 0.1; // Random value between -0.1 and 0.1
            double totalDamage = baseDamage + baseDamage * damageVariation;

            int actualDamage = Math.Max((int)totalDamage, 0);

            if (monster.IsAlive == true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("BATTLE");
                Console.ResetColor();
                Console.WriteLine();

                Console.Write("Lv.");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{monster.MonsterLv}");
                Console.ResetColor();
                Console.Write($" {monster.MonsterName}이(가) Lv.");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{player.Level}");
                Console.ResetColor();
                Console.Write($" {player.Name}에게 공격했습니다!     ");

                Console.Write("[데미지 : ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{actualDamage}");
                Console.ResetColor();
                Console.Write("]");
                Console.WriteLine();
                Console.WriteLine();

                Console.Write("Lv.");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{player.Level} ");
                Console.ResetColor();
                Console.WriteLine($"{player.Name}");

                Console.Write($"HP ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{playerHpInDungeon}");
                Console.ResetColor();
                Console.Write(" -> ");

                playerHpInDungeon -= actualDamage;
                if (playerHpInDungeon <= 0)
                {
                    playerHpInDungeon = 0;
                    Console.WriteLine();
                    Console.WriteLine("1. 결과확인");

                    switch (CheckValidInput(1, 1))
                    {
                        case 1:
                            Display.DisplayBattleResurt(player, monster, selectedMonster, ref playerHpInDungeon);
                            break;


                    }
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{playerHpInDungeon}");
                Console.ResetColor();

                Console.WriteLine();
                Console.WriteLine("1. 다음");

                switch (CheckValidInput(1, 1))
                {
                    case 1:
                        Console.Clear();
                        break;
                }
            }


        }


        

    }
}