using AutoMapper;
using EventsKob.Dtos;
using EventsKob.Models;

namespace EventsKob.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, UserDto>();
            CreateMap<Event, EventDto>();
            CreateMap<Notification, NotificationDto>();
        }

    }
}