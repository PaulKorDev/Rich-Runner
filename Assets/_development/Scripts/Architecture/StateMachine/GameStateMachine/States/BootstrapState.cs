using Assets._development.Scripts.Architecture.ServiceLocator;
using Assets.Scripts.Architecture.StateMachine;

namespace Assets._development.Scripts.Architecture.StateMachine.GameStateMachine.States
{
    public class BootstrapState : BaseGameState
    {
        private SceneServiceLocator _sceneServiceLocator;

        public BootstrapState(StateMachine<BaseGameState> stateMachine, SceneServiceLocator serviceLocator) : base(stateMachine) 
        {
            _sceneServiceLocator = serviceLocator;
        }

        public override void Enter()
        {
            _sceneServiceLocator.RegisterAllServices();

            //Init something
        }
    }
}
