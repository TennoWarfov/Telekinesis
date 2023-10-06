using UnityEngine;

namespace EventBusMechanism
{
    public class EventBusHolder : MonoBehaviour
    {
        public EventBus EventBus { get; private set; }

        private void Awake() => EventBus = new EventBus();
    }
}