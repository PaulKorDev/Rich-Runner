using Assets._development.Scripts.Architecture.EventBus;
using Assets.Scripts.Architecture.ServiceLocator;
using UnityEngine;

namespace Assets.Scripts.Architecture.StateMachine.PlayerStatusStateMachine
{
    public sealed class PoorStatusState : BasePlayerStatusState
    {
        private Animator _animator;
        private GameplayEventBus _eventBus;
        public PoorStatusState(StateMachine<BasePlayerStatusState> stateMachine, Animator animator) : base(stateMachine) {
            _animator = animator;
            _eventBus = ServiceLocator.ServiceLocator.Get<GameplayEventBus>();
            _eventBus.OnBecomeCasual.Subscribe(EnterToCasualState);
        }

        public override void Enter()
        {
            Debug.Log("PoorStatusState");

            _animator.SetTrigger("TrSadWalk");
            //Update player model
            //Update status "poor/rich"
            //Transform animation

        }
        private void EnterToCasualState()
        {
            _eventBus.OnBecomeCasual.Unsubscribe(EnterToCasualState);
            _stateMachine.EnterToState<CasualStatusState>();
        }
    }
}
