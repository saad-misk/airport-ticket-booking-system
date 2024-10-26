using System;
using System.Collections.Generic;
using System.Linq;
using AirportTicketBookingSystem.Models;
using AirportTicketBookingSystem.Services;
using Moq;
using Xunit;

namespace AirportTicketBookingSystem.Tests
{
    public class BookingServiceTests
    {
        private readonly Mock<FileService> _mockFileService;
        private readonly BookingService _bookingService;

        public BookingServiceTests()
        {
            // Create the mock for FileService
            _mockFileService = new Mock<FileService>();
            // Initialize BookingService with the mocked FileService
            _bookingService = new BookingService(_mockFileService.Object);
        }

        [Fact]
        public void BookFlight_ShouldAddBooking()
        {
            // Arrange
            var passengerId = "passenger1";
            var flightNumber = "FL123";
            var flightClass = "Economy";

            // Simulate loading an empty booking list
            _mockFileService.Setup(fs => fs.LoadFromFile<Booking>(It.IsAny<string>()))
                .Returns(new List<Booking>());

            // Act
            _bookingService.BookFlight(passengerId, flightNumber, flightClass);

            // Assert
            _mockFileService.Verify(fs => fs.SaveToFile<Booking>(
                It.IsAny<string>(),
                It.Is<List<Booking>>(bookings =>
                    bookings.Count == 1 &&
                    bookings[0].PassengerId == passengerId &&
                    bookings[0].FlightNumber == flightNumber &&
                    bookings[0].Class == flightClass
                )
            ), Times.Once);
        }

        [Fact]
        public void CancelBooking_ShouldRemoveBooking()
        {
            // Arrange
            var bookingId = Guid.NewGuid().ToString();
            var bookings = new List<Booking>
            {
                new Booking { BookingId = Guid.Parse(bookingId) }
            };

            _mockFileService.Setup(fs => fs.LoadFromFile<Booking>(It.IsAny<string>()))
                .Returns(bookings);

            // Act
            _bookingService.CancelBooking(bookingId);

            // Assert
            _mockFileService.Verify(fs => fs.SaveToFile<Booking>(
                It.IsAny<string>(),
                It.Is<List<Booking>>(b => b.Count == 0)
            ), Times.Once);
        }

        [Fact]
        public void ModifyBooking_ShouldChangeFlightDetails()
        {
            // Arrange
            var bookingId = Guid.NewGuid().ToString();
            var bookings = new List<Booking>
            {
                new Booking { BookingId = Guid.Parse(bookingId), FlightNumber = "FL123", Class = "Economy" }
            };

            _mockFileService.Setup(fs => fs.LoadFromFile<Booking>(It.IsAny<string>()))
                .Returns(bookings);

            var newFlightNumber = "FL456";
            var newClass = "Business";

            // Act
            _bookingService.ModifyBooking(bookingId, newFlightNumber, newClass);

            // Assert
            Assert.Equal(newFlightNumber, bookings.First().FlightNumber);
            Assert.Equal(newClass, bookings.First().Class);
            _mockFileService.Verify(fs => fs.SaveToFile<Booking>(
                It.IsAny<string>(),
                It.Is<List<Booking>>(b =>
                    b.First().FlightNumber == newFlightNumber &&
                    b.First().Class == newClass
                )
            ), Times.Once);
        }

        [Fact]
        public void GetPersonalBookings_ShouldReturnCorrectBookings()
        {
            // Arrange
            var passengerId = "passenger1";
            var bookings = new List<Booking>
            {
                new Booking { PassengerId = passengerId },
                new Booking { PassengerId = "passenger2" }
            };

            _mockFileService.Setup(fs => fs.LoadFromFile<Booking>(It.IsAny<string>()))
                .Returns(bookings);

            // Act
            var result = _bookingService.GetPersonalBookings(passengerId);

            // Assert
            Assert.Single(result);
            Assert.Equal(passengerId, result.First().PassengerId);
        }
    }
}
