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
            int itemDamage = Character.itemStatSumAtk();
            double damageVariation = new Random().NextDouble() * 0.2 - 0.1; // Random value between -0.1 and 0.1
            double totalDamage = baseDamage + itemDamage + ((baseDamage + itemDamage) * damageVariation);
            int actualDamage = Math.Max((int)totalDamage, 0);

            return actualDamage;
        }

<<<<<<< Updated upstream
        public static int EnumyAttackRange(Monster monster)
        {
            int baseDamage = monster.MonsterAtk;
=======
        public static int EnemyAttackRange(Monster monster, Character player)
        {
            int baseDamage = monster.MonsterAtk;
            int baseDef = player.Def;
            int ItemDef = Character.itemStatSumDef();
>>>>>>> Stashed changes
            double damageVariation = new Random().NextDouble() * 0.2 - 0.1; // Random value between -0.1 and 0.1
            double totalDamage = baseDamage + (baseDamage * damageVariation);
            int actualDamage = Math.Max((int)totalDamage, 0);

            return actualDamage;
        }
    }
}