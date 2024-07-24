using Assets._development.Scripts.Architecture.EventBus;
using Assets.Scripts.Architecture.ServiceLocator;
using UnityEngine;

namespace Assets._development.Scripts.View
{
    public class UIRootView : MonoBehaviour
    {
        private void Start()
        {
            ServiceLocator.Get<GameplayEventBus>().OnLevelStarted.Subscribe(HideMainUI);
        }

        private void ShowMainUI()
        {
            gameObject.SetActive(true);
        }
        private void HideMainUI()
        {
            gameObject.SetActive(false);
        }
    }
}
