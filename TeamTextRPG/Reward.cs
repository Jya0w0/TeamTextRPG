using System;
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
        public string DiscriptionName => "랜덤경험치";
        public void Use(Character player)
        {
            int rewardAtk = random.Next(1, 30);
            Console.WriteLine($"공격력 포션을 사용합니다. 공격력이 {rewardAtk}증가합니다.");
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
            Console.WriteLine($"골드 주머니를 사용합니다. {rewardGold}골드를 획득하셨습니다. ");
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
            int rewardNum = random.Next(1, 2);
            if(rewardNum > 1)
            {
                int rewardGold = random.Next(5000, 10000);
                player.Gold += rewardGold;
                Console.WriteLine($"행운상자를 사용합니다. {rewardGold}골드를 획득하셨습니다. ");
            }
            else
            {
                int rewardHp = random.Next(30, 50);
                player.Hp -= rewardHp;
                Console.WriteLine($"행운상자를 사용합니다. 기본 Hp{rewardHp}를 잃었습니다. ");

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
        Console.WriteLine("아래의 보상 아이템 중 하나를 선택하여 사용할 수 있습니다: ");

        foreach (var reward in rewards)
        {
            Console.Write(reward.Name);
            Console.Write(" ");
            Console.WriteLine(reward.DiscriptionName);
        }

        while (true)
        {
            Console.WriteLine("사용할 아이템 이름을 입력하세요.");
            string input = Console.ReadLine();


            IReward selectReward = rewards.Find(rewards => rewards.Name == input);

            if(selectReward != null)
            {
                selectReward.Use(Character.player);
                break;
            }

            else
            {
                Console.WriteLine("잘못입력하셨습니다.");
                Console.WriteLine();
            }
        }
    }
}
