using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViFit.Domain;

namespace ViFit.Application
{
    public class EventStore : IEventStore
    {
        private readonly IEventConverter eventConverter;
        private readonly IEventLogStorageProvider storageProvider;

        public EventStore(IEventConverter eventConverter, IEventLogStorageProvider storageProvider)
        {
            this.eventConverter = eventConverter;
            this.storageProvider = storageProvider;
        }

        public async Task<IEventLog> Get(AggregateId aggregateId)
        {
            var storage = await this.storageProvider.GetStorage(aggregateId);

            return new EventLog(aggregateId, this.eventConverter, storage);
        }
    }
}
