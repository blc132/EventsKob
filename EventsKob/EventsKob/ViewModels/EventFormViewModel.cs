using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EventsKob.Models;
using EventsKob.ViewModels.Validators;

namespace EventsKob.ViewModels
{
    public class EventFormViewModel
    {
        [Required]
        public string Venue { get; set; }

        [Required]
        [FutureDate(ErrorMessage = "Date needs to be future")]
        public string Date { get; set; }

        [Required]
        [ValidTime(ErrorMessage =  "Incorrect time format")]
        public string Time { get; set; }

        [Required]
        public int Genre { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public DateTime GetDateTime()
        {
            return DateTime.Parse($"{Date} {Time}");
        }
    }
}
