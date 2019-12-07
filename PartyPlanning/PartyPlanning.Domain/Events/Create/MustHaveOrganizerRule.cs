namespace PartyPlanning.Domain.Events.Create
{
    public class MustHaveOrganizerRule:EventRule,ICreateEventRule
    {
        public MustHaveOrganizerRule(Event evalutaingEvent) : base(evalutaingEvent)
        { 
        }

        public bool IsValid() =>
            evalutaingEvent.Organizer != null;
    }
}
