    using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using EventsKob.Models;
using EventsKob.ViewModels;
using Microsoft.AspNet.Identity;

namespace EventsKob.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _context.Genres.ToList();
                return View("Create", viewModel);
            }

            var eventMakerId = User.Identity.GetUserId();
            var eventToAdd = new Event
            {
                EventMakerId = eventMakerId,
                DateTime = viewModel.GetDateTime(),
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue,
            };
            _context.Events.Add((eventToAdd));
            _context.SaveChanges();
            return RedirectToAction("Mine", "Events");
        }

        public ActionResult Create()
        {
            var viewModel = new EventFormViewModel
            {
                Genres = _context.Genres.ToList()
            };
            return View(viewModel);
        }

        [Authorize]
        public ActionResult Mine()
        {
            var userId = User.Identity.GetUserId();
            var events = _context.Events
                .Where(e => e.EventMakerId == userId && e.DateTime > DateTime.Now)
                .Include(g => g.Genre).ToList();

            return View(events);
        }

        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var events = _context.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(e => e.Event)
                .Include(e => e.EventMaker)
                .Include(e => e.Genre)
                .ToList();

            var model = new EventsViewModel()
            {
                UpcomingEvents = events,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Events I'm attending"
            };

            return View("Events", model);
        }
    }
}