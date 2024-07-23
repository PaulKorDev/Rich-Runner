using UnityEngine;

namespace Assets.Scripts.Architecture.StateMachine.PlayerGameplayStateMachine
{
    public sealed class LoseState : BasePlayerState
    {
        public LoseState(StateMachine<BasePlayerState> stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            Debug.Log("LoseState");

        }

        public override void UpdateLogic()
        {
        }
    }
}
