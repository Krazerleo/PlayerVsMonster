using PlayerVsMonster.Creatures.Core;
using PlayerVsMonster.Creatures.CreatureBuilder;
using PlayerVsMonster.Services;
using PlayerVsMonster.Utilities;

namespace PlayerVsMonster.AcceptanceTesting
{
    [TestFixture]
    public class GameTests
    {
        private Player _player;
        private Monster _monster;

        [Test]
        public void WhenCreatureTakesMoreDamageThanHealth_ThenItDies()
        {
            _player.AttackCreature(_monster);

            Assert.True(_monster.IsDead == true);
        }

        [Test]
        public void WhenPlayerTakesMoreDamageThanHealth_ThenHeCannotUseMedKits()
        {
            _monster.AttackCreature(_player);

            var healthBeforeApply = _player.CurrentHealthPoints;
            _player.ApplyMedKit();
            var healthAfterApply = _player.CurrentHealthPoints;

            Assert.True(healthAfterApply == healthBeforeApply);
        }

        [Test]
        public void WhenPlayerTakesLessDamageThanHealth_ThenHeCanUseMedKits()
        {
            _monster.AttackCreature(_player);

            var healthBeforeApply = _player.CurrentHealthPoints;
            _player.ApplyMedKit();
            var healthAfterApply = _player.CurrentHealthPoints;

            Assert.True(healthAfterApply >= healthBeforeApply);
        }

        [Test]
        public void WhenDeadCreatureAttacked_DamageNotApplied()
        {
            _monster.AttackCreature(_player);

            var playerHealthBeforeAttack = _player.CurrentHealthPoints;
            _monster.AttackCreature(_player);
            var playerHealthAfterAttack = _player.CurrentHealthPoints;

            Assert.True(playerHealthAfterAttack == playerHealthBeforeAttack);
        }

        [Test]
        public void WhenCreatureTakesLessDamageThanHealth_ThenItIsAlive()
        {
            _player.CreatureStats = _player.CreatureStats with { DamageRange = new IntRange(2, 2) };

            _player.AttackCreature(_monster);

            Assert.True(_monster.IsDead == false);
        }

        [Test]
        public void WhenAttackPointMoreThen30_ThenThrowException()
        {
            Assert.Throws<Exception>(() =>
            {
                new CreatureBuilder()
                .WithCreatureName("player")
                .WithDefensePoints(3)
                .WithMaxHealth(10)
                .WithAttackPoints(35)
                .WithDamageRange(new IntRange(20, 20))
                .GetResultPlayer();
            });
        }

        [Test]
        public void WhenDefensePointMoreThen30_ThenThrowException()
        {
            Assert.Throws<Exception>(() =>
            {
                new CreatureBuilder()
                .WithCreatureName("player")
                .WithDefensePoints(35)
                .WithMaxHealth(10)
                .WithAttackPoints(20)
                .WithDamageRange(new IntRange(20, 20))
                .GetResultPlayer();
            });
        }

        [SetUp]
        public void GameSetup()
        {
            _player = new CreatureBuilder()
                .WithCreatureName("player")
                .WithDefensePoints(3)
                .WithMaxHealth(10)
                .WithAttackPoints(20)
                .WithDamageRange(new IntRange(20, 20))
                .GetResultPlayer();

            var monsterStats = _player.CreatureStats with { AttackPoints = 20 };
            _monster = new Monster(monsterStats, "monster");
        }

        [OneTimeSetUp]
        public void InitFixtureSetup()
        {
            IRandomService randomService = new DeterminedRandomService();
            ServiceLocator.Register(randomService);
        }
    }
}