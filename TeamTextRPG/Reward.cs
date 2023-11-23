using System;
using System.Threading;
using TeamTextRPG;

public class Reward
{
    public Reward()
    {
    }
    public interface IReward
    {
        string Name { get; }
        string DiscriptionName { get; }
        void Use(Character player);
        
    }

    public class StrengthPotion : IReward
    {
        private static Random random = new Random();
        public string Name => "1";
        public string DiscriptionName => "랜덤공격력";
        public void Use(Character player)
        {
            int rewardAtk = random.Next(1, 30);
            Console.WriteLine($"공격력 포션을 사용했다. 공격력이 {rewardAtk}증가했다.");
            player.Atk += rewardAtk;
        }
    }

    public class GoldPotion : IReward
    {
        private static Random random = new Random();
        public string Name => "2";
        public string DiscriptionName => "랜덤골드";
        public void Use(Character player)
        {
            int rewardGold = random.Next(50, 1000);
            Console.WriteLine($"골드 주머니를 사용했다. {rewardGold}골드를 획득했다. ");
            player.Gold += rewardGold;
        }
    }

    public class LuckyBox : IReward
    {
        private static Random random = new Random();

        public string Name => "3";
        public string DiscriptionName => "행운상자";
        public void Use(Character player)
        {
            
            
            int rewardNum = random.Next(1, 4);
            if (rewardNum == 1)
            {
                int rewardGold = random.Next(5000, 10000);
                player.Gold += rewardGold;
                Console.WriteLine($"행운상자를 사용했다. {rewardGold}골드를 획득했다. ");
            }
            else if (rewardNum == 2)
            {

                int rewardHpMinus = random.Next(30, 50);
                if (player.DungeonHp < rewardHpMinus)
                {
                    rewardHpMinus = player.DungeonHp - 1;
                    
                }   
                player.DungeonHp -= rewardHpMinus;
                Console.WriteLine($"행운상자를 사용했다. 기본 Hp{rewardHpMinus}를 잃었다. ");

            }
            else 
            {
                int rewardHpPlus = random.Next(30, 50);
                if(player.Hp - player.DungeonHp < rewardHpPlus)
                {
                    rewardHpPlus = player.Hp - player.DungeonHp;
                }
                player.DungeonHp += rewardHpPlus;
                Console.WriteLine($"행운상자를 사용했다. 기본 Hp{rewardHpPlus}를 회복했다. ");
            }
        }
    }

    public static void StageClear()
    {
        List<IReward> rewards = new List<IReward>
            {
                new StrengthPotion(),
                new GoldPotion(),
                new LuckyBox()
            };
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("아래의 보상 아이템 중 하나를 선택하자: ");

        Interface.LineTextColor("====================================================================================================");
        Console.WriteLine();

        foreach (var reward in rewards)
        {
            Console.Write(reward.Name);
            Console.Write(" ");
            Console.WriteLine(reward.DiscriptionName);
        }
        Console.WriteLine();
        Interface.LineTextColor("====================================================================================================");
        Console.WriteLine() ;
        while (true)
        {
            Console.Write("사용할 아이템 숫자 입력 >> ");
            
            string input = Console.ReadLine();


            IReward selectReward = rewards.Find(rewards => rewards.Name == input);

            if (selectReward != null)
            {
                selectReward.Use(Character.player);
                break;
            }

            else
            {
                Console.WriteLine("잘못입력하셨습니다. 올바른 값을 입력해주세요.");
                Console.WriteLine();
            }
        }

        Interface.LineTextColor("다음 스테이지로 이동");

        
        
    }
}
