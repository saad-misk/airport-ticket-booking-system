using AirportTicketBookingSystem.Helpers;
using AirportTicketBookingSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportTicketBookingSystem.Views
{
    public class AddFlightCommand : ICommand
    {
        private readonly FlightService _flightService;

        public AddFlightCommand(FlightService flightService)
        {
            _flightService = flightService;
        }

        public void Execute()
        {
            Console.WriteLine("... Add Flight ...");
        }
    }
}
