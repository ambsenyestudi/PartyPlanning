using PartyPlanning.Domain.Events.Rules;
using System.Collections.Generic;

namespace PartyPlanning.Domain.Events.Submit
{
    public class SubmitRuleSet : ARuleSet
    {
        public SubmitRuleSet(IList<IRule> ruleList) : base(ruleList)
        {
        }
        public void AddRule(IRule rule)
        {
            RuleList.Add(rule);
        }
    }
}
