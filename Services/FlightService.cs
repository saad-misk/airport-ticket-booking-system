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
        private readonly FileService _fileService;
        public string flightFilePath = $"{AppDomain.CurrentDomain.BaseDirectory}../../../Data/flights.json";

        public FlightService()
        {
            _fileService = new FileService();
        }
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
            return _fileService.LoadFromFile<Flight>(flightFilePath);
        }

        public void AddFlight(Flight flight)
        {
            List<Flight> flights = LoadFlights();
            flights.Add(flight);
            SaveFlights(flights);
        }

        private void SaveFlights(List<Flight> flights)
        {
            _fileService.SaveToFile(flightFilePath, flights);
        }

    }
}
