using UnityEngine;

namespace Assets.Scripts.Architecture.StateMachine.PlayerGameplayStateMachine
{
    public abstract class BasePlayerState : IState, ILogicState
    {
        protected StateMachine<BasePlayerState> _stateMachine;
        protected Animator _animator;
        public BasePlayerState(StateMachine<BasePlayerState> stateMachine, Animator animator) {
            _stateMachine = stateMachine;
            _animator = animator;
        }

        public abstract void Enter();

        public abstract void UpdateLogic();
    }
}
