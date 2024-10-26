using AirportTicketBookingSystem.Models;
using AirportTicketBookingSystem.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

public class FlightServiceTests
{
    private readonly Mock<FileService> _mockFileService;
    private readonly FlightService _flightService;

    public FlightServiceTests()
    {
        _mockFileService = new Mock<FileService>();
        _flightService = new FlightService(_mockFileService.Object);
    }

    [Fact]
    public void GetAvailableFlights_ReturnsMatchingFlights()
    {
        // Arrange
        var criteria = new Flight
        {
            DepartureCountry = "USA",
            DestinationCountry = "Canada"
        };
        var flights = new List<Flight>
        {
            new Flight { FlightNumber = "AB123", DepartureCountry = "USA", DestinationCountry = "Canada" },
            new Flight { FlightNumber = "CD456", DepartureCountry = "USA", DestinationCountry = "Mexico" },
            new Flight { FlightNumber = "EF789", DepartureCountry = "Canada", DestinationCountry = "USA" }
        };

        _mockFileService.Setup(fs => fs.LoadFromFile<Flight>(It.IsAny<string>())).Returns(flights);

        // Act
        var result = _flightService.GetAvailableFlights(criteria);

        // Assert
        Assert.Single(result);
        Assert.Equal("AB123", result.First().FlightNumber);
    }

    [Fact]
    public void GetAvailableFlights_ReturnsAllFlights_WhenCriteriaIsNull()
    {
        // Arrange
        var flights = new List<Flight>
        {
            new Flight { FlightNumber = "AB123", DepartureCountry = "USA", DestinationCountry = "Canada" },
            new Flight { FlightNumber = "CD456", DepartureCountry = "USA", DestinationCountry = "Mexico" }
        };

        _mockFileService.Setup(fs => fs.LoadFromFile<Flight>(It.IsAny<string>())).Returns(flights);

        // Act
        var result = _flightService.GetAvailableFlights(new Flight());

        // Assert
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void AddFlight_AddsFlightSuccessfully()
    {
        // Arrange
        var newFlight = new Flight { FlightNumber = "XY123", DepartureCountry = "UK", DestinationCountry = "France" };
        var existingFlights = new List<Flight>
        {
            new Flight { FlightNumber = "AB123", DepartureCountry = "USA", DestinationCountry = "Canada" }
        };

        _mockFileService.Setup(fs => fs.LoadFromFile<Flight>(It.IsAny<string>())).Returns(existingFlights);
        _mockFileService.Setup(fs => fs.SaveToFile(It.IsAny<string>(), It.IsAny<List<Flight>>()));

        // Act
        _flightService.AddFlight(newFlight);

        // Assert
        _mockFileService.Verify(fs => fs.SaveToFile(It.IsAny<string>(), It.IsAny<List<Flight>>()), Times.Once);
    }
}
