using System;
using PlayerVsMonster.Creatures.Behaviour.Interfaces;
using PlayerVsMonster.Creatures.Core;

namespace PlayerVsMonster.Creatures.Behaviour
{
    internal class DeadPlayerBehaviour : IPlayerBehaviour
    {
        public void ApplyMedkit(Creature creature)
        {
            Console.WriteLine($"{creature.Name} is not able to apply MedKit because of death");
        }
    }
}