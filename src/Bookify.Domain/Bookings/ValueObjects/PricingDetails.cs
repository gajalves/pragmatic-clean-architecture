using Bookify.Domain.Shared;

namespace Bookify.Domain.Bookings.ValueObjects;

public record PricingDetails(
    Money PriceForPeriod,
    Money CleaningFee,
    Money AmenitiesUpCharge,
    Money TotalPrice);
