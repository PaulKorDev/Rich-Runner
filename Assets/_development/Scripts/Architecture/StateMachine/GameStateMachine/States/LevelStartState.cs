using Assets._development.Scripts.Architecture.ServiceLocator;
using Assets.Scripts.Architecture.StateMachine;

namespace Assets._development.Scripts.Architecture.StateMachine.GameStateMachine.States
{
    public class LevelStartState : BaseGameState
    {
        public LevelStartState(StateMachine<BaseGameState> stateMachine) : base(stateMachine) { }

        public override void Enter()
        {
            //Reset all: player earned money, statuses, reset all pickups on scene...
            //Enter to it state when started and restarted game
        }
    }
}
