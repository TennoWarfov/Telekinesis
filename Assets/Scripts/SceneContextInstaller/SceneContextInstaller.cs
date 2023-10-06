using EventBusMechanism;
using UnityEngine;
using Zenject;

public class SceneContextInstaller : MonoInstaller
{
    [SerializeField] private EventBusHolder _eventBusHolder;

    public override void InstallBindings()
    {
        BindEventBus();
    }

    private void BindEventBus()
    {
        Container.Bind<EventBusHolder>().FromInstance(_eventBusHolder).AsSingle();
    }
}
