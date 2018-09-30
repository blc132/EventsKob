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
        public Event Event { get; set; }

        protected Notification()
        {
        }

        public Notification(Event _event, NotificationType type)
        {
            if(_event == null)
                throw new ArgumentNullException("event");

            Event = _event;
            Type = type;
            DateTime = DateTime.Now;
        }
    }
}