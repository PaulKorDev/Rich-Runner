using Assets._development.Scripts.Movement;
using Assets.Scripts.Architecture.ServiceLocator;
using ButchersGames;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int EarnedMoney { get; private set; }
    public PlayerMovement Movement {get; private set;}

    private LevelManager _levelManager;


    public void Init()
    {
        Movement = new PlayerMovement(this);
        _levelManager = ServiceLocator.Get<LevelManager>();
        //Init called when level is loaded/restarted
        //Set _earnedMoney to 0
    }
    private void ResetPlayer()
    {
        var currentLevel = _levelManager.Levels[_levelManager.CurrentLevelIndex];
        EarnedMoney = currentLevel.GetLevelConfig().PlayerConfig.StartMoney;
        transform.position = currentLevel.GetPlayerSpawnPosition();
    }
}
