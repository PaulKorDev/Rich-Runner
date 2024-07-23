namespace Assets.Scripts.Architecture.StateMachine.PlayerGameplayStateMachine
{
    public sealed class LoseState : BasePlayerState
    {
        public LoseState(StateMachine<BasePlayerState> stateMachine) : base(stateMachine) {
        }

        public override void Enter()
        {
        }

    }
}
