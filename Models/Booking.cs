using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportTicketBookingSystem.Models
{
    public class Booking
    {
        public Guid BookingId { get; set; }
        public string FlightNumber { get; set; }
        public string PassengerId { get; set; }
        public string Class { get; set; }
        public DateTime BookingDate { get; set; }

        public override string ToString()
        {
            return $"Booking ID: {BookingId.ToString() ?? "N/A"}, " +
                   $"Flight Number: {FlightNumber ?? "N/A"}, " +
                   $"Passenger ID: {PassengerId ?? "N/A"}, " +
                   $"Class: {Class ?? "N/A"}, " +
                   $"Booking Date: {BookingDate:yyyy-MM-dd}";
        }
    }
}
