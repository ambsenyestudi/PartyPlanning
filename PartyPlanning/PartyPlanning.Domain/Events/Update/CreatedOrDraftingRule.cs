namespace PartyPlanning.Domain.Events.Update
{
    public class CreatedOrDraftingRule: EventRule, IUpdateEventRule
    {
        public CreatedOrDraftingRule(Event evalutaingEvent): base(evalutaingEvent)
        {
        }

        public bool IsValid() =>
            evalutaingEvent.Status == EventState.Created ||
            evalutaingEvent.Status == EventState.Drafting;
    }
}
