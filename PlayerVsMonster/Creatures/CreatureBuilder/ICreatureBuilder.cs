﻿using PlayerVsMonster.Creatures.Core;
using PlayerVsMonster.Utilities;

namespace PlayerVsMonster.Creatures.CreatureBuilder
{
    public interface ICreatureBuilder
    {
        public ICreatureBuilder WithMaxHealth(int maxHealth);

        public ICreatureBuilder WithDamageRange(IntRange damageRange);

        public ICreatureBuilder WithAttackPoints(int attackPoints);

        public ICreatureBuilder WithDefensePoints(int defensePoints);

        public Monster GetResultMonster();

        public Player GetResultPlayer();

        public ICreatureBuilder WithCreatureName(string name);

        public void ResetBuilder();
    }
}