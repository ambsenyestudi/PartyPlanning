using PartyPlanning.Domain.Events.Create;
using PartyPlanning.Domain.Events.Update;
using PartyPlanning.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PartyPlanning.Domain.Events
{
    
    public class EventAgregate
    {
        #region Rules
        public List<ICreateEventRule> CreateRules { get; private set; }
        public List<IUpdateEventRule> UpdateRules { get; private set; }
        #endregion Rules

        public Event Event { get;  private set; }


        public EventAgregate(EventId eventId)
        {
            this.Event = new Event(eventId);
            SetCreateRules();
            SetUpdateRules();
        }

        private void SetCreateRules()
        {
            CreateRules = new List<ICreateEventRule>
            {
                new MustHaveOrganizerRule(Event),
                new MustBeFutureDate(Event)
            };
        }
        private void SetUpdateRules()
        {
            UpdateRules = new List<IUpdateEventRule>
            {
                new CreatedOrDraftingRule(Event),
                new PostiveMaxCapacityRule(Event)
            };
        }

        public void Create(DateTime date, Profile organizer)
        {
            Event.Date = date;
            Event.Organizer = organizer;
            if (CreateRules.Any(x => !x.IsValid())) 
            {
                throw new InvalidOperationException("Create Rules not met");
            }
            Event.Status = EventStatus.Created;
        }

        public void UpdateDate(DateTime dateTime) =>
            UpdateInfo(()=> Event.Date = dateTime);
        
        public void UpdateName(string name) =>
            UpdateInfo(() => Event.Name = name);
        
        public void UpdateText(string description) =>
            UpdateInfo(() => Event.Description = description);
        public void SetLimitOfCapacity(int maxCapacity) =>
            UpdateInfo(() => Event.SetMaxCapacity(maxCapacity));

        public void RemoveLimitOfCapacity() =>
            UpdateInfo(() => Event.RemoveMaxCapcity());
        public void UpdateInfo(Action action)
        {
            action.Invoke();
            if (UpdateRules.Any(x => !x.IsValid()))
            {
                throw new InvalidOperationException("Update Rules not met");
            }
            
            if (Event.Status != EventStatus.Drafting)
            {
                Event.Status = EventStatus.Drafting;
            }
        }
    }
}
