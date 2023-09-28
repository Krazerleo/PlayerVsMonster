using System;
using PlayerVsMonster.Creatures.Behaviour.Interfaces;
using PlayerVsMonster.Creatures.Core;

namespace PlayerVsMonster.Creatures.Behaviour
{
    internal class AlivePlayerBehaviour : IPlayerBehaviour
    {
        private int _medKitsCount = 4;
        public void ApplyMedkit(Creature creature)
        {
            if (_medKitsCount <= 0)
            {
                Console.WriteLine("MedKits exhausted");
                return;
            }

            _medKitsCount--;
            Console.WriteLine("Player applied MedKit");
            creature.CurrentHealthPoints = Math.Min(creature.CreatureStats.MaxHealthPoints,
                creature.CurrentHealthPoints + (int) Math.Floor(creature.CreatureStats.MaxHealthPoints * 0.3));
        }
    }
}