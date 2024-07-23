using Assets._development.Scripts.Architecture.EventBus;
using UnityEngine;

namespace Assets.Scripts.Architecture.StateMachine.PlayerGameplayStateMachine
{
    public sealed class IdleState : BasePlayerState
    {
        private GameplayEventBus _eventBus;
        private Animator _animator;
        public IdleState(StateMachine<BasePlayerState> stateMachine, Animator animator) : base(stateMachine) {
            _animator = animator;
        }

        public override void Enter()
        {
            if (_eventBus == null)
                _eventBus = ServiceLocator.ServiceLocator.Get<GameplayEventBus>();

            _animator.SetTrigger("TrIdle");
            _eventBus.OnLevelStarted.Subscribe(EnterToWalkingState);
        }

        public override void UpdateLogic() { }

        private void EnterToWalkingState() {
            _eventBus.OnLevelStarted.Unsubscribe(EnterToWalkingState);
            _stateMachine.EnterToState<WalkState>();
        }
    }
}
