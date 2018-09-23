using System;
using System.ComponentModel.DataAnnotations;

namespace EventsKob.Models
{
    public class Event
    {
        public int Id { get; set; }

        public bool IsCanceled { get; set; }
        
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

    }
}