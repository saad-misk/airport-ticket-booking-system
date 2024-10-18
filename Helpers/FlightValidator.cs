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
            int cnt = 0;
            foreach (var flight in flights)
            {
                var validationResults = new List<ValidationResult>();
                var context = new ValidationContext(flight);

                cnt++;
                if( !Validator.TryValidateObject(flight, context, validationResults, true))
                {
                    foreach (var validationResult in validationResults)
                    {

                        errors.Add($"Flight({cnt}) {flight.FlightNumber}: {validationResult.ErrorMessage}");
                    }
                }
            }

            return errors;
        }
    }
}
