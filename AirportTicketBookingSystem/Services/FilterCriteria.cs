namespace AirportTicketBookingSystem.Services
{
    public class FilterCriteria
    {
        public string? FlightNumber { get; set; }
        public decimal? Price { get; set; }
        public string? DepartureCountry { get; set; }
        public string? DestinationCountry { get; set; }
        public DateTime? DepartureDate { get; set; }
        public string? DepartureAirport { get; set; }
        public string? ArrivalAirport { get; set; }
        public string? Passenger { get; set; }
        public string? Class { get; set; }

        public override string ToString()
        {
            var departureDateFormatted = DepartureDate.HasValue ? DepartureDate.Value.ToString("yyyy-MM-dd") : "N/A";
            var priceFormatted = Price.HasValue ? Price.Value.ToString("C") : "N/A";

            return $"Flight Number: {FlightNumber ?? "N/A"}, " +
                   $"Price: {priceFormatted}, " +
                   $"Departure Country: {DepartureCountry ?? "N/A"}, " +
                   $"Destination Country: {DestinationCountry ?? "N/A"}, " +
                   $"Departure Date: {departureDateFormatted}, " +
                   $"Departure Airport: {DepartureAirport ?? "N/A"}, " +
                   $"Arrival Airport: {ArrivalAirport ?? "N/A"}, " +
                   $"Passenger: {Passenger ?? "N/A"}, " +
                   $"Class: {Class ?? "N/A"}";
        }

    }
}
