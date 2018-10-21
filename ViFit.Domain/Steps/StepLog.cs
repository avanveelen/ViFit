using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ViFit.Domain.Steps
{
    public class StepLog : IEnumerable
    {
        private readonly IDictionary<DateTime, StepRegistration> items;

        public StepLog(IDictionary<DateTime, StepRegistration> items)
        {
            this.items = items;
        }

        public StepRegistration Get(DateTime date)
        {
            if (this.items.ContainsKey(date))
            {
                return this.items[date];
            }

            return null;
        }

        public int StepCount => this.items.Values.Sum(i => i.Amount);


        public IEnumerator GetEnumerator()
        {
            return this.items.GetEnumerator();
        }
    }
}
