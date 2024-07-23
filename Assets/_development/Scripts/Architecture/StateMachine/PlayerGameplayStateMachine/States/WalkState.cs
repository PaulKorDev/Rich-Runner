using Assets._development.Scripts.Movement;
using UnityEngine;

namespace Assets.Scripts.Architecture.StateMachine.PlayerGameplayStateMachine
{
    public sealed class WalkState : BasePlayerState
    {
        PlayerMovement _playerMovement;
        public WalkState(StateMachine<BasePlayerState> stateMachine, PlayerMovement playerMovement, Animator animator) : base(stateMachine, animator)
        {
            _playerMovement = playerMovement;
        }

        public override void Enter() 
        {
            //Event subscribe to win and lose
        }

        public override void UpdateLogic()
        {
            _playerMovement.Move();
        }
    }
}
