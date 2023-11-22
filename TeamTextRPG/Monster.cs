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

        public static List<Monster> monsters = new List<Monster>
            {
                new Monster("감염된 쥐", 20, 5, 1, true),
                new Monster("다친 경비 견", 10, 10, 1, true),
                new Monster("태아 실험체", 6, 15, 1, true),
                new Monster("방사능 슬라임", 15, 7, 1, true),
                new Monster("감염된 과학자", 30, 15, 2, true),
                new Monster("커다란 가방을 맨 감염자", 40, 10, 2, true),
                new Monster("감염된 경비 견", 20, 20, 2, true)
            };

        public static List<Monster> RandomMonsters()
        {

            List<Monster> selectedMonsters = new List<Monster>();//load list
            Random random = new Random();//random

            int maxMonsters = random.Next(1, monsters.Count); //반복문에 사용될 몬스터 생성 최댓값 랜덤 생성

            for (int i = 0; i < 1; i++)
            {
                Monster selectedMonster = monsters[random.Next(monsters.Count)];
                selectedMonsters.Add(new Monster(selectedMonster));
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

        public Monster(Monster monster)
        {
            MonsterName = monster.MonsterName;
            MonsterHp = monster.MonsterHp;
            MonsterAtk = monster.MonsterAtk;
            MonsterLv = monster.MonsterLv;
            IsAlive = monster.IsAlive;
        }
    }
}


