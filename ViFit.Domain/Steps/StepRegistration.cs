using System;
using System.Collections.Generic;
using System.Text;

namespace ViFit.Domain.Steps
{
    public class StepRegistration
    {
        public StepRegistration(int amount, DateTime date)
        {
            this.Amount = amount;
            this.Date = date;
        }

        public int Amount { get; }

        public DateTime Date { get; }
    }
}
