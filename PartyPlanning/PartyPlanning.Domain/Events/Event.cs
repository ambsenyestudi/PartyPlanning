using PartyPlanning.Domain.Events.Create;
using PartyPlanning.Domain.Events.Update;
using PartyPlanning.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PartyPlanning.Domain.Events
{
    public enum EventState
    {
        None, Createing, Created, Drafting, PendingAproval, Published
    }
    public class Event
    {

        public DateTime Date { get; private set; }
        public EventId EventId { get; }
        public EventState Status { get; private set; }
        public List<ICreateEventRule> CreateRules { get; private set;}
        public Profile Organizer { get; private set; }
        public List<IUpdateEventRule> UpdateRules { get; private set; }

        public Event(EventId eventId)
        {
            this.EventId = eventId;
            this.Status = EventState.Createing;
            SetCreateRules();
            SetUpdateRules();
        }

        private void SetCreateRules()
        {
            CreateRules = new List<ICreateEventRule>
            {
                new MustHaveOrganizerRule(this),
                new MustBeFutureDate(this)
            };
        }
        private void SetUpdateRules()
        {
            UpdateRules = new List<IUpdateEventRule>
            {
                new CreatedOrDraftingRule(this)
            };
        }

        public void Create(DateTime date, Profile organizer)
        {
            Date = date;
            Organizer = organizer;
            if(CreateRules.Any(x => !x.IsValid())) 
            {
                throw new InvalidOperationException("Create Rules not met");
            }
                
            Status = EventState.Created;
        }

        public void UpdateDate(DateTime dateTime)
        {
            if(UpdateRules.Any(x=> x.IsValid()))
            {
                throw new InvalidOperationException("Update Rules not met");
            }
        }
    }
}
