using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;
using EventsKob.Controllers;
using EventsKob.Models;
using EventsKob.ViewModels.Validators;

namespace EventsKob.ViewModels
{
    public class EventFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Venue { get; set; }

        [Required]
        [FutureDate(ErrorMessage = "Date needs to be future")]
        public string Date { get; set; }

        [Required]
        [ValidTime(ErrorMessage =  "Incorrect time format")]
        public string Time { get; set; }

        [Required]
        public int Genre { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public string Heading { get; set; }

        public string Action
        {
            get
            {
                //some magic tricks to avoid using hardcoded magic strings XD
                Expression<Func<EventsController, ActionResult>> update = (u => u.Update(this));
                Expression<Func<EventsController, ActionResult>> create = (u => u.Create(this));

                var action = Id != 0 ? update : create;
                var actionName = (action.Body as MethodCallExpression).Method.Name;
                return actionName;
            }
        }

        public DateTime GetDateTime()
        {
            return DateTime.Parse($"{Date} {Time}");
        }
    }
}
