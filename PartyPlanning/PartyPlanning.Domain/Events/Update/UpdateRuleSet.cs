using System.Collections.Generic;
using PartyPlanning.Domain.Events.Rules;

namespace PartyPlanning.Domain.Events.Update
{
    public class UpdateRuleSet : ARuleSet
    {
        public UpdateRuleSet(IList<IRule> ruleList) : base(ruleList)
        {
        }
    }
}
