using System;

namespace ViFit.Domain
{
    public class AggregateId
    {
        public AggregateId(Guid id, AggregateType aggregateType)
        {
            this.Id = id;
            this.AggregateType = aggregateType;
        }
        public Guid Id { get; }

        public AggregateType AggregateType { get; }
    }

    public class AggregateType
    {
        public static AggregateType Competitor = new AggregateType("competitor");
        
        public AggregateType(string typeName)
        {
            this.TypeName = typeName;
        }

        public string TypeName { get; private set; }
    }
}