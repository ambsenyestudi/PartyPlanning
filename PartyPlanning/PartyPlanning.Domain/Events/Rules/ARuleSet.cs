using System.Collections.Generic;
using System.Linq;

namespace PartyPlanning.Domain.Events.Rules
{
    public class ARuleSet:IRuleSet
    {
        public IList<IRule> RuleList { get; protected set; }
        public ARuleSet(IList<IRule> ruleList)
        {
            RuleList = ruleList;
        }
        public bool IsCompliant() => RuleList.All(x => x.IsCompliant());
    }
}
