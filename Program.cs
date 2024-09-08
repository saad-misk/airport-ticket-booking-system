using AirportTicketBookingSystem.Helpers;
using AirportTicketBookingSystem.Services;
using AirportTicketBookingSystem.Views;

class Program
{
    static void Main(string[] args)
    {

        var bookingService = new BookingService();
        var commandFactory = new CommandFactory(bookingService);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Select Role:");
            Console.WriteLine("1. Passenger");
            Console.WriteLine("2. Manager");
            Console.WriteLine("3. Exit");

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
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
            }

            menuStrategy.DisplayMenu();
        }        

    }
}
