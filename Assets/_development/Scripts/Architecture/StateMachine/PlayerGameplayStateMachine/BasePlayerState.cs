using UnityEngine;

namespace Assets.Scripts.Architecture.StateMachine.PlayerGameplayStateMachine
{
    public abstract class BasePlayerState : IState, ILogicState
    {
        protected StateMachine<BasePlayerState> _stateMachine;
        public BasePlayerState(StateMachine<BasePlayerState> stateMachine) {
            _stateMachine = stateMachine;
        }

        public abstract void Enter();

        public abstract void UpdateLogic();
    }
}
