using AirportTicketBookingSystem.Helpers;
using AirportTicketBookingSystem.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportTicketBookingSystem.Services
{

    public class ManagerService
    {
        private readonly FileService _fileService;
        private string flightFilePath = $"{AppDomain.CurrentDomain.BaseDirectory}../../../Data/flights.json";
        private string bookingFilePath = $"{AppDomain.CurrentDomain.BaseDirectory}../../../Data/bookings.json";

        public ManagerService()
        {
            _fileService = new FileService();
        }
        public List<Booking> FilterBookings(FilterCriteria criteria)
        {
            var bookings = LoadBookings();

            return bookings.Where(b =>
            {
                var flight = GetFlight(b.FlightNumber);
                var flightPrice = flight != null ? GetFlightPrice(b.FlightNumber, b.Class) : (decimal?)null;                
                return
                    (criteria.FlightNumber == null || b.FlightNumber == criteria.FlightNumber) &&
                    (criteria.Price == null || flightPrice == criteria.Price) &&
                    (criteria.DepartureCountry == null || (flight != null && flight.DepartureCountry == criteria.DepartureCountry)) &&
                    (criteria.DestinationCountry == null || (flight != null && flight.DestinationCountry == criteria.DestinationCountry)) &&
                    (criteria.DepartureDate == null || (flight != null && flight.DepartureDate.HasValue && flight.DepartureDate.Value.Date == criteria.DepartureDate.Value.Date)) &&
                    (criteria.DepartureAirport == null || (flight != null && flight.DepartureAirport == criteria.DepartureAirport)) &&
                    (criteria.ArrivalAirport == null || (flight != null && flight.ArrivalAirport == criteria.ArrivalAirport)) &&
                    (criteria.Passenger == null || b.PassengerId == criteria.Passenger) &&
                    (criteria.Class == null || b.Class == criteria.Class);
            }).ToList();
        }

        public List<string> Validate()
        {
            var flights = LoadFlights();

            FlightValidator fv = new FlightValidator();
            List<string> result = fv.ValidateFlight(flights);

            return result;
        }

        public void ValidateReport()
        {
            var txt = Validate();
            foreach(var t in txt)
            {
                Console.WriteLine(t);
            }
            if(txt.Count == 0)
            {
                Console.WriteLine("All Flights are valid");
            }
        }

        private void SaveFlight(Flight flight)
        {
            var flights = LoadFlights();
            flights.Add(flight);

            _fileService.SaveToFile(flightFilePath, flights);
        }

        private Flight GetFlight(string flightNumber)
        {
            var flights = LoadFlights();
            return flights.FirstOrDefault(f => f.FlightNumber == flightNumber) ?? new Flight();
        }

        private List<Booking> LoadBookings()
        {
            return _fileService.LoadFromFile<Booking>(bookingFilePath);
        }

        private List<Flight> LoadFlights()
        {
            return _fileService.LoadFromFile<Flight>(flightFilePath);
        }

        public decimal GetFlightPrice(string flightNumber, string flightClass)
        {
            var flight = GetFlight(flightNumber);
            return flight.ClassPrices.ContainsKey(flightClass) ? flight.ClassPrices[flightClass] : 0;
        }
    }


}
