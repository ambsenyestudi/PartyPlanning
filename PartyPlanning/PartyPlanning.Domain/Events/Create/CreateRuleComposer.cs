using PartyPlanning.Domain.Events.Rules;
using System.Collections.Generic;

namespace PartyPlanning.Domain.Events.Create
{
    public static class CreateRuleComposer
    {
        public static CreateRuleSet BuildCreate(this IList<IRule> ruleCollection) =>
            new CreateRuleSet(ruleCollection);
    }
}
