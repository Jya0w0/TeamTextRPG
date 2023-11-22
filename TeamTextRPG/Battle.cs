using System;
using System.Collections.Generic;
using System.Numerics;

namespace TeamTextRPG
{
    internal class Battle
    {
        public static int PlayerAttackRange(Character player)
        {
            int baseDamage = player.Atk;
            int itemDamage = Item.itemStatSumAtk();
            double damageVariation = new Random().NextDouble() * 0.2 - 0.1; // Random value between -0.1 and 0.1
            double totalDamage = baseDamage + itemDamage + ((baseDamage + itemDamage) * damageVariation);
            int actualDamage = Math.Max((int)totalDamage, 0);

            return actualDamage;
        }

        public static int EnumyAttackRange(Monster monster, Character player)
        {
            int baseDamage = monster.MonsterAtk;
            int baseDef = player.Def;
            double damageVariation = new Random().NextDouble() * 0.2 - 0.1; // Random value between -0.1 and 0.1
            double totalDamage = baseDamage + (baseDamage * damageVariation) - baseDef;
            int actualDamage = Math.Max((int)totalDamage, 0);

            return actualDamage;
        }
    }
}