using Assets._development.Scripts.Architecture.EventBus;
using Assets.Scripts.Architecture.ServiceLocator;
using ButchersGames;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._development.Scripts.View
{
    public class UIRootView : MonoBehaviour
    {
        [SerializeField] private GameObject _mainUI;
        [SerializeField] private GameObject _levelUI;
        [SerializeField] private Text _levelCountText;
        [SerializeField] private Text _earnedMoneyText;
        public void InitUIRoot()
        {
            ServiceLocator.Get<GameplayEventBus>().OnLevelStarted.Subscribe(HideMainUI);
            ServiceLocator.Get<GameplayEventBus>().OnLevelStarted.Subscribe(ShowLevelUI);
            ServiceLocator.Get<GameplayEventBus>().OnLevelRestarted.Subscribe(DisplayLevel);
            ServiceLocator.Get<Player>().EarnedMoney.OnChanged += DisplayEarnedMoney;
        }

        private void ShowMainUI()
        {
            _mainUI.SetActive(true);
        }
        private void HideMainUI()
        {
            _mainUI.SetActive(false);
        }
        private void ShowLevelUI()
        {
            _levelUI.SetActive(true);
        }
        private void HideLevelUI()
        {
            _levelUI.SetActive(false);
        }

        private void DisplayLevel()
        {
            var currentLevel = ServiceLocator.Get<LevelManager>().CurrentLevelIndex + 1;
            _levelCountText.text = currentLevel.ToString();
        }
        private void DisplayEarnedMoney(int value)
        {
            _earnedMoneyText.text = value.ToString();
        }
    }
}
