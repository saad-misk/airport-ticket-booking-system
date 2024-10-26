using AirportTicketBookingSystem.Helpers;
using AirportTicketBookingSystem.Services;
using AirportTicketBookingSystem.Views;

class Program
{
    static void Main(string[] args)
    {
        var bookingService = new BookingService();
        var flightService = new FlightService();
        var managerService = new ManagerService();
        var commandFactory = new CommandFactory(bookingService, flightService, managerService);

        while (true)
        {
            DisplayMainMenu();

            var roleChoice = Console.ReadLine();
            IMenuStrategy menuStrategy;

            switch (roleChoice)
            {
                case "1":
                    menuStrategy = new PassengerMenuStrategy(commandFactory);
                    break;
                case "2":
                    menuStrategy = new ManagerMenuStrategy(commandFactory);
                    break;
                case "3":
                    Console.WriteLine("Exiting the application...");
                    return;
                default:
                    DisplayInvalidChoice();
                    continue;
            }

            menuStrategy.DisplayMenu();
        }
    }

    private static void DisplayMainMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("*****************************************");
        Console.WriteLine("          Welcome to Airport Ticket       ");
        Console.WriteLine("              Booking System             ");
        Console.WriteLine("*****************************************");
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine("Select Role:");
        Console.WriteLine("1. Passenger");
        Console.WriteLine("2. Manager");
        Console.WriteLine("3. Exit");
        Console.Write("Enter your choice: ");
    }

    private static void DisplayInvalidChoice()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid choice. Please try again.");
        Console.ResetColor();
        Console.WriteLine();
    }
}
