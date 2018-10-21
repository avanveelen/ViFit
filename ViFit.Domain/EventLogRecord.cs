using System;

namespace ViFit.Domain
{
    public class EventLogRecord
    {
        public EventLogRecord(SerializedEvent serializedEvent, DateTime timestamp, int version)
        {
            this.Event = serializedEvent;
            this.Timestamp = timestamp;
            this.Version = version;
        }

        public SerializedEvent Event { get; }

        public DateTime Timestamp { get; }

        public int Version { get; }

        public byte[] Checksum { get; }
    }
}
