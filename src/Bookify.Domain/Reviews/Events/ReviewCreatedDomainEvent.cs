using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Reviews.Events;

public sealed record ReviewCreatedDomainEvent(ReviewId ReviewId) : IDomainEvent;