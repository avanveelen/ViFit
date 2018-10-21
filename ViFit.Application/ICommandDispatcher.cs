using System.Threading.Tasks;

namespace ViFit.Application
{
    public interface ICommandDispatcher
    {
        Task Dispatch<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
