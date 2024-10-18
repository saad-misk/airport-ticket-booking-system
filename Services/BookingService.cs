using AirportTicketBookingSystem.Models;

namespace AirportTicketBookingSystem.Services
{
    public class BookingService
    {
        private readonly FileService _fileService;
        private string bookingFilePath = $"{AppDomain.CurrentDomain.BaseDirectory}../../../Data/bookings.json";
        private string passengerFilePath = $"{AppDomain.CurrentDomain.BaseDirectory}../../../Data/passengers.json";

        public BookingService()
        {
            _fileService = new FileService();
        }

        public void BookFlight(string passengerId, string flightNumber, string flightClass)
        {
            var booking = new Booking
            {
                BookingId = Guid.NewGuid(),
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

            int removedCount = bookings.RemoveAll(b => b.BookingId.ToString() == bookingId);

            if (removedCount == 0) 
            {
                Console.WriteLine($"No booking found with ID: {bookingId}");
            }
            else
            {
                Console.WriteLine("Done! Booking was removed.");
            }

            SaveBookings(bookings);
        }

        public void ModifyBooking(string bookingId, string newFlightNumber, string newClass)
        {
            var bookings = LoadBookings();

            var bookingToModify = bookings.FirstOrDefault(b => b.BookingId.ToString() == bookingId);

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
            _fileService.SaveToFile<Booking>(bookingFilePath, bookingsList);
        }
        private void SaveBooking(Booking booking)
        {
            var bookings = LoadBookings();
            bookings.Add(booking);
            SaveBookings(bookings);
        }

        private List<Booking> LoadBookings()
        {
            return _fileService.LoadFromFile<Booking>(bookingFilePath);
        }

    }
}
