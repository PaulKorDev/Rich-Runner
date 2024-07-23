namespace Assets.Scripts.Architecture.StateMachine.PlayerGameplayStateMachine
{
    public sealed class IdleState : BasePlayerState
    {

        public IdleState(StateMachine<BasePlayerState> stateMachine) : base(stateMachine) {
        }

        public override void Enter()
        {
            //Update player model
            //Update status "poor/rich"
            //Transform animation
        }
    }
}
