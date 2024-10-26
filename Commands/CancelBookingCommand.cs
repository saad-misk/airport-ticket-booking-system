using AirportTicketBookingSystem.Helpers;
using AirportTicketBookingSystem.Services;

namespace AirportTicketBookingSystem.Commands
{
    public class CancelBookingCommand : ICommand
    {
        private readonly BookingService _bookingService;

        public CancelBookingCommand(BookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public void Execute()
        {
            var promptUser = new PromptUser();
            var bookingId = promptUser.PromptForString("Enter Booking ID to Cancel: ");
            _bookingService.CancelBooking(bookingId);
        }
    }
}
