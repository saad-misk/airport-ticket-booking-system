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
        private string flightFilePath = $"{AppDomain.CurrentDomain.BaseDirectory}../../../Data/flights.json";
        private string bookingFilePath = $"{AppDomain.CurrentDomain.BaseDirectory}../../../Data/bookings.json";

        public List<Booking> FilterBookings(FilterCriteria criteria)
        {
            var bookings = LoadBookings();
            return bookings.Where(b =>
                (criteria.FlightNumber == null || b.FlightNumber == criteria.FlightNumber) &&
                (criteria.Price == null || GetFlightPrice(b.FlightNumber, b.Class) == criteria.Price) &&
                (criteria.DepartureCountry == null || GetFlight(b.FlightNumber).DepartureCountry == criteria.DepartureCountry) &&
                (criteria.DestinationCountry == null || GetFlight(b.FlightNumber).DestinationCountry == criteria.DestinationCountry) &&
                (criteria.DepartureDate == null || (GetFlight(b.FlightNumber)?.DepartureDate.HasValue == true &&
                 GetFlight(b.FlightNumber)?.DepartureDate.Value.Date == criteria.DepartureDate.Value.Date)  ) && 
                (criteria.DepartureAirport == null || GetFlight(b.FlightNumber).DepartureAirport == criteria.DepartureAirport) &&
                (criteria.ArrivalAirport == null || GetFlight(b.FlightNumber).ArrivalAirport == criteria.ArrivalAirport) &&
                (criteria.Passenger == null || b.PassengerId == criteria.Passenger) &&
                (criteria.Class == null || b.Class == criteria.Class)
            ).ToList();
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
        }
        public void BatchUploadFlights()
        {
            Console.WriteLine("hello");
        }

        private void SaveFlight(Flight flight)
        {
            var flights = LoadFlights();
            flights.Add(flight);

            string updatedJson = JsonConvert.SerializeObject(flights, Formatting.Indented);

            File.WriteAllText(bookingFilePath, updatedJson);
        }

        private Flight GetFlight(string flightNumber)
        {
            var flights = LoadFlights();
            return flights.FirstOrDefault(f => f.FlightNumber == flightNumber) ?? new Flight();
        }

        private List<Booking> LoadBookings()
        {
            if (!File.Exists(bookingFilePath))
            {
                throw new FileNotFoundException($"File not found: {bookingFilePath}");
            }
            string json = File.ReadAllText(bookingFilePath);
            return JsonConvert.DeserializeObject<List<Booking>>(json) ?? new List<Booking>();

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

        private decimal GetFlightPrice(string flightNumber, string flightClass)
        {
            var flight = GetFlight(flightNumber);
            return flight.ClassPrices.ContainsKey(flightClass) ? flight.ClassPrices[flightClass] : 0;
        }
    }


}
