using System;
using System.Numerics;
using System.Text;

namespace TeamTextRPG
{
    public class Display
    {
        //게임 캐릭터 설정
        #region
        public static void DisplayCharacterGenaration()
        {

            string characterName = "";
            string characterClass = "";

            Console.Clear();
            Console.Title = "= Sparta Village =";


            Interface.LineTextColor("==================================================");
            string startTxt = "스파르타 마을에 오신 여러분 환영합니다.\n이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.\n";
            Interface.OutputTxt(startTxt);
            Thread.Sleep(2000);


            Console.Clear();
            string writeName = "이름이 무엇인가요? \n이름: ";
            Interface.OutputTxt(writeName);
            characterName = Console.ReadLine();
            //이름 저장

            Console.Clear();
            string classType = "1. 전사  2. 마법사  3. 궁수";
            Interface.OutputTxt(classType);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            string inputClass = "원하는 직업을 선택하여주세요. \n직업: ";
            Interface.OutputTxt(inputClass);
            int input = Interface.CheckValidInput(1, 3);
            //직업 선택


            switch (input)
            {
                case 1:
                    characterClass = "전사";
                    break;

                case 2:
                    characterClass = "마법사";
                    break;

                case 3:
                    characterClass = "궁수";
                    break;

            }

            Character.player = new Character(characterName, characterClass, 1, 10, 5, 100, 1500, true);
            //직업 저장

        }
        #endregion

        //마을
        #region
        public static void DisplayGameIntro()
        {
            Console.Clear();
            Interface.LineTextColor("==================================================");
            Console.WriteLine();
            Interface.ChooseTextColor("1. 상태보기\n2. 인벤토리\n3. 상    점\n4. 던    전\n0. 메인화면");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.WriteLine();

            int input2 = Interface.CheckValidInput(0, 4);
            switch (input2)
            {
                case 0:
                    Console.Beep();
                    DisplayGameLogo();
                    break;
                case 1:
                    DisplayMyInfo();
                    break;
                case 2:
                    DisplayInventory();
                    break;
                case 3:
                    DisplayShop();
                    break;
                case 4:
                    DisplayDungeon(Character.player);
                    break;
            }
        }
        #endregion

