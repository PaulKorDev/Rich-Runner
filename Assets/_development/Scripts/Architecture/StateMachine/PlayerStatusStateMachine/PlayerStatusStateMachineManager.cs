using Assets._development.Scripts.Architecture.EventBus;
using UnityEngine;

namespace Assets.Scripts.Architecture.StateMachine.PlayerStatusStateMachine
{
    public class PlayerStatusStateMachineManager : MonoBehaviour
    {
        private StateMachine<BasePlayerStatusState> _playerStatusStateMachine = new StateMachine<BasePlayerStatusState>();
        [SerializeField] private GameObject[] _statusModels;


        public void StartPlayerStatusStateMachineManager()
        {
            var player = GetComponent<Player>();
            AddStates(player.GetComponent<Animator>(), player);
            ServiceLocator.ServiceLocator.Get<GameplayEventBus>().OnLevelStarted.Subscribe(EnterToPoorState);
        }

        private void AddStates(Animator animator, Player player)
        {
            _playerStatusStateMachine.AddState(new PoorStatusState(_playerStatusStateMachine, animator, _statusModels));
            _playerStatusStateMachine.AddState(new CasualStatusState(_playerStatusStateMachine, animator, _statusModels));
            _playerStatusStateMachine.AddState(new RichStatusState(_playerStatusStateMachine, animator, _statusModels));
        }

        private void EnterToPoorState()
        {
            ServiceLocator.ServiceLocator.Get<GameplayEventBus>().OnLevelStarted.Unsubscribe(EnterToPoorState);
            _playerStatusStateMachine.EnterToState<PoorStatusState>();
        }
    }
}
