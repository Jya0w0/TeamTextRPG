using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TeamTextRPG
{

    public class Character
    {
        public static Character player;


        public string Name { get; }
        public string Job { get; }
        public int Level { get; }
        public int Atk { get; set; }
        public int Def { get; }
        public int Hp { get; set; }
        public int DungeonHp { get; set; }
        public int Gold { get; set; }
        public int Floor {  get; set; }
        public bool IsAlive { get; } = true;

        public Character(string name, string job, int level, int atk, int def, int hp,int dungeonHp, int gold, int floor, bool isAlive)
        {
            Name = name;
            Job = job;
            Level = level;
            Atk = atk;
            Def = def;
            Hp = hp;
            DungeonHp = dungeonHp;
            Gold = gold;
            Floor = floor;
            IsAlive = isAlive;
        }


    }
}
