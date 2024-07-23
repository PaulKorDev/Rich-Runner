namespace Assets.Scripts.Architecture.StateMachine.PlayerStatusStateMachine
{
    public sealed class RichStatusState : BasePlayerStatusState
    {
        public RichStatusState(StateMachine<BasePlayerStatusState> stateMachine) : base(stateMachine) {
        }

        public override void Enter()
        {
        }

    }
}
