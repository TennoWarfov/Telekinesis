using EventBusMechanism;
using UnityEngine;
using Zenject;

public class ScoreSender : MonoBehaviour
{
    [SerializeField] protected int _score;
    [Inject] private readonly EventBusHolder _eventBusHolder;

    protected virtual void SendScore()
    {
        _eventBusHolder.EventBus.Raise(new ScoreEvent(_score));
    }
}
