using Assets._development.Scripts.Architecture.EventBus;
using UnityEngine;

namespace Assets.Scripts.Architecture.StateMachine.PlayerStatusStateMachine
{
    public sealed class CasualStatusState : BasePlayerStatusState
    {
        private GameplayEventBus _eventBus;
        private Animator _animator;
        public CasualStatusState(StateMachine<BasePlayerStatusState> stateMachine, Animator animator) : base(stateMachine) {
            _animator = animator;
            _eventBus = ServiceLocator.ServiceLocator.Get<GameplayEventBus>();
            _eventBus.OnBecomeRich.Subscribe(EnterToRichState);
            _eventBus.OnBecomePoor.Subscribe(EnterToPoorState);
        }

        public override void Enter()
        {
            Debug.Log("CasualStatusState");
            _animator.SetTrigger("TrWalking");
            //Update player model
            //Update status "poor/rich"
            //Transform animation
        }
        private void EnterToRichState()
        {
            _eventBus.OnBecomeRich.Unsubscribe(EnterToRichState);
            _stateMachine.EnterToState<RichStatusState>();
        }
        private void EnterToPoorState()
        {
            _eventBus.OnBecomePoor.Unsubscribe(EnterToPoorState);
            _stateMachine.EnterToState<PoorStatusState>();
        }
    }
}
