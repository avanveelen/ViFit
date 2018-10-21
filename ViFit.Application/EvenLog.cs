using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViFit.Domain;

namespace ViFit.Application
{
    public class EventLog : IEventLog
    {
        private readonly AggregateId aggregate;
        private readonly IEventConverter eventConverter;
        private readonly IEventLogStorage eventLogStorage;
        private readonly List<IDomainEvent> recordedEvents = new List<IDomainEvent>();

        public EventLog(AggregateId aggregate, IEventConverter eventConverter, IEventLogStorage eventLogStorage)
        {
            this.aggregate = aggregate;
            this.eventConverter = eventConverter;
            this.eventLogStorage = eventLogStorage;
        }

        public async Task CommitAsync()
        {
            if (!this.recordedEvents.Any())
            {
                return;
            }

            var eventsToPersist = this.recordedEvents.ToList();

            this.recordedEvents.Clear();

            var timestamp = DateTime.UtcNow;
            var lastVersion = (await ReplayAsync()).LastOrDefault()?.Version ?? 0;
            var items = new List<EventLogRecord>();

            for (var i = 0; i < eventsToPersist.Count; i++)
            {
                var evt = eventsToPersist[i];
                var serializedEvent = this.eventConverter.Serialize(evt);

                var version = lastVersion + i + 1;
                var item = new EventLogRecord(serializedEvent, timestamp, version);

                items.Add(item);
            }

            await this.eventLogStorage.CommitAsync(items);
        }

        public async Task<EventStream> ReplayAsync()
        {
            var events = new List<Event>();

            foreach (var item in await this.eventLogStorage.ReplayAsync())
            {
                var evt = this.eventConverter.Deserialize(item.Event);
                events.Add(new Event(evt, item.Timestamp, item.Version));
            }

            return new EventStream(events);
        }

        public void Stage(IDomainEvent evt)
        {
            this.recordedEvents.Add(evt);
        }
    }
}
