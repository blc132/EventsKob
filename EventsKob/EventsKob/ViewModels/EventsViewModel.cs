﻿using System.Collections.Generic;
using EventsKob.Models;

namespace EventsKob.ViewModels
{
    public class EventsViewModel
    {
        public IEnumerable<Event> UpcomingEvents { get; set; }
        public bool ShowActions { get; set; }
        public string Heading { get; set; }
    }
}