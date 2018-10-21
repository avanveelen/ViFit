using System;
using System.Collections.Generic;
using System.Text;

namespace ViFit.Domain
{
    public interface IEventConverter
    {
        SerializedEvent Serialize(IDomainEvent domainEvent);

        IDomainEvent Deserialize(SerializedEvent serializedEvent);
    }
}
