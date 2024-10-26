using AirportTicketBookingSystem.Helpers;
using AirportTicketBookingSystem.Services;

namespace AirportTicketBookingSystem.Commands
{
    public class ValidateFlightsCommand : ICommand
    {
        private readonly ManagerService _managerService;

        public ValidateFlightsCommand(ManagerService managerService)
        {
            _managerService = managerService;
        }

        public void Execute()
        {
            _managerService.ValidateReport();
        }
    }
}
