using Bookify.Domain.Apartments.ValueObjects;
using Bookify.Domain.Apartments;
using Bookify.Domain.Shared;
using Bookify.Domain.Apartments.Enums;

namespace Bookify.Application.UnitTests.Apartments;

internal static class ApartmentData
{
    public static Apartment Create() => new(
        Guid.NewGuid(),
        new Name("Test apartment"),
        new Description("Test description"),
        new Address("Country", "State", "ZipCode", "City", "Street"),
        new Money(100.0m, Currency.Usd),
        Money.Zero(),
        new List<Amenity>());
}
