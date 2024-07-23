using Assets._development.Scripts.Architecture.EventBus;
using UnityEngine;

namespace Assets.Scripts.Architecture.StateMachine.PlayerGameplayStateMachine
{
    public sealed class WinState : BasePlayerState
    {
        private Animator _animator;
        public WinState(StateMachine<BasePlayerState> stateMachine, Animator animator) : base(stateMachine)
        {
            _animator = animator;
        }

        public override void Enter()
        {
            Debug.Log("In win state");
            _animator.SetTrigger("TrWin");
        }

        public override void UpdateLogic()
        {
        }


    }
}
