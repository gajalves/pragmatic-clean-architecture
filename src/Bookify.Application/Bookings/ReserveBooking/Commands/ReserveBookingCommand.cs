using Bookify.Application.Abstractions.Messaging;

namespace Bookify.Application.Bookings.ReserveBooking.Commands;

public record ReserveBookingCommand(
    Guid ApartmentId,
    Guid UserId,
    DateOnly StarDate,
    DateOnly EndDate) : ICommand<Guid>;
