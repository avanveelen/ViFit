namespace ViFit.Domain
{
    public class SerializedEvent
    {
        public SerializedEvent(string eventName, string eventData)
        {
            this.EventName = eventName;
            this.EventData = eventData;
        }

        public string EventName { get; }

        public string EventData { get; }
    }
}
