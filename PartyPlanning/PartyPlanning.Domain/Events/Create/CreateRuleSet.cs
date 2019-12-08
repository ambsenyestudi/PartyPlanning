using System.Collections.Generic;
using PartyPlanning.Domain.Events.Rules;

namespace PartyPlanning.Domain.Events.Create
{
    public class CreateRuleSet : ARuleSet
    {
        public CreateRuleSet(IList<IRule> ruleList) : base(ruleList)
        {
        }
    }
}
