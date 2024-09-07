using AirportTicketBookingSystem.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportTicketBookingSystem.Services
{
    public class BookingService
    {
        private string bookingFilePath = "bookings.json";
        private string passengerFilePath = "passengers.json";

        public void BookFlight(string passengerId, string flightNumber, string flightClass)
        {
            var booking = new Booking
            {
                BookingId = Guid.NewGuid().ToString(),
                FlightNumber = flightNumber,
                PassengerId = passengerId,
                Class = flightClass,
                BookingDate = DateTime.Now
            };

            SaveBooking(booking);

        }

        public void CancelBooking(string bookingId)
        {

            List<Booking> bookings = LoadBookings();

            int removedCount = bookings.RemoveAll(b => b.BookingId == bookingId);

            if (removedCount == 0) 
            {
                Console.WriteLine($"No booking found with ID: {bookingId}");
            }

            SaveBookings(bookings);
        }

        public void ModifyBooking(string bookingId, string newFlightNumber, string newClass)
        {
            var bookings = LoadBookings();

            var bookingToModify = bookings.FirstOrDefault(b => b.BookingId == bookingId);

            if(bookingToModify != null)
            {
                bookingToModify.FlightNumber = newFlightNumber;
                bookingToModify.Class = newClass;

                SaveBookings(bookings);
            }
            else
            {
                Console.WriteLine($"No booking found with ID: {bookingId}");
            }

        }

        public List<Booking> GetPersonalBookings(string passengerId)
        {
            var bookings = LoadBookings();
            return bookings.Where(b => b.PassengerId == passengerId).ToList();
        }

        private void SaveBookings(List<Booking> bookingsList)
        {
            var bookings = LoadBookings();
            bookings.Concat(bookingsList);

            string updatedJson = JsonConvert.SerializeObject(bookings, Formatting.Indented);

            File.WriteAllText(bookingFilePath, updatedJson);

        }
        private void SaveBooking(Booking booking)
        {
            var bookings = LoadBookings();
            bookings.Add(booking);

            string updatedJson = JsonConvert.SerializeObject(bookings, Formatting.Indented);

            File.WriteAllText(bookingFilePath, updatedJson);

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

    }
}
