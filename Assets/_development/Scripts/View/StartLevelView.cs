using Assets._development.Scripts.Architecture.EventBus;
using Assets.Scripts.Architecture.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class StartLevelView : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnStartAreaClicked);
    }

    private void OnStartAreaClicked()
    {
        ServiceLocator.Get<GameplayEventBus>().OnLevelStarted.Trigger();
    }

}
