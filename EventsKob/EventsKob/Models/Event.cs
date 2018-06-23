using System;

namespace EventsKob.Models
{
    public class Event
    {
        public int Id { get; set; }
        public ApplicationUser EventMaker { get; set; }
        public DateTime DateTime { get; set; }
        public string Venue { get; set; }
        public Genre Genre { get; set; }
    }
}