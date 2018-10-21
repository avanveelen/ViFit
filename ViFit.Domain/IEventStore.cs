using System.Threading.Tasks;

namespace ViFit.Domain
{
    public interface IEventStore
    {
        Task<IEventLog> Get(AggregateId aggregateId);   
    }
}
