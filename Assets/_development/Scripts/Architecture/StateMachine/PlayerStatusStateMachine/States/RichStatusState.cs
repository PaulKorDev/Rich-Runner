using UnityEngine;

namespace Assets.Scripts.Architecture.StateMachine.PlayerStatusStateMachine
{
    public sealed class RichStatusState : BasePlayerStatusState
    {
        private Animator _animator;
        public RichStatusState(StateMachine<BasePlayerStatusState> stateMachine, Animator animator) : base(stateMachine) {
            _animator = animator;
        }

        public override void Enter()
        {
            Debug.Log("RichStatusState");

            _animator.SetTrigger("TrWalking");
        }

    }
}
