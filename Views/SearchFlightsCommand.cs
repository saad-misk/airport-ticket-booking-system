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
    public class SearchFlightsCommand : ICommand
    {
        private readonly FlightService _flightService;

        public SearchFlightsCommand(FlightService flightService)
        {
            _flightService = flightService;
        }

        public void Execute()
        {
            Flight flightCriteria = GetFlightInformationFromUser();
            var availableFlights = _flightService.GetAvailableFlights(flightCriteria);
            foreach(var flight in availableFlights){
                Console.WriteLine(flight.ToString());
            }
            if (availableFlights.Count == 0)
            {
                Console.WriteLine("There are no matching flights.");
            }
        }

        private Flight GetFlightInformationFromUser()
        {
            var flight = new Flight();
            var promptUser = new PromptUser();
            Console.WriteLine("Enter Flight Information:");

            flight.FlightNumber = promptUser.PromptForNullableString("Enter flight number (or press Enter to skip): ");
            flight.DepartureCountry = promptUser.PromptForNullableString("Enter departure country (or press Enter to skip): ");
            flight.DestinationCountry = promptUser.PromptForNullableString("Enter destination country (or press Enter to skip): ");
            flight.DepartureDate = promptUser.PromptForNullableDate("Enter departure date (yyyy-mm-dd) or press Enter to skip: ");
            flight.DepartureAirport = promptUser.PromptForNullableString("Enter departure airport (or press Enter to skip): ");
            flight.ArrivalAirport = promptUser.PromptForNullableString("Enter arrival airport (or press Enter to skip): ");
            flight.ClassPrices = null;
           

            return flight;
        }
    }
}
