using AirportTicketBookingSystem.Helpers;
using AirportTicketBookingSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportTicketBookingSystem.Views
{
    public class CancelBookingCommand : ICommand
    {
        private readonly BookingService _bookingService;

        public CancelBookingCommand(BookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public void Execute()
        {
            Console.WriteLine(".. CancelBooking ...");
        }
    }
}
