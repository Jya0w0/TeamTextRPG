using System;
namespace TeamTextRPG
{
    public class Monster_AnSky
    {

        public string MonsterName { get; set; }
        public int MonsterHp { get; set; }
        public int MonsterAtk { get; set; }
        public int MonsterLv { get; set; }
        public bool IsAlive { get; set; } = true;



        public static List<Monster_AnSky> RandomMonsters()
        {


            List<Monster_AnSky> monsters = new List<Monster_AnSky>
            {
                new Monster_AnSky("변이 쥐", 50, 20, 1),
                new Monster_AnSky("다친 경비 견", 30, 30, 1),
                new Monster_AnSky("실험체 태아", 20, 20, 1),
                new Monster_AnSky("슬라임", 60, 10, 1)
            };

            List<Monster_AnSky> selectedMonsters = new List<Monster_AnSky>();//load list
            Random random = new Random();//random

            int maxMonsters = random.Next(monsters.Count); //반복문에 사용될 몬스터 생성 최댓값 랜덤 생성

            for (int i = 0; i < maxMonsters; i++)
            {
                selectedMonsters.Add(monsters[random.Next(monsters.Count)]); //
            }

            return selectedMonsters;
        }

        public Monster_AnSky(string monsterName, int monsterHp, int monsterAtk, int monsterLv)
        {
            MonsterName = monsterName;
            MonsterHp = monsterHp;
            MonsterAtk = monsterAtk;
            MonsterLv = monsterLv;

        }
    }
}


