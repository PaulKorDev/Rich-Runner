using UnityEngine;

namespace Assets.Scripts.Architecture.StateMachine.PlayerStatusStateMachine
{
    public class PlayerStatusStateMachineManager
    {
        private StateMachine<BasePlayerStatusState> _playerStatusStateMachine = new StateMachine<BasePlayerStatusState>();

        public PlayerStatusStateMachineManager()
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
