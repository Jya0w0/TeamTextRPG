using System;
using System.Collections.Generic;
using System.Numerics;

namespace TeamTextRPG
{
    internal class Battle_AnSky
    {
        

        public static void DisplayDungeon(Character player)
        {
            int playerHpInDungeon = player.Hp;

            List<Monster_AnSky> selectedMonster = Monster_AnSky.RandomMonsters();

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Battle!!");
                Console.ResetColor();

                Console.WriteLine();

                foreach (var monster in selectedMonster)
                {
                    Console.ForegroundColor = monster.IsAlive ? ConsoleColor.Black : ConsoleColor.Gray;
                    Console.Write($"Lv{monster.MonsterLv} {monster.MonsterName} ");
                    Console.Write(monster.MonsterHp <= 0 ? "Dead" : "Hp: ");
                    Console.ForegroundColor = monster.IsAlive ? ConsoleColor.Green : ConsoleColor.Gray;
                    Console.WriteLine(monster.MonsterHp <= 0 ? "" : $"{monster.MonsterHp}");
                    
                    Console.ResetColor();
                }

                Console.WriteLine();
                Console.WriteLine("[내정보]");
                Console.Write("Lv");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{player.Level}");
                Console.ResetColor();
                Console.WriteLine($" {player.Name} ( {player.Job} )");

                int itemStatAtk = ItemStatSumAtk(player);
                int itemStatDef = ItemStatSumDef(player);
                int itemStatHp = ItemStatSumHp(player);
                int nowHp = playerHpInDungeon + itemStatHp;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"HP : {nowHp}");
                Console.ResetColor();
                StatTextColor("/", player.Hp.ToString(), itemStatHp > 0 ? string.Format(" (+{0})", itemStatHp) : "");

                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("원하는 몬스터를 선택하세요:");
                Console.WriteLine();
                for (int i = 0; i < selectedMonster.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {selectedMonster[i].MonsterName}");
                }

                int monsterChoice = CheckValidInput(1, selectedMonster.Count);

                Console.WriteLine("1. 공격");
                Console.WriteLine("원하는 행동을 선택하세요:");
                

                switch (CheckValidInput(1, 1))
                {
                    case 1:
                        int aliveMonsters = selectedMonster.Count(monster => monster.IsAlive == true);
                        if (aliveMonsters > 0)
                        {
                            Console.WriteLine("원하는 몬스터를 선택하세요:");
                            for (int i = 0; i < selectedMonster.Count; i++)
                            {
                                if (selectedMonster[i].IsAlive)
                                {
                                    Console.WriteLine($"{i + 1}. {selectedMonster[i].MonsterName}");
                                }
                            }


                            PlayerAttack(player, selectedMonster[monsterChoice - 1], ref playerHpInDungeon, selectedMonster);
                            Console.WriteLine();



                        }
                        break;
                    default:
                        Console.WriteLine("올바른 선택이 아닙니다.");
                        break;
                }

                switch (CheckValidInput(1, 1))
                {
                    case 1:
                        int aliveMonsters = selectedMonster.Count(monster => monster.IsAlive == true);
                        Console.Clear();

                        if (aliveMonsters >= 0)
                        {
                            for (int i = 0; i < selectedMonster.Count; i++)
                            {

                                EnumyAttack(player, selectedMonster[i], ref playerHpInDungeon, selectedMonster);
                            }
                        }

                        break;
                }

            } while (selectedMonster.Any(monster => monster.IsAlive));
        }

        private static int ItemStatSumAtk(Character player)
        {
            return 0;
        }

        private static int ItemStatSumDef(Character player)
        {
            return 0;
        }

        private static int ItemStatSumHp(Character player)
        {
            return 0;
        }

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

        private static void PlayerAttack(Character player, Monster_AnSky monster, ref int playerHpInDungeon, List<Monster_AnSky> selectedMonster)
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
                                BattleResurt(player, monster, selectedMonster, ref playerHpInDungeon);
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

        private static void EnumyAttack(Character player, Monster_AnSky monster, ref int playerHpInDungeon, List<Monster_AnSky> selectedMonster)
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
                            BattleResurt(player, monster, selectedMonster, ref playerHpInDungeon);
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


        private static void BattleResurt(Character player, Monster_AnSky monster, List<Monster_AnSky> selectedMonster, ref int playerHpInDungeon)
        {
            int aliveMonsters = selectedMonster.Count(monster => monster.IsAlive == true);
            int playerLastHp = playerHpInDungeon;

            if (aliveMonsters == 0 && playerLastHp > 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Battle!! - Resurt");
                Console.ResetColor();
                Console.WriteLine();

                Console.WriteLine("VICTORY");
                Console.WriteLine();

                Console.Write("던전에서 몬스터 ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{selectedMonster.Count}");
                Console.ResetColor();
                Console.WriteLine("마리를 잡았습니다.");
                Console.WriteLine();

                Console.Write("Lv.");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{player.Level}");
                Console.ResetColor();
                Console.WriteLine($" {player.Name}");

                Console.Write("HP ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{player.Hp} -> {playerHpInDungeon}");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("1. 다음");

                switch (CheckValidInput(1, 1))
                {
                    case 1:
                        Console.Clear();
                        Start.DisplayGameIntro();
                        break;
                }

            }
            else if (aliveMonsters > 0 && playerLastHp == 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Battle!! - Resurt");
                Console.ResetColor();
                Console.WriteLine();

                Console.WriteLine("YOU LOSE");
                Console.WriteLine();

                Console.Write("Lv.");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{player.Level}");
                Console.ResetColor();
                Console.WriteLine($" {player.Name}");

                Console.Write("HP ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{player.Hp} -> {playerHpInDungeon}");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("1. 다음");

                switch (CheckValidInput(1, 1))
                {
                    case 1:
                        Console.Clear();
                        Start.DisplayGameIntro();
                        break;
                }

            }


        }

    }
}