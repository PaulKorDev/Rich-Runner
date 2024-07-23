using Assets.Scripts.Architecture.StateMachine;

namespace Assets._development.Scripts.Architecture.StateMachine.GameStateMachine.States
{
    public class LevelEndState : BaseGameState
    {
        public LevelEndState(StateMachine<BaseGameState> stateMachine) : base(stateMachine) { }

        public override void Enter()
        {
            //Show defeat or win window
            //Show all results, statistics, etc
        }
    }
}
