using System;
using System.Collections.Generic;
using System.Text;

namespace PartyPlanning.Domain.Events.Rules
{
    public class NoCapacityLimitRule : EventRule, IRule
    {
        public NoCapacityLimitRule(Event evalutaingEvent) : base(evalutaingEvent)
        {
        }

        public bool IsCompliant() => !evalutaingEvent.HasLimitedCapacity;
    }
}
