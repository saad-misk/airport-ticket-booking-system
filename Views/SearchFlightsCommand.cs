using AirportTicketBookingSystem.Helpers;
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
            Console.WriteLine("... Search For Available Flights ...");
        }
    }
}
