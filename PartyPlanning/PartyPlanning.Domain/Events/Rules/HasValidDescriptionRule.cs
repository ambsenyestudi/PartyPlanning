using System;
using System.Collections.Generic;
using System.Text;

namespace PartyPlanning.Domain.Events.Rules
{
    public class HasValidDescriptionRule : EventRule, IRule
    {
        public HasValidDescriptionRule(Event evalutaingEvent) : base(evalutaingEvent)
        {
        }

        public bool IsCompliant() => !String.IsNullOrWhiteSpace(evalutaingEvent.Description);
    }
}