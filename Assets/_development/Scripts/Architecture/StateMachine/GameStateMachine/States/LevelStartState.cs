using Assets._development.Scripts.Architecture.EventBus;
using Assets.Scripts.Architecture.ServiceLocator;
using Assets.Scripts.Architecture.StateMachine;
using UnityEngine;

namespace Assets._development.Scripts.Architecture.StateMachine.GameStateMachine.States
{
    public class LevelStartState : BaseGameState
    {
        GameplayEventBus _eventBus;

        public LevelStartState(StateMachine<BaseGameState> stateMachine) : base(stateMachine) { }

        //Enter to it state when started and restarted game
        public override void Enter()
        {
            Debug.Log("In levelStarted state");
            if (_eventBus == null) 
                _eventBus = ServiceLocator.Get<GameplayEventBus>();

            //Reset all: UI, player earned money, statuses, reset all pickups on scene...
            _eventBus.OnLevelRestarted.Trigger();
            _eventBus.OnLevelStarted.Subscribe(EnterToGameLoop);
        }

        private void EnterToGameLoop()
        {
            _eventBus.OnLevelStarted.Unsubscribe(EnterToGameLoop);
            _stateMachine.EnterToState<GameLoopState>();
        }
        
    }
}
