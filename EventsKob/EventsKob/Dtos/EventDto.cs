using System;

namespace EventsKob.Dtos
{
    public class EventDto
    {
        public int Id { get; set; }

        public bool IsCanceled { get; set; }

        public UserDto EventMaker { get; set; }

        public DateTime DateTime { get; set; }

        public string Venue { get; set; }

        public GenreDto Genre { get; set; }
    }
}