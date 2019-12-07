namespace PartyPlanning.Domain.Events.Update
{
    public class PostiveMaxCapacityRule : EventRule, IUpdateEventRule
    {
        public PostiveMaxCapacityRule(Event evalutaingEvent): base(evalutaingEvent)
        {
        }

        public bool IsValid()
        {
            var result = evalutaingEvent.MaxAttendants > 0;
            return result;
        }

    }
}
