using System;
namespace ViFit.Domain.Steps
{
    public class StepRegistrationAdded : IDomainEvent
    {
        public StepRegistrationAdded(int amount, Guid competitorId)
        {
            this.Amount = amount;
            this.CompetitorId = competitorId;
        }

        public int Amount { get; }

        public Guid CompetitorId { get; }
    }
}
