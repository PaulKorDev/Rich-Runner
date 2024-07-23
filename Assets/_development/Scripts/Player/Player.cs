using Assets._development.Configs.ScriptableScripts;
using Assets._development.Scripts.Movement;
using Assets.Scripts.Architecture.ServiceLocator;
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
        var levelManager = ServiceLocator.Get<LevelManager>();
        PlayerConfig = levelManager.Levels[levelManager.CurrentLevelIndex].GetLevelConfig().PlayerConfig; //Update when player move to next level
        
        Movement = new PlayerMovement(this);
        ResetPlayer();
    }

    //ResetPlayer called when level is loaded/restarted
    private void ResetPlayer()
    {
        EarnedMoney = PlayerConfig.StartMoney;
        //Get Current Checkpoint for spawn player
    }

}
