using System;

namespace PartyPlanning.Domain.Events.Rules
{
    public class HasValidNameRule : EventRule, IRule
    {
        public HasValidNameRule(Event evalutaingEvent) : base(evalutaingEvent)
        {
        }
        
        public bool IsCompliant() => !String.IsNullOrWhiteSpace(evalutaingEvent.Name);
    }
}
