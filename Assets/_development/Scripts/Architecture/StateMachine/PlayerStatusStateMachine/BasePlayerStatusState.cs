using UnityEngine;

namespace Assets.Scripts.Architecture.StateMachine.PlayerStatusStateMachine
{
    public abstract class BasePlayerStatusState : IState
    {
        protected StateMachine<BasePlayerStatusState> _stateMachine;
        protected Animator _animator;
        public BasePlayerStatusState(StateMachine<BasePlayerStatusState> stateMachine, Animator animator) {
            _stateMachine = stateMachine;
            _animator = animator;
        }

        public abstract void Enter();

        protected void TurnOnModel(int index, GameObject[] models)
        {
            for (int i = 0; i < models.Length; i++) { 
                bool active = index == i;
                models[i].SetActive(active);
            }
        }
    }
}
