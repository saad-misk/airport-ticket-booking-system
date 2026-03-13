# Airport Ticket Booking System

A console based airport ticket booking system built with **C# / .NET 8** as a backend internship learning project.
---

## Features

### Passenger Role
| Action | Description |
|---|---|
| **Book a Flight** | Browse available flights and book a seat in a specific class (Economy, Business, First Class) |
| **View Bookings** | View all personal bookings by passenger ID |
| **Cancel Booking** | Cancel an existing booking by booking ID |
| **Modify Booking** | Change the flight or class of an existing booking |
| **Search Flights** | Search for available flights by departure/destination country, airport, date, or class |

### Manager Role
| Action | Description |
|---|---|
| **Add Flight** | Add a new flight with details such as airports, dates, and class-based pricing |
| **Search Flights** | Search the flight catalog with flexible criteria |
| **Validate Flights** | Run Data Annotations validation on all flights and generate a report of any errors |
| **View Bookings** | View all bookings in the system |
| **Filter Bookings** | Filter bookings by flight number, price, country, airport, passenger, date, or class |
| **Modify Booking** | Modify any booking in the system |

---

## Design Patterns & Architecture

This project applies several **OOP design patterns** to keep the code modular and maintainable:

### Command Pattern
Every user action (book, cancel, search, etc.) is encapsulated in its own command class implementing the `ICommand` interface. This decouples what the user requests from how it's executed.

```
ICommand
├── BookFlightCommand
├── CancelBookingCommand
├── ModifyBookingCommand
├── ViewBookingsCommand
├── SearchFlightsCommand
├── AddFlightCommand
├── ValidateFlightsCommand
└── FilterBookingsCommand
```

### Strategy Pattern
Role-based menus are implemented using the `IMenuStrategy` interface. The main program selects the appropriate strategy (`PassengerMenuStrategy` or `ManagerMenuStrategy`) at runtime based on the user's role choice.

### Factory Pattern
`CommandFactory` instantiates the correct command object based on the user's menu selection, keeping the menu strategies clean and independent of command construction logic.

## Project Structure

```
AirportTicketBookingSystem/
│
├── Program.cs                  # Entry point
│
├── Models/
│   ├── Flight.cs
│   ├── Booking.cs
│   └── Passenger.cs
│
├── Services/
│   ├── BookingService.cs       # Book, cancel, modify, and retrieve bookings
│   ├── FlightService.cs       # Search and add flights
│   ├── ManagerService.cs      # Filter bookings, validate flights, pricing
│   ├── FilterCriteria.cs      # Criteria object for flexible booking filtering
│   └── FileService.cs         # Generic JSON file read/write using Newtonsoft.Json
│
├── Commands/
│   ├── BookFlightCommand.cs
│   ├── CancelBookingCommand.cs
│   ├── ModifyBookingCommand.cs
│   ├── ViewBookingsCommand.cs
│   ├── SearchFlightsCommand.cs
│   ├── AddFlightCommand.cs
│   ├── ValidateFlightsCommand.cs
│   └── FilterBookingsCommand.cs
│
├── Helpers/
│   ├── ICommand.cs             # Command interface
│   ├── IMenuStrategy.cs        # Strategy interface for role menus
│   ├── FlightValidator.cs      # Runs Data Annotations validation on flights
│   ├── DateRangeAttribute.cs   # Custom validation attribute for dynamic date ranges
│   └── PromptUser.cs           # Console input helper utilities
│
├── Views/
│   ├── CommandFactory.cs       # Factory that creates command objects by menu choice
│   ├── PassengerMenuStrategy.cs
│   └── ManagerMenuStrategy.cs
│
└── Data/
    ├── flights.json            # Persisted flight data
    ├── bookings.json           # Persisted booking data
    └── passengers.json         # Persisted passenger data
```
