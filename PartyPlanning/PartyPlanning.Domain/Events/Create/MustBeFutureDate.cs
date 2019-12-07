using System;

namespace PartyPlanning.Domain.Events.Create
{
    public class MustBeFutureDate : EventRule, ICreateEventRule
    {
        public MustBeFutureDate(Event evalutaingEvent):base(evalutaingEvent)
        {
        }
        public bool IsValid() =>
            DateTime.Now < evalutaingEvent.Date;
    }
}
