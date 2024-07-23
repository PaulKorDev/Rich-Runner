using Assets.Scripts.Architecture.ServiceLocator;
using Assets.Scripts.Architecture.StateMachine;

namespace Assets._development.Scripts.Architecture.StateMachine.GameStateMachine.States
{
    public class BootstrapState : BaseGameState
    {
        private SceneServiceLocator _sceneServiceLocator;
        private Player _player;

        public BootstrapState(StateMachine<BaseGameState> stateMachine, SceneServiceLocator serviceLocator, Player player) : base(stateMachine) 
        {
            _sceneServiceLocator = serviceLocator;
            _player = player;
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
            _player.Init();
        }
    }

}
