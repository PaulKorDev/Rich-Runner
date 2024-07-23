using UnityEngine;

namespace Assets.Scripts.Architecture.StateMachine.PlayerStatusStateMachine
{
    public sealed class PoorStatusState : BasePlayerStatusState
    {
        private Animator _animator;
        public PoorStatusState(StateMachine<BasePlayerStatusState> stateMachine, Animator animator) : base(stateMachine) {
            _animator = animator;
        }

        public override void Enter()
        {
            Debug.Log("PoorStatusState");

            _animator.SetTrigger("TrSadWalk");
            //Update player model
            //Update status "poor/rich"
            //Transform animation
        }
    }
}
