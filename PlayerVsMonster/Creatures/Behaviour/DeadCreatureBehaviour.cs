using System;
using PlayerVsMonster.Creatures.Behaviour.Interfaces;
using PlayerVsMonster.Creatures.Core;

namespace PlayerVsMonster.Creatures.Behaviour
{
    public class DeadCreatureBehaviour : ICreatureBehaviour
    {
        public void AttackCreature(Creature attacker, Creature defender)
        {
            Console.WriteLine($"Dead {attacker.Name} cannot attack");
        }

        public void TakeDamage(Creature attacker, Creature defender)
        {
            Console.WriteLine($"{defender.Name} has been killed before");
        }
    }
}