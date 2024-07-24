using UnityEngine;
using Assets.Scripts.Architecture.StateMachine;
using Assets._development.Scripts.Architecture.StateMachine.GameStateMachine;
using Assets._development.Scripts.Architecture.StateMachine.GameStateMachine.States;
using Assets.Scripts.Architecture.ServiceLocator;
using Assets._development.Scripts.View;

public class GameStateMachineManager : MonoBehaviour
{
    [SerializeField] private SceneServiceLocator _sceneServiceLocator;
    [SerializeField] private UIRootView _uiRoot;

    private StateMachine<BaseGameState> _gameStateMachineManager = new StateMachine<BaseGameState>();

    private void Awake()
    {
        AddStates();
        _gameStateMachineManager.EnterToState<BootstrapState>();
    }

    private void AddStates()
    {
        _gameStateMachineManager.AddState(new BootstrapState(_gameStateMachineManager, _sceneServiceLocator, _uiRoot));
        _gameStateMachineManager.AddState(new LevelStartState(_gameStateMachineManager));
        _gameStateMachineManager.AddState(new GameLoopState(_gameStateMachineManager));
        _gameStateMachineManager.AddState(new LevelEndState(_gameStateMachineManager));
    }
}
