using AirportTicketBookingSystem.Helpers;
using AirportTicketBookingSystem.Services;

namespace AirportTicketBookingSystem.Commands
{
    public class ViewBookingsCommand : ICommand
    {
        private readonly BookingService _bookingService;

        public ViewBookingsCommand(BookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public void Execute()
        {
            PromptUser promptUser = new PromptUser();
            string passengerId = promptUser.PromptForString("Enter Passenger ID: ");
            var bookings = _bookingService.GetPersonalBookings(passengerId);
            foreach (var booking in bookings)
            {
                Console.WriteLine(booking.ToString());
            }
            if (bookings.Count == 0)
            {
                Console.WriteLine($"There are no bookings for passenger with id: {passengerId}");
            }
        }
    }
}