        //캐릭터 정보 보기
        #region
        public static void DisplayMyInfo()
        {
            Console.Clear();
            Console.Title = "= Information =";

            Interface.ChooseTextColor("= 상태보기 =");
            Interface.LineTextColor("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();
            Interface.StatTextColor("Lv. ", Character.player.Level.ToString("00")); // 00, 07 등 한자릿수도 두자릿수로 표현하기 위해 string 타입으로 변환
            Console.WriteLine();
            Console.WriteLine("{0} ( {1} )", Character.player.Name, Character.player.Job);

            int itemStatAtk = Item.itemStatSumAtk();
            int itemStatDef = Item.itemStatSumDef();
            int itemStatHp = Item.itemStatSumHp();
            Interface.StatTextColor("공격력 : ", (Character.player.Atk + itemStatAtk).ToString(), itemStatAtk > 0 ? string.Format(" (+{0})", itemStatAtk) : "");
            Interface.StatTextColor("방어력 : ", (Character.player.Def + itemStatDef).ToString(), itemStatDef > 0 ? string.Format(" (+{0})", itemStatDef) : "");
            Interface.StatTextColor("체 력 : ", Character.player.Hp.ToString(), itemStatHp > 0 ? string.Format(" (+{0})", itemStatHp) : "");
            Interface.StatTextColor("Gold : ", Character.player.Gold.ToString());
            Console.WriteLine();
            Interface.ChooseTextColor("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.WriteLine();

            int input = Interface.CheckValidInput(0, 0);
            switch (input)
            {
                case 0:
                    DisplayGameIntro();
                    break;
            }
        }
        #endregion

        //캐릭터 인벤토리 보기
        #region
        public static void DisplayInventory()
        {
            Console.Clear();
            Console.Title = "= inventory =";

            Interface.ChooseTextColor("= 인벤토리 =");
            Interface.LineTextColor("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Interface.ChooseTextColor("[아이템 목록]");

            for (int i = 0; i < Item.ItemCount; i++)
            {
                Item.items[i].ItemStat();
            }
            Console.WriteLine("");
            Interface.ChooseTextColor("1. 장착관리\n0. 나가기");
            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.WriteLine();

            int input = Interface.CheckValidInput(0, 1);
            switch (input)
            {
                case 0:
                    DisplayGameIntro();
                    break;
                case 1:
                    DisplayerEquip();
                    break;
            }
        }
        #endregion

        // 장착 관리 보기
        #region
        public static void DisplayerEquip()
        {
            Console.Clear();
            Console.Title = "= Item Equip =";

            Interface.ChooseTextColor("= 장착관리 =");
            Interface.LineTextColor("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Interface.ChooseTextColor("[아이템 목록]");
            for (int i = 0; i < Item.ItemCount; i++)
            {
                Item.items[i].ItemStat(true, i + 1);
            }
            Console.WriteLine();
            Interface.ChooseTextColor("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            int input = Interface.CheckValidInput(0, Item.ItemCount);
            switch (input)
            {
                case 0:
                    DisplayInventory();
                    break;
                default:
                    Item.ToggleEquipStatus(input - 1); // 유저가 입력하는건 1, 2, 3...  실제 배열에는 0, 1, 2...
                    DisplayerEquip();
                    break;
            }
        }
        #endregion

        //상점 보기
        #region
        public static void DisplayShop()
        {
            Console.Clear();
            Console.Title = "= Item Shop =";

            Interface.ChooseTextColor(" = 상   점 = ");
            Console.WriteLine();
            // 한글자씩 출력
            Console.ForegroundColor = ConsoleColor.Cyan;
            string shopTxt = "상점이 있던 곳이다.\n그러나 상점은 온데간데 없고 부서진 건물의 흔적만 있을 뿐이다...\n나중에 다시 오자.\n";
            Interface.OutputTxt(shopTxt);
            Console.WriteLine();
            Interface.ChooseTextColor("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.WriteLine();

            int input = Interface.CheckValidInput(0, 0);
            switch (input)
            {
                case 0:
                    DisplayGameIntro();
                    break;
            }
        }
        #endregion

        //게임 로고
        #region
        public static void DisplayGameLogo()
        {
            Console.Clear();
            // 아스키 코드로 이루어진 타이틀 화면을 위한 인코딩 설정
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "= Sparta Dungeon =";

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("                                                                               \r\n ####                  #          ######                                       \r\n##  #                 ##           ##  ##                                      \r\n###   ###   ##   ## # ###  ##      ##  ## ## ## # ##    ####  ###  ###  # ##   \r\n ###  ## # # ##  #### ##  # ##     ##  ## ## #  ## ##  ## #  ## # ## ## ## ##  \r\n  ### ## #  ###  ##   ##   ###     ##  ## ## #  ## ##  ## #  #### ## ## ## ##  \r\n#  ## ## # #  #  ##   ##  #  #     ##  ## ## #  ## ##   ###  ##   ## ## ## ##  \r\n####  ###  ##### ##    ## #####   ######   ###  ## ### ##     ###  ###  ## ### \r\n      ##                                               ####                    \r\n      ###                                              #  #                    \r\n                                                       ####                    ");
            Console.WriteLine();
            Console.WriteLine("          ===== 계속하려면 아무 키나 입력하십시오. =====          ");
            Console.ResetColor();
            Console.ReadKey();
            Console.Beep(); // 삡 소리 나게 하는 것
        }
        #endregion

        //던전 진입
        #region
        public static void DisplayDungeon(Character player)
        {
            int playerHpInDungeon = player.Hp + Item.itemStatSumHp();

            List<Monster> selectedMonster = Monster.RandomMonsters();

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Battle!!");
                Console.ResetColor();

                Console.WriteLine();

                foreach (var monster in selectedMonster)
                {
                    if (monster.IsAlive == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
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

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"HP : {playerHpInDungeon}/");
                Console.ResetColor();
                Console.WriteLine($" {player.Hp}");

                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("원하는 몬스터를 선택하세요:");
                Console.WriteLine();
                for (int i = 0; i < selectedMonster.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {selectedMonster[i].MonsterName}");
                }

                int monsterChoice = Interface.CheckValidInput(1, selectedMonster.Count);

                Console.WriteLine("1. 공격");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("원하는 행동을 선택하세요:");
                Console.WriteLine();

                switch (Interface.CheckValidInput(1, 1))
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

                switch (Interface.CheckValidInput(1, 1))
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
        #endregion

        //던전 결과 보기
        #region
        public static void DisplayBattleResurt(Character player, Monster monster, List<Monster> selectedMonster, ref int playerHpInDungeon)
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

                Reward.StageClear();


                Console.WriteLine("1. 다음");
                Console.WriteLine();

                switch (Interface.CheckValidInput(1, 1))
                {
                    case 1:
                        Console.Clear();
                        DisplayGameIntro();
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
                Console.WriteLine();

                switch (Interface.CheckValidInput(1, 1))
                {
                    case 1:
                        Console.Clear();
                        DisplayGameIntro();
                        break;
                }
            }
        }
        #endregion

        //플레이어 공격 결과 보기
        #region
        public static void PlayerAttack(Character player, Monster monster, ref int playerHpInDungeon, List<Monster> selectedMonster)
        {

            int playerDamage = Battle.PlayerAttackRange(player);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Battle!!");
            Console.ResetColor();


            if (monster.IsAlive)
            {
                Console.Write($"{player.Name}이(가) Lv{monster.MonsterLv} {monster.MonsterName}에게 공격했습니다!      ");
                Console.Write("[데미지 : ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{playerDamage}");
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

                monster.MonsterHp -= playerDamage;

                if (monster.MonsterHp < 0)
                {
                    monster.IsAlive = false;
                    monster.MonsterHp = 0;
                    Console.WriteLine("Dead");
                    int aliveMonsters = selectedMonster.Count(monster => monster.IsAlive == true);
                    if (aliveMonsters == 0)
                    {
                        Console.WriteLine("1. 결과확인");

                        switch (Interface.CheckValidInput(1, 1))
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
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine($"{monster.MonsterName}은(는) 이미 죽었습니다!");
                Console.WriteLine();
                Console.WriteLine("1. 다음");
                Console.WriteLine();
            }
        }
        #endregion

        //적 공격 결과 보기
        #region
        public static void EnumyAttack(Character player, Monster monster, ref int playerHpInDungeon, List<Monster> selectedMonster)
        {

            int monsterDamage = Battle.EnumyAttackRange(monster);

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
                Console.Write($"{monsterDamage}");
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

                playerHpInDungeon -= monsterDamage;
                if (playerHpInDungeon <= 0)
                {
                    playerHpInDungeon = 0;
                    Console.WriteLine();
                    Console.WriteLine("1. 결과확인");
                    Console.WriteLine();

                    switch (Interface.CheckValidInput(1, 1))
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
                Console.WriteLine();

                switch (Interface.CheckValidInput(1, 1))
                {
                    case 1:
                        Console.Clear();
                        break;
                }
            }
        }
        #endregion
    }
}
