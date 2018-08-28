using System;
using System.ComponentModel.DataAnnotations;

namespace EventsKob.ViewModels.Validators
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