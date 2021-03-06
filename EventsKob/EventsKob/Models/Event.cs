﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using EventsKob.ViewModels;

namespace EventsKob.Models
{
    public class Event
    {
        public int Id { get; set; }

        public bool IsCanceled { get; private set; }

        public ApplicationUser EventMaker { get; set; }

        [Required]
        public string EventMakerId { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public int GenreId { get; set; }

        public ICollection<Attendance> Attendances { get; private set; }

        public Event()
        {
            Attendances = new Collection<Attendance>();
        }

        public void Cancel()
        {
            IsCanceled = true;
            var notification = Notification.EventCanceled(this);
            foreach (var attendee in Attendances.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
            }
        }

        public void Update(DateTime dateTime, string venue, int genre)
        {
            var notification = Notification.EventUpdated(this, DateTime, Venue );
            Venue = venue;
            DateTime = dateTime;
            GenreId = genre;

            foreach (var attendee in Attendances.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
            }
        }
    }
}