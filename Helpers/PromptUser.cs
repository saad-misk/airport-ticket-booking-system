using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportTicketBookingSystem.Helpers
{
    public class PromptUser
    {
        public string PromptForString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine() ?? "";
        }

        public DateTime PromptForDate(string prompt)
        {
            DateTime date;
            while (true)
            {
                Console.Write(prompt);
                if (DateTime.TryParse(Console.ReadLine(), out date))
                {
                    return date;
                }
                Console.WriteLine("Invalid date format. Please try again.");
            }
        }

        public decimal PromptForDecimal(string prompt)
        {
            decimal number;
            while (true)
            {
                Console.Write(prompt);
                if (decimal.TryParse(Console.ReadLine(), out number))
                {
                    return number;
                }
                Console.WriteLine("Invalid number format. Please try again.");
            }
        }
    }
}
