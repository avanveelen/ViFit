
using System;
using System.Threading.Tasks;
using ViFit.Domain;
using ViFit.Domain.Steps;

namespace ViFit.Application.Steps
{
    public class StepRegistrationCommandHandler : ICommandHandler<AddStepRegistration>
    {
        private readonly IEventStore eventStore;

        public StepRegistrationCommandHandler(IEventStore eventStore)
        {
            this.eventStore = eventStore;
        }

        public async Task Handle(AddStepRegistration command)
        {
            var eventStore = await this.eventStore.Get(new AggregateId(command.UserId, AggregateType.Competitor));

            eventStore.Stage(new StepRegistrationAdded(100, Guid.NewGuid()));
            await eventStore.CommitAsync();
        }
    }
}
