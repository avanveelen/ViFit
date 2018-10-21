using System;
using System.Threading.Tasks;
using ViFit.Application;
using Microsoft.Extensions.DependencyInjection;

namespace ViFit.Api
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public Task Dispatch<TCommand>(TCommand command) where TCommand : ICommand
        {
            if(command == null)
            {
                throw new ArgumentNullException("Command can not be null", nameof(command));
            }

            var commandHandler = this.serviceProvider.GetRequiredService<ICommandHandler<TCommand>>();
            return commandHandler.Handle(command);
        }
    }
}
