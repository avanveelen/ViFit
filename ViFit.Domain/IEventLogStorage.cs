using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ViFit.Domain
{
    public interface IEventLogStorage
    {
        Task<IReadOnlyList<EventLogRecord>> ReplayAsync();

        Task CommitAsync(IReadOnlyList<EventLogRecord> eventsToPersist);
    }
}
