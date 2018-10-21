using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ViFit.Application
{
    public interface ICommandHandler<TCommand> where TCommand: ICommand
    {
        Task Handle(TCommand command);
    }
}
