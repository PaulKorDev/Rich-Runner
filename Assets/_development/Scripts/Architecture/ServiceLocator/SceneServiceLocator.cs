using Assets._development.Scripts.Architecture.EventBus;
using ButchersGames;
using UnityEngine;

namespace Assets.Scripts.Architecture.ServiceLocator
{
    public class SceneServiceLocator : MonoBehaviour
    {
        [SerializeField] private LevelManager _levelManager;
        [SerializeField] private Player _player;
        public void RegisterAllServices()
        {
            //LevelManager
            //Balance
            RegisterEventBus();
            RegisterLevelManager();
            RegisterPlayer();
        }

        private void RegisterLevelManager()
        {
            ServiceLocator.Register(_levelManager);
        }
        private void RegisterEventBus()
        {
            ServiceLocator.Register(new GameplayEventBus());
        }
        private void RegisterPlayer()
        {
            ServiceLocator.Register(_player);
        }
    }
}
