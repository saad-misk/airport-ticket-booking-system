using AirportTicketBookingSystem.Helpers;
using AirportTicketBookingSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportTicketBookingSystem.Views
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
