using System.Collections.Generic;
using System.Linq;

namespace PartyPlanning.Domain.Events.Rules
{
    public class EventStatusRule : EventRule, IRule
    {
        private readonly IEnumerable<EventStatus> eventStatusCollection;
        public EventStatusRule(Event evalutaingEvent, IEnumerable<EventStatus> possibleStatusCollection) :
            base(evalutaingEvent)
        {
            eventStatusCollection = possibleStatusCollection;
        }
        public EventStatusRule(Event evalutaingEvent, EventStatus eventStatus) :
            this(evalutaingEvent, new List<EventStatus> { eventStatus})
        {
        }

        public bool IsCompliant() =>
            eventStatusCollection.Contains(evalutaingEvent.Status);
    }
}
