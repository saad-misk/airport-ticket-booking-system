using AirportTicketBookingSystem.Helpers;
using AirportTicketBookingSystem.Models;
using AirportTicketBookingSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportTicketBookingSystem.Views
{
    public class BookFlightCommand : ICommand
    {
        private readonly BookingService _bookingService;
        private readonly FlightService _flightService;

        public BookFlightCommand(BookingService bookingService, FlightService flightService)
        {
            _bookingService = bookingService;
            _flightService = flightService;
        }
        public void Execute()
        {
            var promptUser = new PromptUser();
            Console.WriteLine("Enter Booking Information:");

            var passengerId = promptUser.PromptForString("Passenger ID: ");
            var flightNumber = promptUser.PromptForString("Flight Number: ");

            var flightCriteria = new Flight
            {
                FlightNumber = flightNumber,
            };
            var availableFlights = _flightService.GetAvailableFlights(flightCriteria);
            if( availableFlights.Any())
            {
                var flightClass = availableFlights[0].ClassPrices.First().Key;
                _bookingService.BookFlight(passengerId, flightNumber, flightClass);
                Console.WriteLine("Done! Booking a flight");
            }
            else
            {
                Console.WriteLine("There is no flight with that number, Enter an existing flight number");
            }
        }

        
    }
}
