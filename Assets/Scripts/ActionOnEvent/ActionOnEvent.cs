using ActionOnEventScript;
using System;
using UnityEngine;

public abstract class ActionOnEvent : MonoBehaviour
{
    [SerializeField] protected GameObject _iEventInheritor;

    private IEvent _iEvent;

    protected virtual void Awake()
    {
        _iEvent = _iEventInheritor.GetComponent<IEvent>();
        _iEvent.Event += ActionPerformance;
    }

    protected virtual void OnDestroy() => _iEvent.Event -= ActionPerformance;

    protected abstract void ActionPerformance(object obj);

    protected virtual void OnValidate()
    {
        try
        {
            if (!_iEventInheritor.TryGetComponent(out _iEvent))
                _iEventInheritor = null;
        }
        catch (Exception)
        {
            //Debug.LogError($"Assigned gameobject is not inheritor of IEvent interface. {e}");
        }
    }
}
