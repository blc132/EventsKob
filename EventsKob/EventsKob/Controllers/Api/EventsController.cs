using System.Linq;
using System.Web.Http;
using EventsKob.Models;
using Microsoft.AspNet.Identity;

namespace EventsKob.Controllers.Api
{
    [Authorize]
    public class EventsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public EventsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var eventToCancel = _context.Events.Single(e => e.Id == id && e.EventMakerId == userId);

            if (eventToCancel.IsCanceled)
                return NotFound();

            eventToCancel.IsCanceled = true;
            _context.SaveChanges();

            return Ok();

        }
    }
}
