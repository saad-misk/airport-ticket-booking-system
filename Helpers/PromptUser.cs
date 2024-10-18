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
        public string? PromptForNullableString(string prompt)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();
            return string.IsNullOrWhiteSpace(input) ? null : input;
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
        public DateTime? PromptForNullableDate(string prompt)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();
            return DateTime.TryParse(input, out var result) ? (DateTime?)result : null;
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
        public decimal? PromptForNullableDecimal(string prompt)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();
            return decimal.TryParse(input, out var result) ? (decimal?)result : null;
        }
    }
}
