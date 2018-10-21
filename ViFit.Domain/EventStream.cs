using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViFit.Domain
{
    public sealed class EventStream : IEnumerable<Event>
    {
        private readonly IReadOnlyCollection<Event> events;

        public EventStream(IReadOnlyCollection<Event> events)
        {
            this.events = events;
            var lastEvent = events.LastOrDefault();
            this.Version = lastEvent?.Version ?? 0;
        }

        public int Version { get; }
        
        public IEnumerator<Event> GetEnumerator() => this.events.GetEnumerator();
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
