namespace PartyPlanning.Domain.Events.Rules
{
    public class PostiveMaxCapacityRule : EventRule, IRule
    {
        public PostiveMaxCapacityRule(Event evalutaingEvent): base(evalutaingEvent)
        {
        }

        public bool IsCompliant() => evalutaingEvent.HasLimitedCapacity && evalutaingEvent.MaxAttendants > 0;

    }
}
