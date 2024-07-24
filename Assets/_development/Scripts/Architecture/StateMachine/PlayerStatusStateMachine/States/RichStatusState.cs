using Assets._development.Scripts.Architecture.EventBus;
using UnityEngine;

namespace Assets.Scripts.Architecture.StateMachine.PlayerStatusStateMachine
{
    public sealed class RichStatusState : BasePlayerStatusState
    {
        private GameplayEventBus _eventBus;
        private int _richModelIndex = 2;
        private GameObject[] _models;
        public RichStatusState(StateMachine<BasePlayerStatusState> stateMachine, Animator animator, GameObject[] statusModels) : base(stateMachine, animator)
        {
            _eventBus = ServiceLocator.ServiceLocator.Get<GameplayEventBus>();
            _models = statusModels;
            _eventBus.OnBecomeCasual.Subscribe(EnterToCasualState);
        }

        public override void Enter()
        {
            Debug.Log("RichStatusState");
            TurnOnModel(_richModelIndex, _models);
            _animator.SetTrigger("TrWalking");
        }
        private void EnterToCasualState()
        {
            //_eventBus.OnBecomeCasual.Unsubscribe(EnterToCasualState);
            _stateMachine.EnterToState<CasualStatusState>();
        }
    }
}
