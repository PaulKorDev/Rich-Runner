using UnityEngine;

namespace Assets.Scripts.Architecture.StateMachine
{
    public class PlayerStatusStateMachineManager : MonoBehaviour
    {
        private StateMachine<BasePlayerStatusState> _playerStatusStateMachine = new StateMachine<BasePlayerStatusState>();

        private void Awake()
        {
            AddStates();
            _playerStatusStateMachine.EnterToState<PoorStatusState>();
        }

        private void AddStates()
        {
            _playerStatusStateMachine.AddState(new PoorStatusState(_playerStatusStateMachine));
            _playerStatusStateMachine.AddState(new RichStatusState(_playerStatusStateMachine));
        }
    }
}
