using Assets._development.Scripts.Architecture.EventBus;
using UnityEngine;

namespace Assets.Scripts.Architecture.StateMachine.PlayerStatusStateMachine
{
    public sealed class CasualStatusState : BasePlayerStatusState
    {
        private GameplayEventBus _eventBus;
        private int _casualModelIndex = 1;
        private GameObject[] _models;
        public CasualStatusState(StateMachine<BasePlayerStatusState> stateMachine, Animator animator, GameObject[] statusModels) : base(stateMachine, animator) {
            _eventBus = ServiceLocator.ServiceLocator.Get<GameplayEventBus>();
            _models = statusModels;
            _eventBus.OnBecomeRich.Subscribe(EnterToRichState);
            _eventBus.OnBecomePoor.Subscribe(EnterToPoorState);
        }

        public override void Enter()
        {
            Debug.Log("CasualStatusState");
            _animator.SetTrigger("TrWalking");
            TurnOnModel(_casualModelIndex, _models);
            //Update player model
            //Update status "poor/rich"
            //Transform animation
        }
        private void EnterToRichState()
        {
            //_eventBus.OnBecomeRich.Unsubscribe(EnterToRichState);
            _stateMachine.EnterToState<RichStatusState>();
        }
        private void EnterToPoorState()
        {
            //_eventBus.OnBecomePoor.Unsubscribe(EnterToPoorState);
            _stateMachine.EnterToState<PoorStatusState>();
        }
    }
}
