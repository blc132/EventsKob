using System.Collections.Generic;
using EventsKob.Models;

namespace EventsKob.ViewModels
{
    public class FollowingViewModel
    {
        public IEnumerable<ApplicationUser> FollowingEventsMakers { get; set; }
    }
}