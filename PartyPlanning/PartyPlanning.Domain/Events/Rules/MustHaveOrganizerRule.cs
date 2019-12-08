namespace PartyPlanning.Domain.Events.Rules
{
    public class MustHaveOrganizerRule:EventRule,IRule
    {
        public MustHaveOrganizerRule(Event evalutaingEvent) : base(evalutaingEvent)
        { 
        }

        public bool IsCompliant() =>
            evalutaingEvent.Organizer != null;
    }
}
