using PartyPlanning.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace PartyPlanning.Domain.Events
{
    public enum EventStatus
    {
        None, Createing, Created, Drafting, PendingAproval, Published
    }
    public class Event
    {
        public EventId EventId { get; }
        public EventStatus Status { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool HasLimitedCapacity { get => MaxAttendants > 0; }
        public int MaxAttendants { get; private set; }
        public Profile Organizer { get; set; }
        public List<Attendee> Attendees { get; set; }
        public Event(EventId eventId)
        {
            EventId = eventId;
            this.Status = EventStatus.Createing;
        }

        public void SetMaxCapacity(int maxCapacity)
        {
            MaxAttendants = maxCapacity;
        }

        public void RemoveMaxCapcity()
        {
            MaxAttendants = 0;
        }
    }
}
