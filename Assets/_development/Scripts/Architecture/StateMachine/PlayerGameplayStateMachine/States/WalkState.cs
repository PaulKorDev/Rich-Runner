using Assets._development.Scripts.Architecture.EventBus;
using Assets._development.Scripts.Movement;
using UnityEngine;

namespace Assets.Scripts.Architecture.StateMachine.PlayerGameplayStateMachine
{
    public sealed class WalkState : BasePlayerState
    {
        PlayerMovement _playerMovement;
        private GameplayEventBus _eventBus;

        public WalkState(StateMachine<BasePlayerState> stateMachine, PlayerMovement playerMovement) : base(stateMachine)
        {
            _playerMovement = playerMovement;
            _eventBus = ServiceLocator.ServiceLocator.Get<GameplayEventBus>();
        }

        public override void Enter() 
        {
            Debug.Log("WalkState");
            //Event subscribe to win and lose
            _eventBus.OnPlayerWon.Subscribe(EnterToWinState);
        }

        public override void UpdateLogic()
        {
            _playerMovement.Move();
        }
        private void EnterToWinState()
        {
            _eventBus.OnPlayerWon.Unsubscribe(EnterToWinState);
            Debug.Log("EnterToWinState");
            _stateMachine.EnterToState<WinState>();
        }
    }
}
