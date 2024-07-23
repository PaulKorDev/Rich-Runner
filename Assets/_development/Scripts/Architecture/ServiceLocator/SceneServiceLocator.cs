using Assets._development.Scripts.Architecture.EventBus;
using ButchersGames;
using UnityEngine;

namespace Assets.Scripts.Architecture.ServiceLocator
{
    public class SceneServiceLocator : MonoBehaviour
    {
        [SerializeField] private LevelManager _levelManager;
        public void RegisterAllServices()
        {
            //LevelManager
            //Balance
            RegisterEventBus();
            RegisterLevelManager();
        }

        private void RegisterLevelManager()
        {
            ServiceLocator.Register(_levelManager);
        }
        private void RegisterEventBus()
        {
            ServiceLocator.Register(new GameplayEventBus());
        }
    }
}
