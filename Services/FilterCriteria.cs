using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportTicketBookingSystem.Services
{
    public class FilterCriteria
    {
        public string FlightNumber { get; set; }
        public decimal? Price { get; set; }
        public string DepartureCountry { get; set; }
        public string DestinationCountry { get; set; }
        public DateTime? DepartureDate { get; set; } // Nullable DateTime
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public string Passenger { get; set; }
        public string Class { get; set; }
    }
}
