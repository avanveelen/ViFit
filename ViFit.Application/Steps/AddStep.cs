using System;
using System.Collections.Generic;
using System.Text;

namespace ViFit.Application.Steps
{
    public class AddStepRegistration : ICommand
    {
        public AddStepRegistration()
        {
            this.Date = DateTime.Now;
        }

        public int Amount { get; set; }

        public DateTime Date { get; set; }

        public Guid UserId { get; set; }
    }
}
