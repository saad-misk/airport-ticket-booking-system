using AirportTicketBookingSystem.Helpers;

namespace AirportTicketBookingSystem.Views
{
    public class ManagerMenuStrategy : IMenuStrategy
    {
        private readonly CommandFactory _commandFactory;

        public ManagerMenuStrategy(CommandFactory commandFactory)
        {
            _commandFactory = commandFactory;
        }

        public void DisplayMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Manager Menu:");
                Console.WriteLine("1. Add Flight");
                Console.WriteLine("2. Search For Available Flights");
                Console.WriteLine("3. Validate Flights");
                Console.WriteLine("4. View Bookings");
                Console.WriteLine("5. Filter Bookings");
                Console.WriteLine("6. Modify Booking");
                Console.WriteLine("7. Logout");

                string choice = Console.ReadLine() ?? "8";
                if (choice == "7") return;

                try
                {
                    var command = _commandFactory.CreateManagerCommand(choice);
                    command.Execute();
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }
        }
    }
}
