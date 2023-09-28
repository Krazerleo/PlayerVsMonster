using PlayerVsMonster.Utilities;

namespace PlayerVsMonster.Creatures.Core
{
    public readonly record struct CreatureStats
    {
        public int AttackPoints { get; init; }
        public IntRange DamageRange { get; init; }
        public int DefensePoints { get; init; }
        public int MaxHealthPoints { get; init; }

        public CreatureStats(IntRange damageRange, int attackPoints, int defensePoints, int maxHealthPoints)
        {
            DamageRange = damageRange;
            DefensePoints = defensePoints;
            MaxHealthPoints = maxHealthPoints;
            AttackPoints = attackPoints;
        }
    }
}