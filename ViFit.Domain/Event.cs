using System;

namespace ViFit.Domain
{
    public sealed class Event
    {
        public Event(IDomainEvent data, DateTime timestamp, int version)
        {
            this.Data = data;
            this.Timestamp = timestamp;
            this.Version = version;
        }

        public IDomainEvent Data { get; }

        public DateTime Timestamp { get; }

        public int Version { get; }
    }
}