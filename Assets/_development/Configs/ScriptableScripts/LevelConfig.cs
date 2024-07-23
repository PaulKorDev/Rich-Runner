using Assets._development.Configs.ScriptableScripts;
using Assets.Scripts.Architecture.ServiceLocator;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "ScriptableObjects/LevelConfig")]
public class LevelConfig : ScriptableObject, IService
{
    public PickupsConfig PickupsConfig;
    public PlayerConfig PlayerConfig;
}
