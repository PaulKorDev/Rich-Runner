using Assets._development.Scripts.Mechanics.PlayerStatus;
using Assets._development.Scripts.View;
using Assets.Scripts.Architecture.ServiceLocator;
using Assets.Scripts.Architecture.StateMachine;

namespace Assets._development.Scripts.Architecture.StateMachine.GameStateMachine.States
{
    public class BootstrapState : BaseGameState
    {
        private SceneServiceLocator _sceneServiceLocator;
        private UIRootView _rootView;

        public BootstrapState(StateMachine<BaseGameState> stateMachine, SceneServiceLocator serviceLocator, UIRootView uIRootView) : base(stateMachine) 
        {
            _sceneServiceLocator = serviceLocator;
            _rootView = uIRootView;
        }

        public override void Enter()
        {
            RegisterGameServices();
            InitAll();
            _stateMachine.EnterToState<LevelStartState>();
        }

        private void RegisterGameServices() => _sceneServiceLocator.RegisterAllServices();
        private void InitAll()
        {
            ServiceLocator.Get<Player>().Init();
            new MoneyStatus();
            _rootView.InitUIRoot();
        }
    }

}
