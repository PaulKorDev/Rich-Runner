using UnityEngine;

namespace Assets.Scripts.Architecture.StateMachine.PlayerGameplayStateMachine
{
    public sealed class LoseState : BasePlayerState
    {
        public LoseState(StateMachine<BasePlayerState> stateMachine, Animator animator) : base(stateMachine, animator)
        {
        }

        public override void Enter()
        {
        }

        public override void UpdateLogic()
        {
        }
    }
}
