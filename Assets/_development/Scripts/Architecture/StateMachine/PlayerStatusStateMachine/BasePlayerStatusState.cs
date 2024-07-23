﻿namespace Assets.Scripts.Architecture.StateMachine.PlayerStatusStateMachine
{
    public abstract class BasePlayerStatusState : IState
    {
        protected StateMachine<BasePlayerStatusState> _stateMachine;
        public BasePlayerStatusState(StateMachine<BasePlayerStatusState> stateMachine) {
            _stateMachine = stateMachine;
        }

        public abstract void Enter();

    }
}
