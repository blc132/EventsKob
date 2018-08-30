using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EventsKob.Models
{
    public class Follow
    {
        public ApplicationUser Follower { get; set; }
        public ApplicationUser EventMaker { get; set; }

        [Key]
        [Column(Order = 1)]
        public int FollowerId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int EventMakerId { get; set; }
    }
}