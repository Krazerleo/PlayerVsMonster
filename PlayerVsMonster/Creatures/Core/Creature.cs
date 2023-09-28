using PlayerVsMonster.Creatures.Behaviour;
using PlayerVsMonster.Creatures.Behaviour.Interfaces;

namespace PlayerVsMonster.Creatures.Core
{
    public abstract class Creature
    {
        public readonly string Name;
        public CreatureStats CreatureStats;
        public int CurrentHealthPoints;
        private ICreatureBehaviour _creatureBehaviour = new AliveCreatureBehaviour();

        public Creature(CreatureStats creatureStats, string name)
        {
            CreatureStats = creatureStats;
            CurrentHealthPoints = CreatureStats.MaxHealthPoints;
            Name = name;
        }

        public bool IsDead { get; private set; } = false;

        public virtual void AttackCreature(Creature defender)
        {
            _creatureBehaviour.AttackCreature(this, defender);
        }

        public virtual void Die()
        {
            IsDead = true;
            _creatureBehaviour = new DeadCreatureBehaviour();
        }

        public virtual void TakeDamage(Creature attacker)
        {
            _creatureBehaviour.TakeDamage(attacker, this);
        }
    }
}