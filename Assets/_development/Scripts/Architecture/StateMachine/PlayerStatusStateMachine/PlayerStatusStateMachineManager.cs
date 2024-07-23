using Assets._development.Scripts.Architecture.EventBus;
using UnityEngine;

namespace Assets.Scripts.Architecture.StateMachine.PlayerStatusStateMachine
{
    public class PlayerStatusStateMachineManager
    {
        private StateMachine<BasePlayerStatusState> _playerStatusStateMachine = new StateMachine<BasePlayerStatusState>();

        public PlayerStatusStateMachineManager(Player player)
        {
            AddStates(player.GetComponent<Animator>());
            ServiceLocator.ServiceLocator.Get<GameplayEventBus>().OnLevelStarted.Subscribe(EnterToPoorState);
        }

        private void AddStates(Animator animator)
        {
            _playerStatusStateMachine.AddState(new PoorStatusState(_playerStatusStateMachine, animator));
            _playerStatusStateMachine.AddState(new CasualStatusState(_playerStatusStateMachine, animator));
            _playerStatusStateMachine.AddState(new RichStatusState(_playerStatusStateMachine, animator));
        }

        private void EnterToPoorState()
        {
            ServiceLocator.ServiceLocator.Get<GameplayEventBus>().OnLevelStarted.Unsubscribe(EnterToPoorState);
            _playerStatusStateMachine.EnterToState<PoorStatusState>();
        }
    }
}
