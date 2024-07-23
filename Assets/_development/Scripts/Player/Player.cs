using Assets._development.Configs.ScriptableScripts;
using Assets._development.Scripts.Movement;
using Assets.Scripts.Architecture.Reactive;
using Assets.Scripts.Architecture.ServiceLocator;
using Assets.Scripts.Architecture.StateMachine.PlayerGameplayStateMachine;
using Assets.Scripts.Architecture.StateMachine.PlayerStatusStateMachine;
using ButchersGames;
using UnityEngine;

public class Player : MonoBehaviour, IService
{
    public ReactiveProperty<int> EarnedMoney = new(0);
    public PlayerMovement Movement {get; private set;}
    public PlayerConfig PlayerConfig { get; private set; }


    //Init once called in bootstrap
    public void Init()
    {
        SetCurrentPlayerConfig();
        SetMovement();
        StartStateMachines();
    }

    public void IncreaseMoney(int value) => EarnedMoney.Value = (value > 0) ? EarnedMoney.Value + value : throw new System.Exception("Added value must be more than 0");
    public void ReduceMoney(int value) => EarnedMoney.Value = (value > 0) ? EarnedMoney.Value - value : throw new System.Exception("Reduced value must be more than 0");
    //ResetPlayer called when level is loaded/restarted
    private void ResetPlayer()
    {
        EarnedMoney.Value = PlayerConfig.StartMoney;
        var levelManager = ServiceLocator.Get<LevelManager>();
        transform.position = levelManager.Levels[levelManager.CurrentLevelIndex].GetPlayerSpawnPosition();
        //Spawn player on checkpoint instead spawnpoint
    }

    private void SetCurrentPlayerConfig()
    {
        var levelManager = ServiceLocator.Get<LevelManager>();
        PlayerConfig = levelManager.Levels[levelManager.CurrentLevelIndex].GetLevelConfig().PlayerConfig; //Update when player move to next level
    }

    private void StartStateMachines()
    {
        new PlayerStatusStateMachineManager(this);
        GetComponent<PlayerStateMachineManager>().StartPlayerStateMachineManager();
    }
    private void SetMovement() => Movement = new PlayerMovement(this); 
}
