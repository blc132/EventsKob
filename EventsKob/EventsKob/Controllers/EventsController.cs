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
        public ActionResult Create()
        {
            var viewModel = new EventFormViewModel
            {
                Genres = _context.Genres.ToList(),
                Heading = "Add an Event"
            };
            return View("EventForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _context.Genres.ToList();
                return View("EventForm", viewModel);
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

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(EventFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _context.Genres.ToList();
                return View("EventForm", viewModel);
            }

            var eventMakerId = User.Identity.GetUserId();
            var eventToUpdate = _context.Events.Single(e => e.Id == viewModel.Id && e.EventMakerId == eventMakerId);

            eventToUpdate.Update(viewModel.GetDateTime(), viewModel.Venue, viewModel.Genre);
            _context.SaveChanges();

            return RedirectToAction("Mine", "Events");
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();
            var _event = _context.Events.Single(e => e.Id == id &&
                                                     e.EventMakerId == userId);

            var viewModel = new EventFormViewModel
            {
                Heading = "Edit an Event",
                Id = _event.Id,
                Genres = _context.Genres.ToList(),
                Date = _event.DateTime.ToString("d MMM yyyy"),
                Time = _event.DateTime.ToString("HH:mm"),
                Genre = _event.GenreId,
                Venue = _event.Venue
            };
            return View("EventForm", viewModel);
        }

        [Authorize]
        public ActionResult Mine()
        {
            var userId = User.Identity.GetUserId();
            var events = _context.Events
                .Where(e => e.EventMakerId == userId &&
                            e.DateTime > DateTime.Now &&
                            e.IsCanceled == false)
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