namespace Bookify.Domain.Apartments.ValueObjects;

public record Address(
    string Country,
    string State,
    string ZipCode,
    string City,
    string Street);