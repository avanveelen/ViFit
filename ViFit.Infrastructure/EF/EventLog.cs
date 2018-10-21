using System;

namespace ViFit.Infrastructure.EF
{
    public class EventLog
    {
        public Guid AggregateId { get; set; }

        public string AggregateType { get; set; }

        public int Version { get; set; }

        public string EventType { get; set; }

        public string Data { get; set; }

        public DateTime Created { get; set; }
    }
}
