using System;

public class Class1
{
	public Class1()
	{
	}
    public interface IReward
    {
        string Name { get; }
        void Use(Character player);
    }

    public class StrengthPotion : IReward
    {
        private static Random random = new Random();
        public string Name => "랜덤공격력";
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
        public string Name => "랜덤골드";
        public void Use(Character player)
        {
            int rewardGold = random.Next(50, 1000);
            Console.WriteLine($"골드 주머니를 사용합니다. {rewardGold}골드를 획득하셨습니다. ");
            player.Gold += rewardGold;
        }
    }
    public static void StageClear()
    {
        List<IReward> rewards = new List<IReward>
            {
                new StrengthPotion(),
                new GoldPotion(),
            };

        Console.WriteLine("아래의 보상 아이템 중 하나를 선택하여 사용할 수 있습니다: ");

        foreach (var reward in rewards)
        {
            Console.WriteLine(reward.Name);
        }

        Console.WriteLine("사용할 아이템 이름을 입력하세요.");
        string input = Console.ReadLine();



        IReward selectReward = rewards.Find(rewards => rewards.Name == input);
        if (selectReward != null)
        {

            selectReward.Use(Character.Player);
        }



    }
}
