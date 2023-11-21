using System;
namespace TeamTextRPG
{
    public class Monster
    {

        public string MonsterName { get; set; }
        public int MonsterHp { get; set; }
        public int MonsterAtk { get; set; }
        public int MonsterLv { get; set; }
        public bool IsAlive { get; set; } = true;



        public static List<Monster> RandomMonsters()
        {


            List<Monster> monsters = new List<Monster>
            {
                new Monster("변이 쥐", 100, 100, 1, true),
                new Monster("다친 경비 견", 100, 100, 1, true),
                new Monster("실험체 태아", 1, 20, 1, true),
                new Monster("슬라임", 1, 10, 1, true)
            };

            List<Monster> selectedMonsters = new List<Monster>();//load list
            Random random = new Random();//random

            int maxMonsters = random.Next(1, monsters.Count); //반복문에 사용될 몬스터 생성 최댓값 랜덤 생성

            for (int i = 0; i < maxMonsters; i++)
            {
                selectedMonsters.Add(monsters[random.Next(monsters.Count)]); //
            }

            return selectedMonsters;
        }

        public Monster(string monsterName, int monsterHp, int monsterAtk, int monsterLv, bool isAlive)
        {
            MonsterName = monsterName;
            MonsterHp = monsterHp;
            MonsterAtk = monsterAtk;
            MonsterLv = monsterLv;
            IsAlive = isAlive;
        }
    }
}


