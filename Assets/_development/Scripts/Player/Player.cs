using Assets._development.Configs.ScriptableScripts;
using Assets._development.Scripts.Movement;
using Assets.Scripts.Architecture.ServiceLocator;
using Assets.Scripts.Architecture.StateMachine.PlayerGameplayStateMachine;
using Assets.Scripts.Architecture.StateMachine.PlayerStatusStateMachine;
using ButchersGames;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int EarnedMoney { get; private set; }
    public PlayerMovement Movement {get; private set;}
    public PlayerConfig PlayerConfig { get; private set; }


    //Init once called in bootstrap
    public void Init()
    {
        SetCurrentPlayerConfig();
        StartStateMachines();
        SetMovement();
    }

    //ResetPlayer called when level is loaded/restarted
    private void ResetPlayer()
    {
        EarnedMoney = PlayerConfig.StartMoney;
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
        new PlayerStatusStateMachineManager();
        GetComponent<PlayerStateMachineManager>().StartPlayerStateMachineManager();
    }
    private void SetMovement() => Movement = new PlayerMovement(this);
}
