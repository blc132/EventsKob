using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc.Routing.Constraints;

namespace EventsKob.ViewModels
{
    public class FutureDate: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var isValid = DateTime.TryParse(value.ToString(), out var dateTime);
            return (isValid && dateTime > DateTime.Now);
        }
    }
}