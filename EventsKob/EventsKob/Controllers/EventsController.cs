using System;
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

        public ActionResult Create()
        {
            var viewModel = new EventFormViewModel
            {
                Genres = _context.Genres.ToList()
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(EventFormViewModel viewModel)
        {
            var eventMakerId = User.Identity.GetUserId();
            var eventMaker = _context.Users.Single(e => e.Id == eventMakerId);
            var genre = _context.Genres.Single(g => g.Id == viewModel.Genre);
            var eventToAdd = new Event
            {
                EventMaker = eventMaker,
                DateTime = DateTime.Parse($"{viewModel.Date} {viewModel.Time}"),
                Genre = genre,
                Venue = viewModel.Venue,
            };
            _context.Events.Add((eventToAdd));
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}