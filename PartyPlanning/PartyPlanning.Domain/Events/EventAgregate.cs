using PartyPlanning.Domain.Events.Create;
using PartyPlanning.Domain.Events.Rules;
using PartyPlanning.Domain.Events.Submit;
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
        public CreateRuleSet CreateRuleSet { get; private set; }
        public UpdateRuleSet UpdateRuleSet { get; private set; }
        public SubmitRuleSet SubmitRuleSet { get; private set; }

        #endregion Rules
        public Event Event { get;  private set; }

        public EventAgregate(EventId eventId)
        {
            this.Event = new Event(eventId);
            SetCreateRuleSet();
            SetUpdateRules();
            SetSubmitRuleSet();
        }

        private void SetCreateRuleSet()
        {
            CreateRuleSet = RuleCompositor.StartComposing()
                .AddMustHaveOrganizerRule(Event)
                .AddMustBeFutureDate(Event)
                .BuildCreate();
        }
        private void SetUpdateRules()
        {
            UpdateRuleSet = RuleCompositor.StartComposing()
                .AddPossibleUpdateStatus(Event)
                .AddNoLimitOrPostiveMaxCapacityRule(Event)
                .BuildUpdate();
        }
        private void SetSubmitRuleSet()
        {
            SubmitRuleSet = RuleCompositor.StartComposing()
                .AddDraftingRule(Event)
                .AddHasValidName(Event)
                .AddHasValidDescription(Event)
                .BuildSubmit();
        }

        public void Create(DateTime date, Profile organizer)
        {
            Event.Date = date;
            Event.Organizer = organizer;
            EvaluateRuleSet(CreateRuleSet);
            Event.Status = EventStatus.Created;
        }

        public void UpdateDate(DateTime dateTime) =>
            UpdateInfo(()=> Event.Date = dateTime);
        
        public void UpdateName(string name) =>
            UpdateInfo(() => Event.Name = name);
        
        public void UpdateDescription(string description) =>
            UpdateInfo(() => Event.Description = description);
        public void SetLimitOfCapacity(int maxCapacity) =>
            UpdateInfo(() => {
                Event.ActivateCapacityLimit();
                Event.SetMaxCapacity(maxCapacity);
                });

        public void RemoveLimitOfCapacity() =>
            UpdateInfo(() => Event.RemoveMaxCapcity());
        public void UpdateInfo(Action action)
        {
            action.Invoke();
            EvaluateRuleSet(UpdateRuleSet);
            Event.Status = EventStatus.Drafting;
        }
        public void SubmitForPublishing()
        {
            EvaluateRuleSet(SubmitRuleSet);
            Event.Status = EventStatus.PendingAproval;
        }
        public void EvaluateRuleSet(IRuleSet ruleSet)
        {
            if (!ruleSet.IsCompliant())
            {
                throw new InvalidOperationException($"{ruleSet.GetType().Name} Rules not met");
            }
        }
    }
}
