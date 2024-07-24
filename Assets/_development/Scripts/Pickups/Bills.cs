using Assets.Scripts.Architecture.ServiceLocator;
using ButchersGames;
using UnityEngine;

public class Bills : MonoBehaviour
{
    private int _value;
    private int _minValue;
    private int _maxValue;
    void Start()
    {
        var levelMngr = ServiceLocator.Get<LevelManager>();
        _minValue = levelMngr.Levels[levelMngr.CurrentLevelIndex].GetLevelConfig().PickupsConfig.BillsValueMin;
        _maxValue = levelMngr.Levels[levelMngr.CurrentLevelIndex].GetLevelConfig().PickupsConfig.BillsValueMax;
        _value = Random.Range(_minValue, _maxValue);
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<Player>();
        if (player != null)
        {
            player.IncreaseMoney(_value);
            Destroy(gameObject);
        }
    }
}
