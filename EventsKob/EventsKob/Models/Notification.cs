using System;
using System.ComponentModel.DataAnnotations;

namespace EventsKob.Models
{
    public class Notification
    {
        public int Id { get; private set; }
        public DateTime DateTime { get; private set; }
        public NotificationType Type { get; private set; }
        public DateTime? OriginalDateTime { get; set; }
        public string OriginalVenue { get; set; }

        [Required]
        public Event Event { get; private set; }

        protected Notification()
        {
        }

        private Notification(Event _event, NotificationType type)
        {
            Event = _event ?? throw new ArgumentNullException("event");
            Type = type;
            DateTime = DateTime.Now;
        }

        private Notification(Event _event, NotificationType type, DateTime? originalDateTime, string originalVenue)
        {
            Event = _event ?? throw new ArgumentNullException("_event");
            Type = type;
            DateTime = DateTime.Now;
            OriginalDateTime = originalDateTime;
            OriginalVenue = originalVenue;
        }

        public static Notification EventCreated(Event eventCreated)
        {
            return new Notification(eventCreated, NotificationType.EventCreated);
        }

        public static Notification EventUpdated(Event eventUpdated, DateTime originalDateTime, string originalVenue)
        {
            return new Notification(eventUpdated, NotificationType.EventCreated, originalDateTime, originalVenue);
        }

        public static Notification EventCanceled(Event eventCanceled)
        {
            return new Notification(eventCanceled, NotificationType.EventCanceled);
        }

    }
}