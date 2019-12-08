using System.Collections.Generic;

namespace PartyPlanning.Domain.Events.Rules
{
    public static class RuleCompositor
    {
        public static IList<IRule> StartComposing() =>
            new List<IRule>();
        public static IList<IRule> ComposeNewRule(this IList<IRule> ruleCollection, IRule currentRule)
        {
            ruleCollection.Add(currentRule);
            return ruleCollection;
        }
        #region RuleAdding
        public static IList<IRule> AddMustHaveOrganizerRule(this IList<IRule> ruleCollection, Event currentEvent) =>
            ruleCollection.ComposeNewRule(new MustHaveOrganizerRule(currentEvent));
        public static IList<IRule> AddMustBeFutureDate(this IList<IRule> ruleCollection, Event currentEvent) =>
            ruleCollection.ComposeNewRule(new MustBeFutureDateRule(currentEvent));
        public static IList<IRule> AddDraftingRule(this IList<IRule> ruleCollection, Event currentEvent) =>
            ruleCollection.ComposeNewRule(new EventStatusRule(currentEvent, EventStatus.Drafting));
        
        public static IList<IRule> AddPossibleUpdateStatus(this IList<IRule> ruleCollection, Event currentEvent) =>
            ruleCollection.ComposeNewRule(new EventStatusRule(currentEvent, new List<EventStatus>{
                EventStatus.Created,
                EventStatus.Drafting, 
            }));
        public static IList<IRule> AddNoLimitOrPostiveMaxCapacityRule(this IList<IRule> ruleCollection, Event currentEvent) =>
            ruleCollection.ComposeNewRule(
                new OrRule(
                    new NoCapacityLimitRule(currentEvent), 
                    new PostiveMaxCapacityRule(currentEvent)));
        public static IList<IRule> AddHasValidName(this IList<IRule> ruleCollection, Event currentEvent) =>
            ruleCollection.ComposeNewRule(new HasValidNameRule(currentEvent));
        public static IList<IRule> AddHasValidDescription(this IList<IRule> ruleCollection, Event currentEvent) =>
            ruleCollection.ComposeNewRule(new HasValidDescriptionRule(currentEvent));

        #endregion RuleAdding
    }
}
