using Assets._development.Scripts.Architecture.EventBus;
using UnityEngine;

namespace Assets.Scripts.Architecture.StateMachine.PlayerStatusStateMachine
{
    public sealed class RichStatusState : BasePlayerStatusState
    {
        private Animator _animator;
        private GameplayEventBus _eventBus;
        public RichStatusState(StateMachine<BasePlayerStatusState> stateMachine, Animator animator) : base(stateMachine) {
            _animator = animator;
            _eventBus = ServiceLocator.ServiceLocator.Get<GameplayEventBus>();
            _eventBus.OnBecomeCasual.Subscribe(EnterToPoorState);
        }

        public override void Enter()
        {
            Debug.Log("RichStatusState");

            _animator.SetTrigger("TrWalking");
        }
        private void EnterToPoorState()
        {
            _eventBus.OnBecomeCasual.Unsubscribe(EnterToPoorState);
            _stateMachine.EnterToState<PoorStatusState>();
        }
    }
}
