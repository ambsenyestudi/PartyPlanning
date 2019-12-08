using PartyPlanning.Domain.Events;
using PartyPlanning.Domain.Events.Rules;
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
            var createdEvent = new EventAgregate(new EventId());
            var invalidOrganizer = default (Profile);
            var eventDate = DateTime.Now.AddDays(7);
            Assert.Throws<InvalidOperationException>(() => 
                createdEvent.Create(eventDate, invalidOrganizer));
        }
        [Fact]
        public void NotCreateEventOnPastDate()
        {
            var createdEvent = new EventAgregate(new EventId());
            var eventOrganizer = new Profile(new ProfileId());
            var eventDate = DateTime.Now.AddDays(-1);
            Assert.Throws<InvalidOperationException>(() => 
                createdEvent.Create(eventDate, eventOrganizer));
        }
        [Fact]
        public void CreateValidEvent()
        {
            EventAgregate createdEvent = GetValidEvent();
            Assert.NotNull(createdEvent);
        }
        
        [Fact] 
        public void MustNotCreateEmptyRule()
        {
            Assert.Throws<ArgumentException>(() => new MustBeFutureDateRule(null));
        }

        [Fact]
        public void MustNotUpdateCreatingEvent()
        {
            var createdEvent = new EventAgregate(new EventId());
            Assert.Throws<InvalidOperationException>(() => 
                createdEvent.UpdateDate(DateTime.Today.AddDays(1)));
        }

        [Fact]
        public void NotAllowNonPostiveMaxAttendees()
        {
            var createdEvent = GetValidEvent();
            Assert.Throws<InvalidOperationException>(()=> 
                createdEvent.SetLimitOfCapacity(0));
        }

        [Fact]
        public void NotSubmitIncompleteEvent()
        {
            var createdEvent = GetValidEvent();
            Assert.Throws<InvalidOperationException>(() =>
                createdEvent.SubmitForPublishing());
        }
        [Fact]
        public void SubmitCompleteEvent()
        {
            var completeEvent = GetCompleteEvent();
            Assert.NotNull(completeEvent);
        }

        [Fact]
        public void NotSubmitEventWithNoName()
        {
            var noNameEvent = GetCompleteEvent();
            noNameEvent.UpdateName(string.Empty);
            Assert.Throws<InvalidOperationException>(() => noNameEvent.SubmitForPublishing());
        }
        [Fact]
        public void NotSubmitEventWithNoDescription()
        {
            var noNameEvent = GetCompleteEvent();
            noNameEvent.UpdateDescription(string.Empty);
            Assert.Throws<InvalidOperationException>(() => noNameEvent.SubmitForPublishing());
        }
        private EventAgregate GetCompleteEvent()
        {
            var createdEvent = GetValidEvent();
            createdEvent.UpdateName("Xmas party");
            createdEvent.UpdateDescription("Our annual company xmas party");
            return createdEvent;
        
        }
        private EventAgregate GetValidEvent()
        {
            var createdEvent = new EventAgregate(new EventId());
            var eventOrganizer = new Profile(new ProfileId());
            var eventDate = DateTime.Now.AddDays(7);
            createdEvent.Create(eventDate, eventOrganizer);
            return createdEvent;
        }
    }
}
