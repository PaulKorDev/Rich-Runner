using UnityEngine.UI;

namespace Assets.Scripts.Architecture.StateMachine.PlayerStatusStateMachine
{
    public sealed class PoorStatusState : BasePlayerStatusState
    {

        public PoorStatusState(StateMachine<BasePlayerStatusState> stateMachine) : base(stateMachine) {
        }

        public override void Enter()
        {
            //Update player model
            //Update status "poor/rich"
            //Transform animation
        }
    }
}
