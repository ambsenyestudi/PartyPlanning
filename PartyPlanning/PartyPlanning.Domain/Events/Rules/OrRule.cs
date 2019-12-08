namespace PartyPlanning.Domain.Events.Rules
{
    public class OrRule : IRule
    {
        private readonly IRule first;
        private readonly IRule second;

        public OrRule(IRule first, IRule second)
        {
            this.first = first;
            this.second = second;
        }
        public bool IsCompliant()
        {
            var firstResult = first.IsCompliant();
            var secondResult = second.IsCompliant();
            return firstResult || secondResult;
        }   
    }
}
