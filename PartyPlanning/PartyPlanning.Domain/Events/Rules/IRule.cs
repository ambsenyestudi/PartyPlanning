namespace PartyPlanning.Domain.Events.Rules
{
    public interface IRule
    {
        bool IsCompliant();
    }
}