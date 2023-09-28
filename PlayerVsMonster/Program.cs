using System;
using PlayerVsMonster.Creatures.Core;
using PlayerVsMonster.Creatures.CreatureBuilder;
using PlayerVsMonster.Services;
using PlayerVsMonster.Utilities;

namespace PlayerVsMonster
{
    public static class Program
    {
        public static void Main()
        {
            IRandomService randomService = new DefaultRandomService();
            ServiceLocator.Register(randomService);

            var player = new CreatureBuilder()
                .WithCreatureName("player")
                .WithDefensePoints(3)
                .WithMaxHealth(10)
                .WithAttackPoints(20)
                .WithDamageRange(new IntRange(9, 9))
                .GetResultPlayer();

            var monsterStats = player.CreatureStats with { AttackPoints = 20 };
            var monster = new Monster(monsterStats, "monster");

            monster.AttackCreature(player);

            Console.WriteLine($"player hp :{player.CurrentHealthPoints}");
            player.ApplyMedKit();
            Console.WriteLine($"player hp :{player.CurrentHealthPoints}");

            player.AttackCreature(monster);

            monster.AttackCreature(player);
            monster.AttackCreature(player);

            player.ApplyMedKit();
        }
    }
}