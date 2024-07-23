using UnityEngine;

namespace Assets.Scripts.Architecture.StateMachine
{
    public class PlayerStateMachineManager : MonoBehaviour
    {
        private StateMachine<BasePlayerState> _playerStateMachineManager = new StateMachine<BasePlayerState>();

        private void Awake()
        {
            AddStates();
            _playerStateMachineManager.EnterToState<IdleState>();
        }

        private void AddStates()
        {
            _playerStateMachineManager.AddState(new IdleState(_playerStateMachineManager));
            _playerStateMachineManager.AddState(new WalkState(_playerStateMachineManager));
            _playerStateMachineManager.AddState(new WinState(_playerStateMachineManager));
            _playerStateMachineManager.AddState(new LoseState(_playerStateMachineManager));
        }
    }
}
