using System;

namespace PartyPlanning.Domain.Events
{
    public class EventRule
    {
        protected readonly Event evalutaingEvent;
        public EventRule(Event evalutaingEvent)
        {
            if (evalutaingEvent == null)
            {
                throw new ArgumentException(
                    $"Can not create {this.GetType()} can not be created when {typeof(EventAgregate)}is null");
            }
            this.evalutaingEvent = evalutaingEvent;
        }
    }
}
