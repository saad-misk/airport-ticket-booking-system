using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportTicketBookingSystem.Models
{
    public class Booking
    {
        public string BookingId { get; set; }
        public string FlightNumber { get; set; }
        public string PassengerId { get; set; }
        public string Class { get; set; }
        public DateTime BookingDate { get; set; }

    }
}
