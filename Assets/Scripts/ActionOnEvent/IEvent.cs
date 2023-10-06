namespace ActionOnEventScript
{
    public interface IEvent
    {
        public delegate void EventDelegate(object obj);

        public EventDelegate Event { get; set; }
    }
}