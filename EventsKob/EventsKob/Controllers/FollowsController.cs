﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EventsKob.Dtos;
using EventsKob.Models;
using Microsoft.AspNet.Identity;

namespace EventsKob.Controllers
{
    public class FollowsController : ApiController
    {
        private ApplicationDbContext _context;

        public FollowsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowsDto dto)
        {
            var userId = User.Identity.GetUserId();
            var alreadyFollowing =
                _context.Follows.Any(f => f.FollowerId == userId && f.EventMakerId == dto.EventMakerId);

            if (alreadyFollowing)
            {
                return BadRequest("The following already exists");
            }

            var follow = new Follow()
            {
                EventMakerId = dto.EventMakerId,
                FollowerId = userId
            };

            _context.Follows.Add(follow);
            _context.SaveChanges();

            return Ok();
        }
    }

}
