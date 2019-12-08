using PartyPlanning.Domain.Events.Rules;
using System.Collections.Generic;

namespace PartyPlanning.Domain.Events.Update
{
    public static class  UpdateRuleComopositor
    {
        
        public static UpdateRuleSet BuildUpdate(this IList<IRule> ruleCollection) =>
            new UpdateRuleSet(ruleCollection);
    }
}
