using System;
using System.ComponentModel.DataAnnotations;


namespace AirportTicketBookingSystem.Helpers
{
    public class DateRangeAttribute : ValidationAttribute
    {
        private readonly DateTime _minDate;
        private readonly DateTime _maxDate;

        public DateRangeAttribute(int minDaysFromToday, int maxDaysFromToday)
        {
            _minDate = DateTime.Today.AddDays(minDaysFromToday);
            _maxDate = DateTime.Today.AddDays(maxDaysFromToday);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime date)
            {
                if (date < _minDate || date > _maxDate)
                {
                    return new ValidationResult(ErrorMessage ?? $"Date must be between {_minDate.ToShortDateString()} and {_maxDate.ToShortDateString()}");
                }
            }

            return ValidationResult.Success;
        }
    }
}
