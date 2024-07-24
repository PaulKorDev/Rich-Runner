using Assets._development.Scripts.Architecture.EventBus;
using Assets.Scripts.Architecture.ServiceLocator;
using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerStatusView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _statusText;
    [SerializeField] private GameObject _status;

    private void Start()
    {
        var eventBus = ServiceLocator.Get<GameplayEventBus>();
        eventBus.OnLevelStarted.Subscribe(ShowStatus);
        eventBus.OnLevelStarted.Subscribe(SetPoorStatus);
        eventBus.OnBecomePoor.Subscribe(SetPoorStatus);
        eventBus.OnBecomeCasual.Subscribe(SetCasualStatus);
        eventBus.OnBecomeRich.Subscribe(SetRichStatus);
    }

    private void ShowStatus()
    {
        _status.SetActive(true);
    }

    private void SetPoorStatus()
    {
        _statusText.text = "БЕДНЫЙ";
        _statusText.color = Color.red;
    }
    private void SetCasualStatus()
    {
        _statusText.text = "ПРОЦВЕТАЮЩИЙ";
        _statusText.color = Color.yellow;
    }
    private void SetRichStatus()
    {
        _statusText.text = "БОГАТЫЙ";
        _statusText.color = Color.green;
    }
}
