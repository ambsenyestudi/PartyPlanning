using PartyPlanning.Domain.Events;
using PartyPlanning.Domain.Events.Update;
using PartyPlanning.Domain.Users;
using System;
using Xunit;

namespace PartyPlanning.UT.Events
{
    public class EventShould
    {
        [Fact]
        public void NotCreateEventWithNoOrganizer()
        {
            var createdEvent = new Event(new EventId());
            var invalidOrganizer = default (Profile);
            var eventDate = DateTime.Now.AddDays(7);
            Assert.Throws<InvalidOperationException>(() => 
                createdEvent.Create(eventDate, invalidOrganizer));
        }
        [Fact]
        public void NotCreateEventOnPastDate()
        {
            var createdEvent = new Event(new EventId());
            var eventOrganizer = new Profile(new ProfileId());
            var eventDate = DateTime.Now.AddDays(-1);
            Assert.Throws<InvalidOperationException>(() => 
                createdEvent.Create(eventDate, eventOrganizer));
        }
        [Fact]
        public void CreateValidEvent()
        {
            var createdEvent = new Event(new EventId());
            var eventOrganizer = new Profile(new ProfileId());
            var eventDate = DateTime.Now.AddDays(7);
            createdEvent.Create(eventDate, eventOrganizer);
            Assert.NotNull(createdEvent);
        }

        [Fact] 
        public void MustNotCreateEmptyRule()
        {
            Assert.Throws<ArgumentException>(() => new CreatedOrDraftingRule(null));
        }

        [Fact]
        public void MustUpdateCreatingEvent()
        {
            var createdEvent = new Event(new EventId());
            createdEvent.UpdateDate(DateTime.Today.AddDays(1));
            Assert.Throws<ArgumentException>(() => new CreatedOrDraftingRule(null));
        }
    }
}
