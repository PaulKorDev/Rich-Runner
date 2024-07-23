namespace Assets.Scripts.Architecture.StateMachine
{
    public sealed class WinState : BasePlayerState
    {
        public WinState(StateMachine<BasePlayerState> stateMachine) : base(stateMachine) {
        }

        public override void Enter()
        {
        }

    }
}
