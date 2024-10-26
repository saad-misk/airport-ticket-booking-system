using AirportTicketBookingSystem.Helpers;
using AirportTicketBookingSystem.Models;
using AirportTicketBookingSystem.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

public class ManagerServiceTests
{
    private readonly Mock<FileService> _mockFileService;
    private readonly ManagerService _managerService;

    public ManagerServiceTests()
    {
        _mockFileService = new Mock<FileService>();
        _managerService = new ManagerService(_mockFileService.Object);
    }

    [Fact]
    public void FilterBookings_ReturnsMatchingBookings_WhenCriteriaMatch()
    {
        // Arrange
        var bookings = new List<Booking>
        {
            new Booking { FlightNumber = "AB123", PassengerId = "P1", Class = "Economy" },
            new Booking { FlightNumber = "CD456", PassengerId = "P2", Class = "Business" },
            new Booking { FlightNumber = "AB123", PassengerId = "P3", Class = "Economy" }
        };

        var flights = new List<Flight>
        {
            new Flight { FlightNumber = "AB123", DepartureCountry = "USA", DestinationCountry = "Canada", ClassPrices = new Dictionary<string, decimal> { { "Economy", 100 }, { "Business", 200 } } },
            new Flight { FlightNumber = "CD456", DepartureCountry = "UK", DestinationCountry = "France", ClassPrices = new Dictionary<string, decimal> { { "Economy", 150 }, { "Business", 300 } } }
        };

        var criteria = new FilterCriteria
        {
            FlightNumber = "AB123",
            Class = "Economy"
        };

        _mockFileService.Setup(fs => fs.LoadFromFile<Booking>(It.IsAny<string>())).Returns(bookings);
        _mockFileService.Setup(fs => fs.LoadFromFile<Flight>(It.IsAny<string>())).Returns(flights);

        // Act
        var result = _managerService.FilterBookings(criteria);

        // Assert
        Assert.Equal(2, result.Count);
        Assert.All(result, b => Assert.Equal("AB123", b.FlightNumber));
        Assert.All(result, b => Assert.Equal("Economy", b.Class));
    }

    [Fact]
    public void FilterBookings_ReturnsNoBookings_WhenNoCriteriaMatch()
    {
        // Arrange
        var bookings = new List<Booking>
        {
            new Booking { FlightNumber = "AB123", PassengerId = "P1", Class = "Economy" },
            new Booking { FlightNumber = "CD456", PassengerId = "P2", Class = "Business" }
        };

        var flights = new List<Flight>
        {
            new Flight { FlightNumber = "AB123", DepartureCountry = "USA", DestinationCountry = "Canada", ClassPrices = new Dictionary<string, decimal> { { "Economy", 100 } } }
        };

        var criteria = new FilterCriteria
        {
            FlightNumber = "XY789" // No matching flight number
        };

        _mockFileService.Setup(fs => fs.LoadFromFile<Booking>(It.IsAny<string>())).Returns(bookings);
        _mockFileService.Setup(fs => fs.LoadFromFile<Flight>(It.IsAny<string>())).Returns(flights);

        // Act
        var result = _managerService.FilterBookings(criteria);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void FilterBookings_ReturnsFilteredBookings_ByDepartureCountry()
    {
        // Arrange
        var bookings = new List<Booking>
        {
            new Booking { FlightNumber = "AB123", PassengerId = "P1", Class = "Economy" },
            new Booking { FlightNumber = "CD456", PassengerId = "P2", Class = "Business" }
        };

        var flights = new List<Flight>
        {
            new Flight { FlightNumber = "AB123", DepartureCountry = "USA", DestinationCountry = "Canada" },
            new Flight { FlightNumber = "CD456", DepartureCountry = "UK", DestinationCountry = "France" }
        };

        var criteria = new FilterCriteria
        {
            DepartureCountry = "USA"
        };

        _mockFileService.Setup(fs => fs.LoadFromFile<Booking>(It.IsAny<string>())).Returns(bookings);
        _mockFileService.Setup(fs => fs.LoadFromFile<Flight>(It.IsAny<string>())).Returns(flights);

        // Act
        var result = _managerService.FilterBookings(criteria);

        // Assert
        Assert.Single(result);
        Assert.Equal("AB123", result.First().FlightNumber);
    }
}
