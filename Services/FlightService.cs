using AirportTicketBookingSystem.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportTicketBookingSystem.Services
{
    public class FlightService
    {
        public string flightFilePath = "Data/flights.json";

        public List<Flight> GetAvailableFlights(Flight criteria)
        {
            var flights = LoadFlights();
            return flights.Where(f =>
                (criteria.FlightNumber == null || f.FlightNumber.Contains(criteria.FlightNumber)) &&
                (criteria.DepartureCountry == null || f.DepartureCountry == criteria.DepartureCountry) &&
                (criteria.DestinationCountry == null || f.DestinationCountry == criteria.DestinationCountry) &&
                (criteria.DepartureAirport == null || f.DepartureAirport == criteria.DepartureAirport) &&
                (criteria.ArrivalAirport == null || f.ArrivalAirport == criteria.ArrivalAirport) &&
                (criteria.DepartureDate == null || f.DepartureDate == criteria.DepartureDate) &&
                (criteria.ClassPrices == null || f.ClassPrices.Intersect(criteria.ClassPrices) != null)
            ).ToList();
        }
        private List<Flight> LoadFlights()
        {
            if (!File.Exists(flightFilePath))
            {
                throw new FileNotFoundException($"File not found: {flightFilePath}");
            }
            string json = File.ReadAllText(flightFilePath);
            return JsonConvert.DeserializeObject<List<Flight>>(json) ?? new List<Flight>();
        }

    }
}
