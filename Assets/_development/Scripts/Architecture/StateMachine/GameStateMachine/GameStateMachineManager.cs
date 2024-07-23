using Assets.Scripts.Architecture.StateMachine.PlayerGameplayStateMachine;
using Assets.Scripts.Architecture.StateMachine;
using UnityEngine;
using Assets._development.Scripts.Architecture.StateMachine.GameStateMachine;
using Assets._development.Scripts.Architecture.StateMachine.GameStateMachine.States;
using Assets._development.Scripts.Architecture.ServiceLocator;

public class GameStateMachineManager : MonoBehaviour
{
    [SerializeField] private SceneServiceLocator _sceneServiceLocator;

    private StateMachine<BaseGameState> _gameStateMachineManager = new StateMachine<BaseGameState>();

    private void Awake()
    {
        AddStates();
        _gameStateMachineManager.EnterToState<BootstrapState>();
    }

    private void AddStates()
    {
        _gameStateMachineManager.AddState(new BootstrapState(_gameStateMachineManager, _sceneServiceLocator));

    }
}
