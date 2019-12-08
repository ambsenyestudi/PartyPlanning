using System;

namespace PartyPlanning.Domain.Events.Rules
{
    public class MustBeFutureDateRule : EventRule, IRule
    {
        public MustBeFutureDateRule(Event evalutaingEvent):base(evalutaingEvent)
        {
        }

        public bool IsCompliant() =>
            evalutaingEvent.Date > DateTime.Now;
    }
}
