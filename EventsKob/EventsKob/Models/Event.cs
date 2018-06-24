using System;
using System.ComponentModel.DataAnnotations;

namespace EventsKob.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        public ApplicationUser EventMaker { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }

        [Required]
        public Genre Genre { get; set; }
    }
}