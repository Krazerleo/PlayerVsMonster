using System;
using System.Linq;
using PlayerVsMonster.Creatures.Behaviour.Interfaces;
using PlayerVsMonster.Creatures.Core;
using PlayerVsMonster.Services;

namespace PlayerVsMonster.Creatures.Behaviour
{
    public class AliveCreatureBehaviour : ICreatureBehaviour
    {
        private readonly IRandomService _randomService = ServiceLocator.Resolve<IRandomService>();

        public void AttackCreature(Creature attacker, Creature defender)
        {
            defender.TakeDamage(attacker);
        }

        public void TakeDamage(Creature attacker, Creature defender)
        {
            var attackDicesCount = Math.Max(0, attacker.CreatureStats.AttackPoints - defender.CreatureStats.DefensePoints) + 1;
            var hasSuccesfulRoll = Utilities.RandomRollsList
                .GenerateRandomRolls(attackDicesCount, _randomService)
                .Where(val => val >= 5).Any();

            if (hasSuccesfulRoll)
            {
                var damageTaken = _randomService.Next(attacker.CreatureStats.DamageRange);
                defender.CurrentHealthPoints -= damageTaken;

                if (defender.CurrentHealthPoints < 0)
                {
                    Console.WriteLine($"{defender.Name} has been killed");
                    defender.Die();
                }
                else
                {
                    Console.WriteLine($"{defender.Name} get {damageTaken} damage");
                }
            }
            else
            {
                Console.WriteLine($"{defender.Name} dodged attack");
            }
        }
    }
}