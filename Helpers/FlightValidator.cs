using AirportTicketBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportTicketBookingSystem.Helpers
{
    public class FlightValidator
    {
        public List<string> ValidateFlight(List<Flight> flights)
        {
            var errors = new List<string>();

            foreach (var flight in flights)
            {
                var validationResults = new List<ValidationResult>();
                var context = new ValidationContext(flight);

                if( !Validator.TryValidateObject(flight, context, validationResults))
                {
                    foreach (var validationResult in validationResults)
                    {
                        errors.Add($"Flight {flight.FlightNumber}: {validationResult.ErrorMessage}");
                    }
                }
            }

            return errors;
        }
    }
}
