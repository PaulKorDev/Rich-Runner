using Assets.Scripts.Architecture.EventBus;
using Assets.Scripts.Architecture.ServiceLocator;

namespace Assets._development.Scripts.Architecture.EventBus
{
    public class GameplayEventBus : IService
    {
        //Called when player move to next level or dead
        public CustomEvent OnLevelRestarted { get; } = new CustomEvent();
        //Called when player click to screen
        public CustomEvent OnLevelStarted { get; } = new CustomEvent();
        public CustomEvent OnPlayerWon { get; } = new CustomEvent();
        public CustomEvent OnPlayerLost { get; } = new CustomEvent();
        public CustomEvent OnBecomeCasual { get; } = new CustomEvent();
        public CustomEvent OnBecomeRich { get; } = new CustomEvent();
        public CustomEvent OnBecomePoor { get; } = new CustomEvent();
    }
}
