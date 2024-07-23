using Assets.Scripts.Architecture.ServiceLocator;
using ButchersGames;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    private int _value;
    void Start()
    {
        var levelMngr = ServiceLocator.Get<LevelManager>();
        _value = levelMngr.Levels[levelMngr.CurrentLevelIndex].GetLevelConfig().PickupsConfig.BottlesValue;
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<Player>();
        if (player != null)
        {
            player.ReduceMoney(_value);
            Destroy(gameObject);
        }
    }
}
