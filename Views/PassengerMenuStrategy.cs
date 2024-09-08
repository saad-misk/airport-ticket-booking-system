using AirportTicketBookingSystem.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportTicketBookingSystem.Views
{
    public class PassengerMenuStrategy : IMenuStrategy
    {
        private readonly CommandFactory _commandFactory;

        public PassengerMenuStrategy(CommandFactory commandFactory)
        {
            _commandFactory = commandFactory;
        }

        public void DisplayMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Passenger Menu:");
                Console.WriteLine("1. Book Flight");
                Console.WriteLine("2. View Bookings");
                Console.WriteLine("3. Cancel Booking");
                Console.WriteLine("4. Modify Booking");
                Console.WriteLine("5. Search for available flights");
                Console.WriteLine("6. Logout");

                var choice = Console.ReadLine() ?? "7";

                if (choice == "6") return;

                try
                {
                    var command = _commandFactory.CreatePassengerCommand(choice);
                    command.Execute();
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }
            
        }
    }
}
