using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Architecture.StateMachine
{
    public class PlayerStatusStateMachineManager : MonoBehaviour
    {
        private Text _mainText;
        private StateMachine<BasePlayerStatusState> _concreteStateMachine = new StateMachine<BasePlayerStatusState>();

        private void Awake()
        {
            _mainText = GetComponent<Text>();

            AddStates();
            _concreteStateMachine.EnterToState<PoorStatusState>();
        }

        private void AddStates()
        {
            _concreteStateMachine.AddState(new PoorStatusState(_concreteStateMachine));
            _concreteStateMachine.AddState(new RichStatusState(_concreteStateMachine));
        }
    }
}
