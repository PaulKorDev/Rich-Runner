using Assets.Scripts.Architecture.StateMachine;

namespace Assets._development.Scripts.Architecture.StateMachine.GameStateMachine
{
    abstract public class BaseGameState : IState
    {
        protected StateMachine<BaseGameState> _stateMachine;
        public BaseGameState(StateMachine<BaseGameState> stateMachine)
        {
            _stateMachine = stateMachine;
        }
        abstract public void Enter();
    }
}
