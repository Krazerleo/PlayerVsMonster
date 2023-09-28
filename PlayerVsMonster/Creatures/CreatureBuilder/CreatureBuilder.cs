using PlayerVsMonster.Creatures.Core;
using PlayerVsMonster.Utilities;

namespace PlayerVsMonster.Creatures.CreatureBuilder
{
    public class CreatureBuilder : ICreatureBuilder
    {
        private int _attackPoints = 0;
        private string _creatureName = string.Empty;
        private IntRange _damageRange = new(0, 0);
        private int _defensePoint = 0;
        private int _maxHealth = 1;

        public Monster GetResultMonster()
        {
            return new Monster(CompileAllStats(), _creatureName);
        }

        public Player GetResultPlayer()
        {
            return new Player(CompileAllStats(), _creatureName);
        }

        public ICreatureBuilder WithAttackPoints(int attackPoints)
        {
            if (attackPoints < 1 || attackPoints > 30)
            {
                throw new System.Exception("Attack Points is not in range");
            }

            _attackPoints = attackPoints;
            return this;
        }

        public ICreatureBuilder WithCreatureName(string name)
        {
            _creatureName = name;
            return this;
        }

        public ICreatureBuilder WithDamageRange(IntRange damageRange)
        {
            _damageRange = damageRange;
            return this;
        }

        public ICreatureBuilder WithDefensePoints(int defensePoints)
        {
            if (defensePoints < 1 || defensePoints > 30)
            {
                throw new System.Exception("Defense Points is not in range");
            }

            _defensePoint = defensePoints;
            return this;
        }

        public ICreatureBuilder WithMaxHealth(int maxHealth)
        {
            _maxHealth = maxHealth;
            return this;
        }

        private CreatureStats CompileAllStats()
        {
            return new CreatureStats(damageRange: _damageRange,
                attackPoints: _attackPoints,
                defensePoints: _defensePoint,
                maxHealthPoints: _maxHealth);
        }

        void ICreatureBuilder.ResetBuilder()
        {
            _attackPoints = 0;
            _creatureName = string.Empty;
            _damageRange = new IntRange(0, 0);
            _defensePoint = 0;
            _maxHealth = 1;
        }
    }
}