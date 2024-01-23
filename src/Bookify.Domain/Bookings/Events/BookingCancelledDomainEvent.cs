﻿using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Bookings.Events;

public sealed record BookingCancelledDomainEvent(BookingId BookingId) : IDomainEvent;
