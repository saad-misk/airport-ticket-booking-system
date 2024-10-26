using AirportTicketBookingSystem.Helpers;
using System.ComponentModel.DataAnnotations;

namespace AirportTicketBookingSystem.Models
{
    public class Flight
    {
        [Required(ErrorMessage = "Flight number is required.")]
        [StringLength(10, ErrorMessage = "Flight number cannot exceed 10 characters.")]
        public string? FlightNumber { get; set; }

        [Required(ErrorMessage = "Departure country is required.")]
        public string? DepartureCountry { get; set; }

        [Required(ErrorMessage = "Destination country is required.")]
        public string? DestinationCountry { get; set; }

        [Required(ErrorMessage = "Departure date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        //for static Range validation we could use Range()
        //[Range(typeof(DateTime), "1/1/2024", "1/1/2026",
        // ErrorMessage = "Value for {0} must be between {2025} and {2026}")]
        [DateRange(-30, 100, ErrorMessage = "Booking date must be between 1 day and 30 days from today.")]
        public DateTime? DepartureDate { get; set; }

        [Required(ErrorMessage = "Departure airport is required.")]
        public string? DepartureAirport { get; set; }

        [Required(ErrorMessage = "Arrival airport is required.")]
        public string? ArrivalAirport { get; set; }

        [Required(ErrorMessage = "Class prices are required.")]
        public Dictionary<string, decimal> ClassPrices { get; set; } = new Dictionary<string, decimal>();

        //public override string ToString()
        //{
        //    var classPricesFormatted = string.Join(", ", ClassPrices.Select(cp => $"{cp.Key}: {cp.Value:C}"));
        //    var departureDateFormatted = DepartureDate.HasValue ? DepartureDate.Value.ToString("yyyy-MM-dd") : "N/A";

        //    return $"Flight Number: {FlightNumber}, " +
        //           $"Departure Country: {DepartureCountry}, " +
        //           $"Destination Country: {DestinationCountry}, " +
        //           $"Departure Date: {departureDateFormatted}, " +
        //           $"Departure Airport: {DepartureAirport}, " +
        //           $"Arrival Airport: {ArrivalAirport}, " +
        //           $"Class Prices: [{classPricesFormatted}]";
        //}

    }
}
