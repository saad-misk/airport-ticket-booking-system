using AirportTicketBookingSystem.Helpers;
using AirportTicketBookingSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportTicketBookingSystem.Views
{
    public class FilterBookingsCommand : ICommand
    {
        private readonly ManagerService _managerService;

        public FilterBookingsCommand(ManagerService managerService)
        {
            _managerService = managerService;
        }

        public void Execute()
        {
            Console.WriteLine("... Filter Bookings ..");
        }
    }
}
