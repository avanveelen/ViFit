using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViFit.Domain;

namespace ViFit.Infrastructure
{
    public class EventLogRepository : IEventLogStorageProvider
    {
        private readonly EF.ApplicationDbContext applicationDbContext;

        public EventLogRepository(EF.ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public Task<IEventLogStorage> GetStorage(AggregateId aggregate)
        {
            return Task.FromResult((IEventLogStorage)new EventLogStorage(aggregate, this.applicationDbContext));
        }

        private class EventLogStorage : IEventLogStorage
        {
            private readonly AggregateId aggregateId;
            private readonly EF.ApplicationDbContext applicationDbContext;

            public EventLogStorage(AggregateId aggregateId, EF.ApplicationDbContext applicationDbContext)
            {
                this.aggregateId = aggregateId;
                this.applicationDbContext = applicationDbContext;
            }

            public async Task CommitAsync(IReadOnlyList<EventLogRecord> eventsToPersist)
            {
                var entities = eventsToPersist.Select(e => CreateEntity(e));
                this.applicationDbContext.AddRange(entities);
                await this.applicationDbContext.SaveChangesAsync();
            }

            public async Task<IReadOnlyList<EventLogRecord>> ReplayAsync()
            {
                var events = await this.applicationDbContext.EventLogs
                    .Where(l => l.AggregateId == this.aggregateId.Id)
                    .OrderBy(l => l.Version)
                    .ToListAsync();

                return events
                    .Select(e => new EventLogRecord(
                        new SerializedEvent(e.EventType, e.Data),
                        new DateTime(e.Created.Ticks, DateTimeKind.Utc),
                        e.Version))
                    .ToList();
            }

            private EF.EventLog CreateEntity(EventLogRecord e)
            {
                return new EF.EventLog
                {
                    AggregateId = this.aggregateId.Id,
                    AggregateType = this.aggregateId.AggregateType.TypeName,
                    EventType = e.Event.EventName,
                    Data = e.Event.EventData,
                    Created = e.Timestamp,
                    Version = e.Version
                };
            }
        }
    }
}
