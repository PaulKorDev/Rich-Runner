namespace Assets.Scripts.Architecture.StateMachine
{
    public abstract class BasePlayerState : IState
    {
        protected StateMachine<BasePlayerState> _stateMachine;
        public BasePlayerState(StateMachine<BasePlayerState> stateMachine) {
            _stateMachine = stateMachine;
        }

        public abstract void Enter();

    }
}
