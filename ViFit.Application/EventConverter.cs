using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using ViFit.Domain;
using ViFit.Domain.Steps;

namespace ViFit.Application
{
    public class EventConverter : IEventConverter
    {
        private readonly IDictionary<Type, string> eventNameLookup = new Dictionary<Type, string>
        {
            [typeof(StepRegistrationAdded)] = "StepsAdded"
        };

        public IDomainEvent Deserialize(SerializedEvent serializedEvent)
        {
            var type = eventNameLookup.Single(l => l.Value == serializedEvent.EventName).Key;
            return (IDomainEvent)JsonConvert.DeserializeObject(serializedEvent.EventData, type);            
        }

        public SerializedEvent Serialize(IDomainEvent domainEvent)
        {
            var eventName = this.eventNameLookup[domainEvent.GetType()];
            var eventData = JsonConvert.SerializeObject(domainEvent);

            return new SerializedEvent(eventName, eventData);
        }
    }
}
