using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Bookings.Events;

public sealed record BookingConfirmedDomainEvent(BookingId BookingId) : IDomainEvent;
