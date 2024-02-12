using Bookify.Domain.Bookings.ValueObjects;
using Bookify.Domain.Bookings;
using Bookify.Domain.Shared;
using Bookify.Domain.UnitTests.Apartments;
using Bookify.Domain.UnitTests.Users;
using Bookify.Domain.Users;
using Bookify.Domain.Bookings.Events;
using FluentAssertions;

namespace Bookify.Domain.UnitTests.Bookings;

public class BookingTests
{
    [Fact]
    public void Reserve_Should_RaiseBookingReserveDomainEvent()
    {
        // 
        var user = User.Create(UserData.firstName, UserData.lastName, UserData.email);
        var price = new Money(10.0m, Currency.Usd);
        var period = DateRange.Create(new DateOnly(2024, 1, 1), new DateOnly(2024, 1, 10));        
        var apartment = ApartmentData.Create(price);
        var pricingService = new PricingService();

        //
        var booking = Booking.Reserve(apartment, user.Id, period, DateTime.UtcNow, pricingService);

        //
        var domainEvent = booking.GetDomainEvents().OfType<BookingReservedDomainEvent>().SingleOrDefault();
        domainEvent.BookingId.Should().Be(booking.Id);
    }
}
