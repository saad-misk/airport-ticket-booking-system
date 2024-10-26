using AirportTicketBookingSystem.Commands;
using AirportTicketBookingSystem.Helpers;
using AirportTicketBookingSystem.Services;

namespace AirportTicketBookingSystem.Views
{
    public class CommandFactory
    {
        private readonly BookingService _bookingService;
        private readonly FlightService _flightService;
        private readonly ManagerService _managerService;

        public CommandFactory(BookingService bookingService, FlightService flightService, ManagerService managerService)
        {
            _bookingService = bookingService;
            _flightService = flightService;
            _managerService = managerService;
        }

        public ICommand CreatePassengerCommand(string choice)
        {
            return choice switch
            {
                "1" => new BookFlightCommand(_bookingService, _flightService),
                "2" => new ViewBookingsCommand(_bookingService),
                "3" => new CancelBookingCommand(_bookingService),
                "4" => new ModifyBookingCommand(_bookingService, _flightService),
                "5" => new SearchFlightsCommand(_flightService),
                _ => throw new ArgumentException("invalid choice!")
            };
        }
        public ICommand CreateManagerCommand(string choice)
        {
            return choice switch
            {
                "1" => new AddFlightCommand(_flightService),
                "2" => new SearchFlightsCommand(_flightService),
                "3" => new ValidateFlightsCommand(_managerService),
                "4" => new ViewBookingsCommand(_bookingService),
                "5" => new FilterBookingsCommand(_managerService),
                "6" => new ModifyBookingCommand(_bookingService, _flightService),
                _ => throw new ArgumentException("invalid choice!")
            };
        }
    }
}
