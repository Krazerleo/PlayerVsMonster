using PlayerVsMonster.Creatures.Behaviour;
using PlayerVsMonster.Creatures.Behaviour.Interfaces;

namespace PlayerVsMonster.Creatures.Core
{
    public class Player : Creature
    {
        private IPlayerBehaviour _playerBehaviour = new AlivePlayerBehaviour();
        public Player(CreatureStats creatureStats, string name) :
            base(creatureStats, name)
        {
        }

        public override void Die()
        {
            base.Die();
            _playerBehaviour = new DeadPlayerBehaviour();
        }

        public void ApplyMedKit()
        {
            _playerBehaviour.ApplyMedkit(this);
        }
    }
}