using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using EventsKob.Models;
using EventsKob.ViewModels;

namespace EventsKob.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var upcomingEvents = _context.Events
                .Include(e => e.EventMaker)
                .Include(g => g.Genre)
                .Where(g => g.DateTime > DateTime.Now);

            var model = new EventsViewModel()
            {
                UpcomingEvents = upcomingEvents,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Upcoming Events"
            };

            return View("Events", model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}