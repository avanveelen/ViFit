using System.Threading.Tasks;

namespace ViFit.Domain
{
    public interface IReadableEventLog
    {
        Task<EventStream> ReplayAsync();
    }
}
