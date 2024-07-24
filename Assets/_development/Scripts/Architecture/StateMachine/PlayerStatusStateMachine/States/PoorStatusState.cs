using Assets._development.Scripts.Architecture.EventBus;
using Assets.Scripts.Architecture.ServiceLocator;
using UnityEngine;

namespace Assets.Scripts.Architecture.StateMachine.PlayerStatusStateMachine
{
    public sealed class PoorStatusState : BasePlayerStatusState
    {
        private GameplayEventBus _eventBus;
        private int _poorModelIndex = 0;
        private GameObject[] _models;
        public PoorStatusState(StateMachine<BasePlayerStatusState> stateMachine, Animator animator, GameObject[] statusModels) : base(stateMachine, animator)
        {
            _eventBus = ServiceLocator.ServiceLocator.Get<GameplayEventBus>();
            _models = statusModels;
            _eventBus.OnBecomeCasual.Subscribe(EnterToCasualState);
        }

        public override void Enter()
        {
            Debug.Log("PoorStatusState");
            TurnOnModel(_poorModelIndex, _models);
            _animator.SetTrigger("TrSadWalk");
            //Update player model
            //Update status "poor/rich"
            //Transform animation

        }
        private void EnterToCasualState()
        {
            //_eventBus.OnBecomeCasual.Unsubscribe(EnterToCasualState);
            _stateMachine.EnterToState<CasualStatusState>();
        }
    }
}
