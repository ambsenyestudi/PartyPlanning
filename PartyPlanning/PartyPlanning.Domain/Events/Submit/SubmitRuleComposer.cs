using PartyPlanning.Domain.Events.Rules;
using System.Collections.Generic;

namespace PartyPlanning.Domain.Events.Submit
{
    static class SubmitRuleComposer
    {
        public static SubmitRuleSet BuildSubmit(this IList<IRule> ruleCollection) =>
            new SubmitRuleSet(ruleCollection);
    }
}
