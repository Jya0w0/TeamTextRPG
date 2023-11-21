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
        public int Atk { get; }
        public int Def { get; }
        public int Hp { get; }
        public int Gold { get; }
        public bool IsAlive { get; } = true;

        public Character(string name, string job, int level, int atk, int def, int hp, int gold, bool isAlive)
        {
            Name = name;
            Job = job;
            Level = level;
            Atk = atk;
            Def = def;
            Hp = hp;
            Gold = gold;
            IsAlive = isAlive;
        }


    }
}
