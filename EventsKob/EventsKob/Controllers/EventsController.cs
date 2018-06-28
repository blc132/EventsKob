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
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Create()
        {
            var viewModel = new EventFormViewModel
            {
                Genres = _context.Genres.ToList()
            };
            return View(viewModel);
        }
    }
}