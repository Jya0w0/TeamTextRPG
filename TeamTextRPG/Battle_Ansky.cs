using System;
using System.Collections.Generic;

namespace TeamTextRPG
{
    public class Battle_AnSky
    {
        static void DisplayDungeon(Character player)
        {

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
                    Console.WriteLine($"Lv{monster.MonsterLv} {monster.MonsterName} HP: {monster.MonsterHp}");
                    Console.ResetColor();
                }

                Console.WriteLine();
                Console.WriteLine("[내정보]");
                Console.Write("Lv");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{player.Level}");
                Console.ResetColor();
                Console.WriteLine($"{player.Name} ( {player.Job} )");

                int itemStatAtk = ItemStatSumAtk(player);
                int itemStatDef = ItemStatSumDef(player);
                int itemStatHp = ItemStatSumHp(player);
                int nowHp = player.Hp + itemStatHp;

                StatTextColor("Hp : ", player.Hp.ToString(), itemStatHp > 0 ? string.Format(" (+{0})", itemStatHp) : "");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"/{nowHp}");
                Console.ResetColor();
                Console.WriteLine();

                Console.WriteLine("원하는 몬스터를 선택하세요:");
                for (int i = 0; i < selectedMonster.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {selectedMonster[i].MonsterName}");
                }

                int monsterChoice = CheckValidInput(1, selectedMonster.Count);

                Console.WriteLine("1. 공격");
                Console.WriteLine("원하는 행동을 선택하세요:");
                int actionChoice = CheckValidInput(1, 1);

                switch (actionChoice)
                {
                    case 1:
                        int aliveMonsters = selectedMonster.Count(monster => monster.IsAlive);
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


                            PlayerAttack(player, selectedMonster[monsterChoice - 1]);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("더 이상 공격할 몬스터가 없습니다!");

                        }
                        break;
                    default:
                        Console.WriteLine("올바른 선택이 아닙니다.");
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
            // Implement the logic to validate user input.
            int input;
            while (true)
            {
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

        private static void PlayerAttack(Character player, Monster_AnSky monster)
        {
            int baseDamage = player.Atk;

            double damageVariation = new Random().NextDouble() * 0.2 - 0.1; // Random value between -0.1 and 0.1
            double totalDamage = baseDamage + baseDamage * damageVariation;

            int actualDamage = Math.Max((int)totalDamage, 0);

            Console.WriteLine($"{player.Name}이(가) Lv{monster.MonsterLv} {monster.MonsterName}에게 공격했습니다!");

            if (monster.IsAlive)
            {
                Console.WriteLine($"{monster.MonsterName}에게 {actualDamage}의 피해를 입혔습니다!");

                monster.MonsterHp -= actualDamage;

                if (monster.MonsterHp <= 0)
                {
                    monster.IsAlive = false; // Mark the monster as dead
                    Console.WriteLine($"{monster.MonsterName}을(를) 처치했습니다!");
                }
            }
            else
            {
                Console.WriteLine($"{monster.MonsterName}은(는) 이미 죽었습니다!");
            }
        }

        private static void EnumyAttack(Character player, Monster_AnSky monster)
        {
            int baseDamage = monster.MonsterAtk;
            int playerNowHp = player.Hp;


            double damageVariation = new Random().NextDouble() * 0.2 - 0.1; // Random value between -0.1 and 0.1
            double totalDamage = baseDamage + baseDamage * damageVariation;

            int actualDamage = Math.Max((int)totalDamage, 0);

            if (monster.IsAlive)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("BATTLE");
                Console.ResetColor();
                Console.WriteLine();

                Console.Write($"Lv.{monster.MonsterLv} {monster}이(가) Lv.{player.Level} {player.Name}에게 공격했습니다!     ");
                Console.Write("[데미지 : ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{actualDamage}");
                Console.ResetColor();
                Console.Write("]");
                Console.WriteLine();

                Console.Write("Lv.");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{player.Level} ");
                Console.ResetColor();
                Console.Write($"{player.Name}");

                Console.Write($"HP ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{playerNowHp}");
                Console.ResetColor();
                Console.Write(" -> ");

                playerNowHp -= actualDamage;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{playerNowHp}");
                Console.ResetColor();

                if (playerNowHp <= 0)
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("YOU LOSE");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.WriteLine("");
            }
        }
    }
}