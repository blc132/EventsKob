using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventsKob.Models
{
    public class Follow
    {
        public ApplicationUser Follower { get; set; }
        public ApplicationUser EventMaker { get; set; }

        [Key]
        [Column(Order = 1)]
        public string FollowerId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string EventMakerId { get; set; }
    }
}