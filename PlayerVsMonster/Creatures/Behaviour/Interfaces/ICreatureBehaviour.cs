using PlayerVsMonster.Creatures.Core;

namespace PlayerVsMonster.Creatures.Behaviour.Interfaces
{
    public interface ICreatureBehaviour
    {
        public void TakeDamage(Creature attacker, Creature defender);

        public void AttackCreature(Creature attacker, Creature defender);
    }
}