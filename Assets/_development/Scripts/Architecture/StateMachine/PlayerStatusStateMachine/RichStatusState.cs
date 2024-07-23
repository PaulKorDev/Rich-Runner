namespace Assets.Scripts.Architecture.StateMachine
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
