﻿using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Bookings.Events;

public sealed record BookingCompletedDomainEvent(BookingId BookingId) : IDomainEvent;
