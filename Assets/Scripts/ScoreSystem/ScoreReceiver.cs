using EventBusMechanism;
using TMPro;
using UnityEngine;
using Zenject;

public class ScoreReceiver : MonoBehaviour, IEventReceiver<ScoreEvent>
{
    public UniqueId Id { get; } = new UniqueId();

    [SerializeField] private TextMeshProUGUI _scoreText;
    
    [Inject] private readonly EventBusHolder _eventBusHolder;

    private int _playerScore;

    private void OnEnable()
    {
        _eventBusHolder.EventBus.Register(this);
    }

    private void OnDisable()
    {
        _eventBusHolder.EventBus.Unregister(this);
    }

    private void AddScore(int score)
    {
        _playerScore += score;
    }

    public void OnEvent(ScoreEvent @event)
    {
        AddScore(@event.Score);
        _scoreText.text = $"Score: {_playerScore}";
    }
}
