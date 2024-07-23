using Assets.Scripts.Architecture.EventBus;

namespace Assets._development.Scripts.Architecture.EventBus
{
    public class GameplayEventBus
    {
        //Called when player move to next level or dead
        public CustomEvent OnLevelRestarted { get; } = new CustomEvent();
        //Called when player click to screen
        public CustomEvent OnLevelStarted { get; } = new CustomEvent();
    }
}
