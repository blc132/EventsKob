using System.Linq;
using System.Web.Mvc;
using EventsKob.Models;
using Microsoft.AspNet.Identity;

namespace EventsKob.Controllers
{
    public class EventsMakersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsMakersController()
        {
            _context = new ApplicationDbContext();
        }
        
        // GET: EventsMakers
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var eventsMakers = _context.Follows
                .Where(f => f.FollowerId == userId)
                .Select(f => f.EventMaker)
                .ToList();

            return View(eventsMakers);
        }
    }
}