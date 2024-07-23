using Assets._development.Scripts.Architecture.EventBus;
using Assets.Scripts.Architecture.ServiceLocator;
using ButchersGames;
using UnityEngine;

namespace Assets._development.Scripts.Mechanics.PlayerStatus
{
    public class MoneyStatus
    {
        private PlayerStatuses _currentStatus = PlayerStatuses.Poor;

        private int _moneyToBecomeCasual;
        private int _moneyToBecomeRich;

        private GameplayEventBus _eventBus;

        public MoneyStatus()
        {
            _eventBus = ServiceLocator.Get<GameplayEventBus>();

            ServiceLocator.Get<Player>().EarnedMoney.OnChanged += CheckStatus;
            SetLimits();
        }

        private void CheckStatus(int money)
        {
            Debug.Log(money);
            if (money >= _moneyToBecomeRich && _currentStatus != PlayerStatuses.Rich)
            {
                _eventBus.OnBecomeRich.Trigger();
                _currentStatus = PlayerStatuses.Rich;
            } else if (money >= _moneyToBecomeCasual && _currentStatus != PlayerStatuses.Casual)
            {
                _eventBus.OnBecomeCasual.Trigger();
                _currentStatus = PlayerStatuses.Casual;
            } else if (money < _moneyToBecomeCasual && _currentStatus != PlayerStatuses.Poor)
            {
                _eventBus.OnBecomePoor.Trigger();
                _currentStatus = PlayerStatuses.Poor;
            }
        }

        private void SetLimits()
        {
            var lvlMngr = ServiceLocator.Get<LevelManager>();
            var playerConfig = lvlMngr.Levels[lvlMngr.CurrentLevelIndex].GetLevelConfig().PlayerConfig;
            _moneyToBecomeCasual = playerConfig.MoneyToBecomeCasual;
            _moneyToBecomeRich = playerConfig.MoneyToBecomeRich;
        }
    }
}
