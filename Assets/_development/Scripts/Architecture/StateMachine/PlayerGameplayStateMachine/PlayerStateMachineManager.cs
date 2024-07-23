using UnityEngine;

namespace Assets.Scripts.Architecture.StateMachine.PlayerGameplayStateMachine
{
    public class PlayerStateMachineManager : MonoBehaviour
    {
        private StateMachine<BasePlayerState> _playerStateMachineManager = new StateMachine<BasePlayerState>();

        public void StartPlayerStateMachineManager()
        {
            AddStates(GetComponent<Animator>());
            _playerStateMachineManager.EnterToState<IdleState>();
        }

        private void AddStates(Animator animator)
        {
            _playerStateMachineManager.AddState(new IdleState(_playerStateMachineManager, animator));
            _playerStateMachineManager.AddState(new WalkState(_playerStateMachineManager, GetComponent<Player>().Movement, animator));
            _playerStateMachineManager.AddState(new WinState(_playerStateMachineManager, animator));
            _playerStateMachineManager.AddState(new LoseState(_playerStateMachineManager, animator));
        }
    }
}
